using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// An abstract base classs that represents side menu item
    /// </summary>
    public abstract class Side : IMenuItem
    {
        /// <summary>
        /// The name of the side menu item
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the side menu item
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The price of the side menu item
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The calories of the side menu item
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for the preparation of this side menu item
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Returns the name of the item on the list
        /// </summary>
        /// <returns>The item's name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}