namespace TheCashDrawerViewModel.DataTests
{
    /// <summary>
    /// Unit tests for the CashDrawerViewModelUnitTest class
    /// </summary>
    public class CashDrawerViewModelUnitTest
    {
        /// <summary>
        /// This test checks that the new instance of CashDrawerViewModel has the default starting value for every property.
        /// </summary>
        [Fact]
        public void CashDrawerViewModelShouldBeDefault()
        {
            CashDrawer.Reset();
            CashDrawerViewModel cdvm = new(new Order());
            Assert.True(cdvm.CalculateChange);
            Assert.Equal(0u, cdvm.Hundreds);
            Assert.Equal(0u, cdvm.Fifties);
            Assert.Equal(4u, cdvm.Twenties);
            Assert.Equal(10u, cdvm.Tens);
            Assert.Equal(8u, cdvm.Fives);
            Assert.Equal(0u, cdvm.Twos);
            Assert.Equal(20u, cdvm.Ones);
            Assert.Equal(0u, cdvm.DollarCoins);
            Assert.Equal(0u, cdvm.HalfDollarCoins);
            Assert.Equal(80u, cdvm.Quarters);
            Assert.Equal(100u, cdvm.Dimes);
            Assert.Equal(80u, cdvm.Nickles);
            Assert.Equal(100u, cdvm.Pennies);

            Assert.Equal(0u, cdvm.CustomerHundreds);
            Assert.Equal(0u, cdvm.CustomerFifties);
            Assert.Equal(0u, cdvm.CustomerTwenties);
            Assert.Equal(0u, cdvm.CustomerTens);
            Assert.Equal(0u, cdvm.CustomerFives);
            Assert.Equal(0u, cdvm.CustomerTwos);
            Assert.Equal(0u, cdvm.CustomerOnes);
            Assert.Equal(0u, cdvm.CustomerDollarCoins);
            Assert.Equal(0u, cdvm.CustomerHalfDollarCoins);
            Assert.Equal(0u, cdvm.CustomerQuarters);
            Assert.Equal(0u, cdvm.CustomerDimes);
            Assert.Equal(0u, cdvm.CustomerNickles);
            Assert.Equal(0u, cdvm.CustomerPennies);

            Assert.Equal(0u, cdvm.CustomerHundredsChange);
            Assert.Equal(0u, cdvm.CustomerFiftiesChange);
            Assert.Equal(0u, cdvm.CustomerTwentiesChange);
            Assert.Equal(0u, cdvm.CustomerTensChange);
            Assert.Equal(0u, cdvm.CustomerFivesChange);
            Assert.Equal(0u, cdvm.CustomerTwosChange);
            Assert.Equal(0u, cdvm.CustomerOnesChange);
            Assert.Equal(0u, cdvm.CustomerDollarCoinsChange);
            Assert.Equal(0u, cdvm.CustomerHalfDollarCoinsChange);
            Assert.Equal(0u, cdvm.CustomerQuartersChange);
            Assert.Equal(0u, cdvm.CustomerDimesChange);
            Assert.Equal(0u, cdvm.CustomerNicklesChange);
            Assert.Equal(0u, cdvm.CustomerPenniesChange);

            Assert.Equal(0m, cdvm.CustomerQuantity);
            Assert.Equal(0m, cdvm.AmountDue);
            Assert.Equal(0m, cdvm.ChangeOwed);
            Assert.Equal(0m, cdvm.SumOfChanges);
            Assert.Equal(0m, cdvm.TotalSale);
        }

