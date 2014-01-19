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
            this.lblRoll = new System.Windows.Forms.Label();
            this.lblPitch = new System.Windows.Forms.Label();
            this.lblYaw = new System.Windows.Forms.Label();
            this.lblThrottle = new System.Windows.Forms.Label();
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
            this.trkThrottle.Maximum = 250;
            this.trkThrottle.Name = "trkThrottle";
            this.trkThrottle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkThrottle.Size = new System.Drawing.Size(45, 210);
            this.trkThrottle.TabIndex = 1;
            this.trkThrottle.TickFrequency = 10;
            // 
            // trkYaw
            // 
            this.trkYaw.Location = new System.Drawing.Point(12, 237);
            this.trkYaw.Maximum = 250;
            this.trkYaw.Name = "trkYaw";
            this.trkYaw.Size = new System.Drawing.Size(210, 45);
            this.trkYaw.TabIndex = 2;
            this.trkYaw.TickFrequency = 10;
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.Location = new System.Drawing.Point(543, 22);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(31, 13);
            this.lblRoll.TabIndex = 3;
            this.lblRoll.Text = "Roll: ";
            // 
            // lblPitch
            // 
            this.lblPitch.AutoSize = true;
            this.lblPitch.Location = new System.Drawing.Point(543, 61);
            this.lblPitch.Name = "lblPitch";
            this.lblPitch.Size = new System.Drawing.Size(37, 13);
            this.lblPitch.TabIndex = 4;
            this.lblPitch.Text = "Pitch: ";
            // 
            // lblYaw
            // 
            this.lblYaw.AutoSize = true;
            this.lblYaw.Location = new System.Drawing.Point(543, 99);
            this.lblYaw.Name = "lblYaw";
            this.lblYaw.Size = new System.Drawing.Size(34, 13);
            this.lblYaw.TabIndex = 5;
            this.lblYaw.Text = "Yaw: ";
            // 
            // lblThrottle
            // 
            this.lblThrottle.AutoSize = true;
            this.lblThrottle.Location = new System.Drawing.Point(543, 138);
            this.lblThrottle.Name = "lblThrottle";
            this.lblThrottle.Size = new System.Drawing.Size(49, 13);
            this.lblThrottle.TabIndex = 6;
            this.lblThrottle.Text = "Throttle: ";
            // 
            // JoystickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 298);
            this.Controls.Add(this.lblThrottle);
            this.Controls.Add(this.lblYaw);
            this.Controls.Add(this.lblPitch);
            this.Controls.Add(this.lblRoll);
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
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label lblPitch;
        private System.Windows.Forms.Label lblYaw;
        private System.Windows.Forms.Label lblThrottle;
    }
}

