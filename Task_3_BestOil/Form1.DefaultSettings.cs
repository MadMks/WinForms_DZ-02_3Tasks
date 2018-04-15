using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_BestOil
{
    partial class Form1
    {

        // =====    Настройки по умолчанию.

        
        // Формы и нового заказа.
        //


        /// <summary>
        /// Настройки формы по умолчанию.
        /// </summary>
        private void SetDefaultSettings()
        {
            // Выбранный бензин по умолчанию.
            this.comboBoxGas.SelectedIndex = 0;
            this.ShowPriceInTextBoxGasPrise();

            this.SetDefaultRadioAndCheckAndTextBox();

            this.SetDefaultTextBoxQuantity();

            this.SetDefaultAmountPrice();

            this.SetDefaultLabelPrice();
        }


        /// <summary>
        /// Создание списка Бензина (марка, цена).
        /// Привязка к DataSource.
        /// </summary>
        private void CreatingAListOfGasoline()
        {
            GasolineList = new List<Gas>
            {
                new Gas { Name = "А-80", Price = 10.80F },
                new Gas { Name = "А-92", Price = 10.92F },
                new Gas { Name = "А-95", Price = 10.95F },
                new Gas { Name = "А-95+", Price = 10.96F }
            };

            this.comboBoxGas.DataSource = GasolineList;
            this.comboBoxGas.DisplayMember = "Name";
            this.comboBoxGas.ValueMember = "Name";
        }


        /// <summary>
        /// Вывод цен на бензин.
        /// </summary>
        private void SetFuelPrices()
        {
            this.textBoxCafeHotDogPrice.Text = "1,10";
            this.textBoxCafeHamburgerPrice.Text = "2,20";
            this.textBoxCafeFrenchFriesPrice.Text = "3,30";
            this.textBoxCafeCocaColaPrice.Text = "4,40";
        }


        /// <summary>
        /// Настройки по умолчанию radioButton, checkBox и textBox.
        /// </summary>
        private void SetDefaultRadioAndCheckAndTextBox()
        {
            this.radioButtonGBQuantityGas.Checked = true;
            this.textBoxQuantityGas.ReadOnly = false;
            this.textBoxSumGas.ReadOnly = true;

            this.checkBoxCafeHotDog.Checked = false;
            this.checkBoxCafeHamburger.Checked = false;
            this.checkBoxCafeFrenchFries.Checked = false;
            this.checkBoxCafeCocaCola.Checked = false;
        }


        /// <summary>
        /// Настройки по умолчанию для textBox кол-ва товара
        /// (кол-ва бензина/суммы бензина).
        /// </summary>
        private void SetDefaultTextBoxQuantity()
        {
            // Кафе.
            this.textBoxCafeHotDogQuantity.Text = "0";
            this.textBoxCafeHamburgerQuantity.Text = "0";
            this.textBoxCafeFrenchFriesQuantity.Text = "0";
            this.textBoxCafeCocaColaQuantity.Text = "0";

            // Автозаправка.
            this.textBoxQuantityGas.Text = "0";
            this.textBoxSumGas.Text = "0";
        }


        /// <summary>
        /// Настройки по умолчанию label цен (к оплате).
        /// </summary>
        private void SetDefaultLabelPrice()
        {
            this.labelToPayGasPrice.Text = "0,00";
            this.labelToPayCafePrice.Text = "0,00";
            this.labelTotalPaymentPrice.Text = "0,00";
        }


        /// <summary>
        /// Настройки по умолчанию числовых значений цен
        /// (за заправку и за кафе).
        /// </summary>
        private void SetDefaultAmountPrice()
        {
            this.AccountGas = 0.0F;
            this.AccountCafe = 0.0F;
        }
        

    }
}