using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// The class to represent the side menu, Glowing Haystack
    /// </summary>
    public class GlowingHaystack : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the GlowingHaystack instance
        /// </summary>
        public override string Name => "Glowing Haystack";

        /// <summary>
        /// The description of the GlowingHaystack instance
        /// </summary>
        public override string Description => "Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.";

        /// <summary>
        /// A private backing field for the property GreenChileSauce
        /// </summary>
        private bool _greenChileSauce = true;

        /// <summary>
        /// If the GlowingHaystack instance is served with green chile sauce
        /// </summary>
        public bool GreenChileSauce
        {
            get => _greenChileSauce;
            set
            {
                _greenChileSauce = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.GreenChileSauce));
                OnPropertyChanged(nameof(this.Calories));

            }
        }

        /// <summary>
        /// A private backing field for the property SourCream
        /// </summary>
        private bool _sourCream = true;

        /// <summary>
        /// If the GlowingHaystack instance is served with sour cream
        /// </summary>
        public bool SourCream
        {
            get => _sourCream;
            set
            {
                _sourCream = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.SourCream));
                OnPropertyChanged(nameof(this.Calories));

            }
        }

        /// <summary>
        /// A private backing field for the property Tomatoes
        /// </summary>
        private bool _tomatoes = true;

        /// <summary>
        /// If the GlowingHaystack instance is served with tomatoes
        /// </summary>
        public bool Tomatoes
        {
            get => _tomatoes;
            set
            {
                _tomatoes = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.Tomatoes));
                OnPropertyChanged(nameof(this.Calories));

            }
        }

        /// <summary>
        /// The price of the GlowingHaystack instance
        /// </summary>
        public override decimal Price => 2.00m;

        /// <summary>
        /// The calories of the GlowingHaystack instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 470u;
                if (GreenChileSauce) calories += 15u;
                if (SourCream) calories += 23u;
                if (Tomatoes) calories += 22u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this GlowingHaystack
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!GreenChileSauce) instructions.Add("Hold Green Chile Sauce");
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                return instructions;
            }
        }
    }
}
