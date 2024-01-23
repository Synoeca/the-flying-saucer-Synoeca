using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMenu.DataTests
{
    /// <summary>
    /// Unit tests for the Menu class
    /// </summary>
    public class MenuUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the static class Menu.cs contains default menu items
        /// </summary>
        [Fact]
        public void HasDefaultMenuItems()
        {
            IEnumerable<IMenuItem> etrs = Menu.Entrees;
            IEnumerable<IMenuItem> sds = Menu.Sides;
            IEnumerable<IMenuItem> drks = Menu.Drinks;
            IEnumerable<IMenuItem> fm = Menu.FullMenu;

            Assert.Collection(etrs,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item)
            );
            Assert.Collection(sds,
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item)
            );
            Assert.Collection(drks,
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );
            Assert.Collection(fm,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item),
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );
        }

        /// <summary>
        /// This test checks that the static class Menu.cs has default sum of prices
        /// </summary>
        [Fact]
        public void HasDefaultSumOfPrice()
        {
            IEnumerable<IMenuItem> etrs = Menu.Entrees;
            IEnumerable<IMenuItem> sds = Menu.Sides;
            IEnumerable<IMenuItem> drks = Menu.Drinks;
            IEnumerable<IMenuItem> fm = Menu.FullMenu;
            decimal etrSum = 0;
            decimal sdSum = 0;
            decimal drSum = 0;
            decimal fmSum = 0;

            foreach (IMenuItem imi in etrs)
            {
                etrSum += imi.Price;
            }
            Assert.Equal(29.65m, etrSum);

            foreach (IMenuItem imi in sds)
            {
                sdSum += imi.Price;
            }
            Assert.Equal(12.00m, sdSum);

            foreach (IMenuItem imi in drks)
            {
                drSum += imi.Price;
            }
            Assert.Equal(2.00m, drSum);

            foreach (IMenuItem imi in fm)
            {
                fmSum += imi.Price;
            }
            Assert.Equal(43.65m, fmSum);
        }

        /// <summary>
        /// This test checks that the static class Menu.cs has unique combinations
        /// </summary>
        [Fact]
        public void HasUniqueCombination()
        {
            IEnumerable<IMenuItem> etrs = Menu.Entrees;
            IEnumerable<IMenuItem> sds = Menu.Sides;
            IEnumerable<IMenuItem> drks = Menu.Drinks;
            IEnumerable<IMenuItem> fm = Menu.FullMenu;
            
            Assert.Contains(sds, item => {
                if (item is EvisceratedEggs eg)
                {
                    if (eg.Style == EggStyle.OverEasy) { return true; }
                    else { return false; }
                }
                else { return false; }
            });


            Assert.Contains(drks, item => {
                if (item is InorganicSubstance os)
                {
                    if (os.Size == ServingSize.Small) { return true; }
                    else { return false; }
                }
                else { return false; }
            });



            Assert.Contains(drks, item => {
                if (item is LiquifiedVegetation lv)
                {
                    if (lv.Size == ServingSize.Small) { return true; }
                    else { return false; }
                }
                else { return false; }
            });



            Assert.Contains(drks, item => {
                if (item is SaucerFuel sf)
                {
                    if (sf.Size == ServingSize.Small) { return true; }
                    else { return false; }
                }
                else { return false; }
            });





            Assert.Contains(fm, item => {
                if (item is EvisceratedEggs eg)
                {
                    if (eg.Style == EggStyle.OverEasy) { return true; }
                    else { return false; }
                }
                else { return false; }
            });
            Assert.Contains(fm, item => {
                if (item is InorganicSubstance os)
                {
                    if (os.Size == ServingSize.Small) { return true; }
                    else { return false; }
                }
                else { return false; }
            });
            Assert.Contains(fm, item => {
                if (item is LiquifiedVegetation lv)
                {
                    if (lv.Size == ServingSize.Small) { return true; }
                    else { return false; }
                }
                else { return false; }
            });
            Assert.Contains(fm, item => {
                if (item is SaucerFuel sf)
                {
                    if (sf.Size == ServingSize.Small) { return true; }
                    else { return false; }
                }
                else { return false; }
            });
        }

        #endregion

        #region state changes

        #endregion
    }
}
