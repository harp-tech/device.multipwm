#include "app_ios_and_regs.h"
#include "hwbp_core.h"
#include "app_funcs.h"
#include "pwm_gen_functions.h"

extern AppRegs app_regs;

/************************************************************************/
/* Get decimal divider from prescaler                                   */
/************************************************************************/
uint16_t get_divider(uint8_t prescaler)
{
	switch(prescaler)
	{
		case TIMER_PRESCALER_DIV1: return 1;
		case TIMER_PRESCALER_DIV2: return 2;
		case TIMER_PRESCALER_DIV4: return 4;
		case TIMER_PRESCALER_DIV8: return 8;
		case TIMER_PRESCALER_DIV64: return 64;
		case TIMER_PRESCALER_DIV256: return 256;
		case TIMER_PRESCALER_DIV1024: return 1024;
		default: return 0;
	}
}

uint8_t prescaler0, prescaler1, prescaler2, prescaler3;
uint16_t target_count0, target_count1, target_count2, target_count3;
uint16_t duty_cycle0, duty_cycle1, duty_cycle2, duty_cycle3;

/************************************************************************/
/* Calculate real values (frequency and duty cycle)                     */
/************************************************************************/
void hwbp_app_pwm_gen_update_reals_ch0(void)
{
	if (calculate_timer_16bits(32000000, app_regs.REG_CH0_FREQ, &prescaler0, &target_count0))
	{
		app_regs.REG_CH0_REAL_FREQ = 32000000.0 / ((uint32_t)(get_divider(prescaler0)) * (uint32_t)target_count0);
		app_regs.REG_CH0_REAL_DUTYCYCLE = 100.0 * ((float)((uint16_t)(app_regs.REG_CH0_DUTYCYCLE/100.0 * target_count0 + 0.5)) / target_count0);
		duty_cycle0 = app_regs.REG_CH0_DUTYCYCLE/100.0 * target_count0 + 0.5;
		
		if (app_regs.REG_CH0_REAL_DUTYCYCLE <= 0 || app_regs.REG_CH0_REAL_DUTYCYCLE >= 100)
		{
			app_regs.REG_CH0_REAL_FREQ = 0;
			app_regs.REG_CH0_REAL_DUTYCYCLE = 0;
		}
	}
	else
	{
		app_regs.REG_CH0_REAL_FREQ = 0;
		app_regs.REG_CH0_REAL_DUTYCYCLE = 0;
	}
}

void hwbp_app_pwm_gen_update_reals_ch1(void)
{
	if (calculate_timer_16bits(32000000, app_regs.REG_CH1_FREQ, &prescaler1, &target_count1))
	{
		app_regs.REG_CH1_REAL_FREQ = 32000000 / ((uint32_t)(get_divider(prescaler1)) * (uint32_t)target_count1);
		app_regs.REG_CH1_REAL_DUTYCYCLE = 100.0 * ((float)((uint16_t)(app_regs.REG_CH1_DUTYCYCLE/100.0 * target_count1 + 0.5)) / target_count1);
		duty_cycle1 = app_regs.REG_CH1_DUTYCYCLE/100.0 * target_count1 + 0.5;
		
		if (app_regs.REG_CH1_REAL_DUTYCYCLE <= 0 || app_regs.REG_CH1_REAL_DUTYCYCLE >= 100)
		{
			app_regs.REG_CH1_REAL_FREQ = 0;
			app_regs.REG_CH1_REAL_DUTYCYCLE = 0;
		}
	}
	else
	{
		app_regs.REG_CH1_REAL_FREQ = 0;
		app_regs.REG_CH1_REAL_DUTYCYCLE = 0;
	}
}

void hwbp_app_pwm_gen_update_reals_ch2(void)
{
	if (calculate_timer_16bits(32000000, app_regs.REG_CH2_FREQ, &prescaler2, &target_count2))
	{
		app_regs.REG_CH2_REAL_FREQ = 32000000 / ((uint32_t)(get_divider(prescaler2)) * (uint32_t)target_count2);
		app_regs.REG_CH2_REAL_DUTYCYCLE = 100.0 * ((float)((uint16_t)(app_regs.REG_CH2_DUTYCYCLE/100.0 * target_count2 + 0.5)) / target_count2);
		duty_cycle2 = app_regs.REG_CH2_DUTYCYCLE/100.0 * target_count2 + 0.5;
		
		if (app_regs.REG_CH2_REAL_DUTYCYCLE <= 0 || app_regs.REG_CH2_REAL_DUTYCYCLE >= 100)
		{
			app_regs.REG_CH2_REAL_FREQ = 0;
			app_regs.REG_CH2_REAL_DUTYCYCLE = 0;
		}
	}
	else
	{
		app_regs.REG_CH2_REAL_FREQ = 0;
		app_regs.REG_CH2_REAL_DUTYCYCLE = 0;
	}
}

