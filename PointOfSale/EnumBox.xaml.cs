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
    /// Interaction logic for EnumBox.xaml
    /// </summary>
    public partial class EnumBox : UserControl
    {
        public EnumBox()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Register dependency property
        /// </summary>
        public static readonly DependencyProperty EnumProperty = DependencyProperty.Register(
            nameof(Enums),
            typeof(Enum),
            typeof(EnumBox),
            new FrameworkPropertyMetadata(EggStyle.HardBoiled, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        /// <summary>
        /// Get selected item's enum
        /// </summary>
        public Enum Enums
        {
            get => (Enum)GetValue(EnumProperty);
            set
            {
                SetValue(EnumProperty, value);
            } 
        }
    }
}
