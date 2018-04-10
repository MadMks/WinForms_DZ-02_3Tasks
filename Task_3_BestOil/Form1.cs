using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            this.textBoxCafeHotDogQuantity.EnabledChanged
                += TextBoxCafeHotDogQuantity_EnabledChanged;
        }

        private void TextBoxCafeHotDogQuantity_EnabledChanged(object sender, EventArgs e)
        {
            this.AccountCafe += (
                Single.Parse(this.textBoxCafeHotDogPrice.Text)
                * Int32.Parse(this.textBoxCafeHotDogQuantity.Text)
                );
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

            // если чекбокс чекед
            // - и текстБокс Квантити не пустой
            // то считаем, и добавляем в счет кафе.

            // иначе если чекбокс не чекед
            // - и текстБокс  квант не пустой
            // то считаем, и вычтем из счета кафе.

            /// метод подсчета (сендер, аккоунт)
            /// проверка если чекед. то запустить меттод АккоунтПлюс
            /// иначе АккоунтМинус.
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
