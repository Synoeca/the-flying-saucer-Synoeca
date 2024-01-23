using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// The class to represent the side menu, Crop Circle
    /// </summary>
    public class CropCircle : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the CropCircle instance
        /// </summary>
        public override string Name => "Crop Circle";

        /// <summary>
        /// The description of the CropCircle instance
        /// </summary>
        public override string Description => "Oatmeal topped with mixed berries.";

        /// <summary>
        /// A private backing for the property Berries
        /// </summary>
        private bool _berries = true;

        /// <summary>
        /// If the CropCircle instance is served with berries
        /// </summary>
        public bool Berries
        {
            get => _berries;
            set
            {
                _berries = value;
                OnPropertyChanged(nameof(this.Berries));
                OnPropertyChanged(nameof(this.Calories));
                OnPropertyChanged(nameof(this.SpecialInstructions));

            }
        }

        /// <summary>
        /// The price of the CropCircle instance
        /// </summary>
        public override decimal Price => 2.00m;

        /// <summary>
        /// The calories of the CropCircle instance
        /// </summary>
        public override uint Calories => Berries ? 158u + 89u : 158u;

        /// <summary>
        /// Special instructions for the preparation of this CropCircle
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }
    }
}
