using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using TheFTL.DataTests;
using Xunit.Sdk;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TheFTL.DataTests.NotifyCollectionAssert;

namespace TheOrder.DataTests
{
    /// <summary>
    /// A mock menu item for testing
    /// </summary>
    internal class MockMenuItem : IMenuItem
    {
        /// <summary>
        /// The name of the mock menu item
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// The description of the mock menu item
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// The price of the mock menu item
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The calories of the mock menu item
        /// </summary>
        public uint Calories { get; set; }

        /// <summary>
        /// The special instructions of the mock menu item
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; set; } = default!;

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    /// <summary>
    /// Unit tests for the Order class
    /// </summary>
    public class OrderUnitTest
    {
        #region default values

        /// <summary>
        /// This test checks that the new instance of Order has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            Order od = new();
            Assert.Empty(od);
            Assert.False(od.IsReadOnly, $"Expected false but found {od.IsReadOnly}");
            Assert.IsType<List<IMenuItem>>(od.Orders);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that can we create a collcection from multiple orders
        /// </summary>
        [Fact]
        public void CanCreateOrderCollection()
        {
            Order odm = new()
            {
                new MockMenuItem()
                {
                    Name = "cyanea",
                    Description = "Synoeca sp.",
                    Price = 1.00m,
                    Calories = 20u,
                    SpecialInstructions = new List<string> { "Classified in 1775" }
                },

                new MockMenuItem()
                {
                    Name = "surinama",
                    Description = "Synoeca sp.",
                    Price = 2.00m,
                    Calories = 40u,
                    SpecialInstructions = new List<string> { "Classified in 1767" }
                }
            };

            Assert.Equal("cyanea", odm.First().Name);
            Assert.Equal("Synoeca sp.", odm.First().Description);
            Assert.Equal(1.00m, odm.First().Price);
            Assert.Equal(20u, odm.First().Calories);
            Assert.Equal(new List<string> { "Classified in 1775" }, odm.First().SpecialInstructions);

            Assert.Equal("surinama", odm.Last().Name);
            Assert.Equal("Synoeca sp.", odm.Last().Description);
            Assert.Equal(2.00m, odm.Last().Price);
            Assert.Equal(40u, odm.Last().Calories);
            Assert.Equal(new List<string> { "Classified in 1767" }, odm.Last().SpecialInstructions);


            Order od = new()
            {
                new CrashedSaucer(),
                new CrashedSaucer(),
                new CropCircle(),
                new EvisceratedEggs(),
                new FlyingSaucer(),
                new FlyingSaucer(),
                new GlowingHaystack(),
                new InorganicSubstance(),
                new LiquifiedVegetation(),
                new LivestockMutilation(),
                new MissingLinks(),
                new OuterOmelette(),
                new SaucerFuel(),
                new TakenBacon(),
                new YouAreToast()
            };
            
            Assert.Collection(od,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<EvisceratedEggs>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<GlowingHaystack>(item),
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<SaucerFuel>(item),
                item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item)
            );
        }

