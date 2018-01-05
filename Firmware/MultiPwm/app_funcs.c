#include "app_funcs.h"
#include "app_ios_and_regs.h"
#include "hwbp_core.h"
#include "pwm_gen_functions.h"


/************************************************************************/
/* Create pointers to functions                                         */
/************************************************************************/
extern AppRegs app_regs;

void (*app_func_rd_pointer[])(void) = {
	&app_read_REG_CH0_FREQ,
	&app_read_REG_CH1_FREQ,
	&app_read_REG_CH2_FREQ,
	&app_read_REG_CH3_FREQ,
	&app_read_REG_CH0_DUTYCYCLE,
	&app_read_REG_CH1_DUTYCYCLE,
	&app_read_REG_CH2_DUTYCYCLE,
	&app_read_REG_CH3_DUTYCYCLE,
	&app_read_REG_CH0_COUNTS,
	&app_read_REG_CH1_COUNTS,
	&app_read_REG_CH2_COUNTS,
	&app_read_REG_CH3_COUNTS,
	&app_read_REG_CH0_REAL_FREQ,
	&app_read_REG_CH1_REAL_FREQ,
	&app_read_REG_CH2_REAL_FREQ,
	&app_read_REG_CH3_REAL_FREQ,
	&app_read_REG_CH0_REAL_DUTYCYCLE,
	&app_read_REG_CH1_REAL_DUTYCYCLE,
	&app_read_REG_CH2_REAL_DUTYCYCLE,
	&app_read_REG_CH3_REAL_DUTYCYCLE,
	&app_read_REG_CH0_MODE,
	&app_read_REG_CH1_MODE,
	&app_read_REG_CH2_MODE,
	&app_read_REG_CH3_MODE,
	&app_read_REG_TRG0_MASK,
	&app_read_REG_TRG1_MASK,
	&app_read_REG_TRG2_MASK,
	&app_read_REG_TRG3_MASK,
	&app_read_REG_START_PWM,
	&app_read_REG_STOP_PWM,
	&app_read_REG_CH_ENABLE_SINGLE,
	&app_read_REG_RESERVED1,
	&app_read_REG_TRG0_MODE,
	&app_read_REG_TRG1_MODE,
	&app_read_REG_TRG2_MODE,
	&app_read_REG_TRG3_MODE,
	&app_read_REG_CH_CONFEN,
	&app_read_REG_CH_ENABLE,
	&app_read_REG_TRGALL_MODE,
	&app_read_REG_TRIG_STATE,
	&app_read_REG_CH_STATE,
	&app_read_REG_EXEC_STATE,
	&app_read_REG_EVNT_ENABLE
};

bool (*app_func_wr_pointer[])(void*) = {
	&app_write_REG_CH0_FREQ,
	&app_write_REG_CH1_FREQ,
	&app_write_REG_CH2_FREQ,
	&app_write_REG_CH3_FREQ,
	&app_write_REG_CH0_DUTYCYCLE,
	&app_write_REG_CH1_DUTYCYCLE,
	&app_write_REG_CH2_DUTYCYCLE,
	&app_write_REG_CH3_DUTYCYCLE,
	&app_write_REG_CH0_COUNTS,
	&app_write_REG_CH1_COUNTS,
	&app_write_REG_CH2_COUNTS,
	&app_write_REG_CH3_COUNTS,
	&app_write_REG_CH0_REAL_FREQ,
	&app_write_REG_CH1_REAL_FREQ,
	&app_write_REG_CH2_REAL_FREQ,
	&app_write_REG_CH3_REAL_FREQ,
	&app_write_REG_CH0_REAL_DUTYCYCLE,
	&app_write_REG_CH1_REAL_DUTYCYCLE,
	&app_write_REG_CH2_REAL_DUTYCYCLE,
	&app_write_REG_CH3_REAL_DUTYCYCLE,
	&app_write_REG_CH0_MODE,
	&app_write_REG_CH1_MODE,
	&app_write_REG_CH2_MODE,
	&app_write_REG_CH3_MODE,
	&app_write_REG_TRG0_MASK,
	&app_write_REG_TRG1_MASK,
	&app_write_REG_TRG2_MASK,
	&app_write_REG_TRG3_MASK,
	&app_write_REG_START_PWM,
	&app_write_REG_STOP_PWM,
	&app_write_REG_CH_ENABLE_SINGLE,
	&app_write_REG_RESERVED1,
	&app_write_REG_TRG0_MODE,
	&app_write_REG_TRG1_MODE,
	&app_write_REG_TRG2_MODE,
	&app_write_REG_TRG3_MODE,
	&app_write_REG_CH_CONFEN,
	&app_write_REG_CH_ENABLE,
	&app_write_REG_TRGALL_MODE,
	&app_write_REG_TRIG_STATE,
	&app_write_REG_CH_STATE,
	&app_write_REG_EXEC_STATE,
	&app_write_REG_EVNT_ENABLE
};

