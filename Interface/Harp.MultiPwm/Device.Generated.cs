using Bonsai;
using Bonsai.Harp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Xml.Serialization;

namespace Harp.MultiPwm
{
    /// <summary>
    /// Generates events and processes commands for the MultiPwm device connected
    /// at the specified serial port.
    /// </summary>
    [Combinator(MethodName = nameof(Generate))]
    [WorkflowElementCategory(ElementCategory.Source)]
    [Description("Generates events and processes commands for the MultiPwm device.")]
    public partial class Device : Bonsai.Harp.Device, INamedElement
    {
        /// <summary>
        /// Represents the unique identity class of the <see cref="MultiPwm"/> device.
        /// This field is constant.
        /// </summary>
        public const int WhoAmI = 1040;

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        public Device() : base(WhoAmI) { }

        string INamedElement.Name => nameof(MultiPwm);

        /// <summary>
        /// Gets a read-only mapping from address to register type.
        /// </summary>
        public static new IReadOnlyDictionary<int, Type> RegisterMap { get; } = new Dictionary<int, Type>
            (Bonsai.Harp.Device.RegisterMap.ToDictionary(entry => entry.Key, entry => entry.Value))
        {
            { 32, typeof(PwmChannel0Frequency) },
            { 33, typeof(PwmChannel1Frequency) },
            { 34, typeof(PwmChannel2Frequency) },
            { 35, typeof(PwmChannel3Frequency) },
            { 36, typeof(PwmChannel0DutyCycle) },
            { 37, typeof(PwmChannel1DutyCycle) },
            { 38, typeof(PwmChannel2DutyCycle) },
            { 39, typeof(PwmChannel3DutyCycle) },
            { 40, typeof(PwmChannel0NumPulses) },
            { 41, typeof(PwmChannel1NumPulses) },
            { 42, typeof(PwmChannel2NumPulses) },
            { 43, typeof(PwmChannel3NumPulses) },
            { 44, typeof(PwmChannel0RealFrequency) },
            { 45, typeof(PwmChannel1RealFrequency) },
            { 46, typeof(PwmChannel2RealFrequency) },
            { 47, typeof(PwmChannel3RealFrequency) },
            { 48, typeof(PwmChannel0RealDutyCycle) },
            { 49, typeof(PwmChannel1RealDutyCycle) },
            { 50, typeof(PwmChannel2RealDutyCycle) },
            { 51, typeof(PwmChannel3RealDutyCycle) },
            { 52, typeof(PwmChannel0PlaybackMode) },
            { 53, typeof(PwmChannel1PlaybackMode) },
            { 54, typeof(PwmChannel2PlaybackMode) },
            { 55, typeof(PwmChannel3PlaybackMode) },
            { 56, typeof(Trigger0Targets) },
            { 57, typeof(Trigger1Targets) },
            { 58, typeof(Trigger2Targets) },
            { 59, typeof(Trigger3Targets) },
            { 60, typeof(StartSoftwareTrigger) },
            { 61, typeof(StopSoftwareTrigger) },
            { 62, typeof(ArmPwmChannels) },
            { 64, typeof(Trigger0Mode) },
            { 65, typeof(Trigger1Mode) },
            { 66, typeof(Trigger2Mode) },
            { 67, typeof(Trigger3Mode) },
            { 68, typeof(RequestEnable) },
            { 69, typeof(EnablePwmChannels) },
            { 70, typeof(TriggerAllMode) },
            { 71, typeof(TriggerChannelState) },
            { 72, typeof(PwmChannelState) },
            { 73, typeof(PwmExecutionState) },
            { 74, typeof(EnableEvents) }
        };
    }

    /// <summary>
    /// Represents an operator that groups the sequence of <see cref="MultiPwm"/>" messages by register type.
    /// </summary>
    [Description("Groups the sequence of MultiPwm messages by register type.")]
    public partial class GroupByRegister : Combinator<HarpMessage, IGroupedObservable<Type, HarpMessage>>
    {
        /// <summary>
        /// Groups an observable sequence of <see cref="MultiPwm"/> messages
        /// by register type.
        /// </summary>
        /// <param name="source">The sequence of Harp device messages.</param>
        /// <returns>
        /// A sequence of observable groups, each of which corresponds to a unique
        /// <see cref="MultiPwm"/> register.
        /// </returns>
        public override IObservable<IGroupedObservable<Type, HarpMessage>> Process(IObservable<HarpMessage> source)
        {
            return source.GroupBy(message => Device.RegisterMap[message.Address]);
        }
    }

    /// <summary>
    /// Represents an operator that filters register-specific messages
    /// reported by the <see cref="MultiPwm"/> device.
    /// </summary>
    /// <seealso cref="PwmChannel0Frequency"/>
    /// <seealso cref="PwmChannel1Frequency"/>
    /// <seealso cref="PwmChannel2Frequency"/>
    /// <seealso cref="PwmChannel3Frequency"/>
    /// <seealso cref="PwmChannel0DutyCycle"/>
    /// <seealso cref="PwmChannel1DutyCycle"/>
    /// <seealso cref="PwmChannel2DutyCycle"/>
    /// <seealso cref="PwmChannel3DutyCycle"/>
    /// <seealso cref="PwmChannel0NumPulses"/>
    /// <seealso cref="PwmChannel1NumPulses"/>
    /// <seealso cref="PwmChannel2NumPulses"/>
    /// <seealso cref="PwmChannel3NumPulses"/>
    /// <seealso cref="PwmChannel0RealFrequency"/>
    /// <seealso cref="PwmChannel1RealFrequency"/>
    /// <seealso cref="PwmChannel2RealFrequency"/>
    /// <seealso cref="PwmChannel3RealFrequency"/>
    /// <seealso cref="PwmChannel0RealDutyCycle"/>
    /// <seealso cref="PwmChannel1RealDutyCycle"/>
    /// <seealso cref="PwmChannel2RealDutyCycle"/>
    /// <seealso cref="PwmChannel3RealDutyCycle"/>
    /// <seealso cref="PwmChannel0PlaybackMode"/>
    /// <seealso cref="PwmChannel1PlaybackMode"/>
    /// <seealso cref="PwmChannel2PlaybackMode"/>
    /// <seealso cref="PwmChannel3PlaybackMode"/>
    /// <seealso cref="Trigger0Targets"/>
    /// <seealso cref="Trigger1Targets"/>
    /// <seealso cref="Trigger2Targets"/>
    /// <seealso cref="Trigger3Targets"/>
    /// <seealso cref="StartSoftwareTrigger"/>
    /// <seealso cref="StopSoftwareTrigger"/>
    /// <seealso cref="ArmPwmChannels"/>
    /// <seealso cref="Trigger0Mode"/>
    /// <seealso cref="Trigger1Mode"/>
    /// <seealso cref="Trigger2Mode"/>
    /// <seealso cref="Trigger3Mode"/>
    /// <seealso cref="RequestEnable"/>
    /// <seealso cref="EnablePwmChannels"/>
    /// <seealso cref="TriggerAllMode"/>
    /// <seealso cref="TriggerChannelState"/>
    /// <seealso cref="PwmChannelState"/>
    /// <seealso cref="PwmExecutionState"/>
    /// <seealso cref="EnableEvents"/>
    [XmlInclude(typeof(PwmChannel0Frequency))]
    [XmlInclude(typeof(PwmChannel1Frequency))]
    [XmlInclude(typeof(PwmChannel2Frequency))]
    [XmlInclude(typeof(PwmChannel3Frequency))]
    [XmlInclude(typeof(PwmChannel0DutyCycle))]
    [XmlInclude(typeof(PwmChannel1DutyCycle))]
    [XmlInclude(typeof(PwmChannel2DutyCycle))]
    [XmlInclude(typeof(PwmChannel3DutyCycle))]
    [XmlInclude(typeof(PwmChannel0NumPulses))]
    [XmlInclude(typeof(PwmChannel1NumPulses))]
    [XmlInclude(typeof(PwmChannel2NumPulses))]
    [XmlInclude(typeof(PwmChannel3NumPulses))]
    [XmlInclude(typeof(PwmChannel0RealFrequency))]
    [XmlInclude(typeof(PwmChannel1RealFrequency))]
    [XmlInclude(typeof(PwmChannel2RealFrequency))]
    [XmlInclude(typeof(PwmChannel3RealFrequency))]
    [XmlInclude(typeof(PwmChannel0RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel1RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel2RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel3RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel0PlaybackMode))]
    [XmlInclude(typeof(PwmChannel1PlaybackMode))]
    [XmlInclude(typeof(PwmChannel2PlaybackMode))]
    [XmlInclude(typeof(PwmChannel3PlaybackMode))]
    [XmlInclude(typeof(Trigger0Targets))]
    [XmlInclude(typeof(Trigger1Targets))]
    [XmlInclude(typeof(Trigger2Targets))]
    [XmlInclude(typeof(Trigger3Targets))]
    [XmlInclude(typeof(StartSoftwareTrigger))]
    [XmlInclude(typeof(StopSoftwareTrigger))]
    [XmlInclude(typeof(ArmPwmChannels))]
    [XmlInclude(typeof(Trigger0Mode))]
    [XmlInclude(typeof(Trigger1Mode))]
    [XmlInclude(typeof(Trigger2Mode))]
    [XmlInclude(typeof(Trigger3Mode))]
    [XmlInclude(typeof(RequestEnable))]
    [XmlInclude(typeof(EnablePwmChannels))]
    [XmlInclude(typeof(TriggerAllMode))]
    [XmlInclude(typeof(TriggerChannelState))]
    [XmlInclude(typeof(PwmChannelState))]
    [XmlInclude(typeof(PwmExecutionState))]
    [XmlInclude(typeof(EnableEvents))]
    [Description("Filters register-specific messages reported by the MultiPwm device.")]
    public class FilterMessage : FilterMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterMessage"/> class.
        /// </summary>
        public FilterMessage()
        {
            Register = new PwmChannel0Frequency();
        }

