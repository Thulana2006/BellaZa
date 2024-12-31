namespace BellaZa.Components
{
    partial class OrderUIComponent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDetails = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelState = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelPaidState = new System.Windows.Forms.Label();
            this.labelMode = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.labelDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 107);
            this.panel1.TabIndex = 0;
            // 
            // labelDetails
            // 
            this.labelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDetails.Location = new System.Drawing.Point(0, 0);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(163, 107);
            this.labelDetails.TabIndex = 0;
            this.labelDetails.Text = "Pizza ingredients";
            this.labelDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelState);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(167, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 107);
            this.panel2.TabIndex = 1;
            // 
            // labelState
            // 
            this.labelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelState.Location = new System.Drawing.Point(0, 0);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(141, 107);
            this.labelState.TabIndex = 0;
            this.labelState.Text = "Delivering";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.buttonCancel);
            this.panel3.Controls.Add(this.labelPaidState);
            this.panel3.Controls.Add(this.labelMode);
            this.panel3.Controls.Add(this.labelPrice);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(308, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 107);
            this.panel3.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(3, 82);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelPaidState
            // 
            this.labelPaidState.AutoSize = true;
            this.labelPaidState.Location = new System.Drawing.Point(6, 5);
            this.labelPaidState.Name = "labelPaidState";
            this.labelPaidState.Size = new System.Drawing.Size(32, 13);
            this.labelPaidState.TabIndex = 4;
            this.labelPaidState.Text = "PAID";
            this.labelPaidState.TextChanged += new System.EventHandler(this.labelStates_TextChanged);
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Location = new System.Drawing.Point(165, 5);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(60, 13);
            this.labelMode.TabIndex = 3;
            this.labelMode.Text = "DELIVERY";
            this.labelMode.TextChanged += new System.EventHandler(this.labelStates_TextChanged);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(61, 39);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(90, 24);
            this.labelPrice.TabIndex = 2;
            this.labelPrice.Text = "3120 LKR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "rating";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(149, 85);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            65536});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(71, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // OrderUIComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OrderUIComponent";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(540, 115);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelPaidState;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
