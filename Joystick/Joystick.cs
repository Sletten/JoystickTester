using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DirectX.DirectInput;

namespace JoystickInterface
{
    public class Joystick
    {
        private Device joystick;
        private JoystickState state;

        public Joystick(IntPtr windowHandle) {
            createJoystick();
            configureJoystick(windowHandle);
        }

        public void UpdateState()
        {
            state = joystick.CurrentJoystickState;
        }

        public JoystickState State()
        {
            return joystick.CurrentJoystickState;
        }

        public int Roll()
        {
            return state.X;
        }

        public int Pitch()
        {
            return state.Y;
        }

        public int Yaw()
        {
            return state.Rz;
        }

        public void Acquire()
        {
            //Acquire device for capturing.
            joystick.Acquire();
        }

        public void Unacquire()
        {
            //Unacquire device for capturing.
            joystick.Unacquire();
        }

        public int Throttle()
        {
            //Capture throttle
            int throttle = state.GetSlider()[0];
            //Compensate for the default throttle range which is -100 to 100
            //We want it to go from 0 to 100
            int throttlePercentage = (throttle - 100) / -2;
            return throttlePercentage;
        }

        public int PointOfView()
        {
            //Capture point-of-view hat
            int pov = state.GetPointOfView()[0];

            //Convert to degrees if hat is not in center
            if (pov != -1)
                pov /= 100;

            return pov;
        }

        public byte[] Buttons()
        {
            //Capture Buttons.
            byte[] buttons = state.GetButtons();
            if (buttons != null)
                return buttons;
            else
                return new byte[128];
        }

        private void createJoystick() {
            //create joystick device.
            foreach (
                DeviceInstance di in
                Manager.GetDevices(
                    DeviceClass.GameControl,
                    EnumDevicesFlags.AttachedOnly))
            {
                joystick = new Device(di.InstanceGuid);
                break;
            }

            if (joystick == null)
            {
                //Throw exception if joystick not found.
                throw new Exception("No joystick found.");
            }

        }

        private void configureJoystick(IntPtr windowHandle)
        {
            //Set joystick axis ranges.
            foreach (DeviceObjectInstance doi in joystick.Objects)
            {
                if ((doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
                {
                    joystick.Properties.SetRange(
                        ParameterHow.ById,
                        doi.ObjectId,
                        new InputRange(-100, 100));
                }
            }

            //Set joystick axis mode absolute.
            joystick.Properties.AxisModeAbsolute = true;


            joystick.SetCooperativeLevel(
                windowHandle,
                CooperativeLevelFlags.NonExclusive |
                CooperativeLevelFlags.Background);
        }
    }
}
