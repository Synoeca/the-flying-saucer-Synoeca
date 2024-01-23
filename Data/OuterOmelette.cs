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
    /// The class to represent the Outer Omelette entree
    /// </summary>
    public class OuterOmelette : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the OuterOmelette instance
        /// </summary>
        public override string Name => "Outer Omelette";

        /// <summary>
        /// The description of the OuterOmelette instance
        /// </summary>
        public override string Description => "A fully loaded Omelette.";

        /// <summary>
        /// A private backing field for the property CheddarCheese
        /// </summary>
        private bool _cheddarCheese = true;

        /// <summary>
        /// If the OuterOmelette instance is served with cheddar cheese
        /// </summary>
        public bool CheddarCheese
        {
            get => _cheddarCheese;
            set
            {
                _cheddarCheese = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.CheddarCheese));
                OnPropertyChanged(nameof(this.Calories));
            }
        }

        /// <summary>
        /// A private backing field for the property Peppers
        /// </summary>
        private bool _peppers = true;

        /// <summary>
        /// If the OuterOmelette instance is served with peppers
        /// </summary>
        public bool Peppers
        {
            get => _peppers;
            set
            {
                _peppers = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.Peppers));
                OnPropertyChanged(nameof(this.Calories));
            }
        }

        /// <summary>
        /// A private backing field for the property Mushrooms
        /// </summary>
        private bool _mushrooms = true;

        /// <summary>
        /// If the OuterOmelette instance is served with mushrooms
        /// </summary>
        public bool Mushrooms
        {
            get => _mushrooms;
            set
            {
                _mushrooms = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.Mushrooms));
                OnPropertyChanged(nameof(this.Calories));
            }
        }

        /// <summary>
        /// A private backing field for the property Tomatoes
        /// </summary>
        private bool _tomatoes = true;

        /// <summary>
        /// If the OuterOmelette instance is served with tomatoes
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
        /// A private backing field for the property Onions
        /// </summary>
        private bool _onions = true;

        /// <summary>
        /// If the OuterOmelette instance is served with onions
        /// </summary>
        public bool Onions
        {
            get => _onions;
            set
            {
                _onions = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.Onions));
                OnPropertyChanged(nameof(this.Calories));
            }
        }

        /// <summary>
        /// The price of the OuterOmelette instance
        /// </summary>
        public override decimal Price => 7.45m;

        /// <summary>
        /// The calories of the OuterOmelette instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 94u;
                if (CheddarCheese) calories += 113u;
                if (Peppers) calories += 24u;
                if (Mushrooms) calories += 4u;
                if (Tomatoes) calories += 22u;
                if (Onions) calories += 22u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this OuterOmelette
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                if (!Onions) instructions.Add("Hold Onions");
                return instructions;
            }
        }
    }
}
