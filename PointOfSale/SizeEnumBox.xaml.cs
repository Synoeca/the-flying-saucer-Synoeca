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
    /// Interaction logic for SizeEnumBox.xaml
    /// </summary>
    public partial class SizeEnumBox : UserControl
    {
        public SizeEnumBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Register dependency property
        /// </summary>
        public static readonly DependencyProperty EnumsProperty = DependencyProperty.Register(
            nameof(SizeEnums),
            typeof(Enum),
            typeof(SizeEnumBox),
            new FrameworkPropertyMetadata(ServingSize.Small, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        /// <summary>
        /// Get selected items enum
        /// </summary>
        public Enum SizeEnums
        {
            get => (Enum)GetValue(EnumsProperty);
            set
            {
                SetValue(EnumsProperty, value);
            }
        }
    }
}
