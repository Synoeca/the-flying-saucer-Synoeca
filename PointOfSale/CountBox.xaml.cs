using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Interaction logic for CountBox.xaml
    /// </summary>
    public partial class CountBox : UserControl
    {
        public CountBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dependency property for the selected item
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            nameof(Count),
            typeof(uint),
            typeof(CountBox),
            new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        
        /// <summary>
        /// Count property of selected item
        /// </summary>
        public uint Count
        {
            get => (uint)GetValue(CountProperty);
            set
            {
                SetValue(CountProperty, value);
            }
        }

        /// <summary>
        /// Handle increment
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Count != uint.MaxValue) Count++;
            e.Handled = true;
        }

        /// <summary>
        /// Handle decrement
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count != uint.MinValue) Count--;
            e.Handled = true;
        }
    }
}
