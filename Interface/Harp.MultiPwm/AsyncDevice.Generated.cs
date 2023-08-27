using Bonsai.Harp;
using System.Threading.Tasks;

namespace Harp.MultiPwm
{
    /// <inheritdoc/>
    public partial class Device
    {
        /// <summary>
        /// Initializes a new instance of the asynchronous API to configure and interface
        /// with MultiPwm devices on the specified serial port.
        /// </summary>
        /// <param name="portName">
        /// The name of the serial port used to communicate with the Harp device.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous initialization operation. The value of
        /// the <see cref="Task{TResult}.Result"/> parameter contains a new instance of
        /// the <see cref="AsyncDevice"/> class.
        /// </returns>
        public static async Task<AsyncDevice> CreateAsync(string portName)
        {
            var device = new AsyncDevice(portName);
            var whoAmI = await device.ReadWhoAmIAsync();
            if (whoAmI != Device.WhoAmI)
            {
                var errorMessage = string.Format(
                    "The device ID {1} on {0} was unexpected. Check whether a MultiPwm device is connected to the specified serial port.",
                    portName, whoAmI);
                throw new HarpException(errorMessage);
            }

            return device;
        }
    }

    /// <summary>
    /// Represents an asynchronous API to configure and interface with MultiPwm devices.
    /// </summary>
    public partial class AsyncDevice : Bonsai.Harp.AsyncDevice
    {
        internal AsyncDevice(string portName)
            : base(portName)
        {
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel0Frequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel0FrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel0Frequency.Address));
            return PwmChannel0Frequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel0Frequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel0FrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel0Frequency.Address));
            return PwmChannel0Frequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel0Frequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel0FrequencyAsync(float value)
        {
            var request = PwmChannel0Frequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel1Frequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel1FrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel1Frequency.Address));
            return PwmChannel1Frequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel1Frequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel1FrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel1Frequency.Address));
            return PwmChannel1Frequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel1Frequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel1FrequencyAsync(float value)
        {
            var request = PwmChannel1Frequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel2Frequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel2FrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel2Frequency.Address));
            return PwmChannel2Frequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel2Frequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel2FrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel2Frequency.Address));
            return PwmChannel2Frequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel2Frequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel2FrequencyAsync(float value)
        {
            var request = PwmChannel2Frequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel3Frequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel3FrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel3Frequency.Address));
            return PwmChannel3Frequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel3Frequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel3FrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel3Frequency.Address));
            return PwmChannel3Frequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel3Frequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel3FrequencyAsync(float value)
        {
            var request = PwmChannel3Frequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel0DutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel0DutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel0DutyCycle.Address));
            return PwmChannel0DutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel0DutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel0DutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel0DutyCycle.Address));
            return PwmChannel0DutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel0DutyCycle register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel0DutyCycleAsync(float value)
        {
            var request = PwmChannel0DutyCycle.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel1DutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel1DutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel1DutyCycle.Address));
            return PwmChannel1DutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel1DutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel1DutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel1DutyCycle.Address));
            return PwmChannel1DutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel1DutyCycle register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel1DutyCycleAsync(float value)
        {
            var request = PwmChannel1DutyCycle.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel2DutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel2DutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel2DutyCycle.Address));
            return PwmChannel2DutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel2DutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel2DutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel2DutyCycle.Address));
            return PwmChannel2DutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel2DutyCycle register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel2DutyCycleAsync(float value)
        {
            var request = PwmChannel2DutyCycle.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel3DutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel3DutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel3DutyCycle.Address));
            return PwmChannel3DutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel3DutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel3DutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel3DutyCycle.Address));
            return PwmChannel3DutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel3DutyCycle register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel3DutyCycleAsync(float value)
        {
            var request = PwmChannel3DutyCycle.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel0NumPulses register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<uint> ReadPwmChannel0NumPulsesAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(PwmChannel0NumPulses.Address));
            return PwmChannel0NumPulses.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel0NumPulses register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<uint>> ReadTimestampedPwmChannel0NumPulsesAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(PwmChannel0NumPulses.Address));
            return PwmChannel0NumPulses.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel0NumPulses register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel0NumPulsesAsync(uint value)
        {
            var request = PwmChannel0NumPulses.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel1NumPulses register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<uint> ReadPwmChannel1NumPulsesAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(PwmChannel1NumPulses.Address));
            return PwmChannel1NumPulses.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel1NumPulses register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<uint>> ReadTimestampedPwmChannel1NumPulsesAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(PwmChannel1NumPulses.Address));
            return PwmChannel1NumPulses.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel1NumPulses register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel1NumPulsesAsync(uint value)
        {
            var request = PwmChannel1NumPulses.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel2NumPulses register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<uint> ReadPwmChannel2NumPulsesAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(PwmChannel2NumPulses.Address));
            return PwmChannel2NumPulses.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel2NumPulses register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<uint>> ReadTimestampedPwmChannel2NumPulsesAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(PwmChannel2NumPulses.Address));
            return PwmChannel2NumPulses.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel2NumPulses register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel2NumPulsesAsync(uint value)
        {
            var request = PwmChannel2NumPulses.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel3NumPulses register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<uint> ReadPwmChannel3NumPulsesAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(PwmChannel3NumPulses.Address));
            return PwmChannel3NumPulses.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel3NumPulses register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<uint>> ReadTimestampedPwmChannel3NumPulsesAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(PwmChannel3NumPulses.Address));
            return PwmChannel3NumPulses.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel3NumPulses register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel3NumPulsesAsync(uint value)
        {
            var request = PwmChannel3NumPulses.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel0RealFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel0RealFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel0RealFrequency.Address));
            return PwmChannel0RealFrequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel0RealFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel0RealFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel0RealFrequency.Address));
            return PwmChannel0RealFrequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel0RealFrequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel0RealFrequencyAsync(float value)
        {
            var request = PwmChannel0RealFrequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel1RealFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel1RealFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel1RealFrequency.Address));
            return PwmChannel1RealFrequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel1RealFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel1RealFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel1RealFrequency.Address));
            return PwmChannel1RealFrequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel1RealFrequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel1RealFrequencyAsync(float value)
        {
            var request = PwmChannel1RealFrequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel2RealFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel2RealFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel2RealFrequency.Address));
            return PwmChannel2RealFrequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel2RealFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel2RealFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel2RealFrequency.Address));
            return PwmChannel2RealFrequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel2RealFrequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel2RealFrequencyAsync(float value)
        {
            var request = PwmChannel2RealFrequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel3RealFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel3RealFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel3RealFrequency.Address));
            return PwmChannel3RealFrequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel3RealFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel3RealFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel3RealFrequency.Address));
            return PwmChannel3RealFrequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel3RealFrequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel3RealFrequencyAsync(float value)
        {
            var request = PwmChannel3RealFrequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel0RealDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel0RealDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel0RealDutyCycle.Address));
            return PwmChannel0RealDutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel0RealDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel0RealDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel0RealDutyCycle.Address));
            return PwmChannel0RealDutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel1RealDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel1RealDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel1RealDutyCycle.Address));
            return PwmChannel1RealDutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel1RealDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel1RealDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel1RealDutyCycle.Address));
            return PwmChannel1RealDutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel2RealDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel2RealDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel2RealDutyCycle.Address));
            return PwmChannel2RealDutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel2RealDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel2RealDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel2RealDutyCycle.Address));
            return PwmChannel2RealDutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel3RealDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadPwmChannel3RealDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel3RealDutyCycle.Address));
            return PwmChannel3RealDutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel3RealDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedPwmChannel3RealDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(PwmChannel3RealDutyCycle.Address));
            return PwmChannel3RealDutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel0PlaybackMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmPlaybackMode> ReadPwmChannel0PlaybackModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannel0PlaybackMode.Address));
            return PwmChannel0PlaybackMode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel0PlaybackMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmPlaybackMode>> ReadTimestampedPwmChannel0PlaybackModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannel0PlaybackMode.Address));
            return PwmChannel0PlaybackMode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel0PlaybackMode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel0PlaybackModeAsync(PwmPlaybackMode value)
        {
            var request = PwmChannel0PlaybackMode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel1PlaybackMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmPlaybackMode> ReadPwmChannel1PlaybackModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannel1PlaybackMode.Address));
            return PwmChannel1PlaybackMode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel1PlaybackMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmPlaybackMode>> ReadTimestampedPwmChannel1PlaybackModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannel1PlaybackMode.Address));
            return PwmChannel1PlaybackMode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel1PlaybackMode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel1PlaybackModeAsync(PwmPlaybackMode value)
        {
            var request = PwmChannel1PlaybackMode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel2PlaybackMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmPlaybackMode> ReadPwmChannel2PlaybackModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannel2PlaybackMode.Address));
            return PwmChannel2PlaybackMode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel2PlaybackMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmPlaybackMode>> ReadTimestampedPwmChannel2PlaybackModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannel2PlaybackMode.Address));
            return PwmChannel2PlaybackMode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel2PlaybackMode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel2PlaybackModeAsync(PwmPlaybackMode value)
        {
            var request = PwmChannel2PlaybackMode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannel3PlaybackMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmPlaybackMode> ReadPwmChannel3PlaybackModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannel3PlaybackMode.Address));
            return PwmChannel3PlaybackMode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannel3PlaybackMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmPlaybackMode>> ReadTimestampedPwmChannel3PlaybackModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannel3PlaybackMode.Address));
            return PwmChannel3PlaybackMode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PwmChannel3PlaybackMode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePwmChannel3PlaybackModeAsync(PwmPlaybackMode value)
        {
            var request = PwmChannel3PlaybackMode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Trigger0Targets register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmChannels> ReadTrigger0TargetsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger0Targets.Address));
            return Trigger0Targets.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Trigger0Targets register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmChannels>> ReadTimestampedTrigger0TargetsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger0Targets.Address));
            return Trigger0Targets.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Trigger0Targets register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTrigger0TargetsAsync(PwmChannels value)
        {
            var request = Trigger0Targets.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Trigger1Targets register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmChannels> ReadTrigger1TargetsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger1Targets.Address));
            return Trigger1Targets.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Trigger1Targets register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmChannels>> ReadTimestampedTrigger1TargetsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger1Targets.Address));
            return Trigger1Targets.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Trigger1Targets register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTrigger1TargetsAsync(PwmChannels value)
        {
            var request = Trigger1Targets.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Trigger2Targets register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmChannels> ReadTrigger2TargetsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger2Targets.Address));
            return Trigger2Targets.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Trigger2Targets register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmChannels>> ReadTimestampedTrigger2TargetsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger2Targets.Address));
            return Trigger2Targets.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Trigger2Targets register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTrigger2TargetsAsync(PwmChannels value)
        {
            var request = Trigger2Targets.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Trigger3Targets register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmChannels> ReadTrigger3TargetsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger3Targets.Address));
            return Trigger3Targets.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Trigger3Targets register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmChannels>> ReadTimestampedTrigger3TargetsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger3Targets.Address));
            return Trigger3Targets.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Trigger3Targets register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTrigger3TargetsAsync(PwmChannels value)
        {
            var request = Trigger3Targets.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the StartSoftwareTrigger register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<TriggerInput> ReadStartSoftwareTriggerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StartSoftwareTrigger.Address));
            return StartSoftwareTrigger.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the StartSoftwareTrigger register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<TriggerInput>> ReadTimestampedStartSoftwareTriggerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StartSoftwareTrigger.Address));
            return StartSoftwareTrigger.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the StartSoftwareTrigger register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteStartSoftwareTriggerAsync(TriggerInput value)
        {
            var request = StartSoftwareTrigger.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the StopSoftwareTrigger register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<TriggerInput> ReadStopSoftwareTriggerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StopSoftwareTrigger.Address));
            return StopSoftwareTrigger.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the StopSoftwareTrigger register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<TriggerInput>> ReadTimestampedStopSoftwareTriggerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StopSoftwareTrigger.Address));
            return StopSoftwareTrigger.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the StopSoftwareTrigger register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteStopSoftwareTriggerAsync(TriggerInput value)
        {
            var request = StopSoftwareTrigger.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the ArmPwmChannels register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmChannels> ReadArmPwmChannelsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ArmPwmChannels.Address));
            return ArmPwmChannels.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the ArmPwmChannels register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmChannels>> ReadTimestampedArmPwmChannelsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ArmPwmChannels.Address));
            return ArmPwmChannels.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the ArmPwmChannels register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteArmPwmChannelsAsync(PwmChannels value)
        {
            var request = ArmPwmChannels.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Trigger0Mode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<Trigger0ModePayload> ReadTrigger0ModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger0Mode.Address));
            return Trigger0Mode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Trigger0Mode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<Trigger0ModePayload>> ReadTimestampedTrigger0ModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger0Mode.Address));
            return Trigger0Mode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Trigger0Mode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTrigger0ModeAsync(Trigger0ModePayload value)
        {
            var request = Trigger0Mode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Trigger1Mode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<Trigger1ModePayload> ReadTrigger1ModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger1Mode.Address));
            return Trigger1Mode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Trigger1Mode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<Trigger1ModePayload>> ReadTimestampedTrigger1ModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger1Mode.Address));
            return Trigger1Mode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Trigger1Mode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTrigger1ModeAsync(Trigger1ModePayload value)
        {
            var request = Trigger1Mode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Trigger2Mode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<Trigger2ModePayload> ReadTrigger2ModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger2Mode.Address));
            return Trigger2Mode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Trigger2Mode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<Trigger2ModePayload>> ReadTimestampedTrigger2ModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger2Mode.Address));
            return Trigger2Mode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Trigger2Mode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTrigger2ModeAsync(Trigger2ModePayload value)
        {
            var request = Trigger2Mode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Trigger3Mode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<Trigger3ModePayload> ReadTrigger3ModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger3Mode.Address));
            return Trigger3Mode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Trigger3Mode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<Trigger3ModePayload>> ReadTimestampedTrigger3ModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Trigger3Mode.Address));
            return Trigger3Mode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Trigger3Mode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTrigger3ModeAsync(Trigger3ModePayload value)
        {
            var request = Trigger3Mode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the RequestEnable register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmChannels> ReadRequestEnableAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(RequestEnable.Address));
            return RequestEnable.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the RequestEnable register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmChannels>> ReadTimestampedRequestEnableAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(RequestEnable.Address));
            return RequestEnable.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the RequestEnable register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteRequestEnableAsync(PwmChannels value)
        {
            var request = RequestEnable.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the EnablePwmChannels register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmChannels> ReadEnablePwmChannelsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnablePwmChannels.Address));
            return EnablePwmChannels.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the EnablePwmChannels register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmChannels>> ReadTimestampedEnablePwmChannelsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnablePwmChannels.Address));
            return EnablePwmChannels.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the EnablePwmChannels register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteEnablePwmChannelsAsync(PwmChannels value)
        {
            var request = EnablePwmChannels.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerAllMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<TriggerAllModePayload> ReadTriggerAllModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerAllMode.Address));
            return TriggerAllMode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerAllMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<TriggerAllModePayload>> ReadTimestampedTriggerAllModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerAllMode.Address));
            return TriggerAllMode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the TriggerAllMode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTriggerAllModeAsync(TriggerAllModePayload value)
        {
            var request = TriggerAllMode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerChannelState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<TriggerInput> ReadTriggerChannelStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerChannelState.Address));
            return TriggerChannelState.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerChannelState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<TriggerInput>> ReadTimestampedTriggerChannelStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerChannelState.Address));
            return TriggerChannelState.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmChannelState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmChannels> ReadPwmChannelStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannelState.Address));
            return PwmChannelState.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmChannelState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmChannels>> ReadTimestampedPwmChannelStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmChannelState.Address));
            return PwmChannelState.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PwmExecutionState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PwmChannels> ReadPwmExecutionStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmExecutionState.Address));
            return PwmExecutionState.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PwmExecutionState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PwmChannels>> ReadTimestampedPwmExecutionStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PwmExecutionState.Address));
            return PwmExecutionState.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the EnableEvents register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<MultiPwmEvents> ReadEnableEventsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableEvents.Address));
            return EnableEvents.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the EnableEvents register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<MultiPwmEvents>> ReadTimestampedEnableEventsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableEvents.Address));
            return EnableEvents.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the EnableEvents register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteEnableEventsAsync(MultiPwmEvents value)
        {
            var request = EnableEvents.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }
    }
}
