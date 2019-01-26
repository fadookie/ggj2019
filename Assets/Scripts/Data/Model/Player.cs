using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.Model
{
    public class Player
    {
        public int Level { get; set; }
        
        public Stats BaseStats { get; set; }
        
        public Item Armor { get; set; }
        public Item PrimaryHand { get; set; }
        public Item SecondaryHand { get; set; }
        public Item Shield { get; set; }
        public Item Accessory1 { get; set; }
        public Item Accessory2 { get; set; }
        
        public List<Item> Inventory { get; }

        public Stats Stats => ReduceItemModifiers() + BaseStats;
        
        public Player() {
            Inventory = new List<Item>();
            BaseStats = new Stats();
        }

        private Stats ReduceItemModifiers() {
            return new[] {Armor, PrimaryHand, SecondaryHand, Shield, Accessory1, Accessory2}
                .Where(x => x != null)
                .Select(x => x.Stats)
                .Aggregate(new Stats(), (collector, next) => collector + next);
        }

        public override string ToString() {
            return $"{nameof(Level)}: {Level}, {nameof(BaseStats)}: {BaseStats}, {nameof(Armor)}: {Armor}, {nameof(PrimaryHand)}: {PrimaryHand}, {nameof(SecondaryHand)}: {SecondaryHand}, {nameof(Shield)}: {Shield}, {nameof(Accessory1)}: {Accessory1}, {nameof(Accessory2)}: {Accessory2}, {nameof(Inventory)}: {Inventory}, {nameof(Stats)}: {Stats}";
        }
    }
}