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
    /// The class to represent the side menu, Missing Links
    /// </summary>
    public class MissingLinks : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the MissingLinks instance
        /// </summary>
        public override string Name => "Missing Links";

        /// <summary>
        /// The description of the MissingLinks instance
        /// </summary>
        public override string Description => "Sizzling pork sausage links.";

        /// <summary>
        /// A private backing field for Count property
        /// </summary>
        /// <remarks>
        /// Defaults to 2 sausage links
        /// </remarks>
        private uint _count = 2u;

        /// <summary>
        /// The number of a link of sausage in this instance of a Missing Links
        /// </summary>
        /// <remarks>
        /// Must be a value between 1 and 8
        /// </remarks>
        public uint Count
        {
            get => _count;
            set
            {
                if (value <= 8u)
                {
                    if (value >= 1u)
                    {
                        _count = value;
                        OnPropertyChanged(nameof(this.SpecialInstructions));
                        OnPropertyChanged(nameof(this.Count));
                        OnPropertyChanged(nameof(this.Price));
                        OnPropertyChanged(nameof(this.Calories));
                    }

                    else
                    {
                        _count = 1u;
                        OnPropertyChanged(nameof(this.Count));
                        OnPropertyChanged(nameof(this.Price));
                        OnPropertyChanged(nameof(this.Calories));
                    }
                }
                else
                {
                    _count = 8u;
                    OnPropertyChanged(nameof(this.Count));
                    OnPropertyChanged(nameof(this.Price));
                    OnPropertyChanged(nameof(this.Calories));
                }
            }
        }

        /// <summary>
        /// The price of the MissingLinks instance
        /// </summary>
        public override decimal Price => 1.00m * Count;

        /// <summary>
        /// The calories of the MissingLinks instance
        /// </summary>
        public override uint Calories => Count * 391u;

        /// <summary>
        /// Special instructions for the preparation of this MissingLinks
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add($"{Count} links");
                return instructions;
            }
        }
    }
}
