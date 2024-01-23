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
    /// The class for an order of French toast
    /// </summary>
    public class CrashedSaucer : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the CrashedSaucer instance
        /// </summary>
        public override string Name { get; } = "Crashed Saucer";

        /// <summary>
        /// The discription of the CrashedSaucer instance
        /// </summary>
        public override string Description => "A stack of crispy french toast smothered in syrup and topped with a pat of butter.";

        /// <summary>
        /// The private backing field for the StackSize property
        /// </summary>
        private uint _stackSize = 2;

        /// <summary>
        /// The number of french toasts in this instance of a Crashed Saucer
        /// </summary>
        public uint StackSize
        {
            get => _stackSize;
            set
            {
                if (value <= 6)
                {
                    _stackSize = value;
                    OnPropertyChanged(nameof(this.SpecialInstructions));
                    OnPropertyChanged(nameof(this.StackSize));
                    OnPropertyChanged(nameof(this.Calories));
                    OnPropertyChanged(nameof(this.Price));
                }
                else
                {
                    _stackSize = 6;
                    OnPropertyChanged(nameof(this.StackSize));
                    OnPropertyChanged(nameof(this.Calories));
                    OnPropertyChanged(nameof(this.Price));
                }
            }
        }

        /// <summary>
        /// A private backing field for the property Syrup
        /// </summary>
        private bool _syrup = true;

        /// <summary>
        /// If the FyingSaucer instance is served with maple syrup
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Syrup
        {
            get => _syrup;
            set
            {
                _syrup = value;
                OnPropertyChanged(nameof(this.Syrup));
                OnPropertyChanged(nameof(this.Calories));
                OnPropertyChanged(nameof(this.SpecialInstructions));
            }
        }

        /// <summary>
        /// A private backing field for the property Syrup
        /// </summary>
        private bool _butter = true;

        /// <summary>
        /// If the FyingSaucer instance is served with maple syrup
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Butter
        {
            get => _butter;
            set
            {
                _butter = value;
                OnPropertyChanged(nameof(this.Butter));
                OnPropertyChanged(nameof(this.Calories));
                OnPropertyChanged(nameof(this.SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the CrahsedSaucer instance
        /// </summary>
        public override decimal Price => StackSize > 2 ? 6.45m + (StackSize - 2) * 1.50m : 6.45m;

        /// <summary>
        /// The calories of the CarshedSaucer instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 149u * StackSize;
                if (Syrup) calories += 52u;
                if (Butter) calories += 35u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this CrashedSaucer
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (StackSize != 2) instructions.Add($"{StackSize} slices");
                if (!Butter) instructions.Add("Hold Butter");
                if (!Syrup) instructions.Add("Hold Syrup");
                return instructions;
            }
        }

    }
}