void hwbp_app_pwm_gen_update_reals_ch3(void)
{	
	if (calculate_timer_16bits(32000000, app_regs.REG_CH3_FREQ, &prescaler3, &target_count3))
	{
		app_regs.REG_CH3_REAL_FREQ = 32000000 / ((uint32_t)(get_divider(prescaler3)) * (uint32_t)target_count3);
		app_regs.REG_CH3_REAL_DUTYCYCLE = 100.0 * ((float)((uint16_t)(app_regs.REG_CH3_DUTYCYCLE/100.0 * target_count3 + 0.5)) / target_count3);
		duty_cycle3 = app_regs.REG_CH3_DUTYCYCLE/100.0 * target_count3 + 0.5;
		
		if (app_regs.REG_CH3_REAL_DUTYCYCLE <= 0 || app_regs.REG_CH3_REAL_DUTYCYCLE >= 100)
		{
			app_regs.REG_CH3_REAL_FREQ = 0;
			app_regs.REG_CH3_REAL_DUTYCYCLE = 0;
		}
	}
	else
	{
		app_regs.REG_CH3_REAL_FREQ = 0;
		app_regs.REG_CH3_REAL_DUTYCYCLE = 0;
	}
}

/************************************************************************/
/* Start PWMs                                                           */
/************************************************************************/
uint32_t tcount0, tcount1, tcount2, tcount3;

void check_and_start_pwms(uint8_t start_pwm_reg)
{
    uint8_t exec_state = 0;    
    
    /* Run trough the four bits of the START_PWM register */
    for (uint8_t i = 0; i < 4; i++)
    {
        /* Check if a trigger mask should start */
        if (start_pwm_reg & (B_START_TRG0 << i))
        {
            /* Run trough each channel trigger */
            for (uint8_t j = 0; j < 4; j++)
            {
                /* Check if the channel is not already running */
                if (!(app_regs.REG_EXEC_STATE & (B_PWM0STATE << j)))
                {
                    /* Check if the channel should start */
                    if (*((&app_regs.REG_TRG0_MASK) + i) & (B_TRGCH0 << j))
                    {                    
                        switch (j)
                        {
                            case 0: exec_state |= hwbp_app_pwm_gen_start_ch0(); break;
                            case 1: exec_state |= hwbp_app_pwm_gen_start_ch1(); break;
                            case 2: exec_state |= hwbp_app_pwm_gen_start_ch2(); break;
                            case 3: exec_state |= hwbp_app_pwm_gen_start_ch3(); break;
                        }
                        
                        if (TCC0_CTRLA != 0 || TCD0_CTRLA != 0 || TCE0_CTRLA != 0 || TCF0_CTRLA != 0)
                        {
                        	set_SYNC_OUTALL;
                        }                            
                    }
                }
            }
            
            if (exec_state)
            {   
                app_regs.REG_EXEC_STATE |= exec_state;
                
                if (app_regs.REG_EVNT_ENABLE & B_EVT0)
                {
                    core_func_send_event(ADD_REG_EXEC_STATE, true);
                }
                
                exec_state = 0;
            }            
        }
    }
}

uint8_t hwbp_app_pwm_gen_start_ch0(void)
{
	if (!(app_regs.REG_CH_CONFEN & B_USEEN0) || ((app_regs.REG_CH_CONFEN & B_USEEN0) && (app_regs.REG_CH_ENABLE & B_EN0)))
	{		
		if (!(TCC0_CTRLA))
        {
            tcount0 = app_regs.REG_CH0_COUNTS;

		    timer_type0_pwm(&TCC0, prescaler0, target_count0, duty_cycle0, INT_LEVEL_LOW, INT_LEVEL_LOW);
		    set_SYNC_OUT0;
        
            return B_PWM0STATE;
        }            
	}
    
    return 0;    
}

uint8_t hwbp_app_pwm_gen_start_ch1(void)
{
	if (!(app_regs.REG_CH_CONFEN & B_USEEN1) || ((app_regs.REG_CH_CONFEN & B_USEEN1) && (app_regs.REG_CH_ENABLE & B_EN1)))
	{		
		if (!(TCD0_CTRLA))
        {
		    tcount1 = app_regs.REG_CH1_COUNTS;

		    timer_type0_pwm(&TCD0, prescaler1, target_count1, duty_cycle1, INT_LEVEL_LOW, INT_LEVEL_LOW);
		    set_SYNC_OUT1;
        
            return B_PWM1STATE;
        }            
	}
    
    return 0;
}