        /// <summary>
        /// This test checks that can we add or remove multiple orders to a collcection
        /// </summary>
        [Fact]
        public void CanAddRemoveOrders()
        {
            Order odm = new();
            MockMenuItem alpha = new();
            MockMenuItem beta = new();
            MockMenuItem gamma = new();
            MockMenuItem delta = new();
            MockMenuItem epsilon = new();

            odm.Add(alpha);
            Assert.Contains(alpha, odm);
            odm.Add(beta);
            Assert.Contains(beta, odm);
            odm.Add(gamma);
            Assert.Contains(gamma, odm);
            odm.Add(delta);
            Assert.Contains(delta, odm);
            odm.Add(epsilon);
            Assert.Contains(epsilon, odm);

            Assert.True(odm.Remove(odm.ElementAt(odm.Count - 1)));
            Assert.DoesNotContain(epsilon, odm);
            Assert.False(odm.Remove(epsilon));

            Assert.True(odm.Remove(odm.ElementAt(2)));
            Assert.DoesNotContain(gamma, odm);
            Assert.False(odm.Remove(gamma));

            Assert.True(odm.Remove(alpha));
            Assert.DoesNotContain(alpha, odm);
            Assert.False(odm.Remove(alpha));

            Assert.True(odm.Remove(odm.First()));
            Assert.DoesNotContain(beta, odm);
            Assert.False(odm.Remove(beta));

            Assert.True(odm.Remove(odm.Last()));
            Assert.DoesNotContain(delta, odm);
            Assert.False(odm.Remove(delta));

            Assert.Empty(odm);


            Order od = new();
            FlyingSaucer fs = new();
            CrashedSaucer cs = new();
            InorganicSubstance os = new();
            LivestockMutilation lm = new();

            od.Add(fs);
            Assert.Contains(fs, od);
            od.Add(cs);
            Assert.Contains(cs, od);
            od.Add(os);
            Assert.Contains(os, od);
            od.Add(lm);
            Assert.Contains(lm, od);

            Assert.True(od.Remove(od.ElementAt(od.Count - 1)));
            Assert.DoesNotContain(lm, od);
            Assert.False(od.Remove(lm));

            Assert.True(od.Remove(od.ElementAt(2)));
            Assert.DoesNotContain(os, od);
            Assert.False(od.Remove(os));

            Assert.True(od.Remove(fs));
            Assert.DoesNotContain(fs, od);
            Assert.False(od.Remove(fs));

            Assert.True(od.Remove(od.First()));
            Assert.DoesNotContain(cs, od);
            Assert.False(od.Remove(cs));

            Assert.Empty(od);
        }

        /// <summary>
        /// This test checks that can we set List of IMenuItems to a collcection's Orders property
        /// </summary>
        [Fact]
        public void CanSetListMenuItem()
        {
            List<IMenuItem> lmim = new()
            {
                new MockMenuItem() { Name = "alpha" },
                new MockMenuItem() { Name = "beta" },
                new MockMenuItem() { Name = "gamma" }
            };
            Order odm = new();
            odm.Orders = lmim;
            Assert.Collection(odm,
                item => Assert.Same(item, lmim[0]),
                item => Assert.Same(item, lmim[1]),
                item => Assert.Same(item, lmim[2])
            );


            List<IMenuItem> lmi = new()
            {
                new FlyingSaucer(),
                new CrashedSaucer(),
                new LiquifiedVegetation()
            };
            Order od = new();
            od.Orders = lmi;
            Assert.Collection(od, 
                item => Assert.Same(item, lmi[0]),
                item => Assert.Same(item, lmi[1]),
                item => Assert.Same(item, lmi[2])
            );
        }

        /// <summary>
        /// This test checks that can we clear all the orders included in the collection
        /// </summary>
        /// <param name="orders">The amount of orders will be added into collection</param>
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        public void ShouldBeCleared(int orders)
        {
            Order odm = new();
            for (int i = 0; i < orders; i++)
            {
                odm.Add(new MockMenuItem());
            }
            Assert.Equal(orders, odm.Count);
            odm.Clear();
            Assert.Empty(odm);


            Order od = new();
            for (int i=0; i<orders; i++)
            {
                od.Add(new FlyingSaucer());
            }
            Assert.Equal(orders, od.Count);
            od.Clear();
            Assert.Empty(od);
        }

