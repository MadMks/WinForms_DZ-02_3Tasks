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

            //this.comboBoxGas.Items.AddRange(new object[] {
            //    "А-80",
            //    "А-92",
            //    "А-95",
            //    "А-95+"
            //});

            //this.comboBoxGas.Text = "А-80";
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

            //
            this.textBoxCafeHotDogQuantity.TextChanged
                += TextBoxCafeHotDogQuantity_TextChanged;
            this.textBoxCafeHamburgerQuantity.TextChanged
                += TextBoxCafeHamburgerQuantity_TextChanged;
            this.textBoxCafeFrenchFriesQuantity.TextChanged
                += TextBoxCafeFrenchFriesQuantity_TextChanged;
            this.textBoxCafeCocaColaQuantity.TextChanged
                += TextBoxCafeCocaColaQuantity_TextChanged;


            // измеение полной стоимости заказа в кафе
            //this.labelToPayCafePrice +=

           
        }




        // TODO 4 нижних (и может еще какието)
        // внутри вызывать собственное событие
        // "изменение заказа кафе".
        private void TextBoxCafeCocaColaQuantity_TextChanged(object sender, EventArgs e)
        {
            //this.ComputeFullCostOfOrderInCafe();
            ////
            //this.labelToPayCafePrice.Text = this.AccountCafe.ToString();
        }

        private void TextBoxCafeFrenchFriesQuantity_TextChanged(object sender, EventArgs e)
        {
            //this.ComputeFullCostOfOrderInCafe();
            ////
            //this.labelToPayCafePrice.Text = this.AccountCafe.ToString();
        }

        private void TextBoxCafeHamburgerQuantity_TextChanged(object sender, EventArgs e)
        {
            //this.ComputeFullCostOfOrderInCafe();
            ////
            //this.labelToPayCafePrice.Text = this.AccountCafe.ToString();
        }

        private void TextBoxCafeHotDogQuantity_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxCafeHotDogQuantity.Text == "")
            {
                this.textBoxCafeHotDogQuantity.Text = "0";
            }

            // TODO TODO TODO 
            //Color defaultColor = (sender as TextBox).BackColor;


            string quantityPattern = @"^\d+$";
            Regex regex = new Regex(quantityPattern);
            if (regex.IsMatch(this.textBoxCafeHotDogQuantity.Text) == true)
            {
                (sender as TextBox).BackColor = TextBox.DefaultBackColor;

                this.ComputeFullCostOfOrderInCafe();
                //
                this.labelToPayCafePrice.Text = this.AccountCafe.ToString();
            }
            else
            {
                (sender as TextBox).BackColor = Color.PaleVioletRed;
            }

            //this.textBoxCafeHotDogQuantity.Text

            //this.ComputeFullCostOfOrderInCafe();
            ////
            //this.labelToPayCafePrice.Text = this.AccountCafe.ToString();
        }
        


        private void CheckBoxCafeCocaCola_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeCocaColaQuantity);

            //this.ComputeFullCostOfOrderInCafe();
            ////
            //this.labelToPayCafePrice.Text = this.AccountCafe.ToString();
        }

        private void CheckBoxCafeFrenchFries_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeFrenchFriesQuantity);

            //this.ComputeFullCostOfOrderInCafe();
            ////
            //this.labelToPayCafePrice.Text = this.AccountCafe.ToString();
        }

        private void CheckBoxCafeHamburger_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeHamburgerQuantity);

            //this.ComputeFullCostOfOrderInCafe();
            ////
            //this.labelToPayCafePrice.Text = this.AccountCafe.ToString();
        }

        private void CheckBoxCafeHotDog_CheckStateChanged(object sender, EventArgs e)
        {
            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeHotDogQuantity);


            this.ComputeFullCostOfOrderInCafe();
            //
            this.labelToPayCafePrice.Text = this.AccountCafe.ToString();
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
            this.textBoxQuantityGas.ReadOnly = true;
            this.textBoxSumGas.ReadOnly = false;

            this.groupBoxToPayGas.Text = "К выдаче";
            this.labelToPayGasHryvna.Text = "л.";
        }

        private void RadioButtonGBQuantityGas_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxQuantityGas.ReadOnly = false;
            this.textBoxSumGas.ReadOnly = true;

            this.groupBoxToPayGas.Text = "К оплате";
            this.labelToPayGasHryvna.Text = "грн.";
        }

        private void SetDefaultSettings()
        {
            this.ShowPriceInTextBoxGasPrise();

            this.radioButtonGBQuantityGas.Checked = true;
            this.textBoxQuantityGas.ReadOnly = false;
            this.textBoxSumGas.ReadOnly = true;

            this.textBoxCafeHotDogPrice.Text = "1";
            this.textBoxCafeHamburgerPrice.Text = "2";
            this.textBoxCafeFrenchFriesPrice.Text = "3";
            this.textBoxCafeCocaColaPrice.Text = "4";

            this.textBoxCafeHotDogQuantity.Text = "0";
            this.textBoxCafeHamburgerQuantity.Text = "0";
            this.textBoxCafeFrenchFriesQuantity.Text = "0";
            this.textBoxCafeCocaColaQuantity.Text = "0";

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
