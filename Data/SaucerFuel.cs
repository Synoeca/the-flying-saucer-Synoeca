using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// The class for an order of SaucerFuel vegetation
    /// </summary>
    public class SaucerFuel : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the SaucerFuel instance
        /// </summary>
        public override string Name
        {
            get
            {
                if (Decaf == true) return "Decaf Saucer Fuel";
                else return "Saucer Fuel";
            }
        }

        /// <summary>
        /// The description of the SaucerFuel instance
        /// </summary>
        public override string Description => "A steaming cup of coffee.";

        /// <summary>
        /// A private backing field for the property Size
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// The serving size for this instance of a Saucer Fuel
        /// </summary>
        public override ServingSize Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(this.Size));
                OnPropertyChanged(nameof(this.Price));
                OnPropertyChanged(nameof(this.Calories));
            }
        }

        /// <summary>
        /// A private backing field for the property Decaf
        /// </summary>
        private bool _decaf = false;

        /// <summary>
        /// If the SaucerFuel instance is served with decaf
        /// </summary>
        public bool Decaf
        {
            get => _decaf;
            set
            {
                _decaf = value;
                OnPropertyChanged(nameof(this.Decaf));
                OnPropertyChanged(nameof(this.Name));
            }
        }

        /// <summary>
        /// A private backing field for the property Cream
        /// </summary>
        private bool _cream = false;

        /// <summary>
        /// If the SaucerFuel instance is served with cream
        /// </summary>
        public bool Cream
        {
            get => _cream;
            set
            {
                _cream = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.Cream));
                OnPropertyChanged(nameof(this.Calories));
            }
        }

        /// <summary>
        /// The price of the SaucerFuel instance
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
        /// The calories of the SaucerFuel instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint returnCalories = 0u;
                if (Cream) returnCalories = 29u;
                if (Size == ServingSize.Medium)
                {
                    return returnCalories + 2u;
                }
                else if (Size == ServingSize.Large)
                {
                    return returnCalories + 3u;
                }
                else
                {
                    return returnCalories + 1u;
                }
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this SaucerFuel
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Cream) instructions.Add("With Cream");
                return instructions;
            }
        }
    }
}
