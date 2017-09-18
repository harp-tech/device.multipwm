#ifndef _APP_IOS_AND_REGS_H_
#define _APP_IOS_AND_REGS_H_
#include "cpu.h"

void init_ios(void);
/************************************************************************/
/* Definition of input pins                                             */
/************************************************************************/
// TRIG_IN0               Description: 
// TRIG_IN1               Description: 
// TRIG_IN2               Description: 
// TRIG_IN3               Description: 
// TRIG_ALL               Description: 

#define read_TRIG_IN0 read_io(PORTF, 5)         // TRIG_IN0
#define read_TRIG_IN1 read_io(PORTF, 6)         // TRIG_IN1
#define read_TRIG_IN2 read_io(PORTH, 4)         // TRIG_IN2
#define read_TRIG_IN3 read_io(PORTK, 1)         // TRIG_IN3
#define read_TRIG_ALL read_io(PORTQ, 2)         // TRIG_ALL

/************************************************************************/
/* Definition of output pins                                            */
/************************************************************************/
// SYNC_OUT0              Description: Sync Out 0
// SYNC_OUT1              Description: Sync Out 1
// SYNC_OUT2              Description: Sync Out 2
// SYNC_OUT3              Description: Sync Out 3
// PWM_OUT0               Description: Sync Out 0
// PWM_OUT1               Description: Sync Out 1
// PWM_OUT2               Description: Sync Out 2
// PWM_OUT3               Description: Sync Out 3
// SYNC_OUTALL            Description: Sync All
// ENABLED_PWM0           Description: PWM0 enabled
// ENABLED_PWM1           Description: PWM1 enabled
// ENABLED_PWM2           Description: PWM2 enabled
// ENABLED_PWM3           Description: PWM3 enabled

/* SYNC_OUT0 */
#define set_SYNC_OUT0 set_io(PORTC, 1)
#define clr_SYNC_OUT0 clear_io(PORTC, 1)
#define tgl_SYNC_OUT0 toggle_io(PORTC, 1)
#define read_SYNC_OUT0 read_io(PORTC, 1)

/* SYNC_OUT1 */
#define set_SYNC_OUT1 set_io(PORTD, 1)
#define clr_SYNC_OUT1 clear_io(PORTD, 1)
#define tgl_SYNC_OUT1 toggle_io(PORTD, 1)
#define read_SYNC_OUT1 read_io(PORTD, 1)

/* SYNC_OUT2 */
#define set_SYNC_OUT2 set_io(PORTE, 1)
#define clr_SYNC_OUT2 clear_io(PORTE, 1)
#define tgl_SYNC_OUT2 toggle_io(PORTE, 1)
#define read_SYNC_OUT2 read_io(PORTE, 1)

/* SYNC_OUT3 */
#define set_SYNC_OUT3 set_io(PORTF, 1)
#define clr_SYNC_OUT3 clear_io(PORTF, 1)
#define tgl_SYNC_OUT3 toggle_io(PORTF, 1)
#define read_SYNC_OUT3 read_io(PORTF, 1)

/* PWM_OUT0 */
#define set_PWM_OUT0 set_io(PORTC, 0)
#define clr_PWM_OUT0 clear_io(PORTC, 0)
#define tgl_PWM_OUT0 toggle_io(PORTC, 0)
#define read_PWM_OUT0 read_io(PORTC, 0)

/* PWM_OUT1 */
#define set_PWM_OUT1 set_io(PORTD, 0)
#define clr_PWM_OUT1 clear_io(PORTD, 0)
#define tgl_PWM_OUT1 toggle_io(PORTD, 0)
#define read_PWM_OUT1 read_io(PORTD, 0)

/* PWM_OUT2 */
#define set_PWM_OUT2 set_io(PORTE, 0)
#define clr_PWM_OUT2 clear_io(PORTE, 0)
#define tgl_PWM_OUT2 toggle_io(PORTE, 0)
#define read_PWM_OUT2 read_io(PORTE, 0)

