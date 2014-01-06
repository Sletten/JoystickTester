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
            this.lblJoystick = new System.Windows.Forms.Label();
            this.tmrUpdateStick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblJoystick
            // 
            this.lblJoystick.AutoSize = true;
            this.lblJoystick.Location = new System.Drawing.Point(12, 9);
            this.lblJoystick.Name = "lblJoystick";
            this.lblJoystick.Size = new System.Drawing.Size(45, 13);
            this.lblJoystick.TabIndex = 0;
            this.lblJoystick.Text = "Joystick";
            // 
            // tmrUpdateStick
            // 
            this.tmrUpdateStick.Tick += new System.EventHandler(this.tmrUpdateStick_Tick);
            // 
            // JoystickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblJoystick);
            this.Name = "JoystickView";
            this.Text = "Joystick Tester";
            this.Load += new System.EventHandler(this.JoystickView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJoystick;
        private System.Windows.Forms.Timer tmrUpdateStick;
    }
}

