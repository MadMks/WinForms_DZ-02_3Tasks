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
            this.radioButtonYear = new System.Windows.Forms.RadioButton();
            this.radioButtonMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonDay = new System.Windows.Forms.RadioButton();
            this.radioButtonMinute = new System.Windows.Forms.RadioButton();
            this.radioButtonSecond = new System.Windows.Forms.RadioButton();
            this.groupBoxRadioButton.SuspendLayout();
            this.groupBoxAnswer.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBoxDate
            // 
            this.maskedTextBoxDate.Location = new System.Drawing.Point(99, 11);
            this.maskedTextBoxDate.Mask = "00/00/0000";
            this.maskedTextBoxDate.Name = "maskedTextBoxDate";
            this.maskedTextBoxDate.Size = new System.Drawing.Size(66, 21);
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
            this.groupBoxRadioButton.Controls.Add(this.radioButtonSecond);
            this.groupBoxRadioButton.Controls.Add(this.radioButtonMinute);
            this.groupBoxRadioButton.Controls.Add(this.radioButtonDay);
            this.groupBoxRadioButton.Controls.Add(this.radioButtonMonth);
            this.groupBoxRadioButton.Controls.Add(this.radioButtonYear);
            this.groupBoxRadioButton.Location = new System.Drawing.Point(11, 45);
            this.groupBoxRadioButton.Name = "groupBoxRadioButton";
            this.groupBoxRadioButton.Size = new System.Drawing.Size(222, 141);
            this.groupBoxRadioButton.TabIndex = 2;
            this.groupBoxRadioButton.TabStop = false;
            this.groupBoxRadioButton.Text = "Вариант вывода";
            // 
            // groupBoxAnswer
            // 
            this.groupBoxAnswer.Controls.Add(this.labelAnswer);
            this.groupBoxAnswer.Location = new System.Drawing.Point(13, 265);
            this.groupBoxAnswer.Name = "groupBoxAnswer";
            this.groupBoxAnswer.Size = new System.Drawing.Size(220, 50);
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
            this.buttonTimeCompute.Location = new System.Drawing.Point(74, 206);
            this.buttonTimeCompute.Name = "buttonTimeCompute";
            this.buttonTimeCompute.Size = new System.Drawing.Size(96, 39);
            this.buttonTimeCompute.TabIndex = 4;
            this.buttonTimeCompute.Text = "Рассчитать";
            this.buttonTimeCompute.UseVisualStyleBackColor = true;
            this.buttonTimeCompute.Click += new System.EventHandler(this.buttonTimeCompute_Click);
            // 
            // radioButtonYear
            // 
            this.radioButtonYear.AutoSize = true;
            this.radioButtonYear.Location = new System.Drawing.Point(7, 20);
            this.radioButtonYear.Name = "radioButtonYear";
            this.radioButtonYear.Size = new System.Drawing.Size(64, 17);
            this.radioButtonYear.TabIndex = 0;
            this.radioButtonYear.Text = "В годах";
            this.radioButtonYear.UseVisualStyleBackColor = true;
            // 
            // radioButtonMonth
            // 
            this.radioButtonMonth.AutoSize = true;
            this.radioButtonMonth.Location = new System.Drawing.Point(7, 43);
            this.radioButtonMonth.Name = "radioButtonMonth";
            this.radioButtonMonth.Size = new System.Drawing.Size(75, 17);
            this.radioButtonMonth.TabIndex = 1;
            this.radioButtonMonth.Text = "В месяцах";
            this.radioButtonMonth.UseVisualStyleBackColor = true;
            // 
            // radioButtonDay
            // 
            this.radioButtonDay.AutoSize = true;
            this.radioButtonDay.Checked = true;
            this.radioButtonDay.Location = new System.Drawing.Point(7, 66);
            this.radioButtonDay.Name = "radioButtonDay";
            this.radioButtonDay.Size = new System.Drawing.Size(59, 17);
            this.radioButtonDay.TabIndex = 2;
            this.radioButtonDay.TabStop = true;
            this.radioButtonDay.Text = "В днях";
            this.radioButtonDay.UseVisualStyleBackColor = true;
            // 
            // radioButtonMinute
            // 
            this.radioButtonMinute.AutoSize = true;
            this.radioButtonMinute.Location = new System.Drawing.Point(7, 89);
            this.radioButtonMinute.Name = "radioButtonMinute";
            this.radioButtonMinute.Size = new System.Drawing.Size(76, 17);
            this.radioButtonMinute.TabIndex = 3;
            this.radioButtonMinute.Text = "В минутах";
            this.radioButtonMinute.UseVisualStyleBackColor = true;
            // 
            // radioButtonSecond
            // 
            this.radioButtonSecond.AutoSize = true;
            this.radioButtonSecond.Location = new System.Drawing.Point(7, 112);
            this.radioButtonSecond.Name = "radioButtonSecond";
            this.radioButtonSecond.Size = new System.Drawing.Size(82, 17);
            this.radioButtonSecond.TabIndex = 4;
            this.radioButtonSecond.Text = "В секундах";
            this.radioButtonSecond.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 332);
            this.Controls.Add(this.buttonTimeCompute);
            this.Controls.Add(this.groupBoxAnswer);
            this.Controls.Add(this.groupBoxRadioButton);
            this.Controls.Add(this.labelTextBoxDate);
            this.Controls.Add(this.maskedTextBoxDate);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Остаток времени";
            this.groupBoxRadioButton.ResumeLayout(false);
            this.groupBoxRadioButton.PerformLayout();
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
        private System.Windows.Forms.RadioButton radioButtonYear;
        private System.Windows.Forms.RadioButton radioButtonSecond;
        private System.Windows.Forms.RadioButton radioButtonMinute;
        private System.Windows.Forms.RadioButton radioButtonDay;
        private System.Windows.Forms.RadioButton radioButtonMonth;
    }
}