/* PWM_OUT3 */
#define set_PWM_OUT3 set_io(PORTF, 0)
#define clr_PWM_OUT3 clear_io(PORTF, 0)
#define tgl_PWM_OUT3 toggle_io(PORTF, 0)
#define read_PWM_OUT3 read_io(PORTF, 0)

/* SYNC_OUTALL */
#define set_SYNC_OUTALL set_io(PORTC, 2)
#define clr_SYNC_OUTALL clear_io(PORTC, 2)
#define tgl_SYNC_OUTALL toggle_io(PORTC, 2)
#define read_SYNC_OUTALL read_io(PORTC, 2)

/* ENABLED_PWM0 */
#define set_ENABLED_PWM0 set_io(PORTD, 4)
#define clr_ENABLED_PWM0 clear_io(PORTD, 4)
#define tgl_ENABLED_PWM0 toggle_io(PORTD, 4)
#define read_ENABLED_PWM0 read_io(PORTD, 4)

/* ENABLED_PWM1 */
#define set_ENABLED_PWM1 set_io(PORTD, 5)
#define clr_ENABLED_PWM1 clear_io(PORTD, 5)
#define tgl_ENABLED_PWM1 toggle_io(PORTD, 5)
#define read_ENABLED_PWM1 read_io(PORTD, 5)

/* ENABLED_PWM2 */
#define set_ENABLED_PWM2 set_io(PORTD, 6)
#define clr_ENABLED_PWM2 clear_io(PORTD, 6)
#define tgl_ENABLED_PWM2 toggle_io(PORTD, 6)
#define read_ENABLED_PWM2 read_io(PORTD, 6)

/* ENABLED_PWM3 */
#define set_ENABLED_PWM3 set_io(PORTD, 7)
#define clr_ENABLED_PWM3 clear_io(PORTD, 7)
#define tgl_ENABLED_PWM3 toggle_io(PORTD, 7)
#define read_ENABLED_PWM3 read_io(PORTD, 7)


/************************************************************************/
/* Registers' structure                                                 */
/************************************************************************/
typedef struct
{
	float REG_CH0_FREQ;
	float REG_CH1_FREQ;
	float REG_CH2_FREQ;
	float REG_CH3_FREQ;
	float REG_CH0_DUTYCYCLE;
	float REG_CH1_DUTYCYCLE;
	float REG_CH2_DUTYCYCLE;
	float REG_CH3_DUTYCYCLE;
	uint32_t REG_CH0_COUNTS;
	uint32_t REG_CH1_COUNTS;
	uint32_t REG_CH2_COUNTS;
	uint32_t REG_CH3_COUNTS;
	float REG_CH0_REAL_FREQ;
	float REG_CH1_REAL_FREQ;
	float REG_CH2_REAL_FREQ;
	float REG_CH3_REAL_FREQ;
	float REG_CH0_REAL_DUTYCYCLE;
	float REG_CH1_REAL_DUTYCYCLE;
	float REG_CH2_REAL_DUTYCYCLE;
	float REG_CH3_REAL_DUTYCYCLE;
	uint8_t REG_CH0_MODE;
	uint8_t REG_CH1_MODE;
	uint8_t REG_CH2_MODE;
	uint8_t REG_CH3_MODE;
	uint8_t REG_TRG0_MASK;
	uint8_t REG_TRG1_MASK;
	uint8_t REG_TRG2_MASK;
	uint8_t REG_TRG3_MASK;
	uint8_t REG_START_PWM;
	uint8_t REG_STOP_PWM;
	uint8_t REG_CH_ENABLE_SINGLE;
	uint8_t REG_RESERVED1;
	uint8_t REG_TRG0_MODE;
	uint8_t REG_TRG1_MODE;
	uint8_t REG_TRG2_MODE;
	uint8_t REG_TRG3_MODE;
	uint8_t REG_CH_CONFEN;
	uint8_t REG_CH_ENABLE;
	uint8_t REG_TRGALL_MODE;
	uint8_t REG_TRIG_STATE;
	uint8_t REG_CH_STATE;
	uint8_t REG_EXEC_STATE;
	uint8_t REG_EVNT_ENABLE;
} AppRegs;

