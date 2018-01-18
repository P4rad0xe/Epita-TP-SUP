using System;

namespace WestWorldTycoon
{
    public class Attraction :Building
    {
        public const long BUILD_COST = 10000;
        public static readonly long[] UPGRADE_COST = { 5000, 10000, 45000 };
        public static readonly long[] ATTRACTIVENESS = { 500, 1000, 1300, 1500 };

        private int lvl;

        public Attraction()
        {
            lvl = 0;
            type = BuildingType.ATTRACTION;
        }

        public int Lvl
        {
            get { return lvl; }
        }

        public bool Upgrade(ref long money)
        {
            if (lvl < 3 && money >= UPGRADE_COST[lvl])
            {
                money -= UPGRADE_COST[lvl];
                lvl++;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public long Attractiveness()
        {
            return ATTRACTIVENESS[lvl];
        }

        public Attraction(Attraction attraction)
        {
            lvl = attraction.Lvl;
        }
    }
}