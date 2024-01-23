using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// The Interface represent the properties that all menu items share
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Event triggered when a property changes
        /// </summary>
        event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the menu item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The description of the menu item
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The price of the menu item
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// The calories of the menu item
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// The special instructions of the menu item
        /// </summary>
        IEnumerable<string> SpecialInstructions { get; }
    }
}
