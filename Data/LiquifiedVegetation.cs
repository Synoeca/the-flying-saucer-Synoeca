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
    /// The class for an order of liquified vegetation
    /// </summary>
    public class LiquifiedVegetation : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the LiquifiedVegetation instance
        /// </summary>
        public override string Name => "Liquified Vegetation";

        /// <summary>
        /// The description of the LiquifiedVegetation instance
        /// </summary>
        public override string Description => "A cold glass of blended vegetable juice.";

        /// <summary>
        /// A private backing field for the property Size
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// The serving size for this instance of a Liquified Vegetation
        /// </summary>
        public override ServingSize Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(this.Size));
                OnPropertyChanged(nameof(this.Calories));
                OnPropertyChanged(nameof(this.Price));
            }
        }

        /// <summary>
        /// A private backing field for the property Ice
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// If the LiquifiedVegetation instance is served with sour cream
        /// </summary>
        public bool Ice
        {
            get => _ice;
            set
            {
                _ice = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.Ice));
            }
        }

        /// <summary>
        /// The price of the LiquifiedVegetation instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Size == ServingSize.Medium)
                {
                    return 1.50m;
                }

                else if (Size == ServingSize.Large)
                {
                    return 2.00m;
                }
                else
                {
                    return 1.00m;
                }
            }
        }

        /// <summary>
        /// The calories of the LiquifiedVegetation instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == ServingSize.Medium)
                {
                    return 144u;
                }
                else if (Size == ServingSize.Large)
                {
                    return 216u;
                }
                else
                {
                    return 72u;
                }
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this LiquifiedVegetation
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Ice) instructions.Add("No Ice");
                return instructions;
            }
        }
    }
}
