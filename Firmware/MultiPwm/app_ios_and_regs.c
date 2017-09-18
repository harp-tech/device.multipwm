#include <avr/io.h>
#include "hwbp_core_types.h"
#include "app_ios_and_regs.h"

/************************************************************************/
/* Configure and initialize IOs                                         */
/************************************************************************/
void init_ios(void)
{	/* Configure input pins */
	io_pin2in(&PORTF, 5, PULL_IO_UP, SENSE_IO_EDGES_BOTH);               // TRIG_IN0
	io_pin2in(&PORTF, 6, PULL_IO_UP, SENSE_IO_EDGES_BOTH);               // TRIG_IN1
	io_pin2in(&PORTH, 4, PULL_IO_UP, SENSE_IO_EDGES_BOTH);               // TRIG_IN2
	io_pin2in(&PORTK, 1, PULL_IO_UP, SENSE_IO_EDGES_BOTH);               // TRIG_IN3
	io_pin2in(&PORTQ, 2, PULL_IO_UP, SENSE_IO_EDGES_BOTH);               // TRIG_ALL

	/* Configure input interrupts */
	io_set_int(&PORTF, INT_LEVEL_LOW, 0, (1<<5), false);                 // TRIG_IN0
	io_set_int(&PORTF, INT_LEVEL_LOW, 1, (1<<6), false);                 // TRIG_IN1
	io_set_int(&PORTH, INT_LEVEL_LOW, 0, (1<<4), false);                 // TRIG_IN2
	io_set_int(&PORTK, INT_LEVEL_LOW, 0, (1<<1), false);                 // TRIG_IN3
	io_set_int(&PORTQ, INT_LEVEL_LOW, 0, (1<<2), false);                 // TRIG_ALL

	/* Configure output pins */
	io_pin2out(&PORTC, 1, OUT_IO_DIGITAL, IN_EN_IO_DIS);                 // SYNC_OUT0
	io_pin2out(&PORTD, 1, OUT_IO_DIGITAL, IN_EN_IO_DIS);                 // SYNC_OUT1
	io_pin2out(&PORTE, 1, OUT_IO_DIGITAL, IN_EN_IO_DIS);                 // SYNC_OUT2
	io_pin2out(&PORTF, 1, OUT_IO_DIGITAL, IN_EN_IO_DIS);                 // SYNC_OUT3
	io_pin2out(&PORTC, 0, OUT_IO_DIGITAL, IN_EN_IO_EN);                  // PWM_OUT0
	io_pin2out(&PORTD, 0, OUT_IO_DIGITAL, IN_EN_IO_EN);                  // PWM_OUT1
	io_pin2out(&PORTE, 0, OUT_IO_DIGITAL, IN_EN_IO_EN);                  // PWM_OUT2
	io_pin2out(&PORTF, 0, OUT_IO_DIGITAL, IN_EN_IO_EN);                  // PWM_OUT3
	io_pin2out(&PORTC, 2, OUT_IO_DIGITAL, IN_EN_IO_DIS);                 // SYNC_OUTALL
	io_pin2out(&PORTD, 4, OUT_IO_DIGITAL, IN_EN_IO_DIS);                 // ENABLED_PWM0
	io_pin2out(&PORTD, 5, OUT_IO_DIGITAL, IN_EN_IO_DIS);                 // ENABLED_PWM1
	io_pin2out(&PORTD, 6, OUT_IO_DIGITAL, IN_EN_IO_DIS);                 // ENABLED_PWM2
	io_pin2out(&PORTD, 7, OUT_IO_DIGITAL, IN_EN_IO_DIS);                 // ENABLED_PWM3

	/* Initialize output pins */
	clr_SYNC_OUT0;
	clr_SYNC_OUT1;
	clr_SYNC_OUT2;
	clr_SYNC_OUT3;
	clr_PWM_OUT0;
	clr_PWM_OUT1;
	clr_PWM_OUT2;
	clr_PWM_OUT3;
	clr_SYNC_OUTALL;
	clr_ENABLED_PWM0;
	clr_ENABLED_PWM1;
	clr_ENABLED_PWM2;
	clr_ENABLED_PWM3;
}

