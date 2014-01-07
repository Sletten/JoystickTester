using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;
using System.Diagnostics;

namespace JoystickTester
{
    public partial class JoystickView : Form
    {
        private Device joystick;

        private int roll = 0;
        private int pitch = 0;
        
        public JoystickView()
        {
            InitializeComponent();
        }

        private void JoystickView_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("load");
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
                this.Handle,
                CooperativeLevelFlags.NonExclusive |
                CooperativeLevelFlags.Background);

            //Acquire devices for capturing.
            joystick.Acquire();

            tmrUpdateStick.Enabled = true;
        }

        private void UpdateJoystick()
        {
            string info = "Joystick: \n";

            //Get Mouse State.
            JoystickState state = joystick.CurrentJoystickState;
            roll = state.X;
            pitch = state.Y;

            //Capture stick Position.
            info += "\nRoll: " + state.X;
            info += "\nPitch: " + state.Y;
            info += "\nYaw: " + state.Rz;

            //Capture throttle
            int throttle = state.GetSlider()[0];
            //Compensate for the default throttle range which is -100 to 100
            //We want it to go from 0 to 100
            int throttlePercentage = (throttle - 100) / -2;
            info += "\nThrottle: " + throttlePercentage;

            //Capture point-of-view hat
            int pov = state.GetPointOfView()[0];

            //Convert to degrees if hat is not in center
            if (pov != -1)
                pov /= 100;

            //hat is in center
            if (pov == -1) 
                info += "\nPoint-of-view hat: center";
            else
                info += "\nPoint-of-view hat: " + pov + " degrees";

            //Capture Buttons.
            byte[] buttons = state.GetButtons();
            Boolean buttonPushed = false;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] != 0)
                {
                    buttonPushed = true;
                    info += "\nButton: " + (i + 1);
                }
            }

            //displat this if no button is pushed
            if (!buttonPushed)
            {
                info += "\nButton: none";
            }

            //Update throttle tracker
            trkThrottle.Value = throttlePercentage;

            //Update yaw tracker
            trkYaw.Value = state.Rz;

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // get the graphics object to use to draw
            Graphics g = pe.Graphics;

            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.White);

            g.FillRectangle(brush, 10, 10, 210, 210);
            g.DrawRectangle(pen, 10, 10, 210, 210);
            g.DrawRectangle(pen, 110+roll, 110+pitch, 10, 10);
        }

        private void tmrUpdateStick_Tick(object sender, EventArgs e)
        {
            UpdateJoystick();
        }
    }
}