uint8_t hwbp_app_pwm_gen_start_ch2(void)
{
	if (!(app_regs.REG_CH_CONFEN & B_USEEN2) || ((app_regs.REG_CH_CONFEN & B_USEEN2) && (app_regs.REG_CH_ENABLE & B_EN2)))
	{		
		if (!(TCE0_CTRLA))
        {
		    tcount2 = app_regs.REG_CH2_COUNTS;

		    timer_type0_pwm(&TCE0, prescaler2, target_count2, duty_cycle2, INT_LEVEL_LOW, INT_LEVEL_LOW);
		    set_SYNC_OUT2;
        
            return B_PWM2STATE;
        }            
	}
    
    return 0;
}

uint8_t hwbp_app_pwm_gen_start_ch3(void)
{
	if (!(app_regs.REG_CH_CONFEN & B_USEEN3) || ((app_regs.REG_CH_CONFEN & B_USEEN3) && (app_regs.REG_CH_ENABLE & B_EN3)))
	{		
		if (!(TCF0_CTRLA))
        {
		    tcount3 = app_regs.REG_CH3_COUNTS;

		    timer_type0_pwm(&TCF0, prescaler3, target_count3, duty_cycle3, INT_LEVEL_LOW, INT_LEVEL_LOW);
		    set_SYNC_OUT3;
        
            return B_PWM3STATE;
        }            
	}
    
    return 0;
}

/************************************************************************/
/* Stop PWMs                                                            */
/************************************************************************/
extern void update_enabled_pwmx(void);

void check_and_stop_pwms(uint8_t stop_pwm_reg)
{
    uint8_t exec_state = 0;
    
    /* Run trough the four bits of the STOP_PWM register */
    for (uint8_t i = 0; i < 4; i++)
    {
        /* Check if a trigger mask should stop */
        if (stop_pwm_reg & (B_STOP_TRG0 << i))
        {
            /* Run trough each channel trigger */
            for (uint8_t j = 0; j < 4; j++)
            {
                /* Check if the channel is running */
                if (app_regs.REG_EXEC_STATE & (B_PWM0STATE << j))
                {
                    /* Check if the channel should stop */
                    if (*((&app_regs.REG_TRG0_MASK) + i) & (B_TRGCH0 << j))
                    {
                        switch (j)
                        {
                            case 0: exec_state |= hwbp_app_pwm_gen_stop_ch0(); break;
                            case 1: exec_state |= hwbp_app_pwm_gen_stop_ch1(); break;
                            case 2: exec_state |= hwbp_app_pwm_gen_stop_ch2(); break;
                            case 3: exec_state |= hwbp_app_pwm_gen_stop_ch3(); break;
                        }
                        
                        if (TCC0_CTRLA == 0 && TCD0_CTRLA == 0 && TCE0_CTRLA == 0 && TCF0_CTRLA == 0)
                        {
                        	clr_SYNC_OUTALL;
                        }                            
                    }
                }
            }
            
            if (exec_state)
            {
                app_regs.REG_EXEC_STATE &= ~(exec_state);
                
                if (app_regs.REG_EVNT_ENABLE & B_EVT0)
                {
                    core_func_send_event(ADD_REG_EXEC_STATE, true);
                }
                
                exec_state = 0;
            }
        }
    }
    
    update_enabled_pwmx();
}

uint8_t hwbp_app_pwm_gen_stop_ch0(void)
{
	if (TCC0_CTRLA)
    {
        timer_type0_stop(&TCC0);
	    clr_SYNC_OUT0;
        
        if (app_regs.REG_CH_ENABLE_SINGLE & B_SGLE0)
    	    app_regs.REG_CH_ENABLE &= ~(B_EN0);
    	    
    	return B_PWM0STATE;
	}
	
	return 0;
}

uint8_t hwbp_app_pwm_gen_stop_ch1(void)
{
	if (TCD0_CTRLA)
	{
    	timer_type0_stop(&TCD0);
	    clr_SYNC_OUT1;
	    
	    if (app_regs.REG_CH_ENABLE_SINGLE & B_SGLE1)
	        app_regs.REG_CH_ENABLE &= ~(B_EN1);
	    
	    return B_PWM1STATE;
    }
    
    return 0;
}

