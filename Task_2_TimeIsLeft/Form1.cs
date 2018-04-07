using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2_TimeIsLeft
{
    public partial class Form1 : Form
    {
        DateTime enteredDate;

        public Form1()
        {
            InitializeComponent();
        }


        private void maskedTextBoxDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.CheckDate();
            }
        }

        private void buttonTimeCompute_Click(object sender, EventArgs e)
        {
            this.CheckDate();
        }

        private void CheckDate()
        {
            if (IsDateIsCorrect() == true)
            {
                // если дата раньше текущей
                // вывести в Ответ что "введенная дата уже была"
                if (this.IsTheDateWasAlready() == true)
                {
                    this.labelAnswer.Text = "Дата уже была";
                }
                else
                {
                    // вывести ответ в лабел
                    this.DisplayTheAnswer();
                }
            }
            else
            {
                // подсветить красным дату
                // или показать текст что неправильная дата
                this.labelAnswer.Text = "Дата не существует";
            }
        }


        /// <summary>
        /// Дата раньше сегодняшней.
        /// </summary>
        /// <returns>true если дата уже была.</returns>
        private bool IsTheDateWasAlready()
        {
            if (this.enteredDate <= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Проверка введенной даты.
        /// </summary>
        /// <returns>true если дата корректна.</returns>
        private bool IsDateIsCorrect()
        {
            
            
            //DateTime.TryParse(this.maskedTextBoxDate.Text, out dt);

            if (DateTime.TryParse(this.maskedTextBoxDate.Text, out enteredDate))
            {
                //this.labelAnswer.Text = "true";
                return true;
            }
            else
            {
                //this.labelAnswer.Text = "false";
                return false;
            }
        }

        private void DisplayTheAnswer()
        {
            this.labelAnswer.Text = "test Click";

            // проверить дату()
        }

        
    }
}
