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
    /// The class to represent the side menu, Taken Bacon
    /// </summary>
    public class TakenBacon : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the TakenBacon instance
        /// </summary>
        public override string Name => "Taken Bacon";

        /// <summary>
        /// The description of the TakenBacon instance
        /// </summary>
        public override string Description => "Crispy strips of bacon.";

        /// <summary>
        /// The number of strips of bacon in this instance of a Taken Bacon
        /// </summary>
        /// <remarks>
        /// Defaults to 2 strips of bacon
        /// </remarks>
        private uint _count = 2u;


        /// <summary>
        /// The number of biscuits in this instance of a Livestock Mutilation
        /// </summary>
        /// <remarks>
        /// Must be a value between 1 and 6
        /// </remarks>
        public uint Count
        {
            get => _count;
            set
            {
                if (value <= 6u)
                {
                    if (value >= 1u)
                    {
                        _count = value;
                        OnPropertyChanged(nameof(this.SpecialInstructions));
                        OnPropertyChanged(nameof(this.Count));
                        OnPropertyChanged(nameof(this.Calories));
                        OnPropertyChanged(nameof(this.Price));
                    }
                    else
                    {
                        _count = 1u;
                        OnPropertyChanged(nameof(this.Count));
                        OnPropertyChanged(nameof(this.Calories));
                        OnPropertyChanged(nameof(this.Price));
                    }
                }
                else
                {
                    _count = 6u;
                    OnPropertyChanged(nameof(this.Count));
                    OnPropertyChanged(nameof(this.Calories));
                    OnPropertyChanged(nameof(this.Price));
                } 
            }
        }


        /// <summary>
        /// The calories of the TakenBacon instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 43u * Count;
                return calories;
            }
        }


        /// <summary>
        /// The price of the TakenBacon instance
        /// </summary>
        public override decimal Price => 1.00m * Count;


        /// <summary>
        /// Special instructions for the preparation of this TakenBacon
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add($"{Count} strips");
                return instructions;
            }
        }
    }
}
