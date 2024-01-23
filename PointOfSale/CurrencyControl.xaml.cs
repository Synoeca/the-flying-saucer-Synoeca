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
using TheFTL.Data;

namespace TheFTL.PointOfSale
{
    /// <summary>
    /// Interaction logic for CurrencyControl.xaml
    /// </summary>
    public partial class CurrencyControl : UserControl
    {
        /// <summary>
        /// An event triggered when the menu item picked
        /// </summary>
        public event EventHandler<RoutedEventArgs> Return = default!;

        /// <summary>
        /// An event triggered when the ored finalized
        /// </summary>
        public event EventHandler<RoutedEventArgs> Finalize = default!;

        public CurrencyControl()
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
        /// The event hanlder for when the user clicked the Finalize the Order button
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void FinalizeOrderClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                Finalize?.Invoke(sender, e);
            }
        }
    }
}
