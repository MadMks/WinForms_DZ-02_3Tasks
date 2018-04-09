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
            //if ((sender as CheckBox).CheckState == CheckState.Checked)
            //{
            //    this.textBoxCafeHotDogQuantity.ReadOnly = false;
            //}
            //else
            //{
            //    this.textBoxCafeHotDogQuantity.ReadOnly = true;
            //}

            this.StateCheckBoxChangesStateTextBox(
                sender, this.textBoxCafeHotDogQuantity);
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
                textBox.ReadOnly = true;
            }
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
