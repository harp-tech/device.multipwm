#ifndef _PWM_GEN_FUNCTION_H_
#define _PWM_GEN_FUNCTION_H_

/************************************************************************/
/* Get decimal divider from prescaler                                   */
/************************************************************************/
uint16_t get_divider(uint8_t prescaler);

/************************************************************************/
/* Calculate real values (frequency and duty cycle)                     */
/************************************************************************/
void hwbp_app_pwm_gen_update_reals_ch0(void);
void hwbp_app_pwm_gen_update_reals_ch1(void);
void hwbp_app_pwm_gen_update_reals_ch2(void);
void hwbp_app_pwm_gen_update_reals_ch3(void);

/************************************************************************/
/* Start PWMs                                                           */
/************************************************************************/
void check_and_start_pwms(uint8_t start_pwm_reg);
uint8_t hwbp_app_pwm_gen_start_ch0(void);
uint8_t hwbp_app_pwm_gen_start_ch1(void);
uint8_t hwbp_app_pwm_gen_start_ch2(void);
uint8_t hwbp_app_pwm_gen_start_ch3(void);

/************************************************************************/
/* Stop PWMs                                                            */
/************************************************************************/
void check_and_stop_pwms(uint8_t stop_pwm_reg);
uint8_t hwbp_app_pwm_gen_stop_ch0(void);
uint8_t hwbp_app_pwm_gen_stop_ch1(void);
uint8_t hwbp_app_pwm_gen_stop_ch2(void);
uint8_t hwbp_app_pwm_gen_stop_ch3(void);

#endif /* _PWM_GEN_FUNCTION_H_ */