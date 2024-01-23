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
    /// The class to represent the side menu, Eviscerated Eggs
    /// </summary>
    public class EvisceratedEggs : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the EvisceratedEggs instance
        /// </summary>
        public override string Name => "Eviscerated Eggs";

        /// <summary>
        /// The description of the EvisceratedEggs instance
        /// </summary>
        public override string Description => "Eggs prepared the way you like.";

        /// <summary>
        /// A private backing field for Style property
        /// </summary>
        private EggStyle _style = EggStyle.OverEasy;

        /// <summary>
        /// The style of the EvisceratedEggs instance
        /// </summary>
        /// <remarks>
        /// Defaults to over easy
        /// </remarks>
        public EggStyle Style
        {
            get => _style;
            set
            {
                _style = value;
                OnPropertyChanged(nameof(this.SpecialInstructions));
                OnPropertyChanged(nameof(this.Style));
            }
        }

        /// <summary>
        /// The number of eggs in this instance of a Eviscerated Eggs
        /// </summary>
        /// <remarks>
        /// Defaults to 2 eggs
        /// </remarks>
        private uint _count = 2u;

        /// <summary>
        /// The number of eggs in this instance of a Eviscerated Eggs
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
        /// The price of the EvisceratedEggs instance
        /// </summary>
        public override decimal Price => 1.00m * Count;

        /// <summary>
        /// The calories of the EvisceratedEggs instance
        /// </summary>
        public override uint Calories => Count * 78u;

        /// <summary>
        /// Special instructions for the preparation of this EvisceratedEggs
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                foreach (string es in Enum.GetNames(typeof(EggStyle)))
                {
                    if (es == Style.ToString())
                    {
                        if (es == "SoftBoiled") instructions.Add($"Soft Boiled");
                        else if (es == "HardBoiled") instructions.Add($"Hard Boiled");
                        else if (es == "Scrambled") instructions.Add($"Scrambled");
                        else if (es == "Poached") instructions.Add($"Poached");
                        else if (es == "SunnySideUp") instructions.Add($"Sunny Side Up");
                        else instructions.Add($"Over Easy");
                        break;
                    }
                }
                if (Count != 2) instructions.Add($"{Count} eggs");
                return instructions;
            }
        }
    }
}