        /// <summary>
        /// This test checks that can we cast the ICollection of IMenuItem into List of IMenuItem
        /// to customized orders in collection by chaning counts and ingredient and see changed values are correct
        /// </summary>
        [Fact]
        public void CanCutomizeOrders()
        {
            Order odm = new()
            {
                new MockMenuItem() { Price = 1.00m, Calories = 10u, SpecialInstructions = new List<string> { "Alpha" } },
                new MockMenuItem() { Price = 2.00m, Calories = 20u, SpecialInstructions = new List<string> { "Beta" } },
                new MockMenuItem() { Price = 3.00m, Calories = 30u, SpecialInstructions = new List<string> { "Gamma" } },
                new MockMenuItem() { Price = 4.00m, Calories = 40u, SpecialInstructions = new List<string> { "Delta" } }
            };

            int indexBeta = 1;
            int indexDelta = 3;
            Assert.Equal(2.00m, odm.ElementAt(indexBeta).Price);
            Assert.Equal(20u, odm.ElementAt(indexBeta).Calories);
            Assert.Equal(new List<string> { "Beta" }, odm.ElementAt(indexBeta).SpecialInstructions);
            Assert.Equal(4.00m, odm.ElementAt(indexDelta).Price);
            Assert.Equal(40u, odm.ElementAt(indexDelta).Calories);
            Assert.Equal(new List<string> { "Delta" }, odm.ElementAt(indexDelta).SpecialInstructions);

            List<IMenuItem> lmim = odm.ToList();

            MockMenuItem btm = (MockMenuItem)lmim[indexBeta];
            btm.SpecialInstructions = new List<string> { "B" };
            lmim[indexBeta] = btm;

            MockMenuItem dtm = (MockMenuItem)lmim[indexDelta];
            dtm.SpecialInstructions = new List<string> { "D" };
            lmim[indexDelta] = dtm;

            odm.Orders = lmim;
            Assert.Equal(2.00m, odm.ElementAt(indexBeta).Price);
            Assert.Equal(20u, odm.ElementAt(indexBeta).Calories);
            Assert.NotEqual(new List<string> { "Beta" }, odm.ElementAt(indexBeta).SpecialInstructions);
            Assert.Equal(new List<string> { "B" }, odm.ElementAt(indexBeta).SpecialInstructions);
            Assert.Equal(4.00m, odm.ElementAt(indexDelta).Price);
            Assert.Equal(40u, odm.ElementAt(indexDelta).Calories);
            Assert.NotEqual(new List<string> { "Delta" }, odm.ElementAt(indexDelta).SpecialInstructions);
            Assert.Equal(new List<string> { "D" }, odm.ElementAt(indexDelta).SpecialInstructions);


            Order od = new()
            {
                new FlyingSaucer(),
                new LivestockMutilation(),
                new SaucerFuel(),
                new InorganicSubstance()
            };

            int indexLM = 1;
            int indexSF = 2;
            Assert.Equal((49 * 3u) + 140u, od.ElementAt(indexLM).Calories);
            Assert.Equal(7.25m, od.ElementAt(indexLM).Price);
            Assert.Equal(1u, od.ElementAt(indexSF).Calories);
            Assert.Equal(1.00m, od.ElementAt(indexSF).Price);

            List<IMenuItem> lmi = od.ToList();

            LivestockMutilation lm = (LivestockMutilation)lmi[indexLM];
            lm.Biscuits = 5;
            lmi[indexLM] = lm;

            SaucerFuel sf = (SaucerFuel)lmi[indexSF];
            sf.Cream = true;
            lmi[indexSF] = sf;

            od.Orders = lmi;
            Assert.Equal((49 * 5u) + 140u, od.ElementAt(indexLM).Calories);
            Assert.Equal(9.25m, od.ElementAt(indexLM).Price);
            Assert.Equal(1u + 29u, od.ElementAt(indexSF).Calories);
            Assert.Equal(1.00m, od.ElementAt(indexSF).Price);
        }

        /// <summary>
        /// This test checks that can we read specialinstructions of an order inside the collection
        /// </summary>
        [Fact]
        public void CanReadSpecialInstructions()
        {
            Order odm = new();
            for (int i = 1; i <= 100; i++)
            {
                odm.Add(new MockMenuItem() { SpecialInstructions = new List<string>() { i.ToString() } });
            }

            int sum = 0;
            foreach (MockMenuItem mmi in odm.Cast<MockMenuItem>())
            {
                sum += Int32.Parse(mmi.SpecialInstructions.First());
            }

            Assert.Equal(5050, sum);


            Order od = new()
            {
                new FlyingSaucer()
                {
                    StackSize = 10,
                    Syrup = false,
                    WhippedCream = false,
                    Berries = false
                }
            };

            Assert.Collection(od.First().SpecialInstructions,
                item => Assert.Equal("10 Pancakes", item),
                item => Assert.Equal("Hold Syrup", item),
                item => Assert.Equal("Hold Whipped Cream", item),
                item => Assert.Equal("Hold Berries", item)
            );
        }