/************************************************************************/
/* Registers' stuff                                                     */
/************************************************************************/
AppRegs app_regs;

uint8_t app_regs_type[] = {
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_U32,
	TYPE_U32,
	TYPE_U32,
	TYPE_U32,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_FLOAT,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8,
	TYPE_U8
};

uint16_t app_regs_n_elements[] = {
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1,
	1
};

uint8_t *app_regs_pointer[] = {
	(uint8_t*)(&app_regs.REG_CH0_FREQ),
	(uint8_t*)(&app_regs.REG_CH1_FREQ),
	(uint8_t*)(&app_regs.REG_CH2_FREQ),
	(uint8_t*)(&app_regs.REG_CH3_FREQ),
	(uint8_t*)(&app_regs.REG_CH0_DUTYCYCLE),
	(uint8_t*)(&app_regs.REG_CH1_DUTYCYCLE),
	(uint8_t*)(&app_regs.REG_CH2_DUTYCYCLE),
	(uint8_t*)(&app_regs.REG_CH3_DUTYCYCLE),
	(uint8_t*)(&app_regs.REG_CH0_COUNTS),
	(uint8_t*)(&app_regs.REG_CH1_COUNTS),
	(uint8_t*)(&app_regs.REG_CH2_COUNTS),
	(uint8_t*)(&app_regs.REG_CH3_COUNTS),
	(uint8_t*)(&app_regs.REG_CH0_REAL_FREQ),
	(uint8_t*)(&app_regs.REG_CH1_REAL_FREQ),
	(uint8_t*)(&app_regs.REG_CH2_REAL_FREQ),
	(uint8_t*)(&app_regs.REG_CH3_REAL_FREQ),
	(uint8_t*)(&app_regs.REG_CH0_REAL_DUTYCYCLE),
	(uint8_t*)(&app_regs.REG_CH1_REAL_DUTYCYCLE),
	(uint8_t*)(&app_regs.REG_CH2_REAL_DUTYCYCLE),
	(uint8_t*)(&app_regs.REG_CH3_REAL_DUTYCYCLE),
	(uint8_t*)(&app_regs.REG_CH0_MODE),
	(uint8_t*)(&app_regs.REG_CH1_MODE),
	(uint8_t*)(&app_regs.REG_CH2_MODE),
	(uint8_t*)(&app_regs.REG_CH3_MODE),
	(uint8_t*)(&app_regs.REG_TRG0_MASK),
	(uint8_t*)(&app_regs.REG_TRG1_MASK),
	(uint8_t*)(&app_regs.REG_TRG2_MASK),
	(uint8_t*)(&app_regs.REG_TRG3_MASK),
	(uint8_t*)(&app_regs.REG_START_PWM),
	(uint8_t*)(&app_regs.REG_STOP_PWM),
	(uint8_t*)(&app_regs.REG_CH_ENABLE_SINGLE),
	(uint8_t*)(&app_regs.REG_RESERVED1),
	(uint8_t*)(&app_regs.REG_TRG0_MODE),
	(uint8_t*)(&app_regs.REG_TRG1_MODE),
	(uint8_t*)(&app_regs.REG_TRG2_MODE),
	(uint8_t*)(&app_regs.REG_TRG3_MODE),
	(uint8_t*)(&app_regs.REG_CH_CONFEN),
	(uint8_t*)(&app_regs.REG_CH_ENABLE),
	(uint8_t*)(&app_regs.REG_TRGALL_MODE),
	(uint8_t*)(&app_regs.REG_TRIG_STATE),
	(uint8_t*)(&app_regs.REG_CH_STATE),
	(uint8_t*)(&app_regs.REG_EXEC_STATE),
	(uint8_t*)(&app_regs.REG_EVNT_ENABLE)
};