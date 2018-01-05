#include "hwbp_core.h"
#include "hwbp_core_regs.h"
#include "hwbp_core_types.h"

#include "app.h"
#include "app_funcs.h"
#include "app_ios_and_regs.h"

#include "pwm_gen_functions.h"


/************************************************************************/
/* Declare application registers                                        */
/************************************************************************/
extern AppRegs app_regs;
extern uint8_t app_regs_type[];
extern uint16_t app_regs_n_elements[];
extern uint8_t *app_regs_pointer[];
extern void (*app_func_rd_pointer[])(void);
extern bool (*app_func_wr_pointer[])(void*);


/************************************************************************/
/* Initialize app                                                       */
/************************************************************************/
void hwbp_app_initialize(void)
{
	/* Start core */
	core_func_start_core(1040, 1, 1, 1, 1, 1, (uint8_t*)(&app_regs), APP_NBYTES_OF_REG_BANK, APP_REGS_ADD_MAX - APP_REGS_ADD_MIN + 1);
}

/************************************************************************/
/* Handle if a catastrophic error occur                                 */
/************************************************************************/
void core_callback_catastrophic_error_detected(void)
{
	
}

/************************************************************************/
/* General definitions                                                  */
/************************************************************************/


/************************************************************************/
/* General used functions                                               */
/************************************************************************/
void update_enabled_pwmx(void)
{
    if (!core_bool_is_visual_enabled())
        return;
    
    if (!(app_regs.REG_CH_CONFEN & B_USEEN0) || ((app_regs.REG_CH_CONFEN & B_USEEN0) && (app_regs.REG_CH_ENABLE & B_EN0)))
        set_ENABLED_PWM0;
    else
        clr_ENABLED_PWM0;
    
    if (!(app_regs.REG_CH_CONFEN & B_USEEN1) || ((app_regs.REG_CH_CONFEN & B_USEEN1) && (app_regs.REG_CH_ENABLE & B_EN1)))
        set_ENABLED_PWM1;
    else
        clr_ENABLED_PWM1;
    
    if (!(app_regs.REG_CH_CONFEN & B_USEEN2) || ((app_regs.REG_CH_CONFEN & B_USEEN2) && (app_regs.REG_CH_ENABLE & B_EN2)))
        set_ENABLED_PWM2;
    else
        clr_ENABLED_PWM2;
    
    if (!(app_regs.REG_CH_CONFEN & B_USEEN3) || ((app_regs.REG_CH_CONFEN & B_USEEN3) && (app_regs.REG_CH_ENABLE & B_EN3)))
        set_ENABLED_PWM3;
    else
        clr_ENABLED_PWM3;
}

/************************************************************************/
/* Initialization Callbacks                                             */
/************************************************************************/
void core_callback_1st_config_hw_after_boot(void)
{
    /* Initialize IOs */
    /* Don't delete this function!!! */
    init_ios();    
}

void core_callback_reset_registers(void)
{   
   /* Initialize registers */
   app_regs.REG_CH0_FREQ = 10.0;
   app_regs.REG_CH0_DUTYCYCLE = 50;
   app_regs.REG_CH0_COUNTS = 10;
   app_regs.REG_CH0_REAL_FREQ = 10;
   app_regs.REG_CH0_REAL_DUTYCYCLE = 50;
   app_regs.REG_CH0_MODE = GM_CH_MODE_COUNT;
   
   app_regs.REG_CH1_FREQ = 10.0;
   app_regs.REG_CH1_DUTYCYCLE = 50;
   app_regs.REG_CH1_COUNTS = 20;
   app_regs.REG_CH1_REAL_FREQ = 10.0;
   app_regs.REG_CH1_REAL_DUTYCYCLE = 50.0;
   app_regs.REG_CH1_MODE = GM_CH_MODE_COUNT;
   
   app_regs.REG_CH2_FREQ = 10.0;
   app_regs.REG_CH2_DUTYCYCLE = 50;
   app_regs.REG_CH2_COUNTS = 30;
   app_regs.REG_CH2_REAL_FREQ = 10.0;
   app_regs.REG_CH2_REAL_DUTYCYCLE = 50.0;
   app_regs.REG_CH2_MODE = GM_CH_MODE_COUNT;
   
   app_regs.REG_CH3_FREQ = 10.0;
   app_regs.REG_CH3_DUTYCYCLE = 50;
   app_regs.REG_CH3_COUNTS = 40;
   app_regs.REG_CH3_REAL_FREQ = 10.0;
   app_regs.REG_CH3_REAL_DUTYCYCLE = 50.0;
   app_regs.REG_CH3_MODE = GM_CH_MODE_COUNT;

   app_regs.REG_TRG0_MASK = B_TRGCH0;
   app_regs.REG_TRG1_MASK = B_TRGCH1;
   app_regs.REG_TRG2_MASK = B_TRGCH2;
   app_regs.REG_TRG3_MASK = B_TRGCH3;
   app_regs.REG_TRG0_MODE = GM_TRG_MODE_START;
   app_regs.REG_TRG1_MODE = GM_TRG_MODE_START;
   app_regs.REG_TRG2_MODE = GM_TRG_MODE_START;
   app_regs.REG_TRG3_MODE = GM_TRG_MODE_START;
   
   app_regs.REG_START_PWM = 0;
   app_regs.REG_STOP_PWM = 0;
   
   app_regs.REG_CH_ENABLE_SINGLE = 0;
   app_regs.REG_RESERVED1 = 0;

   app_regs.REG_CH_CONFEN = 0;
   app_regs.REG_CH_ENABLE = 0;

   app_regs.REG_TRGALL_MODE = GM_ALL_MODE_TRIG_ALL;

   app_regs.REG_TRIG_STATE = 0;
   app_regs.REG_CH_STATE = 0;
   
   app_regs.REG_EXEC_STATE = 0;
   app_regs.REG_EVNT_ENABLE = B_EVT0;
}