void stop_and_update_ch0_temps(void)
{       
    if (hwbp_app_pwm_gen_stop_ch0())
    {
        app_regs.REG_EXEC_STATE &= ~(B_PWM0STATE);
        
        if (app_regs.REG_EVNT_ENABLE & B_EVT0)
        {
            core_func_send_event(ADD_REG_EXEC_STATE, true);
        }
    }
    
    hwbp_app_pwm_gen_update_reals_ch0();
}

void stop_and_update_ch1_temps(void)
{       
    if (hwbp_app_pwm_gen_stop_ch1())
    {
        app_regs.REG_EXEC_STATE &= ~(B_PWM1STATE);
        
        if (app_regs.REG_EVNT_ENABLE & B_EVT0)
        {
            core_func_send_event(ADD_REG_EXEC_STATE, true);
        }
    }
    
    hwbp_app_pwm_gen_update_reals_ch1();
}

void stop_and_update_ch2_temps(void)
{       
    if (hwbp_app_pwm_gen_stop_ch2())
    {
        app_regs.REG_EXEC_STATE &= ~(B_PWM2STATE);
        
        if (app_regs.REG_EVNT_ENABLE & B_EVT0)
        {
            core_func_send_event(ADD_REG_EXEC_STATE, true);
        }
    }
    
    hwbp_app_pwm_gen_update_reals_ch2();
}

void stop_and_update_ch3_temps(void)
{       
    if (hwbp_app_pwm_gen_stop_ch3())
    {
        app_regs.REG_EXEC_STATE &= ~(B_PWM3STATE);
        
        if (app_regs.REG_EVNT_ENABLE & B_EVT0)
        {
            core_func_send_event(ADD_REG_EXEC_STATE, true);
        }
    }
    
    hwbp_app_pwm_gen_update_reals_ch3();
}

/************************************************************************/
/* REG_CH0_FREQ                                                         */
/************************************************************************/
void app_read_REG_CH0_FREQ(void) {}
bool app_write_REG_CH0_FREQ(void *a)
{	
    float reg = *((float*)a);
    
    if (reg < 0.5 || reg > 32768.0)
        return false;

	app_regs.REG_CH0_FREQ = reg;
    stop_and_update_ch0_temps();
	return true;
}


/************************************************************************/
/* REG_CH1_FREQ                                                         */
/************************************************************************/
void app_read_REG_CH1_FREQ(void) {}
bool app_write_REG_CH1_FREQ(void *a)
{
    float reg = *((float*)a);
    
    if (reg < 0.5 || reg > 32768.0)
        return false;

    app_regs.REG_CH1_FREQ = reg;
    stop_and_update_ch1_temps();
    return true;
}


/************************************************************************/
/* REG_CH2_FREQ                                                         */
/************************************************************************/
void app_read_REG_CH2_FREQ(void) {}
bool app_write_REG_CH2_FREQ(void *a)
{
    float reg = *((float*)a);
    
    if (reg < 0.5 || reg > 32768.0)
        return false;

    app_regs.REG_CH2_FREQ = reg;
    stop_and_update_ch2_temps();
    return true;
}


