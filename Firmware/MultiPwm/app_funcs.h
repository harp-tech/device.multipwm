#ifndef _APP_FUNCTIONS_H_
#define _APP_FUNCTIONS_H_
#include <avr/io.h>


/************************************************************************/
/* Define if not defined                                                */
/************************************************************************/
#ifndef bool
	#define bool uint8_t
#endif
#ifndef true
	#define true 1
#endif
#ifndef false
	#define false 0
#endif


/************************************************************************/
/* Prototypes                                                           */
/************************************************************************/
void app_read_REG_CH0_FREQ(void);
void app_read_REG_CH1_FREQ(void);
void app_read_REG_CH2_FREQ(void);
void app_read_REG_CH3_FREQ(void);
void app_read_REG_CH0_DUTYCYCLE(void);
void app_read_REG_CH1_DUTYCYCLE(void);
void app_read_REG_CH2_DUTYCYCLE(void);
void app_read_REG_CH3_DUTYCYCLE(void);
void app_read_REG_CH0_COUNTS(void);
void app_read_REG_CH1_COUNTS(void);
void app_read_REG_CH2_COUNTS(void);
void app_read_REG_CH3_COUNTS(void);
void app_read_REG_CH0_REAL_FREQ(void);
void app_read_REG_CH1_REAL_FREQ(void);
void app_read_REG_CH2_REAL_FREQ(void);
void app_read_REG_CH3_REAL_FREQ(void);
void app_read_REG_CH0_REAL_DUTYCYCLE(void);
void app_read_REG_CH1_REAL_DUTYCYCLE(void);
void app_read_REG_CH2_REAL_DUTYCYCLE(void);
void app_read_REG_CH3_REAL_DUTYCYCLE(void);
void app_read_REG_CH0_MODE(void);
void app_read_REG_CH1_MODE(void);
void app_read_REG_CH2_MODE(void);
void app_read_REG_CH3_MODE(void);
void app_read_REG_TRG0_MASK(void);
void app_read_REG_TRG1_MASK(void);
void app_read_REG_TRG2_MASK(void);
void app_read_REG_TRG3_MASK(void);
void app_read_REG_START_PWM(void);
void app_read_REG_STOP_PWM(void);
void app_read_REG_CH_ENABLE_SINGLE(void);
void app_read_REG_RESERVED1(void);
void app_read_REG_TRG0_MODE(void);
void app_read_REG_TRG1_MODE(void);
void app_read_REG_TRG2_MODE(void);
void app_read_REG_TRG3_MODE(void);
void app_read_REG_CH_CONFEN(void);
void app_read_REG_CH_ENABLE(void);
void app_read_REG_TRGALL_MODE(void);
void app_read_REG_TRIG_STATE(void);
void app_read_REG_CH_STATE(void);
void app_read_REG_EXEC_STATE(void);
void app_read_REG_EVNT_ENABLE(void);

bool app_write_REG_CH0_FREQ(void *a);
bool app_write_REG_CH1_FREQ(void *a);
bool app_write_REG_CH2_FREQ(void *a);
bool app_write_REG_CH3_FREQ(void *a);
bool app_write_REG_CH0_DUTYCYCLE(void *a);
bool app_write_REG_CH1_DUTYCYCLE(void *a);
bool app_write_REG_CH2_DUTYCYCLE(void *a);
bool app_write_REG_CH3_DUTYCYCLE(void *a);
bool app_write_REG_CH0_COUNTS(void *a);
bool app_write_REG_CH1_COUNTS(void *a);
bool app_write_REG_CH2_COUNTS(void *a);
bool app_write_REG_CH3_COUNTS(void *a);
bool app_write_REG_CH0_REAL_FREQ(void *a);
bool app_write_REG_CH1_REAL_FREQ(void *a);
bool app_write_REG_CH2_REAL_FREQ(void *a);
bool app_write_REG_CH3_REAL_FREQ(void *a);
bool app_write_REG_CH0_REAL_DUTYCYCLE(void *a);
bool app_write_REG_CH1_REAL_DUTYCYCLE(void *a);
bool app_write_REG_CH2_REAL_DUTYCYCLE(void *a);
bool app_write_REG_CH3_REAL_DUTYCYCLE(void *a);
bool app_write_REG_CH0_MODE(void *a);
bool app_write_REG_CH1_MODE(void *a);
bool app_write_REG_CH2_MODE(void *a);
bool app_write_REG_CH3_MODE(void *a);
bool app_write_REG_TRG0_MASK(void *a);
bool app_write_REG_TRG1_MASK(void *a);
bool app_write_REG_TRG2_MASK(void *a);
bool app_write_REG_TRG3_MASK(void *a);
bool app_write_REG_START_PWM(void *a);
bool app_write_REG_STOP_PWM(void *a);
bool app_write_REG_CH_ENABLE_SINGLE(void *a);
bool app_write_REG_RESERVED1(void *a);
bool app_write_REG_TRG0_MODE(void *a);
bool app_write_REG_TRG1_MODE(void *a);
bool app_write_REG_TRG2_MODE(void *a);
bool app_write_REG_TRG3_MODE(void *a);
bool app_write_REG_CH_CONFEN(void *a);
bool app_write_REG_CH_ENABLE(void *a);
bool app_write_REG_TRGALL_MODE(void *a);
bool app_write_REG_TRIG_STATE(void *a);
bool app_write_REG_CH_STATE(void *a);
bool app_write_REG_EXEC_STATE(void *a);
bool app_write_REG_EVNT_ENABLE(void *a);


#endif /* _APP_FUNCTIONS_H_ */