        string INamedElement.Name
        {
            get => $"{nameof(MultiPwm)}.{GetElementDisplayName(Register)}";
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects specific messages
    /// reported by the MultiPwm device.
    /// </summary>
    /// <seealso cref="PwmChannel0Frequency"/>
    /// <seealso cref="PwmChannel1Frequency"/>
    /// <seealso cref="PwmChannel2Frequency"/>
    /// <seealso cref="PwmChannel3Frequency"/>
    /// <seealso cref="PwmChannel0DutyCycle"/>
    /// <seealso cref="PwmChannel1DutyCycle"/>
    /// <seealso cref="PwmChannel2DutyCycle"/>
    /// <seealso cref="PwmChannel3DutyCycle"/>
    /// <seealso cref="PwmChannel0NumPulses"/>
    /// <seealso cref="PwmChannel1NumPulses"/>
    /// <seealso cref="PwmChannel2NumPulses"/>
    /// <seealso cref="PwmChannel3NumPulses"/>
    /// <seealso cref="PwmChannel0RealFrequency"/>
    /// <seealso cref="PwmChannel1RealFrequency"/>
    /// <seealso cref="PwmChannel2RealFrequency"/>
    /// <seealso cref="PwmChannel3RealFrequency"/>
    /// <seealso cref="PwmChannel0RealDutyCycle"/>
    /// <seealso cref="PwmChannel1RealDutyCycle"/>
    /// <seealso cref="PwmChannel2RealDutyCycle"/>
    /// <seealso cref="PwmChannel3RealDutyCycle"/>
    /// <seealso cref="PwmChannel0PlaybackMode"/>
    /// <seealso cref="PwmChannel1PlaybackMode"/>
    /// <seealso cref="PwmChannel2PlaybackMode"/>
    /// <seealso cref="PwmChannel3PlaybackMode"/>
    /// <seealso cref="Trigger0Targets"/>
    /// <seealso cref="Trigger1Targets"/>
    /// <seealso cref="Trigger2Targets"/>
    /// <seealso cref="Trigger3Targets"/>
    /// <seealso cref="StartSoftwareTrigger"/>
    /// <seealso cref="StopSoftwareTrigger"/>
    /// <seealso cref="ArmPwmChannels"/>
    /// <seealso cref="Trigger0Mode"/>
    /// <seealso cref="Trigger1Mode"/>
    /// <seealso cref="Trigger2Mode"/>
    /// <seealso cref="Trigger3Mode"/>
    /// <seealso cref="RequestEnable"/>
    /// <seealso cref="EnablePwmChannels"/>
    /// <seealso cref="TriggerAllMode"/>
    /// <seealso cref="TriggerChannelState"/>
    /// <seealso cref="PwmChannelState"/>
    /// <seealso cref="PwmExecutionState"/>
    /// <seealso cref="EnableEvents"/>
    [XmlInclude(typeof(PwmChannel0Frequency))]
    [XmlInclude(typeof(PwmChannel1Frequency))]
    [XmlInclude(typeof(PwmChannel2Frequency))]
    [XmlInclude(typeof(PwmChannel3Frequency))]
    [XmlInclude(typeof(PwmChannel0DutyCycle))]
    [XmlInclude(typeof(PwmChannel1DutyCycle))]
    [XmlInclude(typeof(PwmChannel2DutyCycle))]
    [XmlInclude(typeof(PwmChannel3DutyCycle))]
    [XmlInclude(typeof(PwmChannel0NumPulses))]
    [XmlInclude(typeof(PwmChannel1NumPulses))]
    [XmlInclude(typeof(PwmChannel2NumPulses))]
    [XmlInclude(typeof(PwmChannel3NumPulses))]
    [XmlInclude(typeof(PwmChannel0RealFrequency))]
    [XmlInclude(typeof(PwmChannel1RealFrequency))]
    [XmlInclude(typeof(PwmChannel2RealFrequency))]
    [XmlInclude(typeof(PwmChannel3RealFrequency))]
    [XmlInclude(typeof(PwmChannel0RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel1RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel2RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel3RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel0PlaybackMode))]
    [XmlInclude(typeof(PwmChannel1PlaybackMode))]
    [XmlInclude(typeof(PwmChannel2PlaybackMode))]
    [XmlInclude(typeof(PwmChannel3PlaybackMode))]
    [XmlInclude(typeof(Trigger0Targets))]
    [XmlInclude(typeof(Trigger1Targets))]
    [XmlInclude(typeof(Trigger2Targets))]
    [XmlInclude(typeof(Trigger3Targets))]
    [XmlInclude(typeof(StartSoftwareTrigger))]
    [XmlInclude(typeof(StopSoftwareTrigger))]
    [XmlInclude(typeof(ArmPwmChannels))]
    [XmlInclude(typeof(Trigger0Mode))]
    [XmlInclude(typeof(Trigger1Mode))]
    [XmlInclude(typeof(Trigger2Mode))]
    [XmlInclude(typeof(Trigger3Mode))]
    [XmlInclude(typeof(RequestEnable))]
    [XmlInclude(typeof(EnablePwmChannels))]
    [XmlInclude(typeof(TriggerAllMode))]
    [XmlInclude(typeof(TriggerChannelState))]
    [XmlInclude(typeof(PwmChannelState))]
    [XmlInclude(typeof(PwmExecutionState))]
    [XmlInclude(typeof(EnableEvents))]
    [XmlInclude(typeof(TimestampedPwmChannel0Frequency))]
    [XmlInclude(typeof(TimestampedPwmChannel1Frequency))]
    [XmlInclude(typeof(TimestampedPwmChannel2Frequency))]
    [XmlInclude(typeof(TimestampedPwmChannel3Frequency))]
    [XmlInclude(typeof(TimestampedPwmChannel0DutyCycle))]
    [XmlInclude(typeof(TimestampedPwmChannel1DutyCycle))]
    [XmlInclude(typeof(TimestampedPwmChannel2DutyCycle))]
    [XmlInclude(typeof(TimestampedPwmChannel3DutyCycle))]
    [XmlInclude(typeof(TimestampedPwmChannel0NumPulses))]
    [XmlInclude(typeof(TimestampedPwmChannel1NumPulses))]
    [XmlInclude(typeof(TimestampedPwmChannel2NumPulses))]
    [XmlInclude(typeof(TimestampedPwmChannel3NumPulses))]
    [XmlInclude(typeof(TimestampedPwmChannel0RealFrequency))]
    [XmlInclude(typeof(TimestampedPwmChannel1RealFrequency))]
    [XmlInclude(typeof(TimestampedPwmChannel2RealFrequency))]
    [XmlInclude(typeof(TimestampedPwmChannel3RealFrequency))]
    [XmlInclude(typeof(TimestampedPwmChannel0RealDutyCycle))]
    [XmlInclude(typeof(TimestampedPwmChannel1RealDutyCycle))]
    [XmlInclude(typeof(TimestampedPwmChannel2RealDutyCycle))]
    [XmlInclude(typeof(TimestampedPwmChannel3RealDutyCycle))]
    [XmlInclude(typeof(TimestampedPwmChannel0PlaybackMode))]
    [XmlInclude(typeof(TimestampedPwmChannel1PlaybackMode))]
    [XmlInclude(typeof(TimestampedPwmChannel2PlaybackMode))]
    [XmlInclude(typeof(TimestampedPwmChannel3PlaybackMode))]
    [XmlInclude(typeof(TimestampedTrigger0Targets))]
    [XmlInclude(typeof(TimestampedTrigger1Targets))]
    [XmlInclude(typeof(TimestampedTrigger2Targets))]
    [XmlInclude(typeof(TimestampedTrigger3Targets))]
    [XmlInclude(typeof(TimestampedStartSoftwareTrigger))]
    [XmlInclude(typeof(TimestampedStopSoftwareTrigger))]
    [XmlInclude(typeof(TimestampedArmPwmChannels))]
    [XmlInclude(typeof(TimestampedTrigger0Mode))]
    [XmlInclude(typeof(TimestampedTrigger1Mode))]
    [XmlInclude(typeof(TimestampedTrigger2Mode))]
    [XmlInclude(typeof(TimestampedTrigger3Mode))]
    [XmlInclude(typeof(TimestampedRequestEnable))]
    [XmlInclude(typeof(TimestampedEnablePwmChannels))]
    [XmlInclude(typeof(TimestampedTriggerAllMode))]
    [XmlInclude(typeof(TimestampedTriggerChannelState))]
    [XmlInclude(typeof(TimestampedPwmChannelState))]
    [XmlInclude(typeof(TimestampedPwmExecutionState))]
    [XmlInclude(typeof(TimestampedEnableEvents))]
    [Description("Filters and selects specific messages reported by the MultiPwm device.")]
    public partial class Parse : ParseBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parse"/> class.
        /// </summary>
        public Parse()
        {
            Register = new PwmChannel0Frequency();
        }

        string INamedElement.Name => $"{nameof(MultiPwm)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents an operator which formats a sequence of values as specific
    /// MultiPwm register messages.
    /// </summary>
    /// <seealso cref="PwmChannel0Frequency"/>
    /// <seealso cref="PwmChannel1Frequency"/>
    /// <seealso cref="PwmChannel2Frequency"/>
    /// <seealso cref="PwmChannel3Frequency"/>
    /// <seealso cref="PwmChannel0DutyCycle"/>
    /// <seealso cref="PwmChannel1DutyCycle"/>
    /// <seealso cref="PwmChannel2DutyCycle"/>
    /// <seealso cref="PwmChannel3DutyCycle"/>
    /// <seealso cref="PwmChannel0NumPulses"/>
    /// <seealso cref="PwmChannel1NumPulses"/>
    /// <seealso cref="PwmChannel2NumPulses"/>
    /// <seealso cref="PwmChannel3NumPulses"/>
    /// <seealso cref="PwmChannel0RealFrequency"/>
    /// <seealso cref="PwmChannel1RealFrequency"/>
    /// <seealso cref="PwmChannel2RealFrequency"/>
    /// <seealso cref="PwmChannel3RealFrequency"/>
    /// <seealso cref="PwmChannel0RealDutyCycle"/>
    /// <seealso cref="PwmChannel1RealDutyCycle"/>
    /// <seealso cref="PwmChannel2RealDutyCycle"/>
    /// <seealso cref="PwmChannel3RealDutyCycle"/>
    /// <seealso cref="PwmChannel0PlaybackMode"/>
    /// <seealso cref="PwmChannel1PlaybackMode"/>
    /// <seealso cref="PwmChannel2PlaybackMode"/>
    /// <seealso cref="PwmChannel3PlaybackMode"/>
    /// <seealso cref="Trigger0Targets"/>
    /// <seealso cref="Trigger1Targets"/>
    /// <seealso cref="Trigger2Targets"/>
    /// <seealso cref="Trigger3Targets"/>
    /// <seealso cref="StartSoftwareTrigger"/>
    /// <seealso cref="StopSoftwareTrigger"/>
    /// <seealso cref="ArmPwmChannels"/>
    /// <seealso cref="Trigger0Mode"/>
    /// <seealso cref="Trigger1Mode"/>
    /// <seealso cref="Trigger2Mode"/>
    /// <seealso cref="Trigger3Mode"/>
    /// <seealso cref="RequestEnable"/>
    /// <seealso cref="EnablePwmChannels"/>
    /// <seealso cref="TriggerAllMode"/>
    /// <seealso cref="TriggerChannelState"/>
    /// <seealso cref="PwmChannelState"/>
    /// <seealso cref="PwmExecutionState"/>
    /// <seealso cref="EnableEvents"/>
    [XmlInclude(typeof(PwmChannel0Frequency))]
    [XmlInclude(typeof(PwmChannel1Frequency))]
    [XmlInclude(typeof(PwmChannel2Frequency))]
    [XmlInclude(typeof(PwmChannel3Frequency))]
    [XmlInclude(typeof(PwmChannel0DutyCycle))]
    [XmlInclude(typeof(PwmChannel1DutyCycle))]
    [XmlInclude(typeof(PwmChannel2DutyCycle))]
    [XmlInclude(typeof(PwmChannel3DutyCycle))]
    [XmlInclude(typeof(PwmChannel0NumPulses))]
    [XmlInclude(typeof(PwmChannel1NumPulses))]
    [XmlInclude(typeof(PwmChannel2NumPulses))]
    [XmlInclude(typeof(PwmChannel3NumPulses))]
    [XmlInclude(typeof(PwmChannel0RealFrequency))]
    [XmlInclude(typeof(PwmChannel1RealFrequency))]
    [XmlInclude(typeof(PwmChannel2RealFrequency))]
    [XmlInclude(typeof(PwmChannel3RealFrequency))]
    [XmlInclude(typeof(PwmChannel0RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel1RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel2RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel3RealDutyCycle))]
    [XmlInclude(typeof(PwmChannel0PlaybackMode))]
    [XmlInclude(typeof(PwmChannel1PlaybackMode))]
    [XmlInclude(typeof(PwmChannel2PlaybackMode))]
    [XmlInclude(typeof(PwmChannel3PlaybackMode))]
    [XmlInclude(typeof(Trigger0Targets))]
    [XmlInclude(typeof(Trigger1Targets))]
    [XmlInclude(typeof(Trigger2Targets))]
    [XmlInclude(typeof(Trigger3Targets))]
    [XmlInclude(typeof(StartSoftwareTrigger))]
    [XmlInclude(typeof(StopSoftwareTrigger))]
    [XmlInclude(typeof(ArmPwmChannels))]
    [XmlInclude(typeof(Trigger0Mode))]
    [XmlInclude(typeof(Trigger1Mode))]
    [XmlInclude(typeof(Trigger2Mode))]
    [XmlInclude(typeof(Trigger3Mode))]
    [XmlInclude(typeof(RequestEnable))]
    [XmlInclude(typeof(EnablePwmChannels))]
    [XmlInclude(typeof(TriggerAllMode))]
    [XmlInclude(typeof(TriggerChannelState))]
    [XmlInclude(typeof(PwmChannelState))]
    [XmlInclude(typeof(PwmExecutionState))]
    [XmlInclude(typeof(EnableEvents))]
    [Description("Formats a sequence of values as specific MultiPwm register messages.")]
    public partial class Format : FormatBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Format"/> class.
        /// </summary>
        public Format()
        {
            Register = new PwmChannel0Frequency();
        }

        string INamedElement.Name => $"{nameof(MultiPwm)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents a register that frequency (Hz) of PWM pulses in channel 0.
    /// </summary>
    [Description("Frequency (Hz) of PWM pulses in channel 0.")]
    public partial class PwmChannel0Frequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0Frequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 32;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel0Frequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel0Frequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel0Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel0Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel0Frequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0Frequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel0Frequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0Frequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel0Frequency register.
    /// </summary>
    /// <seealso cref="PwmChannel0Frequency"/>
    [Description("Filters and selects timestamped messages from the PwmChannel0Frequency register.")]
    public partial class TimestampedPwmChannel0Frequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0Frequency"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel0Frequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel0Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel0Frequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that frequency (Hz) of PWM pulses in channel 1.
    /// </summary>
    [Description("Frequency (Hz) of PWM pulses in channel 1.")]
    public partial class PwmChannel1Frequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1Frequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 33;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel1Frequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel1Frequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel1Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel1Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel1Frequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1Frequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel1Frequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1Frequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel1Frequency register.
    /// </summary>
    /// <seealso cref="PwmChannel1Frequency"/>
    [Description("Filters and selects timestamped messages from the PwmChannel1Frequency register.")]
    public partial class TimestampedPwmChannel1Frequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1Frequency"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel1Frequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel1Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel1Frequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that frequency (Hz) of PWM pulses in channel 2.
    /// </summary>
    [Description("Frequency (Hz) of PWM pulses in channel 2.")]
    public partial class PwmChannel2Frequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2Frequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 34;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel2Frequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel2Frequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel2Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel2Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel2Frequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2Frequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel2Frequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2Frequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel2Frequency register.
    /// </summary>
    /// <seealso cref="PwmChannel2Frequency"/>
    [Description("Filters and selects timestamped messages from the PwmChannel2Frequency register.")]
    public partial class TimestampedPwmChannel2Frequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2Frequency"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel2Frequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel2Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel2Frequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that frequency (Hz) of PWM pulses in channel 3.
    /// </summary>
    [Description("Frequency (Hz) of PWM pulses in channel 3.")]
    public partial class PwmChannel3Frequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3Frequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 35;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel3Frequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel3Frequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel3Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel3Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel3Frequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3Frequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel3Frequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3Frequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel3Frequency register.
    /// </summary>
    /// <seealso cref="PwmChannel3Frequency"/>
    [Description("Filters and selects timestamped messages from the PwmChannel3Frequency register.")]
    public partial class TimestampedPwmChannel3Frequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3Frequency"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel3Frequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel3Frequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel3Frequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that duty cycle (0-100) of PWM pulses in channel 0.
    /// </summary>
    [Description("Duty cycle (0-100) of PWM pulses in channel 0.")]
    public partial class PwmChannel0DutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = 36;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel0DutyCycle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel0DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel0DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel0DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel0DutyCycle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0DutyCycle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel0DutyCycle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0DutyCycle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel0DutyCycle register.
    /// </summary>
    /// <seealso cref="PwmChannel0DutyCycle"/>
    [Description("Filters and selects timestamped messages from the PwmChannel0DutyCycle register.")]
    public partial class TimestampedPwmChannel0DutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel0DutyCycle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel0DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel0DutyCycle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that duty cycle (0-100) of PWM pulses in channel 1.
    /// </summary>
    [Description("Duty cycle (0-100) of PWM pulses in channel 1.")]
    public partial class PwmChannel1DutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = 37;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel1DutyCycle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel1DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel1DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel1DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel1DutyCycle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1DutyCycle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel1DutyCycle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1DutyCycle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel1DutyCycle register.
    /// </summary>
    /// <seealso cref="PwmChannel1DutyCycle"/>
    [Description("Filters and selects timestamped messages from the PwmChannel1DutyCycle register.")]
    public partial class TimestampedPwmChannel1DutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel1DutyCycle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel1DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel1DutyCycle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that duty cycle (0-100) of PWM pulses in channel 2.
    /// </summary>
    [Description("Duty cycle (0-100) of PWM pulses in channel 2.")]
    public partial class PwmChannel2DutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = 38;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel2DutyCycle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel2DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel2DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel2DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel2DutyCycle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2DutyCycle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel2DutyCycle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2DutyCycle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel2DutyCycle register.
    /// </summary>
    /// <seealso cref="PwmChannel2DutyCycle"/>
    [Description("Filters and selects timestamped messages from the PwmChannel2DutyCycle register.")]
    public partial class TimestampedPwmChannel2DutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel2DutyCycle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel2DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel2DutyCycle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that duty cycle (0-100) of PWM pulses in channel 3.
    /// </summary>
    [Description("Duty cycle (0-100) of PWM pulses in channel 3.")]
    public partial class PwmChannel3DutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = 39;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel3DutyCycle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel3DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel3DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel3DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel3DutyCycle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3DutyCycle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel3DutyCycle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3DutyCycle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel3DutyCycle register.
    /// </summary>
    /// <seealso cref="PwmChannel3DutyCycle"/>
    [Description("Filters and selects timestamped messages from the PwmChannel3DutyCycle register.")]
    public partial class TimestampedPwmChannel3DutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3DutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel3DutyCycle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel3DutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel3DutyCycle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that total number of pulses to be generated in channel 0.
    /// </summary>
    [Description("Total number of pulses to be generated in channel 0.")]
    public partial class PwmChannel0NumPulses
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0NumPulses"/> register. This field is constant.
        /// </summary>
        public const int Address = 40;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel0NumPulses"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U32;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel0NumPulses"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel0NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static uint GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt32();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel0NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt32();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel0NumPulses"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0NumPulses"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel0NumPulses"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0NumPulses"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel0NumPulses register.
    /// </summary>
    /// <seealso cref="PwmChannel0NumPulses"/>
    [Description("Filters and selects timestamped messages from the PwmChannel0NumPulses register.")]
    public partial class TimestampedPwmChannel0NumPulses
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0NumPulses"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel0NumPulses.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel0NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetPayload(HarpMessage message)
        {
            return PwmChannel0NumPulses.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that total number of pulses to be generated in channel 1.
    /// </summary>
    [Description("Total number of pulses to be generated in channel 1.")]
    public partial class PwmChannel1NumPulses
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1NumPulses"/> register. This field is constant.
        /// </summary>
        public const int Address = 41;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel1NumPulses"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U32;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel1NumPulses"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel1NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static uint GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt32();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel1NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt32();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel1NumPulses"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1NumPulses"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel1NumPulses"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1NumPulses"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel1NumPulses register.
    /// </summary>
    /// <seealso cref="PwmChannel1NumPulses"/>
    [Description("Filters and selects timestamped messages from the PwmChannel1NumPulses register.")]
    public partial class TimestampedPwmChannel1NumPulses
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1NumPulses"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel1NumPulses.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel1NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetPayload(HarpMessage message)
        {
            return PwmChannel1NumPulses.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that total number of pulses to be generated in channel 2.
    /// </summary>
    [Description("Total number of pulses to be generated in channel 2.")]
    public partial class PwmChannel2NumPulses
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2NumPulses"/> register. This field is constant.
        /// </summary>
        public const int Address = 42;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel2NumPulses"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U32;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel2NumPulses"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel2NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static uint GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt32();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel2NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt32();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel2NumPulses"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2NumPulses"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel2NumPulses"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2NumPulses"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel2NumPulses register.
    /// </summary>
    /// <seealso cref="PwmChannel2NumPulses"/>
    [Description("Filters and selects timestamped messages from the PwmChannel2NumPulses register.")]
    public partial class TimestampedPwmChannel2NumPulses
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2NumPulses"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel2NumPulses.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel2NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetPayload(HarpMessage message)
        {
            return PwmChannel2NumPulses.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that total number of pulses to be generated in channel 3.
    /// </summary>
    [Description("Total number of pulses to be generated in channel 3.")]
    public partial class PwmChannel3NumPulses
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3NumPulses"/> register. This field is constant.
        /// </summary>
        public const int Address = 43;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel3NumPulses"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U32;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel3NumPulses"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel3NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static uint GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt32();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel3NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt32();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel3NumPulses"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3NumPulses"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel3NumPulses"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3NumPulses"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel3NumPulses register.
    /// </summary>
    /// <seealso cref="PwmChannel3NumPulses"/>
    [Description("Filters and selects timestamped messages from the PwmChannel3NumPulses register.")]
    public partial class TimestampedPwmChannel3NumPulses
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3NumPulses"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel3NumPulses.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel3NumPulses"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetPayload(HarpMessage message)
        {
            return PwmChannel3NumPulses.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that real frequency (Hz) of PWM pulses in channel 0.
    /// </summary>
    [Description("Real frequency (Hz) of PWM pulses in channel 0.")]
    public partial class PwmChannel0RealFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 44;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel0RealFrequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel0RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel0RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel0RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel0RealFrequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0RealFrequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel0RealFrequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0RealFrequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel0RealFrequency register.
    /// </summary>
    /// <seealso cref="PwmChannel0RealFrequency"/>
    [Description("Filters and selects timestamped messages from the PwmChannel0RealFrequency register.")]
    public partial class TimestampedPwmChannel0RealFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel0RealFrequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel0RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel0RealFrequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that real frequency (Hz) of PWM pulses in channel 1.
    /// </summary>
    [Description("Real frequency (Hz) of PWM pulses in channel 1.")]
    public partial class PwmChannel1RealFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 45;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel1RealFrequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel1RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel1RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel1RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel1RealFrequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1RealFrequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel1RealFrequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1RealFrequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel1RealFrequency register.
    /// </summary>
    /// <seealso cref="PwmChannel1RealFrequency"/>
    [Description("Filters and selects timestamped messages from the PwmChannel1RealFrequency register.")]
    public partial class TimestampedPwmChannel1RealFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel1RealFrequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel1RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel1RealFrequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that real frequency (Hz) of PWM pulses in channel 2.
    /// </summary>
    [Description("Real frequency (Hz) of PWM pulses in channel 2.")]
    public partial class PwmChannel2RealFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 46;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel2RealFrequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel2RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel2RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel2RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel2RealFrequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2RealFrequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel2RealFrequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2RealFrequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel2RealFrequency register.
    /// </summary>
    /// <seealso cref="PwmChannel2RealFrequency"/>
    [Description("Filters and selects timestamped messages from the PwmChannel2RealFrequency register.")]
    public partial class TimestampedPwmChannel2RealFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel2RealFrequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel2RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel2RealFrequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that real frequency (Hz) of PWM pulses in channel 3.
    /// </summary>
    [Description("Real frequency (Hz) of PWM pulses in channel 3.")]
    public partial class PwmChannel3RealFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = 47;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel3RealFrequency"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel3RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel3RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel3RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel3RealFrequency"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3RealFrequency"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel3RealFrequency"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3RealFrequency"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel3RealFrequency register.
    /// </summary>
    /// <seealso cref="PwmChannel3RealFrequency"/>
    [Description("Filters and selects timestamped messages from the PwmChannel3RealFrequency register.")]
    public partial class TimestampedPwmChannel3RealFrequency
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3RealFrequency"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel3RealFrequency.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel3RealFrequency"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel3RealFrequency.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that real duty cycle (0-100) of PWM pulses in channel 0.
    /// </summary>
    [Description("Real duty cycle (0-100) of PWM pulses in channel 0.")]
    public partial class PwmChannel0RealDutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = 48;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel0RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel0RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel0RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel0RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel0RealDutyCycle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0RealDutyCycle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel0RealDutyCycle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0RealDutyCycle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel0RealDutyCycle register.
    /// </summary>
    /// <seealso cref="PwmChannel0RealDutyCycle"/>
    [Description("Filters and selects timestamped messages from the PwmChannel0RealDutyCycle register.")]
    public partial class TimestampedPwmChannel0RealDutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel0RealDutyCycle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel0RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel0RealDutyCycle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that real duty cycle (0-100) of PWM pulses in channel 1.
    /// </summary>
    [Description("Real duty cycle (0-100) of PWM pulses in channel 1.")]
    public partial class PwmChannel1RealDutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = 49;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel1RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel1RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel1RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel1RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel1RealDutyCycle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1RealDutyCycle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel1RealDutyCycle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1RealDutyCycle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel1RealDutyCycle register.
    /// </summary>
    /// <seealso cref="PwmChannel1RealDutyCycle"/>
    [Description("Filters and selects timestamped messages from the PwmChannel1RealDutyCycle register.")]
    public partial class TimestampedPwmChannel1RealDutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel1RealDutyCycle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel1RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel1RealDutyCycle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that real duty cycle (0-100) of PWM pulses in channel 2.
    /// </summary>
    [Description("Real duty cycle (0-100) of PWM pulses in channel 2.")]
    public partial class PwmChannel2RealDutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = 50;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel2RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel2RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel2RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel2RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel2RealDutyCycle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2RealDutyCycle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel2RealDutyCycle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2RealDutyCycle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel2RealDutyCycle register.
    /// </summary>
    /// <seealso cref="PwmChannel2RealDutyCycle"/>
    [Description("Filters and selects timestamped messages from the PwmChannel2RealDutyCycle register.")]
    public partial class TimestampedPwmChannel2RealDutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel2RealDutyCycle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel2RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel2RealDutyCycle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that real duty cycle (0-100) of PWM pulses in channel 3.
    /// </summary>
    [Description("Real duty cycle (0-100) of PWM pulses in channel 3.")]
    public partial class PwmChannel3RealDutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = 51;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel3RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel3RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel3RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel3RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel3RealDutyCycle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3RealDutyCycle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel3RealDutyCycle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3RealDutyCycle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel3RealDutyCycle register.
    /// </summary>
    /// <seealso cref="PwmChannel3RealDutyCycle"/>
    [Description("Filters and selects timestamped messages from the PwmChannel3RealDutyCycle register.")]
    public partial class TimestampedPwmChannel3RealDutyCycle
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3RealDutyCycle"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel3RealDutyCycle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel3RealDutyCycle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return PwmChannel3RealDutyCycle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that playback mode of channel 0.
    /// </summary>
    [Description("Playback mode of channel 0.")]
    public partial class PwmChannel0PlaybackMode
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int Address = 52;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel0PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel0PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel0PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmPlaybackMode GetPayload(HarpMessage message)
        {
            return (PwmPlaybackMode)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel0PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmPlaybackMode> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmPlaybackMode)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel0PlaybackMode"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0PlaybackMode"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmPlaybackMode value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel0PlaybackMode"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel0PlaybackMode"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmPlaybackMode value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel0PlaybackMode register.
    /// </summary>
    /// <seealso cref="PwmChannel0PlaybackMode"/>
    [Description("Filters and selects timestamped messages from the PwmChannel0PlaybackMode register.")]
    public partial class TimestampedPwmChannel0PlaybackMode
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel0PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel0PlaybackMode.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel0PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmPlaybackMode> GetPayload(HarpMessage message)
        {
            return PwmChannel0PlaybackMode.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that playback mode of channel 1.
    /// </summary>
    [Description("Playback mode of channel 1.")]
    public partial class PwmChannel1PlaybackMode
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int Address = 53;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel1PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel1PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel1PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmPlaybackMode GetPayload(HarpMessage message)
        {
            return (PwmPlaybackMode)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel1PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmPlaybackMode> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmPlaybackMode)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel1PlaybackMode"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1PlaybackMode"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmPlaybackMode value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel1PlaybackMode"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel1PlaybackMode"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmPlaybackMode value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel1PlaybackMode register.
    /// </summary>
    /// <seealso cref="PwmChannel1PlaybackMode"/>
    [Description("Filters and selects timestamped messages from the PwmChannel1PlaybackMode register.")]
    public partial class TimestampedPwmChannel1PlaybackMode
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel1PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel1PlaybackMode.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel1PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmPlaybackMode> GetPayload(HarpMessage message)
        {
            return PwmChannel1PlaybackMode.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that playback mode of channel 2.
    /// </summary>
    [Description("Playback mode of channel 2.")]
    public partial class PwmChannel2PlaybackMode
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int Address = 54;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel2PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel2PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel2PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmPlaybackMode GetPayload(HarpMessage message)
        {
            return (PwmPlaybackMode)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel2PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmPlaybackMode> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmPlaybackMode)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel2PlaybackMode"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2PlaybackMode"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmPlaybackMode value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel2PlaybackMode"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel2PlaybackMode"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmPlaybackMode value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel2PlaybackMode register.
    /// </summary>
    /// <seealso cref="PwmChannel2PlaybackMode"/>
    [Description("Filters and selects timestamped messages from the PwmChannel2PlaybackMode register.")]
    public partial class TimestampedPwmChannel2PlaybackMode
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel2PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel2PlaybackMode.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel2PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmPlaybackMode> GetPayload(HarpMessage message)
        {
            return PwmChannel2PlaybackMode.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that playback mode of channel 3.
    /// </summary>
    [Description("Playback mode of channel 3.")]
    public partial class PwmChannel3PlaybackMode
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int Address = 55;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannel3PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannel3PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannel3PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmPlaybackMode GetPayload(HarpMessage message)
        {
            return (PwmPlaybackMode)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannel3PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmPlaybackMode> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmPlaybackMode)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannel3PlaybackMode"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3PlaybackMode"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmPlaybackMode value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannel3PlaybackMode"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannel3PlaybackMode"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmPlaybackMode value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannel3PlaybackMode register.
    /// </summary>
    /// <seealso cref="PwmChannel3PlaybackMode"/>
    [Description("Filters and selects timestamped messages from the PwmChannel3PlaybackMode register.")]
    public partial class TimestampedPwmChannel3PlaybackMode
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannel3PlaybackMode"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannel3PlaybackMode.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannel3PlaybackMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmPlaybackMode> GetPayload(HarpMessage message)
        {
            return PwmChannel3PlaybackMode.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that target channels that will start the PWM sequence if Trigger0 is activated.
    /// </summary>
    [Description("Target channels that will start the PWM sequence if Trigger0 is activated.")]
    public partial class Trigger0Targets
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger0Targets"/> register. This field is constant.
        /// </summary>
        public const int Address = 56;

        /// <summary>
        /// Represents the payload type of the <see cref="Trigger0Targets"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Trigger0Targets"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Trigger0Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmChannels GetPayload(HarpMessage message)
        {
            return (PwmChannels)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Trigger0Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmChannels)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Trigger0Targets"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger0Targets"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Trigger0Targets"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger0Targets"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Trigger0Targets register.
    /// </summary>
    /// <seealso cref="Trigger0Targets"/>
    [Description("Filters and selects timestamped messages from the Trigger0Targets register.")]
    public partial class TimestampedTrigger0Targets
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger0Targets"/> register. This field is constant.
        /// </summary>
        public const int Address = Trigger0Targets.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Trigger0Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetPayload(HarpMessage message)
        {
            return Trigger0Targets.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that target channels that will start the PWM sequence if Trigger1 is activated.
    /// </summary>
    [Description("Target channels that will start the PWM sequence if Trigger1 is activated.")]
    public partial class Trigger1Targets
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger1Targets"/> register. This field is constant.
        /// </summary>
        public const int Address = 57;

        /// <summary>
        /// Represents the payload type of the <see cref="Trigger1Targets"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Trigger1Targets"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Trigger1Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmChannels GetPayload(HarpMessage message)
        {
            return (PwmChannels)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Trigger1Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmChannels)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Trigger1Targets"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger1Targets"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Trigger1Targets"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger1Targets"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Trigger1Targets register.
    /// </summary>
    /// <seealso cref="Trigger1Targets"/>
    [Description("Filters and selects timestamped messages from the Trigger1Targets register.")]
    public partial class TimestampedTrigger1Targets
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger1Targets"/> register. This field is constant.
        /// </summary>
        public const int Address = Trigger1Targets.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Trigger1Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetPayload(HarpMessage message)
        {
            return Trigger1Targets.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that target channels that will start the PWM sequence if Trigger2 is activated.
    /// </summary>
    [Description("Target channels that will start the PWM sequence if Trigger2 is activated.")]
    public partial class Trigger2Targets
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger2Targets"/> register. This field is constant.
        /// </summary>
        public const int Address = 58;

        /// <summary>
        /// Represents the payload type of the <see cref="Trigger2Targets"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Trigger2Targets"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Trigger2Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmChannels GetPayload(HarpMessage message)
        {
            return (PwmChannels)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Trigger2Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmChannels)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Trigger2Targets"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger2Targets"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Trigger2Targets"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger2Targets"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Trigger2Targets register.
    /// </summary>
    /// <seealso cref="Trigger2Targets"/>
    [Description("Filters and selects timestamped messages from the Trigger2Targets register.")]
    public partial class TimestampedTrigger2Targets
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger2Targets"/> register. This field is constant.
        /// </summary>
        public const int Address = Trigger2Targets.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Trigger2Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetPayload(HarpMessage message)
        {
            return Trigger2Targets.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that target channels that will start the PWM sequence if Trigger3 is activated.
    /// </summary>
    [Description("Target channels that will start the PWM sequence if Trigger3 is activated.")]
    public partial class Trigger3Targets
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger3Targets"/> register. This field is constant.
        /// </summary>
        public const int Address = 59;

        /// <summary>
        /// Represents the payload type of the <see cref="Trigger3Targets"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Trigger3Targets"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Trigger3Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmChannels GetPayload(HarpMessage message)
        {
            return (PwmChannels)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Trigger3Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmChannels)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Trigger3Targets"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger3Targets"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Trigger3Targets"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger3Targets"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Trigger3Targets register.
    /// </summary>
    /// <seealso cref="Trigger3Targets"/>
    [Description("Filters and selects timestamped messages from the Trigger3Targets register.")]
    public partial class TimestampedTrigger3Targets
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger3Targets"/> register. This field is constant.
        /// </summary>
        public const int Address = Trigger3Targets.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Trigger3Targets"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetPayload(HarpMessage message)
        {
            return Trigger3Targets.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that emits a start software-trigger on the channels specified in the mask.
    /// </summary>
    [Description("Emits a start software-trigger on the channels specified in the mask.")]
    public partial class StartSoftwareTrigger
    {
        /// <summary>
        /// Represents the address of the <see cref="StartSoftwareTrigger"/> register. This field is constant.
        /// </summary>
        public const int Address = 60;

        /// <summary>
        /// Represents the payload type of the <see cref="StartSoftwareTrigger"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="StartSoftwareTrigger"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="StartSoftwareTrigger"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static TriggerInput GetPayload(HarpMessage message)
        {
            return (TriggerInput)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="StartSoftwareTrigger"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInput> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((TriggerInput)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="StartSoftwareTrigger"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartSoftwareTrigger"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, TriggerInput value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="StartSoftwareTrigger"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartSoftwareTrigger"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, TriggerInput value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// StartSoftwareTrigger register.
    /// </summary>
    /// <seealso cref="StartSoftwareTrigger"/>
    [Description("Filters and selects timestamped messages from the StartSoftwareTrigger register.")]
    public partial class TimestampedStartSoftwareTrigger
    {
        /// <summary>
        /// Represents the address of the <see cref="StartSoftwareTrigger"/> register. This field is constant.
        /// </summary>
        public const int Address = StartSoftwareTrigger.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="StartSoftwareTrigger"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInput> GetPayload(HarpMessage message)
        {
            return StartSoftwareTrigger.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that emits a stop software-trigger on the channels specified in the mask.
    /// </summary>
    [Description("Emits a stop software-trigger on the channels specified in the mask.")]
    public partial class StopSoftwareTrigger
    {
        /// <summary>
        /// Represents the address of the <see cref="StopSoftwareTrigger"/> register. This field is constant.
        /// </summary>
        public const int Address = 61;

        /// <summary>
        /// Represents the payload type of the <see cref="StopSoftwareTrigger"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="StopSoftwareTrigger"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="StopSoftwareTrigger"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static TriggerInput GetPayload(HarpMessage message)
        {
            return (TriggerInput)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="StopSoftwareTrigger"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInput> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((TriggerInput)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="StopSoftwareTrigger"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StopSoftwareTrigger"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, TriggerInput value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="StopSoftwareTrigger"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StopSoftwareTrigger"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, TriggerInput value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// StopSoftwareTrigger register.
    /// </summary>
    /// <seealso cref="StopSoftwareTrigger"/>
    [Description("Filters and selects timestamped messages from the StopSoftwareTrigger register.")]
    public partial class TimestampedStopSoftwareTrigger
    {
        /// <summary>
        /// Represents the address of the <see cref="StopSoftwareTrigger"/> register. This field is constant.
        /// </summary>
        public const int Address = StopSoftwareTrigger.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="StopSoftwareTrigger"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInput> GetPayload(HarpMessage message)
        {
            return StopSoftwareTrigger.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that arms the PWM channels specified in the mask. Once a PWM is triggered, it must be rearmed.
    /// </summary>
    [Description("Arms the PWM channels specified in the mask. Once a PWM is triggered, it must be rearmed.")]
    public partial class ArmPwmChannels
    {
        /// <summary>
        /// Represents the address of the <see cref="ArmPwmChannels"/> register. This field is constant.
        /// </summary>
        public const int Address = 62;

        /// <summary>
        /// Represents the payload type of the <see cref="ArmPwmChannels"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="ArmPwmChannels"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="ArmPwmChannels"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmChannels GetPayload(HarpMessage message)
        {
            return (PwmChannels)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="ArmPwmChannels"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmChannels)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="ArmPwmChannels"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ArmPwmChannels"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="ArmPwmChannels"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ArmPwmChannels"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// ArmPwmChannels register.
    /// </summary>
    /// <seealso cref="ArmPwmChannels"/>
    [Description("Filters and selects timestamped messages from the ArmPwmChannels register.")]
    public partial class TimestampedArmPwmChannels
    {
        /// <summary>
        /// Represents the address of the <see cref="ArmPwmChannels"/> register. This field is constant.
        /// </summary>
        public const int Address = ArmPwmChannels.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="ArmPwmChannels"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetPayload(HarpMessage message)
        {
            return ArmPwmChannels.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that trigger mode of input channel 0.
    /// </summary>
    [Description("Trigger mode of input channel 0.")]
    public partial class Trigger0Mode
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger0Mode"/> register. This field is constant.
        /// </summary>
        public const int Address = 64;

        /// <summary>
        /// Represents the payload type of the <see cref="Trigger0Mode"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Trigger0Mode"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        static Trigger0ModePayload ParsePayload(byte payload)
        {
            Trigger0ModePayload result;
            result.TriggerMode = (TriggerModeConfig)(byte)(payload & 0x3);
            result.Polarity = (TriggerPolarity)(byte)((payload & 0x10) >> 4);
            return result;
        }

        static byte FormatPayload(Trigger0ModePayload value)
        {
            byte result;
            result = (byte)((byte)value.TriggerMode & 0x3);
            result |= (byte)(((byte)value.Polarity << 4) & 0x10);
            return result;
        }

        /// <summary>
        /// Returns the payload data for <see cref="Trigger0Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static Trigger0ModePayload GetPayload(HarpMessage message)
        {
            return ParsePayload(message.GetPayloadByte());
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Trigger0Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<Trigger0ModePayload> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create(ParsePayload(payload.Value), payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Trigger0Mode"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger0Mode"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, Trigger0ModePayload value)
        {
            return HarpMessage.FromByte(Address, messageType, FormatPayload(value));
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Trigger0Mode"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger0Mode"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, Trigger0ModePayload value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, FormatPayload(value));
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Trigger0Mode register.
    /// </summary>
    /// <seealso cref="Trigger0Mode"/>
    [Description("Filters and selects timestamped messages from the Trigger0Mode register.")]
    public partial class TimestampedTrigger0Mode
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger0Mode"/> register. This field is constant.
        /// </summary>
        public const int Address = Trigger0Mode.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Trigger0Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<Trigger0ModePayload> GetPayload(HarpMessage message)
        {
            return Trigger0Mode.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that trigger mode of input channel 1.
    /// </summary>
    [Description("Trigger mode of input channel 1.")]
    public partial class Trigger1Mode
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger1Mode"/> register. This field is constant.
        /// </summary>
        public const int Address = 65;

        /// <summary>
        /// Represents the payload type of the <see cref="Trigger1Mode"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Trigger1Mode"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        static Trigger1ModePayload ParsePayload(byte payload)
        {
            Trigger1ModePayload result;
            result.TriggerMode = (TriggerModeConfig)(byte)(payload & 0x3);
            result.Polarity = (TriggerPolarity)(byte)((payload & 0x10) >> 4);
            return result;
        }

        static byte FormatPayload(Trigger1ModePayload value)
        {
            byte result;
            result = (byte)((byte)value.TriggerMode & 0x3);
            result |= (byte)(((byte)value.Polarity << 4) & 0x10);
            return result;
        }

        /// <summary>
        /// Returns the payload data for <see cref="Trigger1Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static Trigger1ModePayload GetPayload(HarpMessage message)
        {
            return ParsePayload(message.GetPayloadByte());
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Trigger1Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<Trigger1ModePayload> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create(ParsePayload(payload.Value), payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Trigger1Mode"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger1Mode"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, Trigger1ModePayload value)
        {
            return HarpMessage.FromByte(Address, messageType, FormatPayload(value));
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Trigger1Mode"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger1Mode"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, Trigger1ModePayload value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, FormatPayload(value));
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Trigger1Mode register.
    /// </summary>
    /// <seealso cref="Trigger1Mode"/>
    [Description("Filters and selects timestamped messages from the Trigger1Mode register.")]
    public partial class TimestampedTrigger1Mode
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger1Mode"/> register. This field is constant.
        /// </summary>
        public const int Address = Trigger1Mode.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Trigger1Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<Trigger1ModePayload> GetPayload(HarpMessage message)
        {
            return Trigger1Mode.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that trigger mode of input channel 2.
    /// </summary>
    [Description("Trigger mode of input channel 2.")]
    public partial class Trigger2Mode
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger2Mode"/> register. This field is constant.
        /// </summary>
        public const int Address = 66;

        /// <summary>
        /// Represents the payload type of the <see cref="Trigger2Mode"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Trigger2Mode"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        static Trigger2ModePayload ParsePayload(byte payload)
        {
            Trigger2ModePayload result;
            result.TriggerMode = (TriggerModeConfig)(byte)(payload & 0x3);
            result.Polarity = (TriggerPolarity)(byte)((payload & 0x10) >> 4);
            return result;
        }

        static byte FormatPayload(Trigger2ModePayload value)
        {
            byte result;
            result = (byte)((byte)value.TriggerMode & 0x3);
            result |= (byte)(((byte)value.Polarity << 4) & 0x10);
            return result;
        }

        /// <summary>
        /// Returns the payload data for <see cref="Trigger2Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static Trigger2ModePayload GetPayload(HarpMessage message)
        {
            return ParsePayload(message.GetPayloadByte());
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Trigger2Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<Trigger2ModePayload> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create(ParsePayload(payload.Value), payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Trigger2Mode"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger2Mode"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, Trigger2ModePayload value)
        {
            return HarpMessage.FromByte(Address, messageType, FormatPayload(value));
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Trigger2Mode"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger2Mode"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, Trigger2ModePayload value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, FormatPayload(value));
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Trigger2Mode register.
    /// </summary>
    /// <seealso cref="Trigger2Mode"/>
    [Description("Filters and selects timestamped messages from the Trigger2Mode register.")]
    public partial class TimestampedTrigger2Mode
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger2Mode"/> register. This field is constant.
        /// </summary>
        public const int Address = Trigger2Mode.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Trigger2Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<Trigger2ModePayload> GetPayload(HarpMessage message)
        {
            return Trigger2Mode.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that trigger mode of input channel 3.
    /// </summary>
    [Description("Trigger mode of input channel 3.")]
    public partial class Trigger3Mode
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger3Mode"/> register. This field is constant.
        /// </summary>
        public const int Address = 67;

        /// <summary>
        /// Represents the payload type of the <see cref="Trigger3Mode"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Trigger3Mode"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        static Trigger3ModePayload ParsePayload(byte payload)
        {
            Trigger3ModePayload result;
            result.TriggerMode = (TriggerModeConfig)(byte)(payload & 0x3);
            result.Polarity = (TriggerPolarity)(byte)((payload & 0x10) >> 4);
            return result;
        }

        static byte FormatPayload(Trigger3ModePayload value)
        {
            byte result;
            result = (byte)((byte)value.TriggerMode & 0x3);
            result |= (byte)(((byte)value.Polarity << 4) & 0x10);
            return result;
        }

        /// <summary>
        /// Returns the payload data for <see cref="Trigger3Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static Trigger3ModePayload GetPayload(HarpMessage message)
        {
            return ParsePayload(message.GetPayloadByte());
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Trigger3Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<Trigger3ModePayload> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create(ParsePayload(payload.Value), payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Trigger3Mode"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger3Mode"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, Trigger3ModePayload value)
        {
            return HarpMessage.FromByte(Address, messageType, FormatPayload(value));
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Trigger3Mode"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Trigger3Mode"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, Trigger3ModePayload value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, FormatPayload(value));
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Trigger3Mode register.
    /// </summary>
    /// <seealso cref="Trigger3Mode"/>
    [Description("Filters and selects timestamped messages from the Trigger3Mode register.")]
    public partial class TimestampedTrigger3Mode
    {
        /// <summary>
        /// Represents the address of the <see cref="Trigger3Mode"/> register. This field is constant.
        /// </summary>
        public const int Address = Trigger3Mode.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Trigger3Mode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<Trigger3ModePayload> GetPayload(HarpMessage message)
        {
            return Trigger3Mode.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that requests enable to stimulate.
    /// </summary>
    [Description("Requests enable to stimulate.")]
    public partial class RequestEnable
    {
        /// <summary>
        /// Represents the address of the <see cref="RequestEnable"/> register. This field is constant.
        /// </summary>
        public const int Address = 68;

        /// <summary>
        /// Represents the payload type of the <see cref="RequestEnable"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="RequestEnable"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="RequestEnable"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmChannels GetPayload(HarpMessage message)
        {
            return (PwmChannels)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="RequestEnable"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmChannels)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="RequestEnable"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="RequestEnable"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="RequestEnable"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="RequestEnable"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// RequestEnable register.
    /// </summary>
    /// <seealso cref="RequestEnable"/>
    [Description("Filters and selects timestamped messages from the RequestEnable register.")]
    public partial class TimestampedRequestEnable
    {
        /// <summary>
        /// Represents the address of the <see cref="RequestEnable"/> register. This field is constant.
        /// </summary>
        public const int Address = RequestEnable.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="RequestEnable"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetPayload(HarpMessage message)
        {
            return RequestEnable.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that enable enable.
    /// </summary>
    [Description("Enable enable")]
    public partial class EnablePwmChannels
    {
        /// <summary>
        /// Represents the address of the <see cref="EnablePwmChannels"/> register. This field is constant.
        /// </summary>
        public const int Address = 69;

        /// <summary>
        /// Represents the payload type of the <see cref="EnablePwmChannels"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="EnablePwmChannels"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="EnablePwmChannels"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmChannels GetPayload(HarpMessage message)
        {
            return (PwmChannels)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="EnablePwmChannels"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmChannels)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="EnablePwmChannels"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="EnablePwmChannels"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="EnablePwmChannels"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="EnablePwmChannels"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// EnablePwmChannels register.
    /// </summary>
    /// <seealso cref="EnablePwmChannels"/>
    [Description("Filters and selects timestamped messages from the EnablePwmChannels register.")]
    public partial class TimestampedEnablePwmChannels
    {
        /// <summary>
        /// Represents the address of the <see cref="EnablePwmChannels"/> register. This field is constant.
        /// </summary>
        public const int Address = EnablePwmChannels.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="EnablePwmChannels"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetPayload(HarpMessage message)
        {
            return EnablePwmChannels.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that when triggered, all channels will be affected by the event.
    /// </summary>
    [Description("When triggered, all channels will be affected by the event.")]
    public partial class TriggerAllMode
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerAllMode"/> register. This field is constant.
        /// </summary>
        public const int Address = 70;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerAllMode"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="TriggerAllMode"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        static TriggerAllModePayload ParsePayload(byte payload)
        {
            TriggerAllModePayload result;
            result.TriggerMode = (TriggerAllModeConfig)(byte)(payload & 0x3);
            result.Polarity = (TriggerPolarity)(byte)((payload & 0x10) >> 4);
            return result;
        }

        static byte FormatPayload(TriggerAllModePayload value)
        {
            byte result;
            result = (byte)((byte)value.TriggerMode & 0x3);
            result |= (byte)(((byte)value.Polarity << 4) & 0x10);
            return result;
        }

        /// <summary>
        /// Returns the payload data for <see cref="TriggerAllMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static TriggerAllModePayload GetPayload(HarpMessage message)
        {
            return ParsePayload(message.GetPayloadByte());
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerAllMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerAllModePayload> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create(ParsePayload(payload.Value), payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerAllMode"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerAllMode"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, TriggerAllModePayload value)
        {
            return HarpMessage.FromByte(Address, messageType, FormatPayload(value));
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerAllMode"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerAllMode"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, TriggerAllModePayload value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, FormatPayload(value));
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerAllMode register.
    /// </summary>
    /// <seealso cref="TriggerAllMode"/>
    [Description("Filters and selects timestamped messages from the TriggerAllMode register.")]
    public partial class TimestampedTriggerAllMode
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerAllMode"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerAllMode.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerAllMode"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerAllModePayload> GetPayload(HarpMessage message)
        {
            return TriggerAllMode.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that current state of all trigger channel inputs.
    /// </summary>
    [Description("Current state of all trigger channel inputs.")]
    public partial class TriggerChannelState
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerChannelState"/> register. This field is constant.
        /// </summary>
        public const int Address = 71;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerChannelState"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="TriggerChannelState"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="TriggerChannelState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static TriggerInput GetPayload(HarpMessage message)
        {
            return (TriggerInput)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerChannelState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInput> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((TriggerInput)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerChannelState"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerChannelState"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, TriggerInput value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerChannelState"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerChannelState"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, TriggerInput value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerChannelState register.
    /// </summary>
    /// <seealso cref="TriggerChannelState"/>
    [Description("Filters and selects timestamped messages from the TriggerChannelState register.")]
    public partial class TimestampedTriggerChannelState
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerChannelState"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerChannelState.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerChannelState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInput> GetPayload(HarpMessage message)
        {
            return TriggerChannelState.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that current state of all PWM channel outputs.
    /// </summary>
    [Description("Current state of all PWM channel outputs.")]
    public partial class PwmChannelState
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannelState"/> register. This field is constant.
        /// </summary>
        public const int Address = 72;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmChannelState"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="PwmChannelState"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmChannelState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmChannels GetPayload(HarpMessage message)
        {
            return (PwmChannels)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmChannelState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmChannels)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmChannelState"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannelState"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmChannelState"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmChannelState"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmChannelState register.
    /// </summary>
    /// <seealso cref="PwmChannelState"/>
    [Description("Filters and selects timestamped messages from the PwmChannelState register.")]
    public partial class TimestampedPwmChannelState
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmChannelState"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmChannelState.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmChannelState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetPayload(HarpMessage message)
        {
            return PwmChannelState.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that current state of the PWM execution.
    /// </summary>
    [Description("Current state of the PWM execution.")]
    public partial class PwmExecutionState
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmExecutionState"/> register. This field is constant.
        /// </summary>
        public const int Address = 73;

        /// <summary>
        /// Represents the payload type of the <see cref="PwmExecutionState"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="PwmExecutionState"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="PwmExecutionState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static PwmChannels GetPayload(HarpMessage message)
        {
            return (PwmChannels)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="PwmExecutionState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((PwmChannels)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="PwmExecutionState"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmExecutionState"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="PwmExecutionState"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="PwmExecutionState"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, PwmChannels value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// PwmExecutionState register.
    /// </summary>
    /// <seealso cref="PwmExecutionState"/>
    [Description("Filters and selects timestamped messages from the PwmExecutionState register.")]
    public partial class TimestampedPwmExecutionState
    {
        /// <summary>
        /// Represents the address of the <see cref="PwmExecutionState"/> register. This field is constant.
        /// </summary>
        public const int Address = PwmExecutionState.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="PwmExecutionState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<PwmChannels> GetPayload(HarpMessage message)
        {
            return PwmExecutionState.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that enables the generation of events.
    /// </summary>
    [Description("Enables the generation of events.")]
    public partial class EnableEvents
    {
        /// <summary>
        /// Represents the address of the <see cref="EnableEvents"/> register. This field is constant.
        /// </summary>
        public const int Address = 74;

        /// <summary>
        /// Represents the payload type of the <see cref="EnableEvents"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="EnableEvents"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="EnableEvents"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static MultiPwmEvents GetPayload(HarpMessage message)
        {
            return (MultiPwmEvents)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="EnableEvents"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<MultiPwmEvents> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((MultiPwmEvents)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="EnableEvents"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="EnableEvents"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, MultiPwmEvents value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="EnableEvents"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="EnableEvents"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, MultiPwmEvents value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// EnableEvents register.
    /// </summary>
    /// <seealso cref="EnableEvents"/>
    [Description("Filters and selects timestamped messages from the EnableEvents register.")]
    public partial class TimestampedEnableEvents
    {
        /// <summary>
        /// Represents the address of the <see cref="EnableEvents"/> register. This field is constant.
        /// </summary>
        public const int Address = EnableEvents.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="EnableEvents"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<MultiPwmEvents> GetPayload(HarpMessage message)
        {
            return EnableEvents.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents an operator which creates standard message payloads for the
    /// MultiPwm device.
    /// </summary>
    /// <seealso cref="CreatePwmChannel0FrequencyPayload"/>
    /// <seealso cref="CreatePwmChannel1FrequencyPayload"/>
    /// <seealso cref="CreatePwmChannel2FrequencyPayload"/>
    /// <seealso cref="CreatePwmChannel3FrequencyPayload"/>
    /// <seealso cref="CreatePwmChannel0DutyCyclePayload"/>
    /// <seealso cref="CreatePwmChannel1DutyCyclePayload"/>
    /// <seealso cref="CreatePwmChannel2DutyCyclePayload"/>
    /// <seealso cref="CreatePwmChannel3DutyCyclePayload"/>
    /// <seealso cref="CreatePwmChannel0NumPulsesPayload"/>
    /// <seealso cref="CreatePwmChannel1NumPulsesPayload"/>
    /// <seealso cref="CreatePwmChannel2NumPulsesPayload"/>
    /// <seealso cref="CreatePwmChannel3NumPulsesPayload"/>
    /// <seealso cref="CreatePwmChannel0RealFrequencyPayload"/>
    /// <seealso cref="CreatePwmChannel1RealFrequencyPayload"/>
    /// <seealso cref="CreatePwmChannel2RealFrequencyPayload"/>
    /// <seealso cref="CreatePwmChannel3RealFrequencyPayload"/>
    /// <seealso cref="CreatePwmChannel0RealDutyCyclePayload"/>
    /// <seealso cref="CreatePwmChannel1RealDutyCyclePayload"/>
    /// <seealso cref="CreatePwmChannel2RealDutyCyclePayload"/>
    /// <seealso cref="CreatePwmChannel3RealDutyCyclePayload"/>
    /// <seealso cref="CreatePwmChannel0PlaybackModePayload"/>
    /// <seealso cref="CreatePwmChannel1PlaybackModePayload"/>
    /// <seealso cref="CreatePwmChannel2PlaybackModePayload"/>
    /// <seealso cref="CreatePwmChannel3PlaybackModePayload"/>
    /// <seealso cref="CreateTrigger0TargetsPayload"/>
    /// <seealso cref="CreateTrigger1TargetsPayload"/>
    /// <seealso cref="CreateTrigger2TargetsPayload"/>
    /// <seealso cref="CreateTrigger3TargetsPayload"/>
    /// <seealso cref="CreateStartSoftwareTriggerPayload"/>
    /// <seealso cref="CreateStopSoftwareTriggerPayload"/>
    /// <seealso cref="CreateArmPwmChannelsPayload"/>
    /// <seealso cref="CreateTrigger0ModePayload"/>
    /// <seealso cref="CreateTrigger1ModePayload"/>
    /// <seealso cref="CreateTrigger2ModePayload"/>
    /// <seealso cref="CreateTrigger3ModePayload"/>
    /// <seealso cref="CreateRequestEnablePayload"/>
    /// <seealso cref="CreateEnablePwmChannelsPayload"/>
    /// <seealso cref="CreateTriggerAllModePayload"/>
    /// <seealso cref="CreateTriggerChannelStatePayload"/>
    /// <seealso cref="CreatePwmChannelStatePayload"/>
    /// <seealso cref="CreatePwmExecutionStatePayload"/>
    /// <seealso cref="CreateEnableEventsPayload"/>
    [XmlInclude(typeof(CreatePwmChannel0FrequencyPayload))]
    [XmlInclude(typeof(CreatePwmChannel1FrequencyPayload))]
    [XmlInclude(typeof(CreatePwmChannel2FrequencyPayload))]
    [XmlInclude(typeof(CreatePwmChannel3FrequencyPayload))]
    [XmlInclude(typeof(CreatePwmChannel0DutyCyclePayload))]
    [XmlInclude(typeof(CreatePwmChannel1DutyCyclePayload))]
    [XmlInclude(typeof(CreatePwmChannel2DutyCyclePayload))]
    [XmlInclude(typeof(CreatePwmChannel3DutyCyclePayload))]
    [XmlInclude(typeof(CreatePwmChannel0NumPulsesPayload))]
    [XmlInclude(typeof(CreatePwmChannel1NumPulsesPayload))]
    [XmlInclude(typeof(CreatePwmChannel2NumPulsesPayload))]
    [XmlInclude(typeof(CreatePwmChannel3NumPulsesPayload))]
    [XmlInclude(typeof(CreatePwmChannel0RealFrequencyPayload))]
    [XmlInclude(typeof(CreatePwmChannel1RealFrequencyPayload))]
    [XmlInclude(typeof(CreatePwmChannel2RealFrequencyPayload))]
    [XmlInclude(typeof(CreatePwmChannel3RealFrequencyPayload))]
    [XmlInclude(typeof(CreatePwmChannel0RealDutyCyclePayload))]
    [XmlInclude(typeof(CreatePwmChannel1RealDutyCyclePayload))]
    [XmlInclude(typeof(CreatePwmChannel2RealDutyCyclePayload))]
    [XmlInclude(typeof(CreatePwmChannel3RealDutyCyclePayload))]
    [XmlInclude(typeof(CreatePwmChannel0PlaybackModePayload))]
    [XmlInclude(typeof(CreatePwmChannel1PlaybackModePayload))]
    [XmlInclude(typeof(CreatePwmChannel2PlaybackModePayload))]
    [XmlInclude(typeof(CreatePwmChannel3PlaybackModePayload))]
    [XmlInclude(typeof(CreateTrigger0TargetsPayload))]
    [XmlInclude(typeof(CreateTrigger1TargetsPayload))]
    [XmlInclude(typeof(CreateTrigger2TargetsPayload))]
    [XmlInclude(typeof(CreateTrigger3TargetsPayload))]
    [XmlInclude(typeof(CreateStartSoftwareTriggerPayload))]
    [XmlInclude(typeof(CreateStopSoftwareTriggerPayload))]
    [XmlInclude(typeof(CreateArmPwmChannelsPayload))]
    [XmlInclude(typeof(CreateTrigger0ModePayload))]
    [XmlInclude(typeof(CreateTrigger1ModePayload))]
    [XmlInclude(typeof(CreateTrigger2ModePayload))]
    [XmlInclude(typeof(CreateTrigger3ModePayload))]
    [XmlInclude(typeof(CreateRequestEnablePayload))]
    [XmlInclude(typeof(CreateEnablePwmChannelsPayload))]
    [XmlInclude(typeof(CreateTriggerAllModePayload))]
    [XmlInclude(typeof(CreateTriggerChannelStatePayload))]
    [XmlInclude(typeof(CreatePwmChannelStatePayload))]
    [XmlInclude(typeof(CreatePwmExecutionStatePayload))]
    [XmlInclude(typeof(CreateEnableEventsPayload))]
    [Description("Creates standard message payloads for the MultiPwm device.")]
    public partial class CreateMessage : CreateMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMessage"/> class.
        /// </summary>
        public CreateMessage()
        {
            Payload = new CreatePwmChannel0FrequencyPayload();
        }

        string INamedElement.Name => $"{nameof(MultiPwm)}.{GetElementDisplayName(Payload)}";
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that frequency (Hz) of PWM pulses in channel 0.
    /// </summary>
    [DisplayName("PwmChannel0FrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that frequency (Hz) of PWM pulses in channel 0.")]
    public partial class CreatePwmChannel0FrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that frequency (Hz) of PWM pulses in channel 0.
        /// </summary>
        [Description("The value that frequency (Hz) of PWM pulses in channel 0.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that frequency (Hz) of PWM pulses in channel 0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that frequency (Hz) of PWM pulses in channel 0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel0Frequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that frequency (Hz) of PWM pulses in channel 1.
    /// </summary>
    [DisplayName("PwmChannel1FrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that frequency (Hz) of PWM pulses in channel 1.")]
    public partial class CreatePwmChannel1FrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that frequency (Hz) of PWM pulses in channel 1.
        /// </summary>
        [Description("The value that frequency (Hz) of PWM pulses in channel 1.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that frequency (Hz) of PWM pulses in channel 1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that frequency (Hz) of PWM pulses in channel 1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel1Frequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that frequency (Hz) of PWM pulses in channel 2.
    /// </summary>
    [DisplayName("PwmChannel2FrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that frequency (Hz) of PWM pulses in channel 2.")]
    public partial class CreatePwmChannel2FrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that frequency (Hz) of PWM pulses in channel 2.
        /// </summary>
        [Description("The value that frequency (Hz) of PWM pulses in channel 2.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that frequency (Hz) of PWM pulses in channel 2.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that frequency (Hz) of PWM pulses in channel 2.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel2Frequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that frequency (Hz) of PWM pulses in channel 3.
    /// </summary>
    [DisplayName("PwmChannel3FrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that frequency (Hz) of PWM pulses in channel 3.")]
    public partial class CreatePwmChannel3FrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that frequency (Hz) of PWM pulses in channel 3.
        /// </summary>
        [Description("The value that frequency (Hz) of PWM pulses in channel 3.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that frequency (Hz) of PWM pulses in channel 3.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that frequency (Hz) of PWM pulses in channel 3.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel3Frequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that duty cycle (0-100) of PWM pulses in channel 0.
    /// </summary>
    [DisplayName("PwmChannel0DutyCyclePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that duty cycle (0-100) of PWM pulses in channel 0.")]
    public partial class CreatePwmChannel0DutyCyclePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that duty cycle (0-100) of PWM pulses in channel 0.
        /// </summary>
        [Range(min: 0.1, max: 99.9)]
        [Editor(DesignTypes.NumericUpDownEditor, DesignTypes.UITypeEditor)]
        [Description("The value that duty cycle (0-100) of PWM pulses in channel 0.")]
        public float Value { get; set; } = 50;

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that duty cycle (0-100) of PWM pulses in channel 0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that duty cycle (0-100) of PWM pulses in channel 0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel0DutyCycle.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that duty cycle (0-100) of PWM pulses in channel 1.
    /// </summary>
    [DisplayName("PwmChannel1DutyCyclePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that duty cycle (0-100) of PWM pulses in channel 1.")]
    public partial class CreatePwmChannel1DutyCyclePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that duty cycle (0-100) of PWM pulses in channel 1.
        /// </summary>
        [Range(min: 0.1, max: 99.9)]
        [Editor(DesignTypes.NumericUpDownEditor, DesignTypes.UITypeEditor)]
        [Description("The value that duty cycle (0-100) of PWM pulses in channel 1.")]
        public float Value { get; set; } = 50;

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that duty cycle (0-100) of PWM pulses in channel 1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that duty cycle (0-100) of PWM pulses in channel 1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel1DutyCycle.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that duty cycle (0-100) of PWM pulses in channel 2.
    /// </summary>
    [DisplayName("PwmChannel2DutyCyclePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that duty cycle (0-100) of PWM pulses in channel 2.")]
    public partial class CreatePwmChannel2DutyCyclePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that duty cycle (0-100) of PWM pulses in channel 2.
        /// </summary>
        [Range(min: 0.1, max: 99.9)]
        [Editor(DesignTypes.NumericUpDownEditor, DesignTypes.UITypeEditor)]
        [Description("The value that duty cycle (0-100) of PWM pulses in channel 2.")]
        public float Value { get; set; } = 50;

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that duty cycle (0-100) of PWM pulses in channel 2.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that duty cycle (0-100) of PWM pulses in channel 2.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel2DutyCycle.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that duty cycle (0-100) of PWM pulses in channel 3.
    /// </summary>
    [DisplayName("PwmChannel3DutyCyclePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that duty cycle (0-100) of PWM pulses in channel 3.")]
    public partial class CreatePwmChannel3DutyCyclePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that duty cycle (0-100) of PWM pulses in channel 3.
        /// </summary>
        [Range(min: 0.1, max: 99.9)]
        [Editor(DesignTypes.NumericUpDownEditor, DesignTypes.UITypeEditor)]
        [Description("The value that duty cycle (0-100) of PWM pulses in channel 3.")]
        public float Value { get; set; } = 50;

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that duty cycle (0-100) of PWM pulses in channel 3.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that duty cycle (0-100) of PWM pulses in channel 3.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel3DutyCycle.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that total number of pulses to be generated in channel 0.
    /// </summary>
    [DisplayName("PwmChannel0NumPulsesPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that total number of pulses to be generated in channel 0.")]
    public partial class CreatePwmChannel0NumPulsesPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that total number of pulses to be generated in channel 0.
        /// </summary>
        [Description("The value that total number of pulses to be generated in channel 0.")]
        public uint Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that total number of pulses to be generated in channel 0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that total number of pulses to be generated in channel 0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel0NumPulses.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that total number of pulses to be generated in channel 1.
    /// </summary>
    [DisplayName("PwmChannel1NumPulsesPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that total number of pulses to be generated in channel 1.")]
    public partial class CreatePwmChannel1NumPulsesPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that total number of pulses to be generated in channel 1.
        /// </summary>
        [Description("The value that total number of pulses to be generated in channel 1.")]
        public uint Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that total number of pulses to be generated in channel 1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that total number of pulses to be generated in channel 1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel1NumPulses.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that total number of pulses to be generated in channel 2.
    /// </summary>
    [DisplayName("PwmChannel2NumPulsesPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that total number of pulses to be generated in channel 2.")]
    public partial class CreatePwmChannel2NumPulsesPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that total number of pulses to be generated in channel 2.
        /// </summary>
        [Description("The value that total number of pulses to be generated in channel 2.")]
        public uint Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that total number of pulses to be generated in channel 2.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that total number of pulses to be generated in channel 2.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel2NumPulses.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that total number of pulses to be generated in channel 3.
    /// </summary>
    [DisplayName("PwmChannel3NumPulsesPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that total number of pulses to be generated in channel 3.")]
    public partial class CreatePwmChannel3NumPulsesPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that total number of pulses to be generated in channel 3.
        /// </summary>
        [Description("The value that total number of pulses to be generated in channel 3.")]
        public uint Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that total number of pulses to be generated in channel 3.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that total number of pulses to be generated in channel 3.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel3NumPulses.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that real frequency (Hz) of PWM pulses in channel 0.
    /// </summary>
    [DisplayName("PwmChannel0RealFrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that real frequency (Hz) of PWM pulses in channel 0.")]
    public partial class CreatePwmChannel0RealFrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that real frequency (Hz) of PWM pulses in channel 0.
        /// </summary>
        [Description("The value that real frequency (Hz) of PWM pulses in channel 0.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that real frequency (Hz) of PWM pulses in channel 0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that real frequency (Hz) of PWM pulses in channel 0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel0RealFrequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that real frequency (Hz) of PWM pulses in channel 1.
    /// </summary>
    [DisplayName("PwmChannel1RealFrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that real frequency (Hz) of PWM pulses in channel 1.")]
    public partial class CreatePwmChannel1RealFrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that real frequency (Hz) of PWM pulses in channel 1.
        /// </summary>
        [Description("The value that real frequency (Hz) of PWM pulses in channel 1.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that real frequency (Hz) of PWM pulses in channel 1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that real frequency (Hz) of PWM pulses in channel 1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel1RealFrequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that real frequency (Hz) of PWM pulses in channel 2.
    /// </summary>
    [DisplayName("PwmChannel2RealFrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that real frequency (Hz) of PWM pulses in channel 2.")]
    public partial class CreatePwmChannel2RealFrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that real frequency (Hz) of PWM pulses in channel 2.
        /// </summary>
        [Description("The value that real frequency (Hz) of PWM pulses in channel 2.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that real frequency (Hz) of PWM pulses in channel 2.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that real frequency (Hz) of PWM pulses in channel 2.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel2RealFrequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that real frequency (Hz) of PWM pulses in channel 3.
    /// </summary>
    [DisplayName("PwmChannel3RealFrequencyPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that real frequency (Hz) of PWM pulses in channel 3.")]
    public partial class CreatePwmChannel3RealFrequencyPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that real frequency (Hz) of PWM pulses in channel 3.
        /// </summary>
        [Description("The value that real frequency (Hz) of PWM pulses in channel 3.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that real frequency (Hz) of PWM pulses in channel 3.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that real frequency (Hz) of PWM pulses in channel 3.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel3RealFrequency.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that real duty cycle (0-100) of PWM pulses in channel 0.
    /// </summary>
    [DisplayName("PwmChannel0RealDutyCyclePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that real duty cycle (0-100) of PWM pulses in channel 0.")]
    public partial class CreatePwmChannel0RealDutyCyclePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that real duty cycle (0-100) of PWM pulses in channel 0.
        /// </summary>
        [Description("The value that real duty cycle (0-100) of PWM pulses in channel 0.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that real duty cycle (0-100) of PWM pulses in channel 0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that real duty cycle (0-100) of PWM pulses in channel 0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel0RealDutyCycle.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that real duty cycle (0-100) of PWM pulses in channel 1.
    /// </summary>
    [DisplayName("PwmChannel1RealDutyCyclePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that real duty cycle (0-100) of PWM pulses in channel 1.")]
    public partial class CreatePwmChannel1RealDutyCyclePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that real duty cycle (0-100) of PWM pulses in channel 1.
        /// </summary>
        [Description("The value that real duty cycle (0-100) of PWM pulses in channel 1.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that real duty cycle (0-100) of PWM pulses in channel 1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that real duty cycle (0-100) of PWM pulses in channel 1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel1RealDutyCycle.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that real duty cycle (0-100) of PWM pulses in channel 2.
    /// </summary>
    [DisplayName("PwmChannel2RealDutyCyclePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that real duty cycle (0-100) of PWM pulses in channel 2.")]
    public partial class CreatePwmChannel2RealDutyCyclePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that real duty cycle (0-100) of PWM pulses in channel 2.
        /// </summary>
        [Description("The value that real duty cycle (0-100) of PWM pulses in channel 2.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that real duty cycle (0-100) of PWM pulses in channel 2.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that real duty cycle (0-100) of PWM pulses in channel 2.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel2RealDutyCycle.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that real duty cycle (0-100) of PWM pulses in channel 3.
    /// </summary>
    [DisplayName("PwmChannel3RealDutyCyclePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that real duty cycle (0-100) of PWM pulses in channel 3.")]
    public partial class CreatePwmChannel3RealDutyCyclePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that real duty cycle (0-100) of PWM pulses in channel 3.
        /// </summary>
        [Description("The value that real duty cycle (0-100) of PWM pulses in channel 3.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that real duty cycle (0-100) of PWM pulses in channel 3.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that real duty cycle (0-100) of PWM pulses in channel 3.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel3RealDutyCycle.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that playback mode of channel 0.
    /// </summary>
    [DisplayName("PwmChannel0PlaybackModePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that playback mode of channel 0.")]
    public partial class CreatePwmChannel0PlaybackModePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that playback mode of channel 0.
        /// </summary>
        [Description("The value that playback mode of channel 0.")]
        public PwmPlaybackMode Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that playback mode of channel 0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that playback mode of channel 0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel0PlaybackMode.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that playback mode of channel 1.
    /// </summary>
    [DisplayName("PwmChannel1PlaybackModePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that playback mode of channel 1.")]
    public partial class CreatePwmChannel1PlaybackModePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that playback mode of channel 1.
        /// </summary>
        [Description("The value that playback mode of channel 1.")]
        public PwmPlaybackMode Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that playback mode of channel 1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that playback mode of channel 1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel1PlaybackMode.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that playback mode of channel 2.
    /// </summary>
    [DisplayName("PwmChannel2PlaybackModePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that playback mode of channel 2.")]
    public partial class CreatePwmChannel2PlaybackModePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that playback mode of channel 2.
        /// </summary>
        [Description("The value that playback mode of channel 2.")]
        public PwmPlaybackMode Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that playback mode of channel 2.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that playback mode of channel 2.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel2PlaybackMode.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that playback mode of channel 3.
    /// </summary>
    [DisplayName("PwmChannel3PlaybackModePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that playback mode of channel 3.")]
    public partial class CreatePwmChannel3PlaybackModePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that playback mode of channel 3.
        /// </summary>
        [Description("The value that playback mode of channel 3.")]
        public PwmPlaybackMode Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that playback mode of channel 3.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that playback mode of channel 3.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannel3PlaybackMode.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that target channels that will start the PWM sequence if Trigger0 is activated.
    /// </summary>
    [DisplayName("Trigger0TargetsPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that target channels that will start the PWM sequence if Trigger0 is activated.")]
    public partial class CreateTrigger0TargetsPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that target channels that will start the PWM sequence if Trigger0 is activated.
        /// </summary>
        [Description("The value that target channels that will start the PWM sequence if Trigger0 is activated.")]
        public PwmChannels Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that target channels that will start the PWM sequence if Trigger0 is activated.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that target channels that will start the PWM sequence if Trigger0 is activated.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Trigger0Targets.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that target channels that will start the PWM sequence if Trigger1 is activated.
    /// </summary>
    [DisplayName("Trigger1TargetsPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that target channels that will start the PWM sequence if Trigger1 is activated.")]
    public partial class CreateTrigger1TargetsPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that target channels that will start the PWM sequence if Trigger1 is activated.
        /// </summary>
        [Description("The value that target channels that will start the PWM sequence if Trigger1 is activated.")]
        public PwmChannels Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that target channels that will start the PWM sequence if Trigger1 is activated.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that target channels that will start the PWM sequence if Trigger1 is activated.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Trigger1Targets.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that target channels that will start the PWM sequence if Trigger2 is activated.
    /// </summary>
    [DisplayName("Trigger2TargetsPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that target channels that will start the PWM sequence if Trigger2 is activated.")]
    public partial class CreateTrigger2TargetsPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that target channels that will start the PWM sequence if Trigger2 is activated.
        /// </summary>
        [Description("The value that target channels that will start the PWM sequence if Trigger2 is activated.")]
        public PwmChannels Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that target channels that will start the PWM sequence if Trigger2 is activated.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that target channels that will start the PWM sequence if Trigger2 is activated.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Trigger2Targets.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that target channels that will start the PWM sequence if Trigger3 is activated.
    /// </summary>
    [DisplayName("Trigger3TargetsPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that target channels that will start the PWM sequence if Trigger3 is activated.")]
    public partial class CreateTrigger3TargetsPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that target channels that will start the PWM sequence if Trigger3 is activated.
        /// </summary>
        [Description("The value that target channels that will start the PWM sequence if Trigger3 is activated.")]
        public PwmChannels Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that target channels that will start the PWM sequence if Trigger3 is activated.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that target channels that will start the PWM sequence if Trigger3 is activated.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Trigger3Targets.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that emits a start software-trigger on the channels specified in the mask.
    /// </summary>
    [DisplayName("StartSoftwareTriggerPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that emits a start software-trigger on the channels specified in the mask.")]
    public partial class CreateStartSoftwareTriggerPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that emits a start software-trigger on the channels specified in the mask.
        /// </summary>
        [Description("The value that emits a start software-trigger on the channels specified in the mask.")]
        public TriggerInput Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that emits a start software-trigger on the channels specified in the mask.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that emits a start software-trigger on the channels specified in the mask.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => StartSoftwareTrigger.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that emits a stop software-trigger on the channels specified in the mask.
    /// </summary>
    [DisplayName("StopSoftwareTriggerPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that emits a stop software-trigger on the channels specified in the mask.")]
    public partial class CreateStopSoftwareTriggerPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that emits a stop software-trigger on the channels specified in the mask.
        /// </summary>
        [Description("The value that emits a stop software-trigger on the channels specified in the mask.")]
        public TriggerInput Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that emits a stop software-trigger on the channels specified in the mask.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that emits a stop software-trigger on the channels specified in the mask.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => StopSoftwareTrigger.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that arms the PWM channels specified in the mask. Once a PWM is triggered, it must be rearmed.
    /// </summary>
    [DisplayName("ArmPwmChannelsPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that arms the PWM channels specified in the mask. Once a PWM is triggered, it must be rearmed.")]
    public partial class CreateArmPwmChannelsPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that arms the PWM channels specified in the mask. Once a PWM is triggered, it must be rearmed.
        /// </summary>
        [Description("The value that arms the PWM channels specified in the mask. Once a PWM is triggered, it must be rearmed.")]
        public PwmChannels Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that arms the PWM channels specified in the mask. Once a PWM is triggered, it must be rearmed.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that arms the PWM channels specified in the mask. Once a PWM is triggered, it must be rearmed.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => ArmPwmChannels.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that trigger mode of input channel 0.
    /// </summary>
    [DisplayName("Trigger0ModePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that trigger mode of input channel 0.")]
    public partial class CreateTrigger0ModePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets a value that specifies the trigger mode.
        /// </summary>
        [Description("Specifies the trigger mode.")]
        public TriggerModeConfig TriggerMode { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the polarity of the trigger signal.
        /// </summary>
        [Description("Specifies the polarity of the trigger signal.")]
        public TriggerPolarity Polarity { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that trigger mode of input channel 0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that trigger mode of input channel 0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ =>
            {
                Trigger0ModePayload value;
                value.TriggerMode = TriggerMode;
                value.Polarity = Polarity;
                return Trigger0Mode.FromPayload(MessageType, value);
            });
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that trigger mode of input channel 1.
    /// </summary>
    [DisplayName("Trigger1ModePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that trigger mode of input channel 1.")]
    public partial class CreateTrigger1ModePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets a value that specifies the trigger mode.
        /// </summary>
        [Description("Specifies the trigger mode.")]
        public TriggerModeConfig TriggerMode { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the polarity of the trigger signal.
        /// </summary>
        [Description("Specifies the polarity of the trigger signal.")]
        public TriggerPolarity Polarity { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that trigger mode of input channel 1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that trigger mode of input channel 1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ =>
            {
                Trigger1ModePayload value;
                value.TriggerMode = TriggerMode;
                value.Polarity = Polarity;
                return Trigger1Mode.FromPayload(MessageType, value);
            });
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that trigger mode of input channel 2.
    /// </summary>
    [DisplayName("Trigger2ModePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that trigger mode of input channel 2.")]
    public partial class CreateTrigger2ModePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets a value that specifies the trigger mode.
        /// </summary>
        [Description("Specifies the trigger mode.")]
        public TriggerModeConfig TriggerMode { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the polarity of the trigger signal.
        /// </summary>
        [Description("Specifies the polarity of the trigger signal.")]
        public TriggerPolarity Polarity { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that trigger mode of input channel 2.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that trigger mode of input channel 2.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ =>
            {
                Trigger2ModePayload value;
                value.TriggerMode = TriggerMode;
                value.Polarity = Polarity;
                return Trigger2Mode.FromPayload(MessageType, value);
            });
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that trigger mode of input channel 3.
    /// </summary>
    [DisplayName("Trigger3ModePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that trigger mode of input channel 3.")]
    public partial class CreateTrigger3ModePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets a value that specifies the trigger mode.
        /// </summary>
        [Description("Specifies the trigger mode.")]
        public TriggerModeConfig TriggerMode { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the polarity of the trigger signal.
        /// </summary>
        [Description("Specifies the polarity of the trigger signal.")]
        public TriggerPolarity Polarity { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that trigger mode of input channel 3.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that trigger mode of input channel 3.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ =>
            {
                Trigger3ModePayload value;
                value.TriggerMode = TriggerMode;
                value.Polarity = Polarity;
                return Trigger3Mode.FromPayload(MessageType, value);
            });
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that requests enable to stimulate.
    /// </summary>
    [DisplayName("RequestEnablePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that requests enable to stimulate.")]
    public partial class CreateRequestEnablePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that requests enable to stimulate.
        /// </summary>
        [Description("The value that requests enable to stimulate.")]
        public PwmChannels Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that requests enable to stimulate.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that requests enable to stimulate.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => RequestEnable.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that enable enable.
    /// </summary>
    [DisplayName("EnablePwmChannelsPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that enable enable.")]
    public partial class CreateEnablePwmChannelsPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that enable enable.
        /// </summary>
        [Description("The value that enable enable.")]
        public PwmChannels Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that enable enable.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that enable enable.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => EnablePwmChannels.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that when triggered, all channels will be affected by the event.
    /// </summary>
    [DisplayName("TriggerAllModePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that when triggered, all channels will be affected by the event.")]
    public partial class CreateTriggerAllModePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets a value that specifies the trigger mode.
        /// </summary>
        [Description("Specifies the trigger mode.")]
        public TriggerAllModeConfig TriggerMode { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the polarity of the trigger signal.
        /// </summary>
        [Description("Specifies the polarity of the trigger signal.")]
        public TriggerPolarity Polarity { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that when triggered, all channels will be affected by the event.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that when triggered, all channels will be affected by the event.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ =>
            {
                TriggerAllModePayload value;
                value.TriggerMode = TriggerMode;
                value.Polarity = Polarity;
                return TriggerAllMode.FromPayload(MessageType, value);
            });
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that current state of all trigger channel inputs.
    /// </summary>
    [DisplayName("TriggerChannelStatePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that current state of all trigger channel inputs.")]
    public partial class CreateTriggerChannelStatePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that current state of all trigger channel inputs.
        /// </summary>
        [Description("The value that current state of all trigger channel inputs.")]
        public TriggerInput Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that current state of all trigger channel inputs.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that current state of all trigger channel inputs.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => TriggerChannelState.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that current state of all PWM channel outputs.
    /// </summary>
    [DisplayName("PwmChannelStatePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that current state of all PWM channel outputs.")]
    public partial class CreatePwmChannelStatePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that current state of all PWM channel outputs.
        /// </summary>
        [Description("The value that current state of all PWM channel outputs.")]
        public PwmChannels Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that current state of all PWM channel outputs.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that current state of all PWM channel outputs.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmChannelState.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that current state of the PWM execution.
    /// </summary>
    [DisplayName("PwmExecutionStatePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that current state of the PWM execution.")]
    public partial class CreatePwmExecutionStatePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that current state of the PWM execution.
        /// </summary>
        [Description("The value that current state of the PWM execution.")]
        public PwmChannels Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that current state of the PWM execution.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that current state of the PWM execution.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => PwmExecutionState.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that enables the generation of events.
    /// </summary>
    [DisplayName("EnableEventsPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that enables the generation of events.")]
    public partial class CreateEnableEventsPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that enables the generation of events.
        /// </summary>
        [Description("The value that enables the generation of events.")]
        public MultiPwmEvents Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that enables the generation of events.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that enables the generation of events.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => EnableEvents.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents the payload of the Trigger0Mode register.
    /// </summary>
    public struct Trigger0ModePayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trigger0ModePayload"/> structure.
        /// </summary>
        /// <param name="triggerMode">Specifies the trigger mode.</param>
        /// <param name="polarity">Specifies the polarity of the trigger signal.</param>
        public Trigger0ModePayload(
            TriggerModeConfig triggerMode,
            TriggerPolarity polarity)
        {
            TriggerMode = triggerMode;
            Polarity = polarity;
        }

        /// <summary>
        /// Specifies the trigger mode.
        /// </summary>
        public TriggerModeConfig TriggerMode;

        /// <summary>
        /// Specifies the polarity of the trigger signal.
        /// </summary>
        public TriggerPolarity Polarity;
    }

    /// <summary>
    /// Represents the payload of the Trigger1Mode register.
    /// </summary>
    public struct Trigger1ModePayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trigger1ModePayload"/> structure.
        /// </summary>
        /// <param name="triggerMode">Specifies the trigger mode.</param>
        /// <param name="polarity">Specifies the polarity of the trigger signal.</param>
        public Trigger1ModePayload(
            TriggerModeConfig triggerMode,
            TriggerPolarity polarity)
        {
            TriggerMode = triggerMode;
            Polarity = polarity;
        }

        /// <summary>
        /// Specifies the trigger mode.
        /// </summary>
        public TriggerModeConfig TriggerMode;

        /// <summary>
        /// Specifies the polarity of the trigger signal.
        /// </summary>
        public TriggerPolarity Polarity;
    }

    /// <summary>
    /// Represents the payload of the Trigger2Mode register.
    /// </summary>
    public struct Trigger2ModePayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trigger2ModePayload"/> structure.
        /// </summary>
        /// <param name="triggerMode">Specifies the trigger mode.</param>
        /// <param name="polarity">Specifies the polarity of the trigger signal.</param>
        public Trigger2ModePayload(
            TriggerModeConfig triggerMode,
            TriggerPolarity polarity)
        {
            TriggerMode = triggerMode;
            Polarity = polarity;
        }

        /// <summary>
        /// Specifies the trigger mode.
        /// </summary>
        public TriggerModeConfig TriggerMode;

        /// <summary>
        /// Specifies the polarity of the trigger signal.
        /// </summary>
        public TriggerPolarity Polarity;
    }

    /// <summary>
    /// Represents the payload of the Trigger3Mode register.
    /// </summary>
    public struct Trigger3ModePayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trigger3ModePayload"/> structure.
        /// </summary>
        /// <param name="triggerMode">Specifies the trigger mode.</param>
        /// <param name="polarity">Specifies the polarity of the trigger signal.</param>
        public Trigger3ModePayload(
            TriggerModeConfig triggerMode,
            TriggerPolarity polarity)
        {
            TriggerMode = triggerMode;
            Polarity = polarity;
        }

        /// <summary>
        /// Specifies the trigger mode.
        /// </summary>
        public TriggerModeConfig TriggerMode;

        /// <summary>
        /// Specifies the polarity of the trigger signal.
        /// </summary>
        public TriggerPolarity Polarity;
    }

    /// <summary>
    /// Represents the payload of the TriggerAllMode register.
    /// </summary>
    public struct TriggerAllModePayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerAllModePayload"/> structure.
        /// </summary>
        /// <param name="triggerMode">Specifies the trigger mode.</param>
        /// <param name="polarity">Specifies the polarity of the trigger signal.</param>
        public TriggerAllModePayload(
            TriggerAllModeConfig triggerMode,
            TriggerPolarity polarity)
        {
            TriggerMode = triggerMode;
            Polarity = polarity;
        }

        /// <summary>
        /// Specifies the trigger mode.
        /// </summary>
        public TriggerAllModeConfig TriggerMode;

        /// <summary>
        /// Specifies the polarity of the trigger signal.
        /// </summary>
        public TriggerPolarity Polarity;
    }

    /// <summary>
    /// Available PWM output channels.
    /// </summary>
    [Flags]
    public enum PwmChannels : byte
    {
        Channel0 = 0x0,
        Channel1 = 0x1,
        Channel2 = 0x2,
        Channel3 = 0x4
    }

    /// <summary>
    /// Available trigger input channels.
    /// </summary>
    [Flags]
    public enum TriggerInput : byte
    {
        Channel0 = 0x0,
        Channel1 = 0x1,
        Channel2 = 0x2,
        Channel3 = 0x4
    }

    /// <summary>
    /// Available events that can be enabled/disabled.
    /// </summary>
    [Flags]
    public enum MultiPwmEvents : byte
    {
        Execution = 0x1
    }

    /// <summary>
    /// Available playback modes of the PWM channel.
    /// </summary>
    public enum PlaybackMode : byte
    {
        Count = 0,
        Infinite = 1
    }

    /// <summary>
    /// Available operation modes for trigger input channels.
    /// </summary>
    public enum TriggerModeConfig : byte
    {
        Start = 0,
        StartAndStop = 1
    }

    /// <summary>
    /// Available polarity options for a trigger mode.
    /// </summary>
    public enum TriggerPolarity : byte
    {
        Default = 0,
        Inverted = 8
    }

    /// <summary>
    /// Available operation modes for "All" trigger input channel.
    /// </summary>
    public enum TriggerAllModeConfig : byte
    {
        Start = 0,
        StartAndStop = 1,
        Enable = 2,
        EnableAndStop = 3
    }
}
