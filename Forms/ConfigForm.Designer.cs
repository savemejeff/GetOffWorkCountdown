
namespace GetOffWorkCountdown.Forms
{
    partial class ConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.OnHour = new System.Windows.Forms.NumericUpDown();
            this.OnMinute = new System.Windows.Forms.NumericUpDown();
            this.OffMinute = new System.Windows.Forms.NumericUpDown();
            this.OffHour = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ComfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OnHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffHour)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "On";
            // 
            // OnHour
            // 
            this.OnHour.Location = new System.Drawing.Point(59, 25);
            this.OnHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.OnHour.Name = "OnHour";
            this.OnHour.Size = new System.Drawing.Size(43, 21);
            this.OnHour.TabIndex = 2;
            // 
            // OnMinute
            // 
            this.OnMinute.Location = new System.Drawing.Point(108, 25);
            this.OnMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.OnMinute.Name = "OnMinute";
            this.OnMinute.Size = new System.Drawing.Size(42, 21);
            this.OnMinute.TabIndex = 3;
            // 
            // OffMinute
            // 
            this.OffMinute.Location = new System.Drawing.Point(108, 52);
            this.OffMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.OffMinute.Name = "OffMinute";
            this.OffMinute.Size = new System.Drawing.Size(42, 21);
            this.OffMinute.TabIndex = 6;
            // 
            // OffHour
            // 
            this.OffHour.Location = new System.Drawing.Point(59, 52);
            this.OffHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.OffHour.Name = "OffHour";
            this.OffHour.Size = new System.Drawing.Size(43, 21);
            this.OffHour.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Off";
            // 
            // ComfirmButton
            // 
            this.ComfirmButton.Location = new System.Drawing.Point(12, 80);
            this.ComfirmButton.Name = "ComfirmButton";
            this.ComfirmButton.Size = new System.Drawing.Size(66, 23);
            this.ComfirmButton.TabIndex = 7;
            this.ComfirmButton.Text = "Confirm";
            this.ComfirmButton.UseVisualStyleBackColor = true;
            this.ComfirmButton.Click += new System.EventHandler(this.ComfirmButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(84, 79);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(60, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 115);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ComfirmButton);
            this.Controls.Add(this.OffMinute);
            this.Controls.Add(this.OffHour);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OnMinute);
            this.Controls.Add(this.OnHour);
            this.Controls.Add(this.label1);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OnHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown OnHour;
        private System.Windows.Forms.NumericUpDown OnMinute;
        private System.Windows.Forms.NumericUpDown OffMinute;
        private System.Windows.Forms.NumericUpDown OffHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ComfirmButton;
        private System.Windows.Forms.Button CancelButton;
    }
}