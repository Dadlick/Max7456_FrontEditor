#define DATAOUT 11//MOSI
#define DATAIN  12//MISO
#define SPICLOCK  13//sck
#define MAX7456SELECT 6//ss
#define MAX7456RESET 10//RESET

#define VSYNC 0x02// INT0

//MAX7456 opcodes
#define VM0_reg   0x00
#define VM1_reg   0x01
#define DMM_reg   0x04
#define DMAH_reg  0x05
#define DMAL_reg  0x06
#define DMDI_reg  0x07
#define CMM_reg   0x08
#define CMAH_reg  0x09
#define CMAL_reg  0x0A
#define CMDI_reg  0x0B
#define STAT_reg  0xA0
#define CMDO_reg  0xC0

//MAX7456 commands
#define CLEAR_display 0x04
#define CLEAR_display_vert 0x06
#define END_string 0xff
#define WRITE_nvr 0xa0
#define READ_nvr 0x50

// with NTSC
#define ENABLE_display 0x08
#define ENABLE_display_vert 0x0c
#define MAX7456_reset 0x02
#define DISABLE_display 0x00

// with PAL
// all VM0_reg commands need bit 6 set
//#define ENABLE_display 0x48
//#define ENABLE_display_vert 0x4c
//#define MAX7456_reset 0x42
//#define DISABLE_display 0x40

#define WHITE_level_80 0x03
#define WHITE_level_90 0x02
#define WHITE_level_100 0x01
#define WHITE_level_120 0x00

#define MAX_font_rom 0xff
#define STATUS_reg_nvr_busy 0x20
#define NVM_ram_size 0x36

// with NTSC
//#define MAX_screen_rows 0x0d //13

// with PAL
#define MAX_screen_rows 0x10 //16

volatile byte screen_buffer[MAX_font_rom];
volatile byte character_bitmap[0x40];
volatile byte ascii_binary[0x08];

volatile byte bit_count;
volatile byte byte_count;
volatile int font_count;
volatile int  incomingByte;
volatile int  count;

volatile byte type_data;

