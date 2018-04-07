using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1_DayOftheWeek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
        }


        /// <summary>
        /// Обработчик события при загрузке формы.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowDayInLabel();
        }


        /// <summary>
        /// Обработчик события изменений в строке даты.
        /// </summary>
        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            this.ShowDayInLabel();
        }


        /// <summary>
        /// Выводим день в Label.
        /// </summary>
        private void ShowDayInLabel()
        {
            this.labelDayOfWeek.Text
                = this.ConvertDayIntoRussian(this.datePicker.Value.DayOfWeek);
            
            this.ChangeFirstLetterToUppercase();
        }


        /// <summary>
        /// Меняем первую букву на заглавную.
        /// </summary>
        private void ChangeFirstLetterToUppercase()
        {
            this.labelDayOfWeek.Text
                = this.labelDayOfWeek.Text.Substring(0, 1).ToUpper()
                + this.labelDayOfWeek.Text.Substring(1);
        }


        /// <summary>
        /// Конвертируем день на русский язык.
        /// </summary>
        /// <param name="dayOfWeek">День недели из dataTimePicker.</param>
        /// <returns>день недели на русском языке.</returns>
        private string ConvertDayIntoRussian(DayOfWeek dayOfWeek)
        {
            return CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(dayOfWeek);
        }


    }
}