void core_callback_registers_were_reinitialized(void)
{
    /* Check if the user indication is valid */
    update_enabled_pwmx();

    /* Update registers that depend on others */
    hwbp_app_pwm_gen_update_reals_ch0();
    hwbp_app_pwm_gen_update_reals_ch1();
    hwbp_app_pwm_gen_update_reals_ch2();
    hwbp_app_pwm_gen_update_reals_ch3();

    /* Update trigger state register */
    app_regs.REG_TRIG_STATE = (read_TRIG_IN0) ? B_LTRG0 : 0;
    app_regs.REG_TRIG_STATE |= (read_TRIG_IN1) ? B_LTRG1 : 0;
    app_regs.REG_TRIG_STATE |= (read_TRIG_IN2) ? B_LTRG2 : 0;
    app_regs.REG_TRIG_STATE |= (read_TRIG_IN3) ? B_LTRG3 : 0;
    app_regs.REG_TRIG_STATE |= (read_TRIG_ALL) ? B_LTRGALL : 0;
    
    /* Update channel state register */
    app_regs.REG_CH_STATE  = (read_PWM_OUT0) ? B_SCH0 : 0;
    app_regs.REG_CH_STATE |= (read_PWM_OUT1) ? B_SCH1 : 0;
    app_regs.REG_CH_STATE |= (read_PWM_OUT2) ? B_SCH2 : 0;
    app_regs.REG_CH_STATE |= (read_PWM_OUT3) ? B_SCH3 : 0;

    /* No PWM should be running */
    app_regs.REG_START_PWM = 0;
    app_regs.REG_STOP_PWM = 0;
    app_regs.REG_EXEC_STATE = 0;

    /* Stop PWMs */
    timer_type0_stop(&TCC0);
    timer_type0_stop(&TCD0);
    timer_type0_stop(&TCE0);
    timer_type0_stop(&TCF0);
}

/************************************************************************/
/* Callbacks: Visualization                                             */
/************************************************************************/
void core_callback_visualen_to_on(void)
{
	/* Update channels enable indicators */
	update_enabled_pwmx();
}

void core_callback_visualen_to_off(void)
{
	/* Clear all the enabled indicators */
    clr_ENABLED_PWM0;
    clr_ENABLED_PWM1;
    clr_ENABLED_PWM2;
    clr_ENABLED_PWM3;
}

/************************************************************************/
/* Callbacks: Change on the operation mode                              */
/************************************************************************/
void core_callback_device_to_standby(void)
{
    /* Stop all PWMs when going to standby mode */
    hwbp_app_pwm_gen_stop_ch0();
    hwbp_app_pwm_gen_stop_ch1();
    hwbp_app_pwm_gen_stop_ch2();
    hwbp_app_pwm_gen_stop_ch3();
    clr_SYNC_OUTALL;
    
    /* No PWM should be running */
    app_regs.REG_START_PWM = 0;
    app_regs.REG_STOP_PWM = 0;
    app_regs.REG_EXEC_STATE = 0;
}
void core_callback_device_to_active(void) {}
void core_callback_device_to_enchanced_active(void) {}
void core_callback_device_to_speed(void) {}

/************************************************************************/
/* Callbacks: 1 ms timer                                                */
/************************************************************************/
void core_callback_t_before_exec(void) {}
void core_callback_t_after_exec(void) {}
void core_callback_t_new_second(void) {}
void core_callback_t_500us(void) {}
void core_callback_t_1ms(void) {}

/************************************************************************/
/* Callbacks: uart control                                              */
/************************************************************************/
void core_callback_uart_rx_before_exec(void) {}
void core_callback_uart_rx_after_exec(void) {}
void core_callback_uart_tx_before_exec(void) {}
void core_callback_uart_tx_after_exec(void) {}
void core_callback_uart_cts_before_exec(void) {}
void core_callback_uart_cts_after_exec(void) {}

/************************************************************************/
/* Callbacks: Read app register                                         */
/************************************************************************/
bool core_read_app_register(uint8_t add, uint8_t type)
{
	/* Check if it will not access forbidden memory */
	if (add < APP_REGS_ADD_MIN || add > APP_REGS_ADD_MAX)
		return false;
	
	/* Check if type matches */
	if (app_regs_type[add-APP_REGS_ADD_MIN] != type)
		return false;
	
	/* Receive data */
	(*app_func_rd_pointer[add-APP_REGS_ADD_MIN])();	

	/* Return success */
	return true;
}

/************************************************************************/
/* Callbacks: Write app register                                        */
/************************************************************************/
bool core_write_app_register(uint8_t add, uint8_t type, uint8_t * content, uint16_t n_elements)
{
	/* Check if it will not access forbidden memory */
	if (add < APP_REGS_ADD_MIN || add > APP_REGS_ADD_MAX)
		return false;
	
	/* Check if type matches */
	if (app_regs_type[add-APP_REGS_ADD_MIN] != type)
		return false;

	/* Check if the number of elements matches */
	if (app_regs_n_elements[add-APP_REGS_ADD_MIN] != n_elements)
		return false;

	/* Process data and return false if write is not allowed or contains errors */
	return (*app_func_wr_pointer[add-APP_REGS_ADD_MIN])(content);
}