/************************************************************************/
/* REG_CH3_FREQ                                                         */
/************************************************************************/
void app_read_REG_CH3_FREQ(void) {}
bool app_write_REG_CH3_FREQ(void *a)
{
    float reg = *((float*)a);
    
    if (reg < 0.5 || reg > 32768.0)
        return false;
    
    app_regs.REG_CH3_FREQ = reg;
    stop_and_update_ch3_temps();
    return true;
}


/************************************************************************/
/* REG_CH0_DUTYCYCLE                                                    */
/************************************************************************/
void app_read_REG_CH0_DUTYCYCLE(void) {}
bool app_write_REG_CH0_DUTYCYCLE(void *a)
{
	float reg = *((float*)a);
    
    if (reg <= 0.1 || reg >= 99.9)
	    return false;

	app_regs.REG_CH0_DUTYCYCLE = reg;
    stop_and_update_ch0_temps();
	return true;
}


/************************************************************************/
/* REG_CH1_DUTYCYCLE                                                    */
/************************************************************************/
void app_read_REG_CH1_DUTYCYCLE(void) {}
bool app_write_REG_CH1_DUTYCYCLE(void *a)
{
    float reg = *((float*)a);
    
    if (reg <= 0.1 || reg >= 99.9)
        return false;

    app_regs.REG_CH1_DUTYCYCLE = reg;
    stop_and_update_ch1_temps();
    return true;
}


/************************************************************************/
/* REG_CH2_DUTYCYCLE                                                    */
/************************************************************************/
void app_read_REG_CH2_DUTYCYCLE(void) {}
bool app_write_REG_CH2_DUTYCYCLE(void *a)
{
    float reg = *((float*)a);
    
    if (reg <= 0.1 || reg >= 99.9)
        return false;

    app_regs.REG_CH2_DUTYCYCLE = reg;
    stop_and_update_ch2_temps();
    return true;
}


/************************************************************************/
/* REG_CH3_DUTYCYCLE                                                    */
/************************************************************************/
void app_read_REG_CH3_DUTYCYCLE(void) {}
bool app_write_REG_CH3_DUTYCYCLE(void *a)
{
    float reg = *((float*)a);
    
    if (reg <= 0.1 || reg >= 99.9)
        return false;

    app_regs.REG_CH3_DUTYCYCLE = reg;
    stop_and_update_ch3_temps();
    return true;
}


/************************************************************************/
/* REG_CH0_COUNTS                                                       */
/************************************************************************/
void app_read_REG_CH0_COUNTS(void) {}
bool app_write_REG_CH0_COUNTS(void *a)
{
	if (*((uint32_t*)a) == 0)
        return false;

	app_regs.REG_CH0_COUNTS = *((uint32_t*)a);
    stop_and_update_ch0_temps();
	return true;
}


/************************************************************************/
/* REG_CH1_COUNTS                                                       */
/************************************************************************/
void app_read_REG_CH1_COUNTS(void) {}
bool app_write_REG_CH1_COUNTS(void *a)
{
    if (*((uint32_t*)a) == 0)
        return false;

    app_regs.REG_CH1_COUNTS = *((uint32_t*)a);
    stop_and_update_ch1_temps();
    return true;
}


/************************************************************************/
/* REG_CH2_COUNTS                                                       */
/************************************************************************/
void app_read_REG_CH2_COUNTS(void) {}
bool app_write_REG_CH2_COUNTS(void *a)
{
    if (*((uint32_t*)a) == 0)
        return false;

    app_regs.REG_CH2_COUNTS = *((uint32_t*)a);
    stop_and_update_ch2_temps();
    return true;
}


/************************************************************************/
/* REG_CH3_COUNTS                                                       */
/************************************************************************/
void app_read_REG_CH3_COUNTS(void) {}
bool app_write_REG_CH3_COUNTS(void *a)
{
    if (*((uint32_t*)a) == 0)
        return false;

    app_regs.REG_CH3_COUNTS = *((uint32_t*)a);
    stop_and_update_ch3_temps();
    return true;
}


/************************************************************************/
/* REG_CH0_REAL_FREQ                                                    */
/************************************************************************/
void app_read_REG_CH0_REAL_FREQ(void) {}
bool app_write_REG_CH0_REAL_FREQ(void *a) {return false;}


