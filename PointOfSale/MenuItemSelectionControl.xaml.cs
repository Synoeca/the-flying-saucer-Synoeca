using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// An event triggered when the menu item picked
        /// </summary>
        public event EventHandler<RoutedEventArgs> Pick = default!;

        /// <summary>
        /// Constructs a new menu item instance
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The event handler for when the user selected menu items.
        /// </summary>
        /// <param name="sender">The sender of this event</param>
        /// <param name="e">Metadata for the event</param>
        private void MenuItemSelected(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                Pick?.Invoke(btn, e);
            }
        }
    }
}