        /// <summary>
        /// This test checks that can we get the subtotal from the collection
        /// </summary>
        [Fact]
        public void SubtotalShouldBeCorrect()
        {
            Order odm = new()
            {
                new MockMenuItem() { Price = 1.00m, Calories = 10u, SpecialInstructions = new List<string> { "Alpha" } },
                new MockMenuItem() { Price = 2.00m, Calories = 20u, SpecialInstructions = new List<string> { "Beta" } },
                new MockMenuItem() { Price = 3.00m, Calories = 30u, SpecialInstructions = new List<string> { "Gamma" } },
                new MockMenuItem() { Price = 4.00m, Calories = 40u, SpecialInstructions = new List<string> { "Delta" } },
                new MockMenuItem() { Price = 5.00m, Calories = 50u, SpecialInstructions = new List<string> { "Epsilon" } }
            };
            Assert.Equal(1.00m + 2.00m + 3.00m + 4.00m + 5.00m, odm.Subtotal);


            Order od = new()
            {
                new FlyingSaucer() { StackSize = 8 },
                new LivestockMutilation() { Gravy = true },
                new SaucerFuel() { Size = ServingSize.Large},
                new InorganicSubstance() {Size = ServingSize.Medium}
            };
            Assert.Equal(10.00m + 7.25m + 2.00m + 0.00m, od.Subtotal);
        }

        /// <summary>
        /// This test check that can we get and set the TaxRate from the collection
        /// </summary>
        [Fact]
        public void CanGetSetTaxRate()
        {
            Order od = new() { TaxRate = 0.30m };
            Assert.Equal(0.30m, od.TaxRate);
        }

        /// <summary>
        /// This test checks that can we get Tax for the order by multiplying Subtotal and TaxRate
        /// </summary>
        [Fact]
        public void CanGetTax()
        {
            Order odm = new()
            {
                new MockMenuItem() { Price = 1.00m, Calories = 10u, SpecialInstructions = new List<string> { "Alpha" } },
                new MockMenuItem() { Price = 2.00m, Calories = 20u, SpecialInstructions = new List<string> { "Beta" } },
                new MockMenuItem() { Price = 3.00m, Calories = 30u, SpecialInstructions = new List<string> { "Gamma" } },
                new MockMenuItem() { Price = 4.00m, Calories = 40u, SpecialInstructions = new List<string> { "Delta" } },
                new MockMenuItem() { Price = 5.00m, Calories = 50u, SpecialInstructions = new List<string> { "Epsilon" } }
            };
            odm.TaxRate = 0.30m;
            Assert.Equal(15.00m * 0.30m, odm.Subtotal * odm.TaxRate);
            Assert.Equal(odm.Subtotal * odm.TaxRate, odm.Tax);


            Order od = new()
            {
                new FlyingSaucer() { StackSize = 8 },
                new LivestockMutilation() { Gravy = true },
                new SaucerFuel() { Size = ServingSize.Large},
                new InorganicSubstance() {Size = ServingSize.Medium}
            };
            od.TaxRate = 0.30m;
            Assert.Equal(5.775m, od.Subtotal * od.TaxRate);
            Assert.Equal(od.Subtotal * od.TaxRate, od.Tax);
        }

