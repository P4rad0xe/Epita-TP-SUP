using System;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace WestWorldTycoon
{
    public class Tile
    {
        
        public enum Biome
        {
            SEA, MOUNTAIN, PLAIN
        }

        private Biome biome;
        private Building building;
        
        
        public Tile(Biome b)
        {
            biome = b;
            building = null;
        }

        
        public Tile(Tile tile)
        {
            biome = tile.biome;
            building = tile.building;
        }

        
        public bool Build(ref long money, Building.BuildingType type)
        {
            bool Built = true;
            if (biome == Biome.PLAIN)
            {
                switch (type)
                {
                     case Building.BuildingType.HOUSE:
                         if (money >= House.BUILD_COST)
                         {
                             this.building = new House();
                             money -= House.BUILD_COST;
                         }
                         else
                             Built = false;
                         break;
                         
                     case Building.BuildingType.ATTRACTION:
                         if (money >= Attraction.BUILD_COST)
                         {
                             this.building = new Attraction();
                             money -= Attraction.BUILD_COST;
                         }
                         else
                             Built = false;
                         break;
                         
                     case Building.BuildingType.SHOP:
                         if (money >= Shop.BUILD_COST)
                         {
                             this.building = new Shop();
                             money -= Shop.BUILD_COST;
                         }
                         else
                             Built = false;
                         break;
                         
                     case Building.BuildingType.NONE:
                         break;
                }
            }
            return Built;
        }


        public bool Upgrade(ref long money)
        {
            bool Upgraded = true;
            if (building is House)
                Upgraded = ((House) building).Upgrade(ref money);
            else if (building is Shop)
                Upgraded = ((House) building).Upgrade(ref money);
            else if (building is Attraction)
                Upgraded = ((Attraction) building).Upgrade(ref money);
            else
                Upgraded = false;
            return Upgraded;
        }
        
        
        public long GetHousing()
        {
            long visitors = 0;
            if (building is House)
            {
                visitors += ((House) building).Housing();
            }
            return visitors;
        }
        
        
        public long GetAttractiveness()
        {
            long attractiveness = 0;
            if (building is Attraction)
            {
                attractiveness += ((Attraction) building).Attractiveness();
            }

            return attractiveness;
        }
        
        
        public long GetIncome(long population)
        {
            long income = 0;
            if (building is Shop)
            {
                income += ((Shop) building).Income(population);
            }

            return income;
        }


        public bool Destroy()
        {
            // BONUS
            throw new NotImplementedException();
        }
        

        public Biome GetBiome
        {
            get { return biome; }
        }
    }
}