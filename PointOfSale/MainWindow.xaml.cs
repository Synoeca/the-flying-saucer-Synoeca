using RoundRegister;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheFTL.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TheFTL.PointOfSale.MenuItemSelectionControl;

namespace TheFTL.PointOfSale
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructs main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Order() { TaxRate = 0.30m, Number = Order.LastNumberUsed + 1};
            CollapseAllControls();
            uxMenuItemSelectionControl.Visibility = Visibility.Visible;
            CancelOrder.IsEnabled = false;
            BackToMenu.IsEnabled = false;
        }

        /// <summary>
        /// An event on menu item picked
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void OnPicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                if (sender is Button button)
                {
                    switch (button.Name)
                    {
                        case "FlyingSaucerBtn":
                            order.Add(new FlyingSaucer());
                            break;
                        case "CrashedSaucerBtn":
                            order.Add(new CrashedSaucer());
                            break;
                        case "LivestockMutilationBtn":
                            order.Add(new LivestockMutilation());
                            break;
                        case "OuterOmeletteBtn":
                            order.Add(new OuterOmelette());
                            break;

                        case "CropCircleBtn":
                            order.Add(new CropCircle());
                            break;
                        case "GlowingHaystackBtn":
                            order.Add(new GlowingHaystack());
                            break;
                        case "TakenBaconBtn":
                            order.Add(new TakenBacon());
                            break;
                        case "MissingLinksBtn":
                            order.Add(new MissingLinks());
                            break;
                        case "EvisceratedEggsBtn":
                            order.Add(new EvisceratedEggs());
                            break;
                        case "YouAreToastBtn":
                            order.Add(new YouAreToast());
                            break;

                        case "LiquifiedVegetationBtn":
                            order.Add(new LiquifiedVegetation());
                            break;
                        case "SaucerFuelBtn":
                            order.Add(new SaucerFuel());
                            break;
                        case "InorganicSubstanceBtn":
                            order.Add(new InorganicSubstance());
                            break;
                    }
                }
            }
            CancelOrder.IsEnabled = true;
            e.Handled = true;
        }


        /// <summary>
        /// An event on menu item picked
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void OnSelected(object sender, RoutedEventArgs e)
        {
            if (e.Source is ListView lvi)
            {
                BackToMenu.IsEnabled = true;
                switch (lvi.SelectedItem)
                {
                    case CrashedSaucer:
                        CollapseAllControls();
                        uxCrashedSaucerCustomizationControl.Visibility = Visibility.Visible;
                        uxCrashedSaucerCustomizationControl.DataContext = lvi.SelectedItem;
                        uxCrashedSaucerCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case FlyingSaucer:
                        CollapseAllControls();
                        uxFlyingSaucerCustomizationControl.Visibility = Visibility.Visible;
                        uxFlyingSaucerCustomizationControl.DataContext = lvi.SelectedItem;
                        uxFlyingSaucerCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case LivestockMutilation:
                        CollapseAllControls();
                        uxLivestockMutilationCustomizationControl.Visibility = Visibility.Visible;
                        uxLivestockMutilationCustomizationControl.DataContext = lvi.SelectedItem;
                        uxLivestockMutilationCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case OuterOmelette:
                        CollapseAllControls();
                        uxOuterOmeletteCustomizationControl.Visibility = Visibility.Visible;
                        uxOuterOmeletteCustomizationControl.DataContext = lvi.SelectedItem;
                        uxOuterOmeletteCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case CropCircle:
                        CollapseAllControls();
                        uxCropCircleCustomizationControl.Visibility = Visibility.Visible;
                        uxCropCircleCustomizationControl.DataContext = lvi.SelectedItem;
                        uxCropCircleCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case EvisceratedEggs:
                        CollapseAllControls();
                        uxEvisceratedEggsCustomizationControl.Visibility = Visibility.Visible;
                        uxEvisceratedEggsCustomizationControl.DataContext = lvi.SelectedItem;
                        uxEvisceratedEggsCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case GlowingHaystack:
                        CollapseAllControls();
                        uxGlowingHaystackCustomizationControl.Visibility = Visibility.Visible;
                        uxGlowingHaystackCustomizationControl.DataContext = lvi.SelectedItem;
                        uxGlowingHaystackCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case MissingLinks:
                        CollapseAllControls();
                        uxMissingLinksCustomizationControl.Visibility = Visibility.Visible;
                        uxMissingLinksCustomizationControl.DataContext = lvi.SelectedItem;
                        uxMissingLinksCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case TakenBacon:
                        CollapseAllControls();
                        uxTakenBaconCustomizationControl.Visibility = Visibility.Visible;
                        uxTakenBaconCustomizationControl.DataContext = lvi.SelectedItem;
                        uxTakenBaconCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case YouAreToast:
                        CollapseAllControls();
                        uxYouAreToastCustomizationControl.Visibility = Visibility.Visible;
                        uxYouAreToastCustomizationControl.DataContext = lvi.SelectedItem;
                        uxYouAreToastCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case InorganicSubstance:
                        CollapseAllControls();
                        uxInorganicSubstanceCustomizationControl.Visibility = Visibility.Visible;
                        uxInorganicSubstanceCustomizationControl.DataContext = lvi.SelectedItem;
                        uxInorganicSubstanceCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case LiquifiedVegetation:
                        CollapseAllControls();
                        uxLiquifiedVegetationCustomizationControl.Visibility = Visibility.Visible;
                        uxLiquifiedVegetationCustomizationControl.DataContext = lvi.SelectedItem;
                        uxLiquifiedVegetationCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;

                    case SaucerFuel:
                        CollapseAllControls();
                        uxSaucerFuelCustomizationControl.Visibility = Visibility.Visible;
                        uxSaucerFuelCustomizationControl.DataContext = lvi.SelectedItem;
                        uxSaucerFuelCustomizationControl.SelectedItemIndex = lvi.SelectedIndex + 1;
                        break;
                }
            }

            e.Handled = true;
        }

        /// <summary>
        /// Delete the selected item and collapse the control if the deleted item was showed by control
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void OnRemoved(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button btn)
            {
                if (DataContext is Order order)
                {
                    if (uxMenuItemSelectionControl.Visibility != Visibility.Visible)
                    {
                        switch (btn.DataContext)
                        {
                            case CrashedSaucer:
                                if (uxCrashedSaucerCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxCrashedSaucerCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case FlyingSaucer:
                                if (uxFlyingSaucerCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxFlyingSaucerCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case LivestockMutilation:
                                if (uxLivestockMutilationCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxLivestockMutilationCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case OuterOmelette:
                                if (uxOuterOmeletteCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxOuterOmeletteCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case CropCircle:
                                if (uxCropCircleCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxCropCircleCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case EvisceratedEggs:
                                if (uxEvisceratedEggsCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxEvisceratedEggsCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case GlowingHaystack:
                                if (uxGlowingHaystackCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxGlowingHaystackCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case MissingLinks:
                                if (uxMissingLinksCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxMissingLinksCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case TakenBacon:
                                if (uxTakenBaconCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxTakenBaconCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case YouAreToast:
                                if (uxYouAreToastCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxYouAreToastCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case InorganicSubstance:
                                if (uxInorganicSubstanceCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxInorganicSubstanceCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case LiquifiedVegetation:
                                if (uxLiquifiedVegetationCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxLiquifiedVegetationCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;

                            case SaucerFuel:
                                if (uxSaucerFuelCustomizationControl.Visibility == Visibility.Visible)
                                {
                                    if (uxSaucerFuelCustomizationControl.DataContext == btn.DataContext)
                                    {
                                        CollapseAllControls();
                                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                                    }
                                }
                                break;
                        }
                    }
                    order.Remove((IMenuItem)btn.DataContext);
                    ReIndex(sender);

                    if (order.Count == 0)
                    {
                        CancelOrder.IsEnabled = false;
                        BackToMenu.IsEnabled = false;
                        return;
                    }
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// Clear the order when cancle order button clicked
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void CancleOrderClick(object sender, RoutedEventArgs e)
        {
            DataContext = new Order() { TaxRate = 0.30m, Number = Order.LastNumberUsed + 1 };
            CollapseAllControls();
            uxMenuItemSelectionControl.Visibility = Visibility.Visible;
            BackToMenu.IsEnabled = false;
            CancelOrder.IsEnabled = false;
            e.Handled = true;
        }

        /// <summary>
        /// Clear the order and increase order number
        /// when complete order button clicked
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void CompleteOrderClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                if (order.Count == 0)
                {
                    MessageBox.Show("Please select at least one item.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            CollapseAllControls();
            ButtonGrid.Visibility = Visibility.Collapsed;
            uxPaymentOptionScreenControl.Visibility = Visibility.Visible;
            uxOrderSummaryControl.itemsListView.UnselectAll();
            foreach (var lvi in uxOrderSummaryControl.itemsListView.Items)
            {
                if (lvi != null)
                {
                    if (this.uxOrderSummaryControl.itemsListView.ItemContainerGenerator.ContainerFromItem(lvi) is ListViewItem lbi)
                    {
                        lbi!.IsHitTestVisible = false;
                    }
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// Clear the order and increase order number
        /// when complete order button clicked
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void BacktoMenuClick(object sender, RoutedEventArgs e)
        {
            uxOrderSummaryControl.itemsListView.UnselectAll();
            CollapseAllControls();
            uxMenuItemSelectionControl.Visibility = Visibility.Visible;
            BackToMenu.IsEnabled = false;
            e.Handled = true;
        }

        /// <summary>
        /// An event on return to order clicked
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void OnReturned(object sender, RoutedEventArgs e)
        {
            CollapseAllControls();
            uxMenuItemSelectionControl.Visibility = Visibility.Visible;
            uxOrderSummaryControl.Visibility = Visibility.Visible;
            ButtonGrid.Visibility = Visibility.Visible;
            foreach (var lvi in uxOrderSummaryControl.itemsListView.Items)
            {
                ListViewItem? lbi = this.uxOrderSummaryControl.itemsListView.ItemContainerGenerator.ContainerFromItem(lvi) as ListViewItem;
                lbi!.IsHitTestVisible = true;
            }
            e.Handled = true;
        }

        /// <summary>
        /// An event on return to order clicked
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void OnCardPaid(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                CardTransactionResult str = CardReader.RunCard((double)order.Total);
                switch (str)
                {
                    case CardTransactionResult.Approved:
                        MessageBox.Show("Card Approved", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        PrintReceipt(true, 0, 0);

                        DataContext = new Order() { TaxRate = 0.30m, Number = Order.LastNumberUsed + 1 };
                        CollapseAllControls();
                        ButtonGrid.Visibility = Visibility.Visible;
                        uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                        BackToMenu.IsEnabled = false;
                        CancelOrder.IsEnabled = false;
                        break;

                    case CardTransactionResult.Declined:
                        MessageBox.Show("Card Declined", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                        break;

                    case CardTransactionResult.ReadError:
                        MessageBox.Show("Read Error", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;

                    case CardTransactionResult.InsufficientFunds:
                        MessageBox.Show("Insufficient Funds", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;

                    case CardTransactionResult.IncorrectPin:
                        MessageBox.Show("Incorrect Pin", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// An event on return to order clicked
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void OnCashPaid(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                CollapseAllControls();
                uxOrderSummaryControl.Visibility = Visibility.Collapsed;
                ButtonGrid.Visibility = Visibility.Collapsed;
                uxCurrencyControl.DataContext = new CashDrawerViewModel(order);
                uxCurrencyControl.Visibility = Visibility.Visible;
            }
            e.Handled = true;
        }

        /// <summary>
        /// An event on finalize the order clicked
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void OnFinalized(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                if (sender is Button btn)
                {
                    if(btn.DataContext is CashDrawerViewModel cdvm)
                    {
                        if (cdvm.AmountDue != 0)
                        {
                            MessageBox.Show("Insufficient Amount", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                        }
                        else
                        {
                            cdvm.CalculateChange = false;
                            if (cdvm.ChangeOwed != cdvm.SumOfChanges)
                            {
                                MessageBox.Show("Insufficient Changes", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                                cdvm.CalculateChange = true;
                                return;
                            }
                            MessageBox.Show("Transaction Complete", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            PrintReceipt(false, cdvm.TotalSale + cdvm.ChangeOwed, cdvm.ChangeOwed);

                            CurrencyChanger(cdvm);

                            DataContext = new Order() { TaxRate = 0.30m, Number = Order.LastNumberUsed + 1 };
                            CollapseAllControls();
                            ButtonGrid.Visibility = Visibility.Visible;
                            uxMenuItemSelectionControl.Visibility = Visibility.Visible;
                            uxOrderSummaryControl.Visibility = Visibility.Visible;
                            BackToMenu.IsEnabled = false;
                            CancelOrder.IsEnabled = false;
                        }
                    }
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// Exchange currency when payment is finalized
        /// </summary>
        /// <param name="cdvm">CashDrawerViewModel instance for the currency change</param>
        private void CurrencyChanger(CashDrawerViewModel cdvm)
        {
            CashDrawer.Open();
            CashDrawer.Hundreds -= cdvm.CustomerHundredsChange;
            CashDrawer.Fifties -= cdvm.CustomerFiftiesChange;
            CashDrawer.Twenties -= cdvm.CustomerTwentiesChange;
            CashDrawer.Tens -= cdvm.CustomerTensChange;
            CashDrawer.Fives -= cdvm.CustomerFivesChange;
            CashDrawer.Twos -= cdvm.CustomerTwosChange;
            CashDrawer.Ones -= cdvm.CustomerOnesChange;
            CashDrawer.DollarCoins -= cdvm.CustomerDollarCoinsChange;
            CashDrawer.HalfDollarCoins -= cdvm.CustomerHalfDollarCoinsChange;
            CashDrawer.Quarters -= cdvm.CustomerQuartersChange;
            CashDrawer.Dimes -= cdvm.CustomerDimesChange;
            CashDrawer.Nickles -= cdvm.CustomerNicklesChange;
            CashDrawer.Pennies -= cdvm.CustomerPenniesChange;

            CashDrawer.Hundreds += cdvm.CustomerHundreds;
            CashDrawer.Fifties += cdvm.CustomerFifties;
            CashDrawer.Twenties += cdvm.CustomerTwenties;
            CashDrawer.Tens += cdvm.CustomerTens;
            CashDrawer.Fives += cdvm.CustomerFives;
            CashDrawer.Twos += cdvm.CustomerTwos;
            CashDrawer.Ones += cdvm.CustomerOnes;
            CashDrawer.DollarCoins += cdvm.CustomerDollarCoins;
            CashDrawer.HalfDollarCoins += cdvm.CustomerHalfDollarCoins;
            CashDrawer.Quarters += cdvm.CustomerQuarters;
            CashDrawer.Dimes += cdvm.CustomerDimes;
            CashDrawer.Nickles += cdvm.CustomerNickles;
            CashDrawer.Pennies += cdvm.CustomerPennies;
        }

        /// <summary>
        /// Printing the finalized order
        /// </summary>
        /// <param name="isCard">whether is payment method Card or Cash</param>
        /// <param name="cash">the amount of cash handed over by a customer</param>
        /// <param name="change">the amount of change to give back to the customer</param>
        private void PrintReceipt(bool isCard, decimal cash, decimal change)
        {
            if (DataContext is Order order)
            {
                List<IMenuItem> lmi = order.ToList<IMenuItem>();
                ReceiptPrinter.PrintLine($"               RECEIPT                ");
                ReceiptPrinter.PrintLine($"======================================");
                ReceiptPrinter.PrintLine($"Order #{order.Number}");
                ReceiptPrinter.PrintLine($"{DateTime.Now}");
                ReceiptPrinter.PrintLine($"======================================");
                ReceiptPrinter.PrintLine("");
                ReceiptPrinter.PrintLine($"ID  Name                       Price");
                ReceiptPrinter.PrintLine($"--------------------------------------");
                int i = 1;
                foreach (IMenuItem mi in lmi)
                {
                    ReceiptPrinter.PrintLine($"{i, -4}{mi.Name, -20}       {mi.Price,-10:C}");
                    foreach (string si in mi.SpecialInstructions)
                    {
                        ReceiptPrinter.PrintLine($"{" ", -3} · {si}");
                    }
                    i++;
                }
                ReceiptPrinter.PrintLine("");
                ReceiptPrinter.PrintLine($"======================================");
                ReceiptPrinter.PrintLine("");
                ReceiptPrinter.PrintLine($"Subtotal                       {order.Subtotal,-10:C}");
                ReceiptPrinter.PrintLine($"Tax                            {order.Tax,-10:C}");
                ReceiptPrinter.PrintLine($"Total                          {order.Total,-10:C}");
                ReceiptPrinter.PrintLine("");
                if (isCard)
                {
                    ReceiptPrinter.PrintLine($"Card                           {order.Total,-10:C}");
                    ReceiptPrinter.PrintLine($"Change                         {0,-10:C}");

                }
                else
                {
                    ReceiptPrinter.PrintLine($"Cash                           {cash,-10:C}");
                    ReceiptPrinter.PrintLine($"Change                         {change,-10:C}");
                }
                ReceiptPrinter.PrintLine("");
                ReceiptPrinter.PrintLine($"======================================");
                ReceiptPrinter.PrintLine("");
                ReceiptPrinter.PrintLine($"                 ***                  ");
                ReceiptPrinter.PrintLine($"      Thank You For Your Order!       ");
                ReceiptPrinter.CutTape();
            }
        }

        /// <summary>
        /// Set ID number of each menu item controls to correct index id number
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        private void ReIndex(object sender)
        {
            if (sender is ListView lv)
            {
                foreach (IMenuItem imi in lv.Items)
                {
                    switch (imi)
                    {
                        case CrashedSaucer:
                            int index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxCrashedSaucerCustomizationControl.DataContext);
                            uxCrashedSaucerCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case CropCircle:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxCropCircleCustomizationControl.DataContext);
                            uxCropCircleCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case EvisceratedEggs:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxEvisceratedEggsCustomizationControl.DataContext);
                            uxEvisceratedEggsCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case FlyingSaucer:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxFlyingSaucerCustomizationControl.DataContext);
                            uxFlyingSaucerCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case GlowingHaystack:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxGlowingHaystackCustomizationControl.DataContext);
                            uxGlowingHaystackCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case InorganicSubstance:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxInorganicSubstanceCustomizationControl.DataContext);
                            uxInorganicSubstanceCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case LiquifiedVegetation:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxLiquifiedVegetationCustomizationControl.DataContext);
                            uxLiquifiedVegetationCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case LivestockMutilation:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxLivestockMutilationCustomizationControl.DataContext);
                            uxLivestockMutilationCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case MissingLinks:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxMissingLinksCustomizationControl.DataContext);
                            uxMissingLinksCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case OuterOmelette:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxOuterOmeletteCustomizationControl.DataContext);
                            uxOuterOmeletteCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case SaucerFuel:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxSaucerFuelCustomizationControl.DataContext);
                            uxSaucerFuelCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case TakenBacon:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxTakenBaconCustomizationControl.DataContext);
                            uxTakenBaconCustomizationControl.SelectedItemIndex = index + 1;
                            break;

                        case YouAreToast:
                            index = uxOrderSummaryControl.itemsListView.Items.IndexOf(uxYouAreToastCustomizationControl.DataContext);
                            uxYouAreToastCustomizationControl.SelectedItemIndex = index + 1;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Collapse all controls in PointOfSale project
        /// </summary>
        private void CollapseAllControls()
        {
            uxCrashedSaucerCustomizationControl.Visibility = Visibility.Collapsed;
            uxFlyingSaucerCustomizationControl.Visibility = Visibility.Collapsed;
            uxLivestockMutilationCustomizationControl.Visibility = Visibility.Collapsed;
            uxOuterOmeletteCustomizationControl.Visibility = Visibility.Collapsed;
            uxCropCircleCustomizationControl.Visibility = Visibility.Collapsed;
            uxEvisceratedEggsCustomizationControl.Visibility = Visibility.Collapsed;
            uxGlowingHaystackCustomizationControl.Visibility = Visibility.Collapsed;
            uxMissingLinksCustomizationControl.Visibility = Visibility.Collapsed;
            uxTakenBaconCustomizationControl.Visibility = Visibility.Collapsed;
            uxYouAreToastCustomizationControl.Visibility = Visibility.Collapsed;
            uxInorganicSubstanceCustomizationControl.Visibility = Visibility.Collapsed;
            uxLiquifiedVegetationCustomizationControl.Visibility = Visibility.Collapsed;
            uxSaucerFuelCustomizationControl.Visibility = Visibility.Collapsed;
            uxMenuItemSelectionControl.Visibility = Visibility.Collapsed;
            uxPaymentOptionScreenControl.Visibility = Visibility.Collapsed;
            uxCurrencyControl.Visibility = Visibility.Collapsed;
        }
    }
}
