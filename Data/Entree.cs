using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// An abstract base classs that represents entree menu item
    /// </summary>
    public abstract class Entree : IMenuItem
    {
        /// <summary>
        /// Event triggered when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the entree menu item
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the entree menu item
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The price of the entree menu item
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The calories of the entree menu item
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for the preparation of this entree menu item
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
