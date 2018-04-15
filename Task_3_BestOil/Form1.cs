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
        private const int DELAY_BEFORE_REQUEST = 10;
        public Timer TimerBeforeRequest { get; set; }

        public List<Gas> GasolineList { get; set; }

        public float AccountGas { get; set; }
        public float AccountCafe { get; set; }
        public float AccountTotal { get; set; }
        public float TotalAccountForDay { get; set; }

        DialogResult resultRequest;



        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimerBeforeRequest = new Timer();
            TimerBeforeRequest.Interval = DELAY_BEFORE_REQUEST * 1000;


            this.CreatingAListOfGasoline();

            this.SetFuelPrices();

            this.SetDefaultSettings();

            this.labelSalesAmount.Text = "0,00";

            // gas
            this.comboBoxGas.SelectedIndexChanged
                += ComboBoxGas_SelectedIndexChanged;
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

            this.TimerBeforeRequest.Tick
                += TimerBeforeRequest_Tick;
        }

        private void SetFuelPrices()
        {
            this.textBoxCafeHotDogPrice.Text = "1,10";
            this.textBoxCafeHamburgerPrice.Text = "2,20";
            this.textBoxCafeFrenchFriesPrice.Text = "3,30";
            this.textBoxCafeCocaColaPrice.Text = "4,40";
        }

        private void TimerBeforeRequest_Tick(object sender, EventArgs e)
        {
            this.TimerBeforeRequest.Stop();

            resultRequest = MessageBox.Show("Оформить покупку?", "Оформление покупки",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (resultRequest == DialogResult.Yes)
            {
                //if (this.radioButtonGBSumGas.Checked == true)
                //{
                //    this.AccountTotal += Single.Parse(this.textBoxSumGas.Text);
                //}

                this.TotalAccountForDay += this.AccountTotal;

                this.labelSalesAmount.Text = this.TotalAccountForDay.ToString("0.00");

                // обнулить
                this.SetDefaultSettings();

                //this.TimerBeforeRequest.Stop();
            }
            else
            {
                this.TimerBeforeRequest.Start();
            }
        }

        private void ButtonTotalPaymentToCount_MouseClick(object sender, MouseEventArgs e)
        {
            
            // При каждом подсчете обнуляем общую сумму покупки с заправки и кафе.
            this.AccountTotal = 0;


            if (this.radioButtonGBQuantityGas.Checked == true)
            {
                this.AccountTotal += this.AccountGas;
            }
            else if (this.radioButtonGBSumGas.Checked == true)
            {
                this.AccountTotal += Single.Parse(this.textBoxSumGas.Text);
            }

            this.AccountTotal += this.AccountCafe;

            this.labelTotalPaymentPrice.Text = this.AccountTotal.ToString("0.00");


            if (this.TimerBeforeRequest.Enabled == false)
            {
                //this.TimerBeforeRequest.Stop();

                //this.PurchaseRequest();
                // Не запускать таймер если ничего не выбрали.
                if (this.AccountTotal > 0)
                {
                    this.TimerBeforeRequest.Start();
                }

                
            }

            

            //this.TimerBeforeRequest.Start();
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
        /// Обработчик события "выбор марки бензина".
        /// </summary>
        private void ComboBoxGas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowPriceInTextBoxGasPrise();
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
        /// Показать цену за бензин в textBox.
        /// </summary>
        private void ShowPriceInTextBoxGasPrise()
        {
            this.textBoxGasPrise.Text
                = (this.comboBoxGas.SelectedItem as Gas)
                .Price.ToString("0.00");
        }


    }
}
