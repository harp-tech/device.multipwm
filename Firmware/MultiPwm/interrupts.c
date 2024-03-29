#include "cpu.h"
#include "hwbp_core_types.h"
#include "app_ios_and_regs.h"
#include "app_funcs.h"
#include "hwbp_core.h"

/************************************************************************/
/* Declare application registers                                        */
/************************************************************************/
extern AppRegs app_regs;

/************************************************************************/
/* Interrupts from Timers                                               */
/************************************************************************/
// ISR(TCC0_OVF_vect, ISR_NAKED)
// ISR(TCD0_OVF_vect, ISR_NAKED)
// ISR(TCE0_OVF_vect, ISR_NAKED)
// ISR(TCF0_OVF_vect, ISR_NAKED)
// 
// ISR(TCC0_CCA_vect, ISR_NAKED)
// ISR(TCD0_CCA_vect, ISR_NAKED)
// ISR(TCE0_CCA_vect, ISR_NAKED)
// ISR(TCF0_CCA_vect, ISR_NAKED)
// 
// ISR(TCD1_OVF_vect, ISR_NAKED)
// 
// ISR(TCD1_CCA_vect, ISR_NAKED)

/************************************************************************/ 
/* TRIG_IN0                                                             */
/************************************************************************/
ISR(PORTF_INT0_vect, ISR_NAKED)
{
	reti();
}

/************************************************************************/ 
/* TRIG_IN1                                                             */
/************************************************************************/
ISR(PORTF_INT1_vect, ISR_NAKED)
{
	reti();
}

/************************************************************************/ 
/* TRIG_IN2                                                             */
/************************************************************************/
ISR(PORTH_INT0_vect, ISR_NAKED)
{
	reti();
}

/************************************************************************/ 
/* TRIG_IN3                                                             */
/************************************************************************/
ISR(PORTK_INT0_vect, ISR_NAKED)
{
	reti();
}

/************************************************************************/ 
/* TRIG_ALL                                                             */
/************************************************************************/
ISR(PORTQ_INT0_vect, ISR_NAKED)
{
	reti();
}

