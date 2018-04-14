using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_3_BestOil.Properties;

namespace Task_3_BestOil
{
    public partial class Form1 : Form
    {
        public List<Gas> GasolineList { get; set; }

        public float AccountGas { get; set; }
        public float AccountCafe { get; set; }
        public float AccountTotal { get; set; }
        public float TotalAccountForDay { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.CreatingAListOfGasoline();

            this.SetDefaultSettings();

            

            // gas
            this.comboBoxGas.SelectedIndexChanged += ComboBoxGas_SelectedIndexChanged;
            this.radioButtonGBQuantityGas.CheckedChanged
                += RadioButtonGBQuantityGas_CheckedChanged;
            this.radioButtonGBSumGas.CheckedChanged
                += RadioButtonGBSumGas_CheckedChanged;

            // cafe
            this.checkBoxCafeHotDog.CheckStateChanged 
                += CheckBoxCafeHotDog_CheckStateChanged;
            this.checkBoxCafeHamburger.CheckStateChanged
                += CheckBoxCafeHamburger_CheckStateChanged;
            this.checkBoxCafeFrenchFries.CheckStateChanged
                += CheckBoxCafeFrenchFries_CheckStateChanged;
            this.checkBoxCafeCocaCola.CheckStateChanged
                += CheckBoxCafeCocaCola_CheckStateChanged;

            // подписываю на 4 события свой обработчик.
            this.textBoxCafeHotDogQuantity.TextChanged
                 += TextBoxCafe_Quantity_TextChanged;
            this.textBoxCafeHamburgerQuantity.TextChanged
                += TextBoxCafe_Quantity_TextChanged;
            this.textBoxCafeFrenchFriesQuantity.TextChanged
                += TextBoxCafe_Quantity_TextChanged;
            this.textBoxCafeCocaColaQuantity.TextChanged
                += TextBoxCafe_Quantity_TextChanged;


            // при нажатии мышкой на поле - цифры выделяются,
            // для удобства введения кол-ва товара.
            // один обработчик.
            this.textBoxCafeHotDogQuantity.MouseClick
                += TextBoxCafe_Quantity_MouseClick;
            this.textBoxCafeHamburgerQuantity.MouseClick
                += TextBoxCafe_Quantity_MouseClick;
            this.textBoxCafeFrenchFriesQuantity.MouseClick
                += TextBoxCafe_Quantity_MouseClick;
            this.textBoxCafeCocaColaQuantity.MouseClick
                += TextBoxCafe_Quantity_MouseClick;

            //
            this.textBoxGasPrise.TextChanged
                += TextBoxGas_QuantitySumPrice_TextChanged;
            this.textBoxQuantityGas.TextChanged
                += TextBoxGas_QuantitySumPrice_TextChanged;
            this.textBoxSumGas.TextChanged
                += TextBoxGas_QuantitySumPrice_TextChanged;
            // при нажатии мышкой на поле - цифры выделяются,
            // для удобства введения кол-ва или суммы бензина.
            // один обработчик.
            this.textBoxQuantityGas.MouseClick
                += TextBoxCafe_Quantity_MouseClick;
            this.textBoxSumGas.MouseClick
                += TextBoxCafe_Quantity_MouseClick;

            //
            this.buttonTotalPaymentToCount.MouseClick
                += ButtonTotalPaymentToCount_MouseClick;
        }

        private void ButtonTotalPaymentToCount_MouseClick(object sender, MouseEventArgs e)
        {
            this.AccountTotal = 0;

            if (this.radioButtonGBQuantityGas.Checked == true)
            {
                this.AccountTotal += this.AccountGas;
            }

            this.AccountTotal += this.AccountCafe;

            this.labelTotalPaymentPrice.Text = this.AccountTotal.ToString("0.00");
        }

        private void TextBoxCafe_Quantity_MouseClick(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();   // TODO заменить одним обработчиком!?
        }

        private void TextBoxGas_Quantity_MouseClick(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();   // TODO заменить одним обработчиком!?
        }

        // один обработчик на 4 события
        /// <summary>
        /// cafe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxCafe_Quantity_TextChanged(object sender, EventArgs e)
        {
            if (this.IsOnlyNumbersAreEntered(sender) == true)
            {
                this.ComputeFullCostOfOrderInCafe();
                //
                this.labelToPayCafePrice.Text = this.AccountCafe.ToString("0.00");
            }
            else
            {
                this.ErrorHandlingInput(sender);
            }
        }


        // один обработчик на 3 события
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



        private void CheckBoxCafeCocaCola_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeCocaColaQuantity);
        }

        private void CheckBoxCafeFrenchFries_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeFrenchFriesQuantity);
        }

        private void CheckBoxCafeHamburger_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeHamburgerQuantity);
        }

        private void CheckBoxCafeHotDog_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeHotDogQuantity);
        }


        /// <summary>
        /// Считаем полную стоимость заказа в кафе.
        /// </summary>
        private void ComputeFullCostOfOrderInCafe()
        {
            // Обнуляем сумму счета кафе перед пересчетом.
            this.AccountCafe = 0;

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

        private void RadioButtonGBSumGas_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxQuantityGas.ReadOnly = true;    // отключаем ввод.
            this.textBoxSumGas.ReadOnly = false;

            this.groupBoxToPayGas.Text = "К выдаче";
            this.labelToPayGasHryvna.Text = "л.";

            this.textBoxQuantityGas.Text = "0";
        }

        private void RadioButtonGBQuantityGas_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxQuantityGas.ReadOnly = false;
            this.textBoxSumGas.ReadOnly = true;     // отключаем ввод.

            this.groupBoxToPayGas.Text = "К оплате";
            this.labelToPayGasHryvna.Text = "грн.";

            this.textBoxSumGas.Text = "0";
        }

        private void SetDefaultSettings()
        {
            this.ShowPriceInTextBoxGasPrise();

            this.radioButtonGBQuantityGas.Checked = true;
            this.textBoxQuantityGas.ReadOnly = false;
            this.textBoxSumGas.ReadOnly = true;

            this.textBoxCafeHotDogPrice.Text = "1,10";
            this.textBoxCafeHamburgerPrice.Text = "2,20";
            this.textBoxCafeFrenchFriesPrice.Text = "3,30";
            this.textBoxCafeCocaColaPrice.Text = "4,40";

            this.textBoxCafeHotDogQuantity.Text = "0";
            this.textBoxCafeHamburgerQuantity.Text = "0";
            this.textBoxCafeFrenchFriesQuantity.Text = "0";
            this.textBoxCafeCocaColaQuantity.Text = "0";


            this.textBoxQuantityGas.Text = "0";
            this.textBoxSumGas.Text = "0";

            this.AccountGas = 0.0F;
            this.AccountCafe = 0.0F;
        }

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

        private void ComboBoxGas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowPriceInTextBoxGasPrise();
        }

        private void ShowPriceInTextBoxGasPrise()
        {
            this.textBoxGasPrise.Text
                = (this.comboBoxGas.SelectedItem as Gas)
                .Price.ToString("0.00");
        }
    }
}