/************************************************************************/
/* Registers' address                                                   */
/************************************************************************/
/* Registers */
#define ADD_REG_CH0_FREQ                    32 // FLOAT  Frequency of pulses on channel 0
#define ADD_REG_CH1_FREQ                    33 // FLOAT  Frequency of pulses on channel 1
#define ADD_REG_CH2_FREQ                    34 // FLOAT  Frequency of pulses on channel 2
#define ADD_REG_CH3_FREQ                    35 // FLOAT  Frequency of pulses on channel 3
#define ADD_REG_CH0_DUTYCYCLE               36 // FLOAT  Duty cycle of pulses on channel 0
#define ADD_REG_CH1_DUTYCYCLE               37 // FLOAT  Duty cycle of pulses on channel 1
#define ADD_REG_CH2_DUTYCYCLE               38 // FLOAT  Duty cycle of pulses on channel 2
#define ADD_REG_CH3_DUTYCYCLE               39 // FLOAT  Duty cycle of pulses on channel 3
#define ADD_REG_CH0_COUNTS                  40 // U32    Number of pulses on channel 0
#define ADD_REG_CH1_COUNTS                  41 // U32    Number of pulses on channel 1
#define ADD_REG_CH2_COUNTS                  42 // U32    Number of pulses on channel 2
#define ADD_REG_CH3_COUNTS                  43 // U32    Number of pulses on channel 3
#define ADD_REG_CH0_REAL_FREQ               44 // FLOAT  Real frequency that will be performed on channel 0
#define ADD_REG_CH1_REAL_FREQ               45 // FLOAT  Real frequency that will be performed on channel 1
#define ADD_REG_CH2_REAL_FREQ               46 // FLOAT  Real frequency that will be performed on channel 2
#define ADD_REG_CH3_REAL_FREQ               47 // FLOAT  Real frequency that will be performed on channel 3
#define ADD_REG_CH0_REAL_DUTYCYCLE          48 // FLOAT  Real duty cycle that will be performed on channel 0
#define ADD_REG_CH1_REAL_DUTYCYCLE          49 // FLOAT  Real duty cycle that will be performed on channel 1
#define ADD_REG_CH2_REAL_DUTYCYCLE          50 // FLOAT  Real duty cycle that will be performed on channel 2
#define ADD_REG_CH3_REAL_DUTYCYCLE          51 // FLOAT  Real duty cycle that will be performed on channel 3
#define ADD_REG_CH0_MODE                    52 // U8     
#define ADD_REG_CH1_MODE                    53 // U8     
#define ADD_REG_CH2_MODE                    54 // U8     
#define ADD_REG_CH3_MODE                    55 // U8     
#define ADD_REG_TRG0_MASK                   56 // U8     
#define ADD_REG_TRG1_MASK                   57 // U8     
#define ADD_REG_TRG2_MASK                   58 // U8     
#define ADD_REG_TRG3_MASK                   59 // U8     
#define ADD_REG_START_PWM                   60 // U8     Start execution of PWMs configured on TRGx_MASK
#define ADD_REG_STOP_PWM                    61 // U8     Stop execution of PWMs configured on TRGx_MASK
#define ADD_REG_CH_ENABLE_SINGLE            62 // U8     
#define ADD_REG_RESERVED1                   63 // U8     
#define ADD_REG_TRG0_MODE                   64 // U8     
#define ADD_REG_TRG1_MODE                   65 // U8     
#define ADD_REG_TRG2_MODE                   66 // U8     
#define ADD_REG_TRG3_MODE                   67 // U8     
#define ADD_REG_CH_CONFEN                   68 // U8     Request Enable to stimulate
#define ADD_REG_CH_ENABLE                   69 // U8     Enable channels
#define ADD_REG_TRGALL_MODE                 70 // U8     
#define ADD_REG_TRIG_STATE                  71 // U8     Read only. Current digital state of the TRIG IN inputs.
#define ADD_REG_CH_STATE                    72 // U8     Read only. Current digital state of the PWM OUT outputs.
#define ADD_REG_EXEC_STATE                  73 // U8     State of each PWM execution.
#define ADD_REG_EVNT_ENABLE                 74 // U8     Enable the Events

