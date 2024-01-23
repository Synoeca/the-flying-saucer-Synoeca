using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{

    /// <summary>
    /// The class to represent the side menu, You Are Toast
    /// </summary>
    public class YouAreToast : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the YouAreToast instance
        /// </summary>
        public override string Name => "You're Toast";

        /// <summary>
        /// The description of the YouAreToast instance
        /// </summary>
        public override string Description => "Texas toast.";

        /// <summary>
        /// The number of slices of toast in this instance of a You Are Toast
        /// </summary>
        /// <remarks>
        /// Defaults to 2 slices of toast
        /// </remarks>
        private uint _count = 2u;

        /// <summary>
        /// The number of slices of toast in this instance of a You Are Toast
        /// </summary>
        /// <remarks>
        /// Must be a value between 1 and 8
        /// </remarks>
        public uint Count
        {
            get => _count;
            set
            {
                
                if (value <= 12u)
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
                    _count = 12u;
                    OnPropertyChanged(nameof(this.Count));
                    OnPropertyChanged(nameof(this.Calories));
                    OnPropertyChanged(nameof(this.Price));
                } 
            }
        }

        /// <summary>
        /// The price of the YouAreToast instance
        /// </summary>
        public override decimal Price => 1.00m * Count;

        /// <summary>
        /// The calories of the YouAreToast instance
        /// </summary>
        public override uint Calories => Count * 100u;

        /// <summary>
        /// Special instructions for the preparation of this YouAreToast
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add($"{Count} slices");
                return instructions;
            }
        }
    }
}