//////////////////////////////////////////////////////////////
void setup()
{
  byte spi_junk;
  int x;
  Serial.begin(115200);
  Serial.flush();
  pinMode(MAX7456RESET,OUTPUT);
  digitalWrite(MAX7456RESET,HIGH); //disable device
  
  pinMode(MAX7456SELECT,OUTPUT);
  digitalWrite(MAX7456SELECT,HIGH); //disable device

  pinMode(DATAOUT, OUTPUT);
  pinMode(DATAIN, INPUT);
  pinMode(SPICLOCK,OUTPUT);
  pinMode(VSYNC, INPUT);

  // SPCR = 01010000
  //interrupt disabled,spi enabled,msb 1st,master,clk low when idle,
  //sample on leading edge of clk,system clock/4 rate (4 meg)
  SPCR = (1<<SPE)|(1<<MSTR);
  spi_junk=SPSR;
  spi_junk=SPDR;
  delay(250);

  // force soft reset on Max7456
  digitalWrite(MAX7456SELECT,LOW);
  spi_transfer(VM0_reg);
  spi_transfer(MAX7456_reset);
  digitalWrite(MAX7456SELECT,HIGH);
  delay(500);

  // set all rows to same character white level, 90%
  digitalWrite(MAX7456SELECT,LOW);
  for (x = 0; x < MAX_screen_rows; x++)
  {
    spi_transfer(x + 0x10);
    spi_transfer(WHITE_level_90);
  }

  // make sure the Max7456 is enabled
  spi_transfer(VM0_reg);
  spi_transfer(ENABLE_display);
  digitalWrite(MAX7456SELECT,HIGH);

  incomingByte = 0;
  count = 0;
  bit_count = 0;
  byte_count = 0;
  font_count = 0;
  type_data=0;
  
  //display all 256 internal MAX7456 characters
  for (x = 0; x < MAX_font_rom; x++)
  {
    screen_buffer[x] = x;
  }
   count = MAX_font_rom;
   write_new_screen();  
  delay(100);  
}
//////////////////////////////////////////////////////////////
void loop()
{
  byte x;
  
  if (Serial.available() > 0)
  {
    // read the incoming byte:
    incomingByte = Serial.read();
    switch(type_data)
    {
      case 0://determine the type of command
        switch(incomingByte) 
        {
          case 83: // we write symbol
            type_data = 1;
          break;
          case 86: // display all 256 internal MAX7456 characters
            pinMode(MAX7456SELECT,OUTPUT);
            pinMode(MAX7456SELECT,HIGH);
            // force soft reset on Max7456
            digitalWrite(MAX7456SELECT,LOW);
            spi_transfer(VM0_reg);
            spi_transfer(MAX7456_reset);
            digitalWrite(MAX7456SELECT,HIGH);
            delay(500);
            for (x = 0; x < MAX_font_rom; x++)
            {
              screen_buffer[x] = x;
            }
            count = MAX_font_rom;
            write_new_screen();
            type_data = 0; 
          break;
          case 87: // we read symbol
            type_data = 3;
          break; 
          default:
          break;
        }  
      break;
      case 1://number of character write
        font_count = incomingByte;
        type_data = 2;
      break;
      case 2:// Download obtain data symbol
        character_bitmap[byte_count] = incomingByte;
        byte_count++;
      break;
      case 3://number of character read
        byte x, myChar;
        font_count = incomingByte;
         read_NVM(); // read description of the character
         for(x = 0; x < NVM_ram_size; x++) // transfer 54 or 64 bytes of character descriptions character_bitmap
         {
           myChar = character_bitmap[x];
           Serial.write(myChar); //refer the data symbol
         } 
         type_data = 0; 
        
      break;
    }  
  }
  
  // we have one completed character
  // write the character to NVM 
  if(byte_count == 64)
  {
    write_NVM();    
    byte_count = 0;
    type_data = 0;
  }
}
//////////////////////////////////////////////////////////////
byte spi_transfer(volatile byte data)
{
  SPDR = data;                    // Start the transmission
  while (!(SPSR & (1<<SPIF)))     // Wait the end of the transmission
  {
  };
  return SPDR;                    // return the received byte
}
//////////////////////////////////////////////////////////////
void write_new_screen()
{
  int x, local_count;
  byte char_address_hi, char_address_lo;
  byte screen_char;
  
  local_count = count;
  
  char_address_hi = 0;
  char_address_lo = 60; // start on third line   

  // clear the screen
  digitalWrite(MAX7456SELECT,LOW);
  spi_transfer(DMM_reg);
  spi_transfer(CLEAR_display);
  digitalWrite(MAX7456SELECT,HIGH);

  // disable display
  digitalWrite(MAX7456SELECT,LOW);
  spi_transfer(VM0_reg); 
  spi_transfer(DISABLE_display);

  spi_transfer(DMM_reg); //dmm
  //spi_transfer(0x21); //16 bit trans background
  spi_transfer(0x01); //16 bit trans w/o background

  spi_transfer(DMAH_reg); // set start address high
  spi_transfer(char_address_hi);

  spi_transfer(DMAL_reg); // set start address low
  spi_transfer(char_address_lo);

  x = 0;
  while(local_count) // write out full screen
  {
    screen_char = screen_buffer[x];
    spi_transfer(DMDI_reg);
    spi_transfer(screen_char);
    x++;
    local_count--;
  }

  spi_transfer(DMDI_reg);
  spi_transfer(END_string);

  spi_transfer(VM0_reg); // turn on screen next vertical
  spi_transfer(ENABLE_display_vert);
  digitalWrite(MAX7456SELECT,HIGH);
}
//////////////////////////////////////////////////////////////
void write_NVM()
{
  byte x;
  byte char_address_hi, char_address_lo;
  byte screen_char;

  char_address_hi = font_count;
  char_address_lo = 0;
 //Serial.println("write_new_screen");   

  // disable display
  digitalWrite(MAX7456SELECT,LOW);
  spi_transfer(VM0_reg); 
  spi_transfer(DISABLE_display);

  spi_transfer(CMAH_reg); // set start address high
  spi_transfer(char_address_hi);

  for(x = 0; x < NVM_ram_size; x++) // write out 54 (out of 64) bytes of character to shadow ram
  {
    screen_char = character_bitmap[x];
    spi_transfer(CMAL_reg); // set start address low
    spi_transfer(x);
    spi_transfer(CMDI_reg);
    spi_transfer(screen_char);
  }

  // transfer a 54 bytes from shadow ram to NVM
  spi_transfer(CMM_reg);
  spi_transfer(WRITE_nvr);
  
  // wait until bit 5 in the status register returns to 0 (12ms)
  while ((spi_transfer(STAT_reg) & STATUS_reg_nvr_busy) != 0x00);

  spi_transfer(VM0_reg); // turn on screen next vertical
  spi_transfer(ENABLE_display_vert);
  digitalWrite(MAX7456SELECT,HIGH);  
}
//////////////////////////////////////////////////////////////
void read_NVM()
{
  byte x;
  byte char_address_hi, char_address_lo;

  char_address_hi = font_count;
  char_address_lo = 0;

  // disable display
  digitalWrite(MAX7456SELECT,LOW);
  spi_transfer(VM0_reg); 
  spi_transfer(DISABLE_display);

  spi_transfer(CMAH_reg); // set start address high
  spi_transfer(char_address_hi);

  // transfer a 54 bytes from NVM to shadow ram
  spi_transfer(CMM_reg);
  spi_transfer(READ_nvr);
  delay(5);

  for(x = 0; x < NVM_ram_size; x++) // write out 54 (out of 64) bytes of character from shadow ram
  { 
    spi_transfer(CMAL_reg); // set start address low
    spi_transfer(x);
    spi_transfer(CMDO_reg);
    character_bitmap[x] = spi_transfer(0xff); // 8 bits of anything to drive the spi bus
  }
  // wait until bit 5 in the status register returns to 0 (up to 12ms)
  while ((spi_transfer(STAT_reg) & STATUS_reg_nvr_busy) != 0x00);
 
  //spi_transfer(VM0_reg); // turn on screen next vertical
  //spi_transfer(ENABLE_display_vert);
  digitalWrite(MAX7456SELECT,HIGH);  
}