/************************************************************************/
/* PWM Generator registers' memory limits                               */
/*                                                                      */
/* DON'T change the APP_REGS_ADD_MIN value !!!                          */
/* DON'T change these names !!!                                         */
/************************************************************************/
/* Memory limits */
#define APP_REGS_ADD_MIN                    0x20
#define APP_REGS_ADD_MAX                    0x4A
#define APP_NBYTES_OF_REG_BANK              103

/************************************************************************/
/* Registers' bits                                                      */
/************************************************************************/
#define MSK_CH_MODE                        (1<<0)       // 
#define GM_CH_MODE_COUNT                   (0<<0)       // 
#define GM_CH_MODE_INFINITE                (1<<0)       // 
#define B_TRGCH0                           (1<<0)       // Trigger PWM on channel 0
#define B_TRGCH1                           (1<<1)       // Trigger PWM on channel 1
#define B_TRGCH2                           (1<<2)       // Trigger PWM on channel 2
#define B_TRGCH3                           (1<<3)       // Trigger PWM on channel  3
#define B_START_TRG0                       (1<<0)       // 
#define B_START_TRG1                       (1<<1)       // 
#define B_START_TRG2                       (1<<2)       // 
#define B_START_TRG3                       (1<<3)       // 
#define B_STOP_TRG0                        (1<<0)       // 
#define B_STOP_TRG1                        (1<<1)       // 
#define B_STOP_TRG2                        (1<<2)       // 
#define B_STOP_TRG3                        (1<<3)       // 
#define B_SGLE0                            (1<<0)       // Disable channel 0 after running the PWM
#define B_SGLE1                            (1<<1)       // Disable channel 1 after running the PWM
#define B_SGLE2                            (1<<2)       // Disable channel 2 after running the PWM
#define B_SGLE3                            (1<<3)       // Disable channel 3 after running the PWM
#define MSK_TRG_MODE                       (1<<0)       // 
#define GM_TRG_MODE_START                  (0<<0)       // 
#define GM_TRG_MODE_START_AND_STOP         (1<<0)       // 
#define B_NTRG                             (1<<3)       // 
#define B_USEEN0                           (1<<0)       // 
#define B_USEEN1                           (1<<1)       // 
#define B_USEEN2                           (1<<2)       // 
#define B_USEEN3                           (1<<3)       // 
#define B_EN0                              (1<<0)       // Enable channel 0
#define B_EN1                              (1<<1)       // Enable channel 1
#define B_EN2                              (1<<2)       // Enable channel 2
#define B_EN3                              (1<<3)       // Enable channel 3
#define MSK_ALL_MODE                       (3<<0)       // 
#define GM_ALL_MODE_TRIG_ALL               (0<<0)       // 
#define GM_ALL_MODE_TRIG_ALL_AND_STOP      (1<<0)       // 
#define GM_ALL_MODE_ENABLE                 (2<<0)       // 
#define GM_ALL_MODE_ENABLE_AND_STOP        (3<<0)       // 
#define B_NEG                              (1<<3)       // 
#define B_LTRG0                            (1<<0)       // 
#define B_LTRG1                            (1<<1)       // 
#define B_LTRG2                            (1<<2)       // 
#define B_LTRG3                            (1<<3)       // 
#define B_LTRGALL                          (1<<4)       // 
#define B_SCH0                             (1<<0)       // 
#define B_SCH1                             (1<<1)       // 
#define B_SCH2                             (1<<2)       // 
#define B_SCH3                             (1<<3)       // 
#define B_PWM0STATE                        (1<<0)       // 
#define B_PWM1STATE                        (1<<1)       // 
#define B_PWM2STATE                        (1<<2)       // 
#define B_PWM3STATE                        (1<<3)       // 
#define B_EVT0                             (1<<0)       // Events of register EXEC_STATE

#endif /* _APP_REGS_H_ */