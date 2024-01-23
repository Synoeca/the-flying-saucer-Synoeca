using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// The class for an order of biscuits and gravy
    /// </summary>
    public class LivestockMutilation : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the LivestockMutilation instance
        /// </summary>
        public override string Name => "Livestock Mutilation";

        /// <summary>
        /// The description of the LivestockMutilation instance
        /// </summary>
        public override string Description => "A hearty serving of biscuits, smothered in sausage-laden gravy.";

        /// <summary>
        /// The private backing field for the Biscuits property
        /// </summary>
        private uint _biscuits = 3u;

        /// <summary>
        /// The number of biscuits in this instance of a Livestock Mutilation
        /// </summary>
        /// <remarks>
        /// It was impossible for me to put an if statement inside the expression body setter,
        /// so I used the ternary operator instead
        /// </remarks>
        public uint Biscuits
        {
            get => _biscuits;
            set
            {
                if (value <= 8u)
                {
                    _biscuits = value;
                    OnPropertyChanged(nameof(this.SpecialInstructions));
                    OnPropertyChanged(nameof(this.Biscuits));
                    OnPropertyChanged(nameof(this.Calories));
                    OnPropertyChanged(nameof(this.Price));
                }
                else
                {
                    _biscuits = 8u;
                    OnPropertyChanged(nameof(this.Biscuits));
                    OnPropertyChanged(nameof(this.Calories));
                    OnPropertyChanged(nameof(this.Price));
                }
            }
        }

        /// <summary>
        /// A private backing field for the property Gravy
        /// </summary>
        private bool _gravy = true;

        /// <summary>
        /// If the LivestockMutilation instance is served with gravy
        /// </summary>
        public bool Gravy
        {
            get => _gravy;
            set
            {
                _gravy = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.Gravy));
                OnPropertyChanged(nameof(this.Calories));
            }
        }

        /// <summary>
        /// The price of the LivestockMutilation instance
        /// </summary>
        public override decimal Price => Biscuits > 3 ? 7.25m + (Biscuits - 3) * 1.00m : 7.25m;

        /// <summary>
        /// The calories of the LivestockMutilation instance
        /// </summary>
        public override uint Calories => Gravy ? 49u * Biscuits + 140 : 49u * Biscuits;

        /// <summary>
        /// Special instructions for the preparation of this LivestockMutilation
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Biscuits != 3) instructions.Add($"{Biscuits} biscuits");
                if (!Gravy) instructions.Add("Hold Gravy");
                return instructions;
            }
        }
    }
}
