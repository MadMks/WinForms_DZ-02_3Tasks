﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Task_3_BestOil
{
    partial class Form1
    {
        private void ComputeAmountOfGas()
        {
            if (this.IsOnlyNumbersAreEnteredOrFloat(this.textBoxSumGas) == true)
            {
                this.AccountGas
                = Single.Parse(this.textBoxSumGas.Text)
                / Single.Parse(this.textBoxGasPrise.Text);
            }
            else
            {
                this.ErrorHandlingInput(this.textBoxSumGas);
            }
        }


        private void ComputeAmountToBePaidForGas()
        {


            if (this.IsOnlyNumbersAreEnteredOrFloat(this.textBoxQuantityGas) == true)
            {
                this.AccountGas
                = Single.Parse(this.textBoxGasPrise.Text)
                * Single.Parse(this.textBoxQuantityGas.Text);
            }
            else
            {
                this.ErrorHandlingInput(this.textBoxQuantityGas);
            }
        }

        private bool IsOnlyNumbersAreEnteredOrFloat(TextBox textBox)
        {
            string quantityPattern = @"^\d+|\d+[,]\d+$";
            Regex regex = new Regex(quantityPattern);   // регулярное выражение.

            if (regex.IsMatch(textBox.Text) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Обработка ошибок ввода
        /// </summary>
        /// <param name="sender"></param>
        private void ErrorHandlingInput(object sender)
        {
            if ((sender as TextBox).Text != "")
            {
                MessageBox.Show(
                   "Можно вводить только цифры.", "Ошибка ввода",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            (sender as TextBox).Text = "0";
            (sender as TextBox).SelectAll();
        }

        /// <summary>
        /// Вводится ли только числовое значение.
        /// </summary>
        /// <param name="sender">textBox в котором произошли изменения.</param>
        /// <returns>true если вводится числовое значение.</returns>
        private bool IsOnlyNumbersAreEntered(object sender)
        {
            string quantityPattern = @"^\d+$";
            Regex regex = new Regex(quantityPattern);   // регулярное выражение.

            if (regex.IsMatch((sender as TextBox).Text) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        /// <summary>
        /// Считаем полную стоимость заказа в кафе.
        /// </summary>
        private void ComputeFullCostOfOrderInCafe()
        {
            // Обнуляем сумму счета кафе перед пересчетом.
            this.AccountCafe = 0.0F;

            if (this.checkBoxCafeHotDog.Checked == true)
            {
                this.AddToAccountPriceForOneProductName(
                    this.textBoxCafeHotDogPrice, this.textBoxCafeHotDogQuantity);
            }

            if (this.checkBoxCafeHamburger.Checked == true)
            {
                this.AddToAccountPriceForOneProductName(
                    this.textBoxCafeHamburgerPrice, this.textBoxCafeHamburgerQuantity);
            }

            if (this.checkBoxCafeFrenchFries.Checked == true)
            {
                this.AddToAccountPriceForOneProductName(
                    this.textBoxCafeFrenchFriesPrice, this.textBoxCafeFrenchFriesQuantity);
            }

            if (this.checkBoxCafeCocaCola.Checked == true)
            {
                this.AddToAccountPriceForOneProductName(
                    this.textBoxCafeCocaColaPrice, this.textBoxCafeCocaColaQuantity);
            }
        }



        /// <summary>
        /// Добавить к счету цену за одно название продукта.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        private void AddToAccountPriceForOneProductName(TextBox price, TextBox quantity)
        {
            this.AccountCafe
                += Single.Parse(price.Text) * Int32.Parse(quantity.Text);
        }

        /// <summary>
        /// В завсимости от состояния чекБокса,
        /// меняем соответствующее состояние текстБокса.
        /// </summary>
        /// <param name="sender">Объект чекБокса выбранного товара.</param>
        /// <param name="textBox">ТекстБокс кол-ва товара,
        /// выбранного чекБоксом.</param>
        private void StateCheckBoxChangesStateTextBox(
            object sender, TextBox textBox)
        {
            if ((sender as CheckBox).CheckState == CheckState.Checked)
            {
                textBox.ReadOnly = false;
            }
            else
            {
                textBox.ReadOnly = true;    // выключаем ввод.
            }

            textBox.Text = "0";
        }


    }
}