        /// <summary>
        /// This test checks that can we get Total that is the sum of the Subtotal and Tax
        /// </summary>
        [Fact]
        public void CanGetTotal()
        {
            Order odm = new()
            {
                new MockMenuItem() { Price = 1.00m, Calories = 10u, SpecialInstructions = new List<string> { "Alpha" } },
                new MockMenuItem() { Price = 2.00m, Calories = 20u, SpecialInstructions = new List<string> { "Beta" } },
                new MockMenuItem() { Price = 3.00m, Calories = 30u, SpecialInstructions = new List<string> { "Gamma" } },
                new MockMenuItem() { Price = 4.00m, Calories = 40u, SpecialInstructions = new List<string> { "Delta" } },
                new MockMenuItem() { Price = 5.00m, Calories = 50u, SpecialInstructions = new List<string> { "Epsilon" } }
            };
            odm.TaxRate = 0.30m;
            Assert.Equal(Math.Round(1.00m + 2.00m + 3.00m + 4.00m + 5.00m + (1.00m + 2.00m + 3.00m + 4.00m + 5.00m)*0.30m, 2), odm.Total);


            Order od = new()
            {
                new FlyingSaucer() { StackSize = 8 },
                new LivestockMutilation() { Gravy = true },
                new SaucerFuel() { Size = ServingSize.Large},
                new InorganicSubstance() {Size = ServingSize.Medium}
            };
            od.TaxRate = 0.30m;
            Assert.Equal(Math.Round(10.00m + 7.25m + 2.00m + 0.00m + 5.775m, 2), od.Total);
        }
        /// <summary>
        /// This test checks that if the Order class actually implements INotifyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Order od = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(od);
            Assert.IsAssignableFrom<INotifyCollectionChanged>(od);
        }

        /// <summary>
        /// This test checks that when the TaxRate Property in Order collection are changed
        /// the PropertyChanged event indeed be triggered
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order od = new();
            Assert.PropertyChanged(od, "TaxRate", () => { od.TaxRate = 0.15m; });
            Assert.PropertyChanged(od, "Subtotal", () => { od.TaxRate = 0.16m; });
            Assert.PropertyChanged(od, "Tax", () => { od.TaxRate = 0.17m; });
            Assert.PropertyChanged(od, "Total", () => { od.TaxRate = 0.18m; });
        }

        /// <summary>
        /// This test checks that when the values in Order collection are changed the PropertyChanged event indeed be triggered
        /// </summary>
        [Fact]
        public void PropertyChangedShouldBeTriggered()
        {
            FlyingSaucer fs = new();
            CrashedSaucer cs = new();
            LiquifiedVegetation lv = new();

            Order od = new() { fs, cs, lv };
            od.TaxRate = 0.30m;

            List<IMenuItem> lmi = new() { fs, cs, lv };

            Assert.PropertyChanged(od, "Subtotal", () => od.Add(new FlyingSaucer()));
            Assert.PropertyChanged(od, "Tax", () => od.Add(new CrashedSaucer()));
            Assert.PropertyChanged(od, "Total", () => od.Add(new SaucerFuel()));

            Assert.PropertyChanged(od, "Subtotal", () => od.Clear());
            Assert.PropertyChanged(od, "Tax", () => od.Clear());
            Assert.PropertyChanged(od, "Total", () => od.Clear());

            Assert.PropertyChanged(od, "Subtotal", () => od.Add(fs));
            Assert.PropertyChanged(od, "Tax", () => od.Add(cs));
            Assert.PropertyChanged(od, "Total", () => od.Add(lv));

            Assert.PropertyChanged(od, "Subtotal", () => od.Remove(fs));
            Assert.PropertyChanged(od, "Tax", () => od.Remove(cs));
            Assert.PropertyChanged(od, "Total", () => od.Remove(lv));
            
            Assert.PropertyChanged(od, "Subtotal", () => od.Orders = lmi);
            Assert.PropertyChanged(od, "Tax", () => od.Orders = lmi);
            Assert.PropertyChanged(od, "Total", () => od.Orders = lmi);
        }

        /// <summary>
        /// This test checks that when the values in Order collection are changed the CollectionChanged event indeed be triggered
        /// </summary>
        [Fact]
        public void CollectionChangeShouldBeTriggered()
        {
            FlyingSaucer fs = new();
            CrashedSaucer cs = new();
            LiquifiedVegetation lv = new();
            Order od = new();
            od.TaxRate = 0.30m;

            List<IMenuItem> lmi = new() { fs };

            Assert.Throws<NotifyCollectionChangedNotTriggeredException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedAdd(od, fs, () => { od.Remove(fs); });
            });
            Assert.Throws<NotifyCollectionChangedWrongActionException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedAdd(od, fs, () => { od.Clear(); });
            });
            Assert.Throws<NotifyCollectionChangedAddException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedAdd(od, fs, () => { od.Add(fs); od.Add(new CrashedSaucer()); });
            });
            Assert.Throws<NotifyCollectionChangedAddException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedAdd(od, fs, () => { od.Add(new CrashedSaucer());});
            });
            NotifyCollectionAssert.NotifyCollectionChangedAdd(od, fs, () => { od.Add(fs); });

           
            Assert.Throws< NotifyCollectionAssert.NotifyCollectionChangedNotTriggeredException > (() => {
                NotifyCollectionAssert.NotifyCollectionChangedRemove(od, fs, () => { od.Remove(new FlyingSaucer()); });
            });
            Assert.Throws<NotifyCollectionAssert.NotifyCollectionChangedWrongActionException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedRemove(od, fs, () => { od.Add(fs); });
            });
            Assert.Throws<NotifyCollectionAssert.NotifyCollectionChangedRemoveException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedRemove(od, new CrashedSaucer(), () => { od.Remove(fs); });
            });
            NotifyCollectionAssert.NotifyCollectionChangedRemove(od, fs, () => { od.Remove(fs); });



            Assert.Throws<NotifyCollectionAssert.NotifyCollectionChangedWrongActionException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedReset(od, () => { od.Remove(fs); });
            });
            Order odm = new();
            Assert.Throws<NotifyCollectionAssert.NotifyCollectionChangedNotTriggeredException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedReset(od, () => { odm.Clear(); });
            });
            NotifyCollectionAssert.NotifyCollectionChangedReset(od, () => { od.Clear(); });


            Assert.Throws<NotifyCollectionAssert.NotifyCollectionChangedWrongActionException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedReplace(od, lmi, () => { od.Clear(); });
            });
            Assert.Throws<NotifyCollectionAssert.NotifyCollectionChangedNotTriggeredException>(() => {
                NotifyCollectionAssert.NotifyCollectionChangedReplace(od, lmi, () => { od.Remove(fs); });
            });
            NotifyCollectionAssert.NotifyCollectionChangedReplace(od, lmi, () => { od.Orders = lmi; });
        }
        
        /// <summary>
        /// This test checks that the static Propery in the Order.cs is actually static
        /// </summary>
        [Fact]
        public void LastNumberUsedShouldbeStatic()
        {
            Assert.Equal(0, Order.LastNumberUsed);
            Order.LastNumberUsed++;
            Assert.Equal(1, Order.LastNumberUsed);
            Order.LastNumberUsed += 2;
            Assert.Equal(3, Order.LastNumberUsed);
            Order.LastNumberUsed -= 3;
            Assert.Equal(0, Order.LastNumberUsed);
            Order.LastNumberUsed -= 11;
            Assert.Equal(-11, Order.LastNumberUsed);
            Order.LastNumberUsed += 5;
            Assert.Equal(-6, Order.LastNumberUsed);
            Order.LastNumberUsed +=6;
            Assert.Equal(0, Order.LastNumberUsed);
        }

        /// <summary>
        /// The Number property in the Order.cs should be updated for each subsequent Order
        /// </summary>
        /// <param name="numOrder">The number of orders to be placed.</param>
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(40)]
        [InlineData(80)]
        [InlineData(160)]
        [InlineData(320)]
        [InlineData(640)]
        [InlineData(1280)]
        public void NumberShouldBeUpdated(int numOrder)
        {
            for (int i = 0; i < numOrder; i++)
            {
                Order od = new() { Number = Order.LastNumberUsed + 1 };
                Assert.Equal(Order.LastNumberUsed, od.Number);
                Console.WriteLine(od.Number);
                Assert.Equal(Order.LastNumberUsed, od.Number);
            }
            Assert.Equal(numOrder, Order.LastNumberUsed);
            Console.WriteLine(Order.LastNumberUsed);
            Assert.Equal(numOrder, Order.LastNumberUsed);
            Order.LastNumberUsed = 0;
        }

        /// <summary>
        /// This test checks that the PlaceAt date and time reflect when the order is created
        /// </summary>
        [Fact]
        public void PlacedAtShouldBeCorrect()
        {
            Order od1 = new();
            Assert.Equal(DateTime.Now.ToString(), od1.PlacedAt.ToString());
            Console.WriteLine(od1.PlacedAt);
            Assert.Equal(DateTime.Now.ToString(), od1.PlacedAt.ToString());

            Order od2 = new() { PlacedAt = DateTime.Now.ToUniversalTime() };
            Assert.Equal(DateTime.Now.ToUniversalTime().ToString(), od2.PlacedAt.ToString());
            Console.WriteLine(od2.PlacedAt);
            Assert.Equal(DateTime.Now.ToUniversalTime().ToString(), od2.PlacedAt.ToString());
        }

        #endregion
    }
}
