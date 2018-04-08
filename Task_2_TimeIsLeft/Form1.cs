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

        /// <summary>
        /// Вводимая дата пользователем.
        /// </summary>
        private DateTime _enteredDate;
        /// <summary>
        /// Промежуток времени до вводимой даты.
        /// </summary>
        private TimeSpan _timeLeft;
        /// <summary>
        /// Строка с ответом.
        /// </summary>
        private string _answerStr;



        public Form1()
        {
            InitializeComponent();
        }



        // Обработчики событий.


        /// <summary>
        /// Обработчик нажатия клавиши на textBox
        /// </summary>
        private void maskedTextBoxDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.CheckDate();
            }
        }


        /// <summary>
        /// Обработчик нажатия кнопку "Рассчитать".
        /// </summary>
        private void buttonTimeCompute_Click(object sender, EventArgs e)
        {
            this.CheckDate();
        }



        // Методы.

        
        
        /// <summary>
        /// Проверка даты.
        /// </summary>
        private void CheckDate()
        {
            if (IsDateIsCorrect() == true)
            {
                if (this.IsTheDateWasAlready() == true)
                {
                    this.DisplayTheAnswer("Дата уже была");
                }
                else
                {
                    this.ComputeTheRemainingTime();

                    this.DisplayTheAnswer(_answerStr);
                }
            }
            else
            {
                this.DisplayTheAnswer("Дата не существует");
            }
        }


        /// <summary>
        /// Вычисление оставшегося времени.
        /// </summary>
        private void ComputeTheRemainingTime()
        {
            // Вычисление разницы времени.
            this._timeLeft = this._enteredDate - DateTime.Now;

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


        /// <summary>
        /// Вычисление кол-ва лет.
        /// </summary>
        /// <returns>Строка с значением кол-ва лет.</returns>
        private string ComputeNumberOfYears()
        {
            return Math.Round(
                        (double)_timeLeft.Days / NUMBER_OF_DAYS_IN_A_YEAR, 1
                        ).ToString()
                    + " лет/год(а)";
        }


        /// <summary>
        /// Вычисление кол-ва месяцев.
        /// </summary>
        /// <returns>Строка с значением кол-ва месяцев.</returns>
        private string ComputeNumberOfMonths()
        {
            return Math.Round(
                        (double)_timeLeft.Days / NUMBER_OF_DAYS_IN_A_MONTH, 1
                        ).ToString()
                    + " месяц(ев)";
        }


        /// <summary>
        /// Вычисление кол-ва дней.
        /// </summary>
        /// <returns>Строка с значением кол-ва дней.</returns>
        private string ComputeNumberOfDays()
        {
            return _timeLeft.Days.ToString()
                    + " день/дней";
        }


        /// <summary>
        /// Вычисление кол-ва минут.
        /// </summary>
        /// <returns>Строка с значением кол-ва минут.</returns>
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
        /// Вычисление кол-ва секунд до указанной даты.
        /// </summary>
        /// <returns>Строка с значением кол-во секунд.</returns>
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
            if (this._enteredDate <= DateTime.Now)
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
            if (DateTime.TryParse(this.maskedTextBoxDate.Text, out _enteredDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Вывод ответа на форму.
        /// </summary>
        /// <param name="str">Строка для вывода.</param>
        private void DisplayTheAnswer(string str)
        {
            this.labelAnswer.Text = str;
        }


    }
}