        /// <summary>
        /// This test checks that the new instance of CashDrawerViewModel indeed reflect order Total
        /// </summary>
        [Fact]
        public void AmountDueShouldReflectAddedOrderTotal()
        {
            CashDrawer.Reset();
            Order od = new()
            {
                new FlyingSaucer()
            };
            od.TaxRate = 0.30m;
            CashDrawerViewModel cdvm = new(od);

            Assert.Equal(11.05m, cdvm.AmountDue);
            od.Add(new FlyingSaucer());
            Assert.Equal(22.10m, cdvm.AmountDue);
            od.Add(new CrashedSaucer());
            Assert.Equal(30.48m, cdvm.AmountDue);
            od.Add(new LivestockMutilation());
            Assert.Equal(39.91m, cdvm.AmountDue);
            od.Add(new OuterOmelette());
            Assert.Equal(49.60m, cdvm.AmountDue);
            od.Add(new CropCircle());
            Assert.Equal(52.20m, cdvm.AmountDue);
            od.Add(new GlowingHaystack());
            Assert.Equal(54.80m, cdvm.AmountDue);
            od.Add(new TakenBacon());
            Assert.Equal(57.40m, cdvm.AmountDue);
            od.Add(new MissingLinks());
            Assert.Equal(60.00m, cdvm.AmountDue);
            od.Add(new EvisceratedEggs());
            Assert.Equal(62.60m, cdvm.AmountDue);
            od.Add(new YouAreToast());
            Assert.Equal(65.20m, cdvm.AmountDue);
            od.Add(new LiquifiedVegetation());
            Assert.Equal(66.50m, cdvm.AmountDue);
            od.Add(new SaucerFuel());
            Assert.Equal(67.80m, cdvm.AmountDue);
            od.Add(new InorganicSubstance());
            Assert.Equal(67.80m, cdvm.AmountDue);
        }