uint8_t hwbp_app_pwm_gen_stop_ch2(void)
{
	if (TCE0_CTRLA)
	{
    	timer_type0_stop(&TCE0);
	    clr_SYNC_OUT2;
		
        if (app_regs.REG_CH_ENABLE_SINGLE & B_SGLE2)
		    app_regs.REG_CH_ENABLE &= ~(B_EN2);
		    
	    return B_PWM2STATE;
    }
    
    return 0;
}

uint8_t hwbp_app_pwm_gen_stop_ch3(void)
{
	if (TCF0_CTRLA)
	{
    	timer_type0_stop(&TCF0);
	    clr_SYNC_OUT3;	
		
        if (app_regs.REG_CH_ENABLE_SINGLE & B_SGLE3)
		    app_regs.REG_CH_ENABLE &= ~(B_EN3);
		    
	    return B_PWM3STATE;
    }
    
    return 0;
}

/************************************************************************/
/* PWM interrupts                                                       */
/************************************************************************/
ISR(TCC0_OVF_vect, ISR_NAKED)
{
	reti();
}

ISR(TCC0_CCA_vect, ISR_NAKED)
{
	if (--tcount0 == 0)
		if ((app_regs.REG_CH0_MODE & MSK_CH_MODE) == GM_CH_MODE_COUNT)
		{
			hwbp_app_pwm_gen_stop_ch0();
            
            if (TCD0_CTRLA == 0 && TCE0_CTRLA == 0 && TCF0_CTRLA == 0)
                clr_SYNC_OUTALL;
            
            app_regs.REG_EXEC_STATE &= ~(B_PWM0STATE);
            
            if (app_regs.REG_EVNT_ENABLE & B_EVT0)
            {
                core_func_send_event(ADD_REG_EXEC_STATE, true);
            }
            
            update_enabled_pwmx();
		}

	reti();
}

ISR(TCD0_OVF_vect, ISR_NAKED)
{
	reti();
}

ISR(TCD0_CCA_vect, ISR_NAKED)
{
	if (--tcount1 == 0)
		if ((app_regs.REG_CH1_MODE & MSK_CH_MODE) == GM_CH_MODE_COUNT)
		{
    		hwbp_app_pwm_gen_stop_ch1();            
            
            if (TCC0_CTRLA == 0 && TCE0_CTRLA == 0 && TCF0_CTRLA == 0)
                clr_SYNC_OUTALL;
            
            app_regs.REG_EXEC_STATE &= ~(B_PWM1STATE);
            
            if (app_regs.REG_EVNT_ENABLE & B_EVT0)
            {
                core_func_send_event(ADD_REG_EXEC_STATE, true);
            }
            
            update_enabled_pwmx();
		}

	reti();
}

ISR(TCE0_OVF_vect, ISR_NAKED)
{
	reti();
}

ISR(TCE0_CCA_vect, ISR_NAKED)
{
	if (--tcount2 == 0)
		if ((app_regs.REG_CH2_MODE & MSK_CH_MODE) == GM_CH_MODE_COUNT)
		{
			hwbp_app_pwm_gen_stop_ch2();
            
            if (TCC0_CTRLA == 0 && TCD0_CTRLA == 0 && TCF0_CTRLA == 0)
                clr_SYNC_OUTALL;
            
            app_regs.REG_EXEC_STATE &= ~(B_PWM2STATE);
            
            if (app_regs.REG_EVNT_ENABLE & B_EVT0)
            {
                core_func_send_event(ADD_REG_EXEC_STATE, true);
            }
            
            update_enabled_pwmx();
		}

	reti();
}


ISR(TCF0_OVF_vect, ISR_NAKED)
{
	reti();
}

ISR(TCF0_CCA_vect, ISR_NAKED)
{
	if (--tcount3 == 0)
		if ((app_regs.REG_CH3_MODE & MSK_CH_MODE) == GM_CH_MODE_COUNT)
		{
			hwbp_app_pwm_gen_stop_ch3();
            
            if (TCC0_CTRLA == 0 && TCD0_CTRLA == 0 && TCE0_CTRLA == 0)
                clr_SYNC_OUTALL;
            
            app_regs.REG_EXEC_STATE &= ~(B_PWM3STATE);
            
            if (app_regs.REG_EVNT_ENABLE & B_EVT0)
            {
                core_func_send_event(ADD_REG_EXEC_STATE, true);
            }
            
            update_enabled_pwmx();
		}

	reti();
}

/************************************************************************/
/* External pin interrupts                                              */
/************************************************************************/
/* TRIG_IN0 */
ISR(PORTF_INT0_vect, ISR_NAKED)
{	
	if((read_TRIG_IN0 && !(app_regs.REG_TRG0_MODE & B_NTRG)) || (!read_TRIG_IN0 && (app_regs.REG_TRG0_MODE & B_NTRG)))
	{
        check_and_start_pwms(B_START_TRG0);
	}
	else if((app_regs.REG_TRG0_MODE & MSK_TRG_MODE) == GM_TRG_MODE_START_AND_STOP)
	{
        check_and_stop_pwms(B_STOP_TRG0);
	}

	reti();
}

