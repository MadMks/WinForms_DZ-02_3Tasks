using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3_BestOil
{
    partial class Form1
    {

        // =====    Обработчики событий.


        /// <summary>
        /// Обработчик тика таймера.
        /// </summary>
        private void TimerBeforeRequest_Tick(object sender, EventArgs e)
        {
            this.TimerBeforeRequest.Stop();

            resultRequest = MessageBox.Show("Оформить покупку?", "Оформление покупки",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultRequest == DialogResult.Yes)
            {
                this.TotalAccountForDay += this.AccountTotal;

                this.labelSalesAmount.Text = this.TotalAccountForDay.ToString("0.00");

                this.SetDefaultSettings();
            }
            else
            {
                this.TimerBeforeRequest.Start();
            }
        }


        /// <summary>
        /// Обработчик нажатия на кнопку "подсчитать".
        /// </summary>
        private void ButtonTotalPaymentToCount_MouseClick(object sender, MouseEventArgs e)
        {
            // При каждом подсчете обнуляем общую сумму покупки с заправки и кафе.
            this.AccountTotal = 0;

            this.ComputeAmountOfTheOrderInCafeAndInGas();

            this.labelTotalPaymentPrice.Text = this.AccountTotal.ToString("0.00");


            if (this.TimerBeforeRequest.Enabled == false)
            {
                // Не запускать таймер если ничего не выбрали.
                if (this.AccountTotal > 0)
                {
                    this.TimerBeforeRequest.Start();
                }
            }
        }


        /// <summary>
        /// Обработчик нажатия на поле ввода кол-ва товара.
        /// </summary>
        private void TextBoxCafeAndGas_Quantity_MouseClick(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }


        /// <summary>
        /// Обработчик изменения кол-ва товара в кафе (при заказе).
        /// Один обработчик на несколько событий (текстБоксов).
        /// </summary>
        private void TextBoxCafe_Quantity_TextChanged(object sender, EventArgs e)
        {
            if (this.IsOnlyNumbersAreEntered(sender) == true)
            {
                this.ComputeFullCostOfOrderInCafe();

                this.labelToPayCafePrice.Text = this.AccountCafe.ToString("0.00");
            }
            else
            {
                this.ErrorHandlingInput(sender);
            }
        }


        /// <summary>
        /// Обработчик изменения кол-ва покупаемого бензина на заправке.
        /// Один обработчик на несколько событий (текстБоксов).
        /// </summary>
        private void TextBoxGas_QuantitySumPrice_TextChanged(object sender, EventArgs e)
        {
            if (this.radioButtonGBQuantityGas.Checked == true)
            {
                this.ComputeAmountToBePaidForGas();
            }
            else if (this.radioButtonGBSumGas.Checked == true)
            {
                this.ComputeAmountOfGas();
            }

            this.labelToPayGasPrice.Text = this.AccountGas.ToString("0.00");
        }


        /// <summary>
        /// Обработчик изменения состояния чекБокса "CocaCola".
        /// Меняет состояние соответствующего текстБокса.
        /// </summary>
        private void CheckBoxCafeCocaCola_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeCocaColaQuantity);
        }


        /// <summary>
        /// Обработчик изменения состояния чекБокса "FrenchFries".
        /// Меняет состояние соответствующего текстБокса.
        /// </summary>
        private void CheckBoxCafeFrenchFries_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeFrenchFriesQuantity);
        }


        /// <summary>
        /// Обработчик изменения состояния чекБокса "Hamburger".
        /// Меняет состояние соответствующего текстБокса.
        /// </summary>
        private void CheckBoxCafeHamburger_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeHamburgerQuantity);
        }


        /// <summary>
        /// Обработчик изменения состояния чекБокса "HotDog".
        /// Меняет состояние соответствующего текстБокса.
        /// </summary>
        private void CheckBoxCafeHotDog_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeHotDogQuantity);
        }


        /// <summary>
        /// Обработчик события "выбор марки бензина".
        /// </summary>
        private void ComboBoxGas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowPriceInTextBoxGasPrise();
        }


        /// <summary>
        /// Обработчик выбора расчета бензина (исходя из суммы).
        /// </summary>
        private void RadioButtonGBSumGas_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxQuantityGas.ReadOnly = true;    // отключаем ввод.
            this.textBoxSumGas.ReadOnly = false;

            this.groupBoxToPayGas.Text = "К выдаче";
            this.labelToPayGasHryvna.Text = "л.";

            this.textBoxQuantityGas.Text = "0";
        }


        /// <summary>
        /// Обработчик выбора расчета бензина (исходя из кол-ва литров).
        /// </summary>
        private void RadioButtonGBQuantityGas_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxQuantityGas.ReadOnly = false;
            this.textBoxSumGas.ReadOnly = true;     // отключаем ввод.

            this.groupBoxToPayGas.Text = "К оплате";
            this.labelToPayGasHryvna.Text = "грн.";

            this.textBoxSumGas.Text = "0";
        }


    }
}