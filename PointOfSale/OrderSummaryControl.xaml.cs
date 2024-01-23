using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        /// <summary>
        /// An event triggered when the menu item picked
        /// </summary>
        public event EventHandler<RoutedEventArgs> Select = default!;

        /// <summary>
        /// An event triggered when the menu item picked
        /// </summary>
        public event EventHandler<RoutedEventArgs> Remove = default!;

        /// <summary>
        /// Constructs order summary display
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();
            ((INotifyCollectionChanged)itemsListView.Items).CollectionChanged += AutoScrollDown!;
        }

        /// <summary>
        /// Automatically scroll down when new items are added to the listview.
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void AutoScrollDown(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                itemsListView.ScrollIntoView(e.NewItems?[0]);
            }
        }

        /// <summary>
        /// Auto resize gridview columns when the main windows size changes
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void AutoResizeGridColumns(object sender, SizeChangedEventArgs e)
        {
            if (sender is ListView listView)
            {
                if (listView.View is GridView gView)
                {
                    var workingWidth = (listView.ActualWidth - SystemParameters.VerticalScrollBarWidth)*0.96;
                    var col1 = 0.10;
                    var col2 = 0.52;
                    var col3 = 0.18;
                    var col4 = 0.20;

                    gView.Columns[0].Width = workingWidth * col1;
                    gView.Columns[1].Width = workingWidth * col2;
                    gView.Columns[2].Width = workingWidth * col3;
                    gView.Columns[2].Width = workingWidth * col4;
                }
            }
        }

        /// <summary>
        /// The event handler for when the user selected menu items.
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void CustomItemSelected(object sender, RoutedEventArgs e)
        {
            if (sender is ListView lvi)
            {
                Select?.Invoke(lvi, e);
            }
        }

        /// <summary>
        /// The event handler for when the user clicked the button of remove item
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (DataContext is Order order)
            {
                //Remove?.Invoke(sender, e);
                Remove?.Invoke(itemsListView, e);
                ICollectionView cv = CollectionViewSource.GetDefaultView(itemsListView.ItemsSource);
                cv.Refresh();
            }
        }
    }
}