/* TRIG_IN1 */
ISR(PORTF_INT1_vect, ISR_NAKED)
{
	if((read_TRIG_IN1 && !(app_regs.REG_TRG1_MODE & B_NTRG)) || (!read_TRIG_IN1 && (app_regs.REG_TRG1_MODE & B_NTRG)))
	{
    	check_and_start_pwms(B_START_TRG1);
	}
	else if((app_regs.REG_TRG1_MODE & MSK_TRG_MODE) == GM_TRG_MODE_START_AND_STOP)
	{
    	check_and_stop_pwms(B_STOP_TRG1);
	}

	reti();
}


/* TRIG_IN2 */
ISR(PORTH_INT0_vect, ISR_NAKED)
{
	if((read_TRIG_IN2 && !(app_regs.REG_TRG2_MODE & B_NTRG)) || (!read_TRIG_IN2 && (app_regs.REG_TRG2_MODE & B_NTRG)))
	{
    	check_and_start_pwms(B_START_TRG2);
	}
	else if((app_regs.REG_TRG2_MODE & MSK_TRG_MODE) == GM_TRG_MODE_START_AND_STOP)
	{
    	check_and_stop_pwms(B_STOP_TRG2);
	}

	reti();
}


/* TRIG_IN3 */
ISR(PORTK_INT0_vect, ISR_NAKED)
{
	if((read_TRIG_IN3 && !(app_regs.REG_TRG3_MODE & B_NTRG)) || (!read_TRIG_IN3 && (app_regs.REG_TRG3_MODE & B_NTRG)))
	{
    	check_and_start_pwms(B_START_TRG3);
	}
	else if((app_regs.REG_TRG3_MODE & MSK_TRG_MODE) == GM_TRG_MODE_START_AND_STOP)
	{
    	check_and_stop_pwms(B_STOP_TRG3);
	}

	reti();
}


/* TRIG_ALL */
ISR(PORTQ_INT0_vect, ISR_NAKED)
{
	if((read_TRIG_ALL && !(app_regs.REG_TRGALL_MODE & B_NEG)) || (!read_TRIG_ALL && (app_regs.REG_TRGALL_MODE & B_NEG)))
	{
		if ((app_regs.REG_TRGALL_MODE & MSK_ALL_MODE) == GM_ALL_MODE_TRIG_ALL || (app_regs.REG_TRGALL_MODE & MSK_ALL_MODE) == GM_ALL_MODE_TRIG_ALL_AND_STOP)
		{
            uint8_t exec_state = 0;
            exec_state |= hwbp_app_pwm_gen_start_ch0();
            exec_state |= hwbp_app_pwm_gen_start_ch1();
            exec_state |= hwbp_app_pwm_gen_start_ch2();
            exec_state |= hwbp_app_pwm_gen_start_ch3();
            set_SYNC_OUTALL;
            
            if (exec_state)
            {   
                app_regs.REG_EXEC_STATE |= exec_state;
                
                if (app_regs.REG_EVNT_ENABLE & B_EVT0)
                {
                    core_func_send_event(ADD_REG_EXEC_STATE, true);
                }
            }                
		}
		else
		{
			app_regs.REG_CH_ENABLE |= B_EN3 | B_EN2 | B_EN1 | B_EN0;
			update_enabled_pwmx();
		}
	}
	else if ((app_regs.REG_TRGALL_MODE & MSK_ALL_MODE) == GM_ALL_MODE_TRIG_ALL_AND_STOP || (app_regs.REG_TRGALL_MODE & MSK_ALL_MODE) == GM_ALL_MODE_ENABLE_AND_STOP )
	{
        uint8_t exec_state = 0;
        exec_state |= hwbp_app_pwm_gen_stop_ch0();
        exec_state |= hwbp_app_pwm_gen_stop_ch1();
        exec_state |= hwbp_app_pwm_gen_stop_ch2();
        exec_state |= hwbp_app_pwm_gen_stop_ch3();
        clr_SYNC_OUTALL;
            
        if (exec_state)
        {
            app_regs.REG_EXEC_STATE &= ~(exec_state);
                
            if (app_regs.REG_EVNT_ENABLE & B_EVT0)
            {
                core_func_send_event(ADD_REG_EXEC_STATE, true);
            }
        }       
	}
	
	reti();
}