/************************************************************************/
/* REG_CH1_REAL_FREQ                                                    */
/************************************************************************/
void app_read_REG_CH1_REAL_FREQ(void) {}
bool app_write_REG_CH1_REAL_FREQ(void *a) {return false;}


/************************************************************************/
/* REG_CH2_REAL_FREQ                                                    */
/************************************************************************/
void app_read_REG_CH2_REAL_FREQ(void) {}
bool app_write_REG_CH2_REAL_FREQ(void *a) {return false;}


/************************************************************************/
/* REG_CH3_REAL_FREQ                                                    */
/************************************************************************/
void app_read_REG_CH3_REAL_FREQ(void) {}
bool app_write_REG_CH3_REAL_FREQ(void *a) {return false;}


/************************************************************************/
/* REG_CH0_REAL_DUTYCYCLE                                               */
/************************************************************************/
void app_read_REG_CH0_REAL_DUTYCYCLE(void) {}
bool app_write_REG_CH0_REAL_DUTYCYCLE(void *a) {return false;}


/************************************************************************/
/* REG_CH1_REAL_DUTYCYCLE                                               */
/************************************************************************/
void app_read_REG_CH1_REAL_DUTYCYCLE(void) {}
bool app_write_REG_CH1_REAL_DUTYCYCLE(void *a) {return false;}


/************************************************************************/
/* REG_CH2_REAL_DUTYCYCLE                                               */
/************************************************************************/
void app_read_REG_CH2_REAL_DUTYCYCLE(void) {}
bool app_write_REG_CH2_REAL_DUTYCYCLE(void *a) {return false;}


/************************************************************************/
/* REG_CH3_REAL_DUTYCYCLE                                               */
/************************************************************************/
void app_read_REG_CH3_REAL_DUTYCYCLE(void) {}
bool app_write_REG_CH3_REAL_DUTYCYCLE(void *a) {return false;}


/************************************************************************/
/* REG_CH0_MODE                                                         */
/************************************************************************/
void app_read_REG_CH0_MODE(void) {}
bool app_write_REG_CH0_MODE(void *a)
{
    if (*((uint8_t*)a) & ~MSK_CH_MODE)
        return false;

	app_regs.REG_CH0_MODE = *((uint8_t*)a);
	return true;
}


/************************************************************************/
/* REG_CH1_MODE                                                         */
/************************************************************************/
void app_read_REG_CH1_MODE(void) {}
bool app_write_REG_CH1_MODE(void *a)
{
    if (*((uint8_t*)a) & ~MSK_CH_MODE)
        return false;

    app_regs.REG_CH1_MODE = *((uint8_t*)a);
    return true;
}


/************************************************************************/
/* REG_CH2_MODE                                                         */
/************************************************************************/
void app_read_REG_CH2_MODE(void) {}
bool app_write_REG_CH2_MODE(void *a)
{
    if (*((uint8_t*)a) & ~MSK_CH_MODE)
        return false;

    app_regs.REG_CH2_MODE = *((uint8_t*)a);
    return true;
}


/************************************************************************/
/* REG_CH3_MODE                                                         */
/************************************************************************/
void app_read_REG_CH3_MODE(void) {}
bool app_write_REG_CH3_MODE(void *a)
{
    if (*((uint8_t*)a) & ~MSK_CH_MODE)
        return false;

    app_regs.REG_CH3_MODE = *((uint8_t*)a);
    return true;
}


/************************************************************************/
/* REG_TRG0_MASK                                                        */
/************************************************************************/
void app_read_REG_TRG0_MASK(void) {}
bool app_write_REG_TRG0_MASK(void *a)
{
	if (*((uint8_t*)a) & ~(B_TRGCH0 | B_TRGCH1 | B_TRGCH2 | B_TRGCH3))
        return false;

	app_regs.REG_TRG0_MASK = *((uint8_t*)a);
	return true;
}


/************************************************************************/
/* REG_TRG1_MASK                                                        */
/************************************************************************/
void app_read_REG_TRG1_MASK(void) {}
bool app_write_REG_TRG1_MASK(void *a)
{
    if (*((uint8_t*)a) & ~(B_TRGCH0 | B_TRGCH1 | B_TRGCH2 | B_TRGCH3))
        return false;

    app_regs.REG_TRG1_MASK = *((uint8_t*)a);
    return true;
}


/************************************************************************/
/* REG_TRG2_MASK                                                        */
/************************************************************************/
void app_read_REG_TRG2_MASK(void) {}
bool app_write_REG_TRG2_MASK(void *a)
{
    if (*((uint8_t*)a) & ~(B_TRGCH0 | B_TRGCH1 | B_TRGCH2 | B_TRGCH3))
        return false;

    app_regs.REG_TRG2_MASK = *((uint8_t*)a);
    return true;
}


/************************************************************************/
/* REG_TRG3_MASK                                                        */
/************************************************************************/
void app_read_REG_TRG3_MASK(void) {}
bool app_write_REG_TRG3_MASK(void *a)
{
    if (*((uint8_t*)a) & ~(B_TRGCH0 | B_TRGCH1 | B_TRGCH2 | B_TRGCH3))
        return false;

    app_regs.REG_TRG3_MASK = *((uint8_t*)a);
    return true;
}


/************************************************************************/
/* REG_START_PWM                                                        */
/************************************************************************/
void app_read_REG_START_PWM(void)
{
    app_regs.REG_START_PWM = 0;
}

bool app_write_REG_START_PWM(void *a)
{
    if (*((uint8_t*)a) & ~(B_START_TRG0 | B_START_TRG1 | B_START_TRG2 | B_START_TRG3))
        return false;
    
    app_regs.REG_START_PWM = *((uint8_t*)a);
    check_and_start_pwms(*((uint8_t*)a));
	return true;
}


/************************************************************************/
/* REG_STOP_PWM                                                         */
/************************************************************************/
void app_read_REG_STOP_PWM(void)
{
    app_regs.REG_STOP_PWM = 0;
}

bool app_write_REG_STOP_PWM(void *a)
{
    if (*((uint8_t*)a) & ~(B_STOP_TRG0 | B_STOP_TRG1 | B_STOP_TRG2 | B_STOP_TRG3))
        return false;
    
    app_regs.REG_STOP_PWM = *((uint8_t*)a);
    check_and_stop_pwms(*((uint8_t*)a));
    return true;
}


/************************************************************************/
/* REG_CH_ENABLE_SINGLE                                                 */
/************************************************************************/
void app_read_REG_CH_ENABLE_SINGLE(void) {};
bool app_write_REG_CH_ENABLE_SINGLE(void *a) 
{
    if (*((uint8_t*)a) & ~(B_SGLE0 | B_SGLE1 | B_SGLE2 | B_SGLE3))
        return false;
    
    app_regs.REG_CH_ENABLE_SINGLE = *((uint8_t*)a);        
    return true;
}        


/************************************************************************/
/* REG_RESERVED1                                                        */
/************************************************************************/
void app_read_REG_RESERVED1(void) {};
bool app_write_REG_RESERVED1(void *a) {return true;}
    

/************************************************************************/
/* REG_TRG0_MODE                                                        */
/************************************************************************/
void app_read_REG_TRG0_MODE(void) {}
bool app_write_REG_TRG0_MODE(void *a)
{
	if (*((uint8_t*)a) & ~(MSK_TRG_MODE | B_NTRG))
        return false;

	app_regs.REG_TRG0_MODE = *((uint8_t*)a);
	return true;
}


/************************************************************************/
/* REG_TRG1_MODE                                                        */
/************************************************************************/
void app_read_REG_TRG1_MODE(void) {}
bool app_write_REG_TRG1_MODE(void *a)
{
    if (*((uint8_t*)a) & ~(MSK_TRG_MODE | B_NTRG))
        return false;

    app_regs.REG_TRG1_MODE = *((uint8_t*)a);
    return true;
}


/************************************************************************/
/* REG_TRG2_MODE                                                        */
/************************************************************************/
void app_read_REG_TRG2_MODE(void) {}
bool app_write_REG_TRG2_MODE(void *a)
{
    if (*((uint8_t*)a) & ~(MSK_TRG_MODE | B_NTRG))
        return false;

    app_regs.REG_TRG2_MODE = *((uint8_t*)a);
    return true;
}


