namespace Task_2_TimeIsLeft
{
    partial class Form1
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
            this.maskedTextBoxDate = new System.Windows.Forms.MaskedTextBox();
            this.labelTextBoxDate = new System.Windows.Forms.Label();
            this.groupBoxRadioButton = new System.Windows.Forms.GroupBox();
            this.groupBoxAnswer = new System.Windows.Forms.GroupBox();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.buttonTimeCompute = new System.Windows.Forms.Button();
            this.groupBoxAnswer.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBoxDate
            // 
            this.maskedTextBoxDate.Location = new System.Drawing.Point(12, 33);
            this.maskedTextBoxDate.Mask = "00/00/0000";
            this.maskedTextBoxDate.Name = "maskedTextBoxDate";
            this.maskedTextBoxDate.Size = new System.Drawing.Size(187, 21);
            this.maskedTextBoxDate.TabIndex = 0;
            this.maskedTextBoxDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxDate_KeyDown);
            // 
            // labelTextBoxDate
            // 
            this.labelTextBoxDate.AutoSize = true;
            this.labelTextBoxDate.Location = new System.Drawing.Point(12, 17);
            this.labelTextBoxDate.Name = "labelTextBoxDate";
            this.labelTextBoxDate.Size = new System.Drawing.Size(78, 13);
            this.labelTextBoxDate.TabIndex = 1;
            this.labelTextBoxDate.Text = "Введите дату";
            // 
            // groupBoxRadioButton
            // 
            this.groupBoxRadioButton.Location = new System.Drawing.Point(12, 70);
            this.groupBoxRadioButton.Name = "groupBoxRadioButton";
            this.groupBoxRadioButton.Size = new System.Drawing.Size(200, 100);
            this.groupBoxRadioButton.TabIndex = 2;
            this.groupBoxRadioButton.TabStop = false;
            this.groupBoxRadioButton.Text = "Вариант вывода";
            // 
            // groupBoxAnswer
            // 
            this.groupBoxAnswer.Controls.Add(this.labelAnswer);
            this.groupBoxAnswer.Location = new System.Drawing.Point(15, 202);
            this.groupBoxAnswer.Name = "groupBoxAnswer";
            this.groupBoxAnswer.Size = new System.Drawing.Size(252, 50);
            this.groupBoxAnswer.TabIndex = 3;
            this.groupBoxAnswer.TabStop = false;
            this.groupBoxAnswer.Text = "До указанной даты осталось:";
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.Location = new System.Drawing.Point(7, 21);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(78, 13);
            this.labelAnswer.TabIndex = 0;
            this.labelAnswer.Text = "Введите дату";
            // 
            // buttonTimeCompute
            // 
            this.buttonTimeCompute.Location = new System.Drawing.Point(118, 177);
            this.buttonTimeCompute.Name = "buttonTimeCompute";
            this.buttonTimeCompute.Size = new System.Drawing.Size(75, 23);
            this.buttonTimeCompute.TabIndex = 4;
            this.buttonTimeCompute.Text = "Рассчитать";
            this.buttonTimeCompute.UseVisualStyleBackColor = true;
            this.buttonTimeCompute.Click += new System.EventHandler(this.buttonTimeCompute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 264);
            this.Controls.Add(this.buttonTimeCompute);
            this.Controls.Add(this.groupBoxAnswer);
            this.Controls.Add(this.groupBoxRadioButton);
            this.Controls.Add(this.labelTextBoxDate);
            this.Controls.Add(this.maskedTextBoxDate);
            this.Name = "Form1";
            this.Text = "Остаток времени";
            this.groupBoxAnswer.ResumeLayout(false);
            this.groupBoxAnswer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBoxDate;
        private System.Windows.Forms.Label labelTextBoxDate;
        private System.Windows.Forms.GroupBox groupBoxRadioButton;
        private System.Windows.Forms.GroupBox groupBoxAnswer;
        private System.Windows.Forms.Button buttonTimeCompute;
        private System.Windows.Forms.Label labelAnswer;
    }
}

