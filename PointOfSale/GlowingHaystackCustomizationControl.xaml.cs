using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for GlowingHaystackCustomizationControl.xaml
    /// </summary>
    public partial class GlowingHaystackCustomizationControl : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// A PropertyChanged event handler would notify of property change of SelectedItemIndex
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        public GlowingHaystackCustomizationControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A private backing field of the property SelectedItemIndex
        /// </summary>
        private int _selectedItemIndex;

        /// <summary>
        /// An index of the selected item
        /// </summary>
        public int SelectedItemIndex
        {
            get => _selectedItemIndex;
            set
            {
                _selectedItemIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItemIndex)));
            }
        }
    }
}
