namespace JoystickTester
{
    partial class JoystickView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrUpdateStick = new System.Windows.Forms.Timer(this.components);
            this.trkThrottle = new System.Windows.Forms.TrackBar();
            this.trkYaw = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trkThrottle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrUpdateStick
            // 
            this.tmrUpdateStick.Interval = 10;
            this.tmrUpdateStick.Tick += new System.EventHandler(this.tmrUpdateStick_Tick);
            // 
            // trkThrottle
            // 
            this.trkThrottle.Location = new System.Drawing.Point(257, 12);
            this.trkThrottle.Maximum = 100;
            this.trkThrottle.Name = "trkThrottle";
            this.trkThrottle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkThrottle.Size = new System.Drawing.Size(45, 210);
            this.trkThrottle.TabIndex = 1;
            this.trkThrottle.TickFrequency = 10;
            // 
            // trkYaw
            // 
            this.trkYaw.Location = new System.Drawing.Point(12, 237);
            this.trkYaw.Maximum = 100;
            this.trkYaw.Minimum = -100;
            this.trkYaw.Name = "trkYaw";
            this.trkYaw.Size = new System.Drawing.Size(210, 45);
            this.trkYaw.TabIndex = 2;
            this.trkYaw.TickFrequency = 10;
            // 
            // JoystickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 298);
            this.Controls.Add(this.trkYaw);
            this.Controls.Add(this.trkThrottle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "JoystickView";
            this.Text = "Joystick Tester";
            this.Load += new System.EventHandler(this.JoystickView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkThrottle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrUpdateStick;
        private System.Windows.Forms.TrackBar trkThrottle;
        private System.Windows.Forms.TrackBar trkYaw;
    }
}