/************************************************************************/
/* REG_TRG3_MODE                                                        */
/************************************************************************/
void app_read_REG_TRG3_MODE(void) {}
bool app_write_REG_TRG3_MODE(void *a)
{
    if (*((uint8_t*)a) & ~(MSK_TRG_MODE | B_NTRG))
        return false;

    app_regs.REG_TRG3_MODE = *((uint8_t*)a);
    return true;
}


/************************************************************************/
/* REG_CH_CONFEN                                                        */
/************************************************************************/
extern void update_enabled_pwmx(void);

void app_read_REG_CH_CONFEN(void) {}
bool app_write_REG_CH_CONFEN(void *a)
{
    if (*((uint8_t*)a) & ~(B_USEEN0 | B_USEEN1 | B_USEEN2 | B_USEEN3))
        return false;
    
	app_regs.REG_CH_CONFEN = *((uint8_t*)a);
	update_enabled_pwmx();
	return true;
}


/************************************************************************/
/* REG_CH_ENABLE                                                        */
/************************************************************************/
void app_read_REG_CH_ENABLE(void) {}
bool app_write_REG_CH_ENABLE(void *a)
{
    if (*((uint8_t*)a) & ~(B_EN0 | B_EN1 | B_EN2 | B_EN3))
	    return false;
    
    app_regs.REG_CH_ENABLE = *((uint8_t*)a);    
	update_enabled_pwmx();
	return true;
}


/************************************************************************/
/* REG_TRGALL_MODE                                                      */
/************************************************************************/
void app_read_REG_TRGALL_MODE(void) {}
bool app_write_REG_TRGALL_MODE(void *a)
{
    if (*((uint8_t*)a) & ~(MSK_ALL_MODE | B_NEG))
	    return false;

	app_regs.REG_TRGALL_MODE = *((uint8_t*)a);
	return true;
}


/************************************************************************/
/* REG_TRIG_STATE                                                       */
/************************************************************************/
void app_read_REG_TRIG_STATE(void)
{
    app_regs.REG_TRIG_STATE  = (read_TRIG_IN0) ? B_LTRG0 : 0;
    app_regs.REG_TRIG_STATE |= (read_TRIG_IN1) ? B_LTRG1 : 0;
    app_regs.REG_TRIG_STATE |= (read_TRIG_IN2) ? B_LTRG2 : 0;
    app_regs.REG_TRIG_STATE |= (read_TRIG_IN3) ? B_LTRG3 : 0;
    app_regs.REG_TRIG_STATE |= (read_TRIG_ALL) ? B_LTRGALL : 0;
}

bool app_write_REG_TRIG_STATE(void *a) {return false;}


/************************************************************************/
/* REG_CH_STATE                                                         */
/************************************************************************/
void app_read_REG_CH_STATE(void)
{
    app_regs.REG_CH_STATE  = (read_PWM_OUT0) ? B_SCH0 : 0;
    app_regs.REG_CH_STATE |= (read_PWM_OUT1) ? B_SCH1 : 0;
    app_regs.REG_CH_STATE |= (read_PWM_OUT2) ? B_SCH2 : 0;
    app_regs.REG_CH_STATE |= (read_PWM_OUT3) ? B_SCH3 : 0;
}

bool app_write_REG_CH_STATE(void *a) {return false;}


/************************************************************************/
/* REG_EXEC_STATE                                                       */
/************************************************************************/
void app_read_REG_EXEC_STATE(void) {}
bool app_write_REG_EXEC_STATE(void *a) {return false;}


/************************************************************************/
/* REG_EVNT_ENABLE                                                      */
/************************************************************************/
void app_read_REG_EVNT_ENABLE(void) {}

bool app_write_REG_EVNT_ENABLE(void *a)
{
	if (*((uint8_t*)a) & ~(B_EVT0))
        return false;

	app_regs.REG_EVNT_ENABLE = *((uint8_t*)a);
	return true;
}