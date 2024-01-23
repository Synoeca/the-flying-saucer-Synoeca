using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TheFTL.DataTests
{
    /// <summary>
    /// This class implements tests for the INotifyCollectionChanged Implementation
    /// </summary>
    public static class NotifyCollectionAssert
    {
        /// <summary>
        /// A exception for when the NotifyCollectionChanged not triggered
        /// </summary>
        public class NotifyCollectionChangedNotTriggeredException : XunitException
        {
            public NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction expectedAction) : base($"Expected a NotifyCollectionChanged event with an action of {expectedAction} to be invoked, but saw none.") { }
        }

        /// <summary>
        /// An exception for when the NotifyCollectionChanged show wrong action
        /// </summary>
        public class NotifyCollectionChangedWrongActionException : XunitException
        {
            public NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction expectedAction, NotifyCollectionChangedAction actualAction) : base($"Expected a NotifyCollectionChanged event with an action of {expectedAction} to be invoked, but saw {actualAction}") { }
        }

        /// <summary>
        /// An exception for when the NotifyCollectionChanged show wrong object with add action
        /// </summary>
        public class NotifyCollectionChangedAddException : XunitException
        {
            public NotifyCollectionChangedAddException(object expected, object actual) : base($"Expected a NotifyCollectionChanged event with an action of Add and object {expected} but instead saw {actual}") { }
        }

        /// <summary>
        /// An exception for when the NotifyCollectionChanged show wrong object and index with remove action
        /// </summary>
        public class NotifyCollectionChangedRemoveException : XunitException
        {
            public NotifyCollectionChangedRemoveException(object expectedItem, int expectedIndex, object actualItem, int actualIndex) : base($"Expected a NotifyCollectionChanged event with an action of Remove and object {expectedItem} at index {expectedIndex} but instead saw {actualItem} at index  {actualIndex}") { }
        }

        /// <summary>
        /// An assertion method of the add item to the INotifyCollection
        /// </summary>
        /// <typeparam name="T">The generic type T for the INotifyCollection</typeparam>
        /// <param name="collection">An instance of the INotifyCollection</param>
        /// <param name="newItem">A new item to be added to the collection</param>
        /// <param name="testCode">A given test code</param>
        /// <exception cref="NotifyCollectionChangedWrongActionException"></exception>
        /// <exception cref="NotifyCollectionChangedAddException"></exception>
        /// <exception cref="NotifyCollectionChangedNotTriggeredException"></exception>
        public static void NotifyCollectionChangedAdd<T>(INotifyCollectionChanged collection, T newItem, Action testCode)
        {
            // A flag to indicate if the event triggered successfully
            bool notifySucceeded = false;

            // An event handler to attach to the INotifyCollectionChanged and be 
            // notified when the Add event occurs.
            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                // Make sure the event is an Add event
                if (args.Action != NotifyCollectionChangedAction.Add)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Add, args.Action);
                }
                /*
                // Make sure we added just one item
                if (args.NewItems?.Count != 1)
                {
                    // We'll use the collection of added items as the second argument
                    throw new NotifyCollectionChangedAddException(newItem!, args.NewItems!);
                }
                */
                
                // Make sure the added item is what we expected
                if (!args.NewItems[0]!.Equals(newItem))
                {
                    // Here we only have one item in the changed collection, so we'll report it directly
                    throw new NotifyCollectionChangedAddException(newItem!, args.NewItems[0]!);
                }

                // If we reach this point, the NotifyCollectionChanged event was triggered successfully
                // and contains the correct item! We'll set the flag to true so we know.
                notifySucceeded = true;
            };

            // Now we connect the event handler 
            collection.CollectionChanged += handler;

            // And attempt to trigger the event by running the actionCode
            // We place this in a try/catch to be able to utilize the finally 
            // clause, but don't actually catch any exceptions
            try
            {
                testCode();
                // After this code has been run, our handler should have 
                // triggered, and if all went well, the notifySucceed is true
                if (!notifySucceeded)
                {
                    // If notifySucceed is false, the event was not triggered
                    // We throw an exception denoting that
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Add);
                }
            }
            // We don't actually want to catch an exception - we want it to 
            // bubble up and be reported as a failing test.  So we don't 
            // have a catch () {} clause to this try/catch.
            finally
            {
                // However, we *do* want to remove the event handler. We do 
                // this in a finally block so it will happen even if we do 
                // have an exception occur. 
                collection.CollectionChanged -= handler;
            }
        }

        /// <summary>
        /// An assertion method of the remove item to the INotifyCollection
        /// </summary>
        /// <typeparam name="T">The generic type T for the INotifyCollection</typeparam>
        /// <param name="collection">An instance of the INotifyCollection</param>
        /// <param name="removeItem">A new item to be removed from the collection</param>
        /// <param name="testCode">A given test code</param>
        /// <exception cref="NotifyCollectionChangedWrongActionException"></exception>
        /// <exception cref="NotifyCollectionChangedAddException"></exception>
        /// <exception cref="NotifyCollectionChangedNotTriggeredException"></exception>
        public static void NotifyCollectionChangedRemove<T>(INotifyCollectionChanged collection, T removeItem, Action testCode)
        {
            // A flag to indicate if the event triggered successfully
            bool notifySucceeded = false;

            // An event handler to attach to the INotifyCollectionChanged and be 
            // notified when the Add event occurs.
            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                // Make sure the event is an Remove event
                if (args.Action != NotifyCollectionChangedAction.Remove)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Remove, args.Action);
                }
                /*
                // Make sure we removed just one item
                if (args.OldItems!.Count != 1)
                {
                    // We'll use the collection of removed items as the second argument
                    throw new NotifyCollectionChangedRemoveException(removeItem!, 0, args.OldItems![0]!, 0);
                }
                */

                // Make sure the removed item is what we expected
                if (!args.OldItems![0]!.Equals(removeItem))
                {
                    // Here we only have one item in the changed collection, so we'll report it directly
                    throw new NotifyCollectionChangedRemoveException(removeItem!, 0, args.OldItems![0]!, 0);
                }

                notifySucceeded = true;
            };

            collection.CollectionChanged += handler;
            try
            {
                testCode();
                if (!notifySucceeded)
                {
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Remove);
                }
            }
            finally
            {
                collection.CollectionChanged -= handler;
            }
        }

        /// <summary>
        /// An assertion method of the reset item to the INotifyCollection
        /// </summary>
        /// <typeparam name="T">The generic type T for the INotifyCollection</typeparam>
        /// <param name="collection">An instance of the INotifyCollection</param>
        /// <param name="testCode">A given test code</param>
        /// <exception cref="NotifyCollectionChangedWrongActionException"></exception>
        /// <exception cref="NotifyCollectionChangedAddException"></exception>
        /// <exception cref="NotifyCollectionChangedNotTriggeredException"></exception>
        public static void NotifyCollectionChangedReset(INotifyCollectionChanged collection, Action testCode)
        {
            // A flag to indicate if the event triggered successfully
            bool notifySucceeded = false;

            // An event handler to attach to the INotifyCollectionChanged and be 
            // notified when the Add event occurs.
            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                // Make sure the event is an Reset event
                if (args.Action != NotifyCollectionChangedAction.Reset)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Reset, args.Action);
                }

                notifySucceeded = true;
            };

            collection.CollectionChanged += handler;
            try
            {
                testCode();
                if (!notifySucceeded)
                {
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Reset);
                }
            }
            finally
            {
                collection.CollectionChanged -= handler;
            }
        }

        /// <summary>
        /// An assertion method of the replace item to the INotifyCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">An instance of the INotifyCollection</param>
        /// <param name="oldlist">An given list to replace</param>
        /// <param name="testCode">A given test code</param>
        /// <exception cref="NotifyCollectionChangedWrongActionException"></exception>
        /// <exception cref="NotifyCollectionChangedNotTriggeredException"></exception>
        public static void NotifyCollectionChangedReplace<T>(INotifyCollectionChanged collection, IList<T> oldlist, Action testCode)
        {
            // A flag to indicate if the event triggered successfully
            bool notifySucceeded = false;

            // An event handler to attach to the INotifyCollectionChanged and be
            // notified when the Add event occurs.
            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                // Make sure the event is an Replace event
                if (args.Action != NotifyCollectionChangedAction.Replace)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Replace, args.Action);
                }

                notifySucceeded = true;
            };

            collection.CollectionChanged += handler;
            try
            {
                testCode();
                if (!notifySucceeded)
                {
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Replace);
                }
            }
            finally
            {
                collection.CollectionChanged -= handler;
            }
        }
    }
}
