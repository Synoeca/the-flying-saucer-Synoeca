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
    /// Interaction logic for CurrencyBox.xaml
    /// </summary>
    public partial class CurrencyBox : UserControl
    {
        public CurrencyBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dependency property for the selected currency
        /// </summary>
        public static readonly DependencyProperty CurrencyProperty = DependencyProperty.Register(
            nameof(CurrencyCount),
            typeof(decimal),
            typeof(CurrencyBox),
            new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        /// <summary>
        /// Count property of selected item
        /// </summary>
        public decimal CurrencyCount
        {
            get => (decimal)GetValue(CurrencyProperty);
            set
            {
                SetValue(CurrencyProperty, value);
            }
        }

        /// <summary>
        /// Handle increment
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (CurrencyCount != decimal.MaxValue) CurrencyCount++;
            e.Handled = true;
        }

        /// <summary>
        /// Handle decrement
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (CurrencyCount != 0) CurrencyCount--;
            e.Handled = true;
        }
    }
}
