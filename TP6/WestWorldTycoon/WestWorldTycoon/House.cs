using System;
using System.Runtime.InteropServices;

namespace WestWorldTycoon
{
    public class House : Building
    {
        public const long BUILD_COST = 250;
        public static readonly long[] UPGRADE_COST ={ 750, 3000, 10000 };
        public static readonly long[] HOUSING ={ 300, 500, 650, 750 };

        private int lvl;
        
        public House()
        {
            lvl = 0;
            type = BuildingType.HOUSE;
        }


        public House(House house)
        {
            lvl = house.lvl;
            type = house.type;
        }

        
        public long Housing()
        {
            return HOUSING[lvl];
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
        
        public int Lvl
        {
            get { return lvl; }
        }
    }
}