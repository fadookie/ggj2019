using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace Data.Model
{
    public class Player
    {
        public int Level { get; }
        
        public Stats BaseStats { get; }
        
        public ReactiveProperty<Item> Armor { get; }
        public ReactiveProperty<Item> PrimaryHand { get; }
        public ReactiveProperty<Item> SecondaryHand { get; }
        public ReactiveProperty<Item> Shield { get; }
        public ReactiveProperty<Item> Accessory1 { get; }
        public ReactiveProperty<Item> Accessory2 { get; }
        
        public ReactiveCollection<Item> Inventory { get; }

        private readonly ReactiveProperty<Stats> stats;
        public IReadOnlyReactiveProperty<Stats> Stats => stats.ToReadOnlyReactiveProperty();

        public Player() {
            BaseStats = new Stats();
            Armor = new ReactiveProperty<Item>();
            PrimaryHand = new ReactiveProperty<Item>();
            SecondaryHand = new ReactiveProperty<Item>();
            Shield = new ReactiveProperty<Item>();
            Accessory1 = new ReactiveProperty<Item>();
            Accessory2 = new ReactiveProperty<Item>();
            Inventory = new ReactiveCollection<Item>();
            stats = new ReactiveProperty<Stats>();
        }

        private Stats ReduceItemModifiers() {
            return new[] {Armor, PrimaryHand, SecondaryHand, Shield, Accessory1, Accessory2}
                .Where(x => x != null)
                .Select(x => x.Value.Stats)
                .Aggregate(new Stats(), (collector, next) => collector + next);
        }

        private void UpdateStats() {
            stats.Value = ReduceItemModifiers() + BaseStats;
        }

        public override string ToString() {
            return $"{nameof(Level)}: {Level}, {nameof(BaseStats)}: {BaseStats}, {nameof(Armor)}: {Armor}, {nameof(PrimaryHand)}: {PrimaryHand}, {nameof(SecondaryHand)}: {SecondaryHand}, {nameof(Shield)}: {Shield}, {nameof(Accessory1)}: {Accessory1}, {nameof(Accessory2)}: {Accessory2}, {nameof(Inventory)}: {Inventory}, {nameof(Stats)}: {Stats}";
        }
    }
}