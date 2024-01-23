using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// The class for an order of Inorganic Substance
    /// </summary>
    public class InorganicSubstance : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the InorganicSubstance instance
        /// </summary>
        public override string Name => "Inorganic Substance";

        /// <summary>
        /// The description of the InorganicSubstance instance
        /// </summary>
        public override string Description => "A cold glass of ice water.";

        /// <summary>
        /// A private backing field for the property Size
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// The serving size for this instance of a Inorganic Substance
        /// </summary>
        public override ServingSize Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(this.Size));

            }
        }

        /// <summary>
        /// A private backing field for the property Ice
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// If the InorganicSubstance instance is served with sour cream
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
        /// The price of the InorganicSubstance instance
        /// </summary>
        public override decimal Price => 0.00m;

        /// <summary>
        /// The calories of the InorganicSubstance instance
        /// </summary>
        public override uint Calories => 0u;

        /// <summary>
        /// Special instructions for the preparation of this InorganicSubstance
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
