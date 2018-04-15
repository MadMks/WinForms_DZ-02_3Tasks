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
    /// <summary>
    /// Форма приложения.
    /// </summary>
    public partial class Form1 : Form
    {
        private const int MILLISECONDS_IN_SECOND = 1000;

        private const int DELAY_BEFORE_REQUEST = 10;
        public Timer TimerBeforeRequest { get; set; }

        public List<Gas> GasolineList { get; set; }

        public float AccountGas { get; set; }
        public float AccountCafe { get; set; }
        public float AccountTotal { get; set; }
        public float TotalAccountForDay { get; set; }

        DialogResult resultRequest;



        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
        }


        /// <summary>
        /// Обработчик загрузки формы.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            TimerBeforeRequest = new Timer();
            TimerBeforeRequest.Interval = DELAY_BEFORE_REQUEST * MILLISECONDS_IN_SECOND;

            this.CreatingAListOfGasoline();

            this.SetFuelPrices();

            this.SetDefaultSettings();

            this.labelSalesAmount.Text = "0,00";

            this.SignHandlersToEvents();
        }


        /// <summary>
        /// Подписываем обработчики событий.
        /// </summary>
        private void SignHandlersToEvents()
        {
            this.SubscribeAddGoodsToOrderInGas();
            
            this.SubscribeAddGoodsToOrderInCafe();
            
            this.SubscribeChangesInNumberOfGoodsInCafe();

            this.SubscribeChangesInNumberOfGoodsInGas();

            this.SubscribeToClickingOnTheInputField();

            // Подписка на нажатие кнопки "Посчитать".
            this.buttonTotalPaymentToCount.MouseClick
                += ButtonTotalPaymentToCount_MouseClick;

            // Подписка на "тик" таймера.
            this.TimerBeforeRequest.Tick
                += TimerBeforeRequest_Tick;
        }


        /// <summary>
        /// Подписка на добавление товара в заказ заправки.
        /// </summary>
        private void SubscribeAddGoodsToOrderInGas()
        {
            this.comboBoxGas.SelectedIndexChanged
                += ComboBoxGas_SelectedIndexChanged;
            this.radioButtonGBQuantityGas.CheckedChanged
                += RadioButtonGBQuantityGas_CheckedChanged;
            this.radioButtonGBSumGas.CheckedChanged
                += RadioButtonGBSumGas_CheckedChanged;
        }


        /// <summary>
        /// Подписка на добавление товара в заказ кафе.
        /// </summary>
        private void SubscribeAddGoodsToOrderInCafe()
        {
            this.checkBoxCafeHotDog.CheckStateChanged
                += CheckBoxCafeHotDog_CheckStateChanged;
            this.checkBoxCafeHamburger.CheckStateChanged
                += CheckBoxCafeHamburger_CheckStateChanged;
            this.checkBoxCafeFrenchFries.CheckStateChanged
                += CheckBoxCafeFrenchFries_CheckStateChanged;
            this.checkBoxCafeCocaCola.CheckStateChanged
                += CheckBoxCafeCocaCola_CheckStateChanged;
        }


        /// <summary>
        /// Подписка на события нажатия на поле ввода (заправка/кафе).
        /// Один обработчик.
        /// </summary>
        private void SubscribeToClickingOnTheInputField()
        {
            // При нажатии мышкой на поле - цифры выделяются.

            // Для удобства введения кол-ва товара.
            this.textBoxCafeHotDogQuantity.MouseClick
                += TextBoxCafeAndGas_Quantity_MouseClick;
            this.textBoxCafeHamburgerQuantity.MouseClick
                += TextBoxCafeAndGas_Quantity_MouseClick;
            this.textBoxCafeFrenchFriesQuantity.MouseClick
                += TextBoxCafeAndGas_Quantity_MouseClick;
            this.textBoxCafeCocaColaQuantity.MouseClick
                += TextBoxCafeAndGas_Quantity_MouseClick;
            
            // Для удобства введения кол-ва или суммы бензина.
            this.textBoxQuantityGas.MouseClick
                += TextBoxCafeAndGas_Quantity_MouseClick;
            this.textBoxSumGas.MouseClick
                += TextBoxCafeAndGas_Quantity_MouseClick;
        }


        /// <summary>
        /// Подписка на события изменений кол-ва товаров в заказе (заправка).
        /// Один обработчик.
        /// </summary>
        private void SubscribeChangesInNumberOfGoodsInGas()
        {
            this.textBoxGasPrise.TextChanged
                += TextBoxGas_QuantitySumPrice_TextChanged;
            this.textBoxQuantityGas.TextChanged
                += TextBoxGas_QuantitySumPrice_TextChanged;
            this.textBoxSumGas.TextChanged
                += TextBoxGas_QuantitySumPrice_TextChanged;
        }


        /// <summary>
        /// Подписка на события изменений кол-ва товаров в заказе (кафе).
        /// Один обработчик.
        /// </summary>
        private void SubscribeChangesInNumberOfGoodsInCafe()
        {
            this.textBoxCafeHotDogQuantity.TextChanged
                 += TextBoxCafe_Quantity_TextChanged;
            this.textBoxCafeHamburgerQuantity.TextChanged
                += TextBoxCafe_Quantity_TextChanged;
            this.textBoxCafeFrenchFriesQuantity.TextChanged
                += TextBoxCafe_Quantity_TextChanged;
            this.textBoxCafeCocaColaQuantity.TextChanged
                += TextBoxCafe_Quantity_TextChanged;
        }


    }
}