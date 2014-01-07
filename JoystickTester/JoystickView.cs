using Microsoft.DirectX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JoystickInterface;


namespace JoystickTester
{
    public partial class JoystickView : Form
    {
        private Joystick joystick;

        private int roll = 0;
        private int pitch = 0;
        private int pov = -1;
        
        public JoystickView()
        {
            InitializeComponent();
        }

        private void JoystickView_Load(object sender, EventArgs e)
        {
            joystick = new Joystick(this.Handle);
            joystick.Acquire();

            tmrUpdateStick.Enabled = true;
        }

        private void UpdateJoystick()
        {

            joystick.UpdateState();
     
            //Capture stick Position.
            roll = joystick.Roll();
            pitch = joystick.Pitch();

            //Capture point-of-view hat
            pov = joystick.PointOfView();

            //Capture Buttons.
            byte[] buttons = joystick.Buttons();
            Boolean buttonPushed = false;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] != 0)
                {
                    buttonPushed = true;
                    //button i+1 pressed
                }
            }

            //display this if no button is pushed
            if (!buttonPushed)
            {
                //none
            }

            //Update throttle tracker
            int throttlePercentage = joystick.Throttle();
            if (throttlePercentage >= 0 && throttlePercentage <= 100)
                trkThrottle.Value = throttlePercentage;

            //Update yaw tracker
            int yaw = joystick.Yaw();
            if ( yaw >= -100 && yaw <= 100)
                trkYaw.Value = yaw;

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //Paint the base before we do anything else
            base.OnPaint(pe);

            // get the graphics object to use to draw
            Graphics g = pe.Graphics;

            //Create something we can draw with
            Pen pen = new Pen(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush blackBrush = new SolidBrush(Color.Black);

            //Joystick position
            g.FillRectangle(whiteBrush, 10, 10, 210, 210);
            g.DrawRectangle(pen, 10, 10, 210, 210);
            g.FillRectangle(blackBrush, 110+roll, 110+pitch, 10, 10);

            //Circles of PoV
            for (int i = 0; i < 8; i++)
            {
                int x = (int)(50 * Math.Cos(2 * Math.PI * i / 8));
                int y = (int)(50 * Math.Sin(2 * Math.PI * i / 8));
                g.DrawEllipse(pen, x + 400, y + 100, 20, 20);
            }

            //Fill the correct circle when PoV hat is not in center
            if (pov != -1)
            {
                int xPressed = (int)(50 * Math.Cos(2 * Math.PI * (pov/45-2) / 8));
                int yPressed = (int)(50 * Math.Sin(2 * Math.PI * (pov/45-2) / 8));
                g.FillEllipse(blackBrush, xPressed + 400, yPressed + 100, 20, 20);
            }
            else
            {
                //Fill center if PoV hat is not used
                g.FillEllipse(blackBrush, 400, 100, 20, 20);
            }
        }

        private void tmrUpdateStick_Tick(object sender, EventArgs e)
        {
            UpdateJoystick();
        }

        private void JoystickView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            joystick.Unacquire();
        }
    }
}
