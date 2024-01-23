using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// The class represents an order containing multiple, potentially customized menu items
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// Event triggered when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Event triggered when a collection changes
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// A private backing field for Orders property
        /// </summary>
        private ICollection<IMenuItem> _orders = new List<IMenuItem>();

        /// <summary>
        /// An instance of an order collection
        /// </summary>
        public ICollection<IMenuItem> Orders
        {
            get => _orders;
            set
            {
                List<IMenuItem> old = _orders.ToList();
                _orders = value;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, old, _orders.ToList()));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
        }

        /// <summary>
        /// Gets the number of orders contained in the current instance
        /// </summary>
        public int Count => Orders.Count;

        /// <summary>
        /// Indicates whether the current collection of orders is read-only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an item to the current collection of orders
        /// </summary>
        /// <param name="item">
        /// The item to add to the current collection of orders
        /// </param>
        public void Add(IMenuItem item)
        {
            Orders.Add(item);
            item.PropertyChanged += HandleItemPropertyChanged;
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Clears all items from the current collection of orders.
        /// </summary>
        public void Clear()
        {
            Orders.Clear();
            foreach (IMenuItem imi in _orders)
            {
                imi.PropertyChanged -= HandleItemPropertyChanged;
            }
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Determines whether the current collection of orders contains a specific value
        /// </summary>
        /// <param name="item">
        /// The object to locate in the current collection of orders
        /// </param>
        /// <returns>
        /// true, if item is found in the current collection of orders; otherwise, false
        /// </returns>
        public bool Contains(IMenuItem item)
        {
            return Orders.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the current collection of orders to a Array, starting at the specified index
        /// </summary>
        /// <param name="array">
        /// A one-dimensional, zero-based Array that is the destination of the elements copied from the current instance
        /// </param>
        /// <param name="arrayIndex">
        /// A Int32 that specifies the zero-based index in array at which copying begins
        /// </param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            Orders.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of orders
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection of orders
        /// </returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return Orders.GetEnumerator();
        }

        /// <summary>
        /// Removes the first occurrence of an item from the current collection of orders
        /// </summary>
        /// <param name="item">
        /// The item to remove from the current collection of orders
        /// </param>
        /// <returns>
        /// true, if item was removed from the current collection of orders
        /// false, if item was not found in the current collection of orders
        /// </returns>
        public bool Remove(IMenuItem item)
        {
            int index = _orders.ToList().IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            bool result = Orders.Remove(item);
            item.PropertyChanged -= HandleItemPropertyChanged;
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            return result;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection of orders
        /// </summary>
        /// <returns>
        /// An IEnumerator object that can be used to iterate through the collection of orders
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Orders.GetEnumerator();
        }

        
        /// <summary>
        /// A private backing field of static property LastNumberUsed.
        /// </summary>
        private static int _lastNumberUsed = 0;

        /// <summary>
        /// A static variable to keep track of the last number used.
        /// </summary>
        public static int LastNumberUsed
        {
            get => _lastNumberUsed;
            set => _lastNumberUsed = value;
        }

        /// <summary>
        /// A private backing field of static property Number.
        /// </summary>
        private int _number = LastNumberUsed;

        /// <summary>
        /// The number identifying an individual order.
        /// </summary>
        public int Number
        {
            get => _number;
            init
            {
                LastNumberUsed++;
                _number = value;
            }
        }

        /// <summary>
        /// A date and time corresponding to when the order was started.
        /// </summary>
        public DateTime PlacedAt { get; init; } = DateTime.Now;

        /// <summary>
        /// The price of all items in the order
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal subs = 0;
                foreach (IMenuItem items in Orders)
                {
                    subs += items.Price;
                }
                return subs;
            }
        }

        /// <summary>
        /// The private backing field for the property TaxRate
        /// </summary>
        private decimal _taxRate;

        /// <summary>
        /// The sales tax rate
        /// </summary>
        public decimal TaxRate
        {
            get => _taxRate;
            set
            {
                _taxRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
        }

        /// <summary>
        /// The tax for the order (Subtotal * TaxRate)
        /// </summary>
        public decimal Tax => Subtotal * TaxRate;

        /// <summary>
        /// The sum of the Subtotal and Tax
        /// </summary>
        public decimal Total => Math.Round(Subtotal + Tax, 2);

        /// <summary>
        /// c
        /// </summary>
        /// <param name="sender">d</param>
        /// <param name="args">d</param>
        private void HandleItemPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Price")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Orders)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
        }
    }
}
