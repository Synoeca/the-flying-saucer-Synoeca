using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// An abstract base classs that represents drinks
    /// </summary>
    public abstract class Drink : IMenuItem
    {
        /// <summary>
        /// Event triggered when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the drink
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the drink
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The serving size of the drink
        /// </summary>
        public abstract ServingSize Size { get; set; }

        /// <summary>
        /// The price of the drink
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The calories of the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for the preparation of this drink
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// Returns the name of the item on the list
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// A helper method of invoking PropertyChangedEvent
        /// </summary>
        /// <param name="propertyName">A name of property that changed its contents</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
