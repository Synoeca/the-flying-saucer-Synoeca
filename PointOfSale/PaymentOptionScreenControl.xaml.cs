using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheFTL.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentOptionScreenControl.xaml
    /// </summary>
    public partial class PaymentOptionScreenControl : UserControl
    {
        /// <summary>
        /// An event triggered when the menu item picked
        /// </summary>
        public event EventHandler<RoutedEventArgs> Return = default!;

        /// <summary>
        /// An event triggered when the menu item picked
        /// </summary>
        public event EventHandler<RoutedEventArgs> Card = default!;

        /// <summary>
        /// An event triggered when the menu item picked
        /// </summary>
        public event EventHandler<RoutedEventArgs> Cash = default!;

        public PaymentOptionScreenControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The event handler for when the user clicked the Return to Order button
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void ReturnToOrderClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                Return?.Invoke(btn, e);
            }
        }

        /// <summary>
        /// The event handler for when the user clicked the Credit/Debit button
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void SelectCardPayment(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                Card?.Invoke(btn, e);
            }
        }

        /// <summary>
        /// The event handler for when the user clicked the Credit/Debit button
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void SelectCashPayment(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                Cash?.Invoke(btn, e);
            }
        }
    }
}
