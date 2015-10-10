using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UisSubsea.RovTopside.Data
{
    public class MainPacketBuilder : PacketBuilder
    {
        private IJoystick joystick;
        private int negativePitch, negativeRoll;

        private int checkValueRoll = 0;
        private int checkValuePitch = 0;
        private Boolean reverse;

        private byte roll, pitch;

        public MainPacketBuilder(IJoystick joystick)
            : base(joystick)
        {
            this.joystick = joystick;
        }

        public void ToggleReverse()
        {
            if (joystickIsInNeutral())
            {
                if (reverse)
                    reverse = false;
                else
                    reverse = true;
            }
        }

        public override byte[] BuildJoystickStatePacket()
        {
            /*
            if (reverse)
            {
                roll = TransformRollToOpposite();
                pitch = TransformPitchToOpposite();
                return new byte[]
               {
                   roll,
                   pitch,
                   Yaw(),
                   Throttle(),
                   ButtonsPressed(),
                   HatPov(),
               };
            } 
            else*/ // not using this part for now
            {
                return new byte[]
                {
                    Roll(),
                    Pitch(),
                    Throttle(),
                    Yaw(),
                 };
            }
        }

        private Boolean joystickIsInNeutral()
        {
            if (joystick.Pitch() == 128 && joystick.Roll() == 128)
                return true;
            else
                return false;
        }

        private byte TransformPitchToOpposite()
        {
            int temp = joystick.Pitch();

            checkValuePitch = temp - 128;
            if (checkValuePitch > 0)
            {
                negativePitch = 128 - checkValuePitch;
            }
            else
            {
                checkValuePitch *= -1;
                negativePitch = 128 + checkValuePitch;
                checkValuePitch = 0;
            }

            return (byte)negativePitch;
        }
        private byte TransformRollToOpposite()
        {
            int temp = joystick.Roll();

            checkValueRoll = temp - 128;
            if (checkValueRoll > 0)
            {
                negativeRoll = 128 - checkValueRoll;
            }
            else
            {
                checkValueRoll *= -1;
                negativeRoll = 128 + checkValueRoll;
                checkValueRoll = 0;
            }

            return (byte)negativeRoll;

        }
    }
}

