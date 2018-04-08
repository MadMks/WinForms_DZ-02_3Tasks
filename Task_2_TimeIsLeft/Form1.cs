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
        private const int NUMBER_OF_DAYS_IN_A_YEAR = 365;
        private const int NUMBER_OF_DAYS_IN_A_MONTH = 30;
        private const int NUMBER_OF_MINUTES_IN_A_DAY = 1440;
        private const int NUMBER_OF_MINUTES_IN_A_HOURS = 60;
        private const int NUMBER_OF_SECONDS_IN_A_MINUTE = 60;


        DateTime enteredDate;   // TODO
        TimeSpan _timeLeft;
        string _answerStr;

        public Form1()
        {
            InitializeComponent();
        }


        private void maskedTextBoxDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                // то событие Ентер кнопки
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
                    //this.labelAnswer.Text = "Дата уже была";
                    this.DisplayTheAnswer("Дата уже была");
                }
                else
                {
                    // вычисления оставшегося времени
                    this.ComputeTheRemainingTime();

                    // вывести ответ в лабел
                    this.DisplayTheAnswer(_answerStr);
                }
            }
            else
            {
                // подсветить красным дату
                //this.maskedTextBoxDate.BackColor = Color.FromArgb(232, 107, 107);   // TODO
                // или показать текст что неправильная дата
                //this.labelAnswer.Text = "Дата не существует";
                this.DisplayTheAnswer("Дата не существует");
            }
        }

        private void ComputeTheRemainingTime()
        {
            // Вычисление разницы времени.
            this._timeLeft = this.enteredDate - DateTime.Now;

            // Сохранение и вычисление ответа
            // соответственно выбора в radioButton.
            if (this.radioButtonYear.Checked == true)
            {
                _answerStr = this.ComputeNumberOfYears();
            }
            else if (this.radioButtonMonth.Checked == true)
            {
                _answerStr = this.ComputeNumberOfMonths();
            }
            else if (this.radioButtonDay.Checked == true)
            {
                _answerStr = this.ComputeNumberOfDays();
            }
            else if (this.radioButtonMinute.Checked == true)
            {
                _answerStr = this.ComputeNumberOfMinutes();
            }
            else if (this.radioButtonSecond.Checked == true)
            {
                _answerStr = this.ComputeNumberOfSeconds();
            }
        }

        private string ComputeNumberOfYears()
        {
            return Math.Round(
                        (double)_timeLeft.Days / NUMBER_OF_DAYS_IN_A_YEAR, 1
                        ).ToString()
                    + " лет/год(а)";
        }

        private string ComputeNumberOfMonths()
        {
            return Math.Round(
                        (double)_timeLeft.Days / NUMBER_OF_DAYS_IN_A_MONTH, 1
                        ).ToString()
                    + " месяц(ев)";
        }

        private string ComputeNumberOfDays()
        {
            return _timeLeft.Days.ToString()
                    + " день/дней";
        }

        private string ComputeNumberOfMinutes()
        {
            return (
                        (_timeLeft.Days * NUMBER_OF_MINUTES_IN_A_DAY)
                        + (_timeLeft.Hours * NUMBER_OF_MINUTES_IN_A_HOURS)
                        + _timeLeft.Minutes
                    ).ToString()
                    + " минут(а)";
        }

        /// <summary>
        /// Вычислить количество секунд до указанной даты.
        /// </summary>
        /// <returns>Строка в которой указано "кол-во секунд".</returns>
        private string ComputeNumberOfSeconds()
        {
            return (
                        (
                            (
                                (_timeLeft.Days * NUMBER_OF_MINUTES_IN_A_DAY)
                                + (_timeLeft.Hours * NUMBER_OF_MINUTES_IN_A_HOURS)
                                + _timeLeft.Minutes
                            )
                            * NUMBER_OF_SECONDS_IN_A_MINUTE
                        )
                        + _timeLeft.Seconds
                    ).ToString()
                    + " секунд(а)";
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
            if (DateTime.TryParse(this.maskedTextBoxDate.Text, out enteredDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void DisplayTheAnswer(string str)
        {
            this.labelAnswer.Text = str;
        }


    }
}
