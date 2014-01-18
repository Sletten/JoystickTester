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

        //Create something we can draw with
        private Pen pen;
        private Brush whiteBrush;
        private Brush blackBrush;
        private Font font;
        
        public JoystickView()
        {
            InitializeComponent();

            pen = new Pen(Color.Black);
            whiteBrush = new SolidBrush(Color.White);
            blackBrush = new SolidBrush(Color.Black);
            font = new Font("Arial", 10); 
        }

        private void JoystickView_Load(object sender, EventArgs e)
        {
            joystick = new Joystick(this.Handle);
            joystick.Acquire();

            tmrUpdateStick.Enabled = true;
        }

        private void UpdateJoystick()
        {
            //Capture stick Position.
            roll = joystick.Roll();
            pitch = joystick.Pitch();

            //Capture point-of-view hat
            pov = joystick.PointOfView();

            updateThrottleTracker();
            updateYawTracker();

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //Paint the base before we do anything else
            base.OnPaint(pe);

            // get the graphics object to use to draw
            Graphics g = pe.Graphics;

            drawJoystickPosition(g);
            drawPoV(g);
            drawButtons(g);
        }

        private void updateYawTracker()
        {
            //Update yaw tracker
            int yaw = joystick.Yaw();
            if (yaw >= -100 && yaw <= 100)
                trkYaw.Value = yaw;
        }

        private void updateThrottleTracker()
        {
            //Update throttle tracker
            int throttlePercentage = joystick.Throttle();
            if (throttlePercentage >= 0 && throttlePercentage <= 100)
                trkThrottle.Value = throttlePercentage;
        }

        private void drawJoystickPosition(Graphics g)
        {
            //Joystick position
            g.FillRectangle(whiteBrush, 10, 10, 210, 210);
            g.DrawRectangle(pen, 10, 10, 210, 210);
            g.FillRectangle(blackBrush, 110 + roll, 110 + pitch, 10, 10);
        }

        private void drawPoV(Graphics g)
        {
            //Circles of PoV
            for (int i = 0; i < 8; i++)
            {
                int x = (int)(50 * Math.Cos(2 * Math.PI * i / 8));
                int y = (int)(50 * Math.Sin(2 * Math.PI * i / 8));
                g.DrawEllipse(pen, x + 400, y + 70, 20, 20);
            }

            //Fill the correct circle when PoV hat is not in center
            if (pov != -1)
            {
                int xPressed = (int)(50 * Math.Cos(2 * Math.PI * (pov / 45 - 2) / 8));
                int yPressed = (int)(50 * Math.Sin(2 * Math.PI * (pov / 45 - 2) / 8));
                g.FillEllipse(blackBrush, xPressed + 400, yPressed + 70, 20, 20);
            }
            else
            {
                //Fill center if PoV hat is not used
                g.FillEllipse(blackBrush, 400, 70, 20, 20);
            }
        }

        private void drawButtons(Graphics g)
        {
            //Gauge for 10 buttons.
            for (int i = 0; i < 10; i++)
            {
                //Highlight buttons that are pressed
                if (joystick.Buttons()[i] != 0)
                {
                    g.FillEllipse(blackBrush, (350 + i * 30), 200, 20, 20);
                    g.DrawString((i + 1).ToString(), font, whiteBrush, new PointF((353 + i * 30.0F), 203.0F));
                }
                else
                {
                    g.DrawEllipse(pen, (350 + i * 30), 200, 20, 20);
                    g.DrawString((i + 1).ToString(), font, blackBrush, new PointF((353 + i * 30.0F), 203.0F));
                }
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