        /// <summary>
        /// This test checks that the new instance of CashDrawerViewModel indeed reflect order Total
        /// </summary>
        [Fact]
        public void AmountDueShouldReflectRemovedOrderTotal()
        {
            CashDrawer.Reset();
            Order od = new()
            {
                new FlyingSaucer(),
                new FlyingSaucer(),
                new CrashedSaucer(),
                new LivestockMutilation(),
                new OuterOmelette(),
                new CropCircle(),
                new GlowingHaystack(),
                new TakenBacon(),
                new MissingLinks(),
                new EvisceratedEggs(),
                new YouAreToast(),
                new LiquifiedVegetation(),
                new SaucerFuel(),
                new InorganicSubstance(),
            };
            od.TaxRate = 0.30m;
            CashDrawerViewModel cdvm = new(od);

            Assert.Equal(67.80m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(67.80m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(66.50m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(65.20m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(62.60m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(60.00m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(57.40m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(54.80m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(52.20m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(49.60m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(39.91m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(30.48m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(22.10m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(11.05m, cdvm.AmountDue);
            od.Remove(od.Last());
            Assert.Equal(0m, cdvm.AmountDue);
        }

        /// <summary>d
        /// This test checks that the new instance of CashDrawerViewModel indeed reflect Total change as with order customization
        /// </summary>
        [Fact]
        public void AmountDueShouldReflectCustomization()
        {
            CashDrawer.Reset();
            Order od = new()
            {
                new FlyingSaucer(),
                new CrashedSaucer(),
                new LivestockMutilation(),
                new OuterOmelette(),
                new CropCircle(),
                new GlowingHaystack(),
                new TakenBacon(),
                new MissingLinks(),
                new EvisceratedEggs(),
                new YouAreToast(),
                new LiquifiedVegetation(),
                new SaucerFuel(),
                new InorganicSubstance(),
            };
            od.TaxRate = 0.30m;
            CashDrawerViewModel cdvm = new(od);

            if (od.ElementAt(0) is FlyingSaucer fs)
            {
                fs.StackSize = 12;
                Assert.Equal(62.60m, cdvm.AmountDue);
            }

            if (od.ElementAt(1) is CrashedSaucer cs)
            {
                cs.StackSize = 6;
                Assert.Equal(70.40m, cdvm.AmountDue);
            }

            if (od.ElementAt(0) is FlyingSaucer fss)
            {
                fss.StackSize = 0;
                Assert.Equal(64.54m, cdvm.AmountDue);
            }

            if (od.ElementAt(2) is LivestockMutilation lm)
            {
                lm.Biscuits = 8;
                Assert.Equal(71.04m, cdvm.AmountDue);
            }

            if (od.ElementAt(6) is TakenBacon tb)
            {
                tb.Count = 6;
                Assert.Equal(76.24m, cdvm.AmountDue);
            }

            if (od.ElementAt(7) is MissingLinks ml)
            {
                ml.Count = 8;
                Assert.Equal(84.04m, cdvm.AmountDue);
            }

            if (od.ElementAt(8) is EvisceratedEggs eg)
            {
                eg.Count = 6;
                Assert.Equal(89.24m, cdvm.AmountDue);
            }

            if (od.ElementAt(9) is YouAreToast yt)
            {
                yt.Count = 12;
                Assert.Equal(102.24m, cdvm.AmountDue);
            }

            if (od.ElementAt(10) is LiquifiedVegetation lv)
            {
                lv.Size = ServingSize.Large;
                Assert.Equal(103.54m, cdvm.AmountDue);
            }

            if (od.ElementAt(11) is SaucerFuel sf)
            {
                sf.Size = ServingSize.Large;
                Assert.Equal(104.84m, cdvm.AmountDue);
            }

            if (od.ElementAt(12) is InorganicSubstance os)
            {
                os.Size = ServingSize.Large;
                Assert.Equal(104.84m, cdvm.AmountDue);
            }
        }

        /// <summary>
        /// This test checks that the new instance of CashDrawerViewModel indeed reflect Amount due
        /// when the customer increase currency amount
        /// </summary>
        [Fact]
        public void CustomerCurrencyShouldDecreaseAmountDue()
        {
            CashDrawer.Reset();
            Order od = new()
            {
                new FlyingSaucer(),
                new FlyingSaucer(),
                new FlyingSaucer(),
                new FlyingSaucer(),
                new CrashedSaucer(),
                new CrashedSaucer(),
                new CrashedSaucer(),
                new CrashedSaucer(),
                new LivestockMutilation(),
                new LivestockMutilation(),
                new LivestockMutilation(),
                new LivestockMutilation(),
                new OuterOmelette(),
                new OuterOmelette(),
                new OuterOmelette(),
                new OuterOmelette(),
                new CropCircle(),
                new CropCircle(),
                new CropCircle(),
                new CropCircle(),
                new GlowingHaystack(),
                new GlowingHaystack(),
                new GlowingHaystack(),
                new GlowingHaystack(),
                new TakenBacon(),
                new TakenBacon(),
                new TakenBacon(),
                new TakenBacon(),
                new MissingLinks(),
                new MissingLinks(),
                new MissingLinks(),
                new MissingLinks(),
                new EvisceratedEggs(),
                new EvisceratedEggs(),
                new EvisceratedEggs(),
                new EvisceratedEggs(),
                new YouAreToast(),
                new YouAreToast(),
                new YouAreToast(),
                new YouAreToast(),
                new LiquifiedVegetation(),
                new LiquifiedVegetation(),
                new LiquifiedVegetation(),
                new LiquifiedVegetation(),
                new SaucerFuel(),
                new SaucerFuel(),
                new SaucerFuel(),
                new SaucerFuel(),
                new InorganicSubstance(),
                new InorganicSubstance(),
                new InorganicSubstance(),
                new InorganicSubstance()
            };
            od.TaxRate = 0.30m;
            CashDrawerViewModel cdvm = new(od);

            cdvm.CustomerPennies = 1;
            Assert.Equal(226.97m, cdvm.AmountDue);
            cdvm.CustomerNickles = 1;
            Assert.Equal(226.92m, cdvm.AmountDue);
            cdvm.CustomerDimes = 1;
            Assert.Equal(226.82m, cdvm.AmountDue);
            cdvm.CustomerQuarters = 1;
            Assert.Equal(226.57m, cdvm.AmountDue);
            cdvm.CustomerHalfDollarCoins = 1;
            Assert.Equal(226.07m, cdvm.AmountDue);
            cdvm.CustomerDollarCoins = 1;
            Assert.Equal(225.07m, cdvm.AmountDue);
            cdvm.CustomerOnes = 1;
            Assert.Equal(224.07m, cdvm.AmountDue);
            cdvm.CustomerTwos = 1;
            Assert.Equal(222.07m, cdvm.AmountDue);
            cdvm.CustomerFives = 1;
            Assert.Equal(217.07m, cdvm.AmountDue);
            cdvm.CustomerTens = 1;
            Assert.Equal(207.07m, cdvm.AmountDue);
            cdvm.CustomerTwenties = 1;
            Assert.Equal(187.07m, cdvm.AmountDue);
            cdvm.CustomerFifties = 1;
            Assert.Equal(137.07m, cdvm.AmountDue);
            cdvm.CustomerHundreds = 1;
            Assert.Equal(37.07m, cdvm.AmountDue);
        }

        /// <summary>
        /// This test checks that the new instance of CashDrawerViewModel indeed reflect Change Owed of the Customer
        /// </summary>
        [Fact]
        public void ChangeOwedShouldBeReflected()
        {
            CashDrawer.Reset();
            Order od = new()
            {
                new SaucerFuel()
                {
                    Size=ServingSize.Medium
                }
            };
            od.TaxRate = 0.30m;
            CashDrawerViewModel cdvm = new(od);

            cdvm.CustomerHundreds = 1;
            Assert.Equal(98.05m, cdvm.ChangeOwed);

            cdvm.CustomerHundreds = 0;
            cdvm.CustomerFifties = 1;
            Assert.Equal(48.05m, cdvm.ChangeOwed);

            cdvm.CustomerFifties = 0;
            cdvm.CustomerTwenties = 1;
            Assert.Equal(18.05m, cdvm.ChangeOwed);

            cdvm.CustomerTwenties = 0;
            cdvm.CustomerTens = 1;
            Assert.Equal(8.05m, cdvm.ChangeOwed);

            cdvm.CustomerTens = 0;
            cdvm.CustomerFives = 1;
            Assert.Equal(3.05m, cdvm.ChangeOwed);

            cdvm.CustomerFives = 0;
            cdvm.CustomerTwos = 1;
            Assert.Equal(0.05m, cdvm.ChangeOwed);

            cdvm.CustomerTwos = 0;
            cdvm.CustomerOnes = 3;
            Assert.Equal(1.05m, cdvm.ChangeOwed);

            cdvm.CustomerOnes = 0;
            cdvm.CustomerDollarCoins = 2;
            Assert.Equal(0.05m, cdvm.ChangeOwed);

            cdvm.CustomerDollarCoins = 0;
            cdvm.CustomerHalfDollarCoins = 5;
            Assert.Equal(0.55m, cdvm.ChangeOwed);

            cdvm.CustomerHalfDollarCoins = 0;
            cdvm.CustomerQuarters = 9;
            Assert.Equal(0.30m, cdvm.ChangeOwed);

            cdvm.CustomerQuarters = 0;
            cdvm.CustomerDimes = 22;
            Assert.Equal(0.25m, cdvm.ChangeOwed);

            cdvm.CustomerDimes = 0;
            cdvm.CustomerNickles = 51;
            Assert.Equal(0.60m, cdvm.ChangeOwed);

            cdvm.CustomerNickles = 0;
            cdvm.CustomerPennies = 202;
            Assert.Equal(0.07m, cdvm.ChangeOwed);
        }

        /// <summary>
        /// This test checks that the new instance of CashDrawerViewModel indeed reflect Give as change currency amount
        /// </summary>
        [Fact]
        public void GiveAsChangeShouldBeCorrect()
        {
            CashDrawer.Reset();
            Order od = new()
            {
                new SaucerFuel()
                {
                    Size=ServingSize.Medium
                }
            };
            od.TaxRate = 0.30m;
            CashDrawerViewModel cdvm = new(od);

            cdvm.CustomerHundreds = 1;
            Assert.Equal(98.05m, cdvm.ChangeOwed);
            Assert.Equal(4u, cdvm.CustomerTwentiesChange);
            Assert.Equal(1u, cdvm.CustomerTensChange);
            Assert.Equal(1u, cdvm.CustomerFivesChange);
            Assert.Equal(3u, cdvm.CustomerOnesChange);
            Assert.Equal(1u, cdvm.CustomerNicklesChange);
            cdvm.CustomerHundreds = 0;
            Assert.Equal(0m, cdvm.ChangeOwed);

            cdvm.CustomerFifties = 1;
            Assert.Equal(48.05m, cdvm.ChangeOwed);
            Assert.Equal(2u, cdvm.CustomerTwentiesChange);
            Assert.Equal(1u, cdvm.CustomerFivesChange);
            Assert.Equal(3u, cdvm.CustomerOnesChange);
            Assert.Equal(1u, cdvm.CustomerNicklesChange);
            cdvm.CustomerFifties = 0;
            Assert.Equal(0m, cdvm.ChangeOwed);

            cdvm.CustomerTwenties = 1;
            Assert.Equal(18.05m, cdvm.ChangeOwed);
            Assert.Equal(1u, cdvm.CustomerTensChange);
            Assert.Equal(1u, cdvm.CustomerFivesChange);
            Assert.Equal(3u, cdvm.CustomerOnesChange);
            Assert.Equal(1u, cdvm.CustomerNicklesChange);
            cdvm.CustomerTwenties = 0;
            Assert.Equal(0m, cdvm.ChangeOwed);

            cdvm.CustomerTens = 1;
            Assert.Equal(8.05m, cdvm.ChangeOwed);
            Assert.Equal(1u, cdvm.CustomerFivesChange);
            Assert.Equal(3u, cdvm.CustomerOnesChange);
            Assert.Equal(1u, cdvm.CustomerNicklesChange);
            cdvm.CustomerTens = 0;
            Assert.Equal(0m, cdvm.ChangeOwed);

            cdvm.CustomerFives = 1;
            Assert.Equal(3.05m, cdvm.ChangeOwed);
            Assert.Equal(3u, cdvm.CustomerOnesChange);
            Assert.Equal(1u, cdvm.CustomerNicklesChange);
            cdvm.CustomerFives = 0;
            Assert.Equal(0m, cdvm.ChangeOwed);

            cdvm.CustomerTwos = 1;
            Assert.Equal(0.05m, cdvm.ChangeOwed);
            Assert.Equal(1u, cdvm.CustomerNicklesChange);
            cdvm.CustomerTwos = 0;
            Assert.Equal(0m, cdvm.ChangeOwed);
        }

        /// <summary>
        /// This test checks that the new instance of CashDrawerViewModel indeed reject finalize order with insufficient amount
        /// </summary>
        [Fact]
        public void SumofChangesShouldBeCorrect()
        {
            CashDrawer.Reset();
            Order od = new()
            {
                new FlyingSaucer()
            };
            od.TaxRate = 0.30m;
            CashDrawerViewModel cdvm = new(od);

            cdvm.CustomerHundreds = 1;
            Assert.Equal(88.95m, cdvm.ChangeOwed);
            Assert.Equal(88.95m, cdvm.SumOfChanges);
            Assert.Equal(cdvm.ChangeOwed, cdvm.SumOfChanges);
            cdvm.CustomerHundreds = 0;
            Assert.Equal(0m, cdvm.ChangeOwed);

            cdvm.CustomerFifties = 1;
            Assert.Equal(38.95m, cdvm.ChangeOwed);
            Assert.Equal(38.95m, cdvm.SumOfChanges);
            Assert.Equal(cdvm.ChangeOwed, cdvm.SumOfChanges);
            cdvm.CustomerFifties = 0;
            Assert.Equal(0m, cdvm.ChangeOwed);

            cdvm.CustomerTwenties = 1;
            Assert.Equal(8.95m, cdvm.ChangeOwed);
            Assert.Equal(8.95m, cdvm.SumOfChanges);
            Assert.Equal(cdvm.ChangeOwed, cdvm.SumOfChanges);
            cdvm.CustomerTwenties = 0;
            Assert.Equal(0m, cdvm.ChangeOwed);
        }
    }
}