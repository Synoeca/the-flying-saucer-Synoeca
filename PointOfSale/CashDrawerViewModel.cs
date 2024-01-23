using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.PointOfSale
{
    /// <summary>
    /// Intermediary ViewModel class for payment with cash
    /// </summary>
    public class CashDrawerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// A PropertyChanged event handler would notify of property changing
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Whether the control would make appropriate change
        /// </summary>
        public bool CalculateChange { get; set; } = true;

        /// <summary>
        /// A private backing field for the current order
        /// </summary>
        private Order _order;

        #region RoundRegisterProperties

        /// <summary>
        /// The Cash Drawer's Hundreds value of bill
        /// </summary>
        public uint Hundreds { get; set; }

        /// <summary>
        /// The Cash Drawer's Fifties value of bill
        /// </summary>
        public uint Fifties { get; set; }

        /// <summary>
        /// The Cash Drawer's Twenties value of bill
        /// </summary>
        public uint Twenties { get; set; }

        /// <summary>
        /// The Cash Drawer's Tens value of bill
        /// </summary>
        public uint Tens { get; set; }

        /// <summary>
        /// The Cash Drawer's Fives value of bill
        /// </summary>
        public uint Fives { get; set; }

        /// <summary>
        /// The Cash Drawer's Twos value of bill
        /// </summary>
        public uint Twos { get; set; }

        /// <summary>
        /// The Cash Drawer's Ones value of bill
        /// </summary>
        public uint Ones { get; set; }

        /// <summary>
        /// The Cash Drawer's DollarCoins value of Coin
        /// </summary>
        public uint DollarCoins { get; set; }

        /// <summary>
        /// The Cash Drawer's HalfDollarCoins value of Coin
        /// </summary>
        public uint HalfDollarCoins { get; set; }

        /// <summary>
        /// The Cash Drawer's Quarters value of Coin
        /// </summary>
        public uint Quarters { get; set; }

        /// <summary>
        /// The Cash Drawer's Dimes value of Coin
        /// </summary>
        public uint Dimes { get; set; }

        /// <summary>
        /// The Cash Drawer's Nickles value of Coin
        /// </summary>
        public uint Nickles { get; set; }

        /// <summary>
        /// The Cash Drawer's Pennies value of Coin
        /// </summary>
        public uint Pennies { get; set; }

        /// <summary>
        /// The Cash Drawer's Total
        /// </summary>
        public decimal TotalCurrency => CorrectGetTotal();

        /// <summary>
        /// Revised original GetTotal Method
        /// </summary>
        /// <returns>Correct Total of CashDrawers Currency</returns>
        public decimal CorrectGetTotal()
        {
            return 0m + (decimal)(100 * CashDrawer.Hundreds) + (decimal)(50 * CashDrawer.Fifties) + (decimal)(20 * CashDrawer.Twenties)
                + (decimal)(10 * CashDrawer.Tens) + (decimal)(5 * CashDrawer.Fives) + (decimal)(2 * CashDrawer.Twos) + (decimal)CashDrawer.Ones
                + (decimal)CashDrawer.DollarCoins + 0.50m * (decimal)CashDrawer.HalfDollarCoins + 0.25m * (decimal)CashDrawer.Quarters
                + 0.10m * (decimal)CashDrawer.Dimes + 0.05m * (decimal)CashDrawer.Nickles + 0.01m * (decimal)CashDrawer.Pennies;
        }
        #endregion

        #region CustomerCurrencyProperties
        /// <summary>
        /// A private backing field for the property CustomerHundreds
        /// </summary>
        private uint _customerHundreds;

        /// <summary>
        /// The Customer's Hundreds value of bill
        /// </summary>
        public uint CustomerHundreds
        {
            get => _customerHundreds;
            set
            {
                _customerHundreds = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerHundreds)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity))); 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerTwenties
        /// </summary>
        private uint _customerFifties;

        /// <summary>
        /// The Customer's Fifties value of bill
        /// </summary>
        public uint CustomerFifties
        {
            get => _customerFifties;
            set
            {
                _customerFifties = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerFifties)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerTwenties
        /// </summary>
        private uint _customerTwenties;

        /// <summary>
        /// The Customer's Fifties value of bill
        /// </summary>
        public uint CustomerTwenties
        {
            get => _customerTwenties;
            set
            {
                _customerTwenties = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTwenties)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerTens
        /// </summary>
        private uint _customerTens;

        /// <summary>
        /// The Customer's Tens value of bill
        /// </summary>
        public uint CustomerTens
        {
            get => _customerTens;
            set
            {
                _customerTens = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTens)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerFives
        /// </summary>
        private uint _customerFives;

        /// <summary>
        /// The Customer's Fives value of bill
        /// </summary>
        public uint CustomerFives
        {
            get => _customerFives;
            set
            {
                _customerFives = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerFives)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerTwos
        /// </summary>
        private uint _customerTwos;

        /// <summary>
        /// The Customer's Twos value of bill
        /// </summary>
        public uint CustomerTwos
        {
            get => _customerTwos;
            set
            {
                _customerTwos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTwos)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerOnes
        /// </summary>
        private uint _customerOnes;

        /// <summary>
        /// The Customer's Ones value of bill
        /// </summary>
        public uint CustomerOnes
        {
            get => _customerOnes;
            set
            {
                _customerOnes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerOnes)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerDollarCoins
        /// </summary>
        private uint _customerDollarCoins;

        /// <summary>
        /// The Customer's One Dollars value of coins
        /// </summary>
        public uint CustomerDollarCoins
        {
            get => _customerDollarCoins;
            set
            {
                _customerDollarCoins = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerDollarCoins)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerHalfDollarCoins
        /// </summary>
        private uint _customerHalfDollarCoins;

        /// <summary>
        /// The Customer's Half Dollars value of coins
        /// </summary>
        public uint CustomerHalfDollarCoins
        {
            get => _customerHalfDollarCoins;
            set
            {
                _customerHalfDollarCoins = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerHalfDollarCoins)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerQuarters
        /// </summary>
        private uint _customerQuarters;

        /// <summary>
        /// The Customer's Quarters value of coins
        /// </summary>
        public uint CustomerQuarters
        {
            get => _customerQuarters;
            set
            {
                _customerQuarters = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuarters)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerDimes
        /// </summary>
        private uint _customerDimes;

        /// <summary>
        /// The Customer's Dimes value of coins
        /// </summary>
        public uint CustomerDimes
        {
            get => _customerDimes;
            set
            {
                _customerDimes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerDimes)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerDimes
        /// </summary>
        private uint _customerNickles;

        /// <summary>
        /// The Customer's Dimes value of coins
        /// </summary>
        public uint CustomerNickles
        {
            get => _customerNickles;
            set
            {
                _customerNickles = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerNickles)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerPennies
        /// </summary>
        private uint _customerPennies;

        /// <summary>
        /// The Customer's Pennies value of coins
        /// </summary>
        public uint CustomerPennies
        {
            get => _customerPennies;
            set
            {
                _customerPennies = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerPennies)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuantity)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AmountDue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeOwed)));
            }
        }
        #endregion

        #region CustomerChangeProperties
        /// <summary>
        /// A private backing field for the property CustomerHundredsChange
        /// </summary>
        private uint _customerHundredsChange;

        /// <summary>
        /// The Customer's HundredsChange value of bill
        /// </summary>
        public uint CustomerHundredsChange
        {
            get => _customerHundredsChange;
            set
            {
                _customerHundredsChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerHundredsChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerTwentiesChange
        /// </summary>
        private uint _customerFiftiesChange;

        /// <summary>
        /// The Customer's FiftiesChange value of bill
        /// </summary>
        public uint CustomerFiftiesChange
        {
            get => _customerFiftiesChange;
            set
            {
                _customerFiftiesChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerFiftiesChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerTwentiesChange
        /// </summary>
        private uint _customerTwentiesChange;

        /// <summary>
        /// The Customer's TwentiesChange value of bill
        /// </summary>
        public uint CustomerTwentiesChange
        {
            get => _customerTwentiesChange;
            set
            {
                _customerTwentiesChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTwentiesChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerTensChange
        /// </summary>
        private uint _customerTensChange;

        /// <summary>
        /// The Customer's TensChange value of bill
        /// </summary>
        public uint CustomerTensChange
        {
            get => _customerTensChange;
            set
            {
                _customerTensChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTensChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerFivesChange
        /// </summary>
        private uint _customerFivesChange;

        /// <summary>
        /// The Customer's FivesChange value of bill
        /// </summary>
        public uint CustomerFivesChange
        {
            get => _customerFivesChange;
            set
            {
                _customerFivesChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerFivesChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerTwosChange
        /// </summary>
        private uint _customerTwosChange;

        /// <summary>
        /// The Customer's TwosChange value of bill
        /// </summary>
        public uint CustomerTwosChange
        {
            get => _customerTwosChange;
            set
            {
                _customerTwosChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTwosChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerOnesChange
        /// </summary>
        private uint _customerOnesChange;

        /// <summary>
        /// The Customer's OnesChange value of bill
        /// </summary>
        public uint CustomerOnesChange
        {
            get => _customerOnesChange;
            set
            {
                _customerOnesChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerOnesChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerDollarCoinsChange
        /// </summary>
        private uint _customerDollarCoinsChange;

        /// <summary>
        /// The Customer's One DollarsChange value of coins
        /// </summary>
        public uint CustomerDollarCoinsChange
        {
            get => _customerDollarCoinsChange;
            set
            {
                _customerDollarCoinsChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerDollarCoinsChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerHalfDollarCoinsChange
        /// </summary>
        private uint _customerHalfDollarCoinsChange;

        /// <summary>
        /// The Customer's Half DollarsChange value of coins
        /// </summary>
        public uint CustomerHalfDollarCoinsChange
        {
            get => _customerHalfDollarCoinsChange;
            set
            {
                _customerHalfDollarCoinsChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerHalfDollarCoinsChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerQuartersChange
        /// </summary>
        private uint _customerQuartersChange;

        /// <summary>
        /// The Customer's QuartersChange value of coins
        /// </summary>
        public uint CustomerQuartersChange
        {
            get => _customerQuartersChange;
            set
            {
                _customerQuartersChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuartersChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerDimesChange
        /// </summary>
        private uint _customerDimesChange;

        /// <summary>
        /// The Customer's DimesChange value of coins
        /// </summary>
        public uint CustomerDimesChange
        {
            get => _customerDimesChange;
            set
            {
                _customerDimesChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerDimesChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerDimesChange
        /// </summary>
        private uint _customerNicklesChange;

        /// <summary>
        /// The Customer's DimesChange value of coins
        /// </summary>
        public uint CustomerNicklesChange
        {
            get => _customerNicklesChange;
            set
            {
                _customerNicklesChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerNicklesChange)));
            }
        }

        /// <summary>
        /// A private backing field for the property CustomerPenniesChange
        /// </summary>
        private uint _customerPenniesChange;

        /// <summary>
        /// The Customer's Pennies value of coins
        /// </summary>
        public uint CustomerPenniesChange
        {
            get => _customerPenniesChange;
            set
            {
                _customerPenniesChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerPenniesChange)));
            }
        }
        #endregion

        #region ControlInteractionProperties

        /// <summary>
        /// The Cash Drawer's Total
        /// </summary>
        public decimal TotalSale => Math.Round(_order.Total, 2);

        /// <summary>
        /// The customer's cash quantity
        /// </summary>
        public decimal CustomerQuantity
        {
            get
            {
               return 0m + (decimal)(100 * CustomerHundreds) + (decimal)(50 * CustomerFifties)
                   + (decimal)(20 * CustomerTwenties) + (decimal)(10 * CustomerTens) + (decimal)(5 * CustomerFives) + (decimal)(2 * CustomerTwos)
                   + (decimal)CustomerOnes + (decimal)CustomerDollarCoins + 0.50m * (decimal)CustomerHalfDollarCoins
                   + 0.25m * (decimal)CustomerQuarters + 0.10m * (decimal)CustomerDimes + 0.05m * (decimal)CustomerNickles + 0.01m * (decimal)CustomerPennies;
            }
        }

        /// <summary>
        /// The amount due of cash payment
        /// </summary>
        public decimal AmountDue
        {
            get
            {
                if (_order.Total - CustomerQuantity < 0)
                {
                    return 0;
                }
                else
                {
                    return TotalSale - CustomerQuantity;
                }
            }
        }
        
        /// <summary>
        /// The amount due of cash payment
        /// </summary>
        public decimal ChangeOwed
        {
            get
            {
                if (TotalSale - CustomerQuantity >= 0)
                {
                    Hundreds += CustomerHundredsChange;
                    Fifties += CustomerFiftiesChange;
                    Twenties += CustomerTwentiesChange;
                    Tens += CustomerTensChange;
                    Fives += CustomerFivesChange;
                    Twos += CustomerTwosChange;
                    Ones += CustomerOnesChange;
                    DollarCoins += CustomerDollarCoinsChange;
                    HalfDollarCoins += CustomerHalfDollarCoinsChange;
                    Quarters += CustomerQuartersChange;
                    Dimes += CustomerDimesChange;
                    Nickles += CustomerNicklesChange;
                    Pennies += CustomerPenniesChange;

                    //MakeAppropriateChange(-1 * (TotalSale - CustomerQuantity));
                    
                    CustomerHundredsChange = 0;
                    CustomerFiftiesChange = 0;
                    CustomerTwentiesChange = 0;
                    CustomerTensChange = 0;
                    CustomerFivesChange = 0;
                    CustomerTwosChange = 0;
                    CustomerOnesChange = 0;
                    CustomerDollarCoinsChange = 0;
                    CustomerHalfDollarCoinsChange = 0;
                    CustomerQuartersChange = 0;
                    CustomerDimesChange = 0;
                    CustomerNicklesChange = 0;
                    CustomerPenniesChange = 0;
                    

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerHundredsChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerFiftiesChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTwentiesChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTensChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerFivesChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTwosChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerOnesChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerDollarCoinsChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerHalfDollarCoinsChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuartersChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerDimesChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerNicklesChange)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerPenniesChange)));

                    return 0;
                }
                else
                {
                    if (CalculateChange)
                    {
                        Hundreds += CustomerHundredsChange;
                        Fifties += CustomerFiftiesChange;
                        Twenties += CustomerTwentiesChange;
                        Tens += CustomerTensChange;
                        Fives += CustomerFivesChange;
                        Twos += CustomerTwosChange;
                        Ones += CustomerOnesChange;
                        DollarCoins += CustomerDollarCoinsChange;
                        HalfDollarCoins += CustomerHalfDollarCoinsChange;
                        Quarters += CustomerQuartersChange;
                        Dimes += CustomerDimesChange;
                        Nickles += CustomerNicklesChange;
                        Pennies += CustomerPenniesChange;

                        
                        CustomerHundredsChange = 0;
                        CustomerFiftiesChange = 0;
                        CustomerTwentiesChange = 0;
                        CustomerTensChange = 0;
                        CustomerFivesChange = 0;
                        CustomerTwosChange = 0;
                        CustomerOnesChange = 0;
                        CustomerDollarCoinsChange = 0;
                        CustomerHalfDollarCoinsChange = 0;
                        CustomerQuartersChange = 0;
                        CustomerDimesChange = 0;
                        CustomerNicklesChange = 0;
                        CustomerPenniesChange = 0;
                        

                        MakeAppropriateChange(-1 * (TotalSale - CustomerQuantity));

                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerHundredsChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerFiftiesChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTwentiesChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTensChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerFivesChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerTwosChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerOnesChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerDollarCoinsChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerHalfDollarCoinsChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerQuartersChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerDimesChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerNicklesChange)));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomerPenniesChange)));
                    }
                    return -1*(TotalSale - CustomerQuantity);
                }
            }
        }

        /// <summary>
        /// Calculate appropriate change for the cash payment
        /// </summary>
        /// <param name="changeOwed">The value of changed owed of cash transaction</param>
        private void MakeAppropriateChange(decimal changeOwed)
        {
            decimal change = changeOwed;
            if (Hundreds != 0)
            {
                uint bound = Hundreds;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 100) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 100;
                        Hundreds--;
                        CustomerHundredsChange++;
                    }
                }
            }

            if (Fifties != 0)
            {
                uint bound = Fifties;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 50) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 50;
                        Fifties--;
                        CustomerFiftiesChange++;
                    }
                }
            }

            if (Twenties != 0)
            {
                uint bound = Twenties;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 20) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 20;
                        Twenties--;
                        CustomerTwentiesChange++;
                    }
                }
            }

            if (Tens != 0)
            {
                uint bound = Tens;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 10) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 10;
                        Tens--;
                        CustomerTensChange++;
                    }
                }
            }

            if (Fives != 0)
            {
                uint bound = Fives;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 5) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 5;
                        Fives--;
                        CustomerFivesChange++;
                    }
                }
            }

            if (Twos != 0)
            {
                uint bound = Twos;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 2) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 2;
                        Twos--;
                        CustomerTwosChange++;
                    }
                }
            }

            if (Ones != 0)
            {
                uint bound = Ones;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 1) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 1;
                        Ones--;
                        CustomerOnesChange++;
                    }
                }
            }

            if (DollarCoins != 0)
            {
                uint bound = DollarCoins;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 1) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 1;
                        DollarCoins--;
                        CustomerDollarCoinsChange++;
                    }
                }
            }

            if (HalfDollarCoins != 0)
            {
                uint bound = HalfDollarCoins;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 0.5m) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 0.5m;
                        HalfDollarCoins--;
                        CustomerHalfDollarCoinsChange++;
                    }
                }
            }

            if (Quarters != 0)
            {
                uint bound = Quarters;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 0.25m) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 0.25m;
                        Quarters--;
                        CustomerQuartersChange++;
                    }
                }
            }

            if (Dimes != 0)
            {
                uint bound = Dimes;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 0.10m) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 0.10m;
                        Dimes--;
                        CustomerDimesChange++;
                    }
                }
            }

            if (Nickles != 0)
            {
                uint bound = Nickles;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 0.05m) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 0.05m;
                        Nickles--;
                        CustomerNicklesChange++;
                    }
                }
            }

            if (Pennies != 0)
            {
                uint bound = Pennies;
                for (int i = 0; i < bound; i++)
                {
                    if ((change - 0.01m) < 0)
                    {
                        break;
                    }
                    else
                    {
                        change -= 0.01m;
                        Pennies--;
                        CustomerPenniesChange++;
                    }
                }
            }
        }

        /// <summary>
        /// Sum of changes for cash payment
        /// </summary>
        public decimal SumOfChanges
        {
            get
            {
                decimal soc;
                soc = 0m + (decimal)(100 * CustomerHundredsChange) + (decimal)(50 * CustomerFiftiesChange)
                   + (decimal)(20 * CustomerTwentiesChange) + (decimal)(10 * CustomerTensChange) + (decimal)(5 * CustomerFivesChange)
                   + (decimal)(2 * CustomerTwosChange) + (decimal)CustomerOnesChange + (decimal)CustomerDollarCoinsChange
                   + 0.50m * (decimal)CustomerHalfDollarCoinsChange + 0.25m * (decimal)CustomerQuartersChange
                   + 0.10m * (decimal)CustomerDimesChange + 0.05m * (decimal)CustomerNicklesChange + 0.01m * (decimal)CustomerPenniesChange;
                return soc;
            }
        }

        #endregion

        public CashDrawerViewModel(Order order)
        {
            _order = order;
            this.Hundreds = CashDrawer.Hundreds;
            this.Fifties = CashDrawer.Fifties;
            this.Twenties = CashDrawer.Twenties;
            this.Tens = CashDrawer.Tens;
            this.Fives = CashDrawer.Fives;
            this.Twos = CashDrawer.Twos;
            this.Ones = CashDrawer.Ones;
            this.DollarCoins = CashDrawer.DollarCoins;
            this.HalfDollarCoins = CashDrawer.HalfDollarCoins;
            this.Quarters = CashDrawer.Quarters;
            this.Dimes = CashDrawer.Dimes;
            this.Nickles = CashDrawer.Nickles;
            this.Pennies = CashDrawer.Pennies;
        }
    }
}
