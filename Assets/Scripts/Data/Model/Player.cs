using System;
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
        
        public IEnumerable<ReactiveProperty<Item>> AllItemSlots => new[]
            {Armor, PrimaryHand, SecondaryHand, Shield, Accessory1, Accessory2};
        
        public ReactiveCollection<Item> Inventory { get; }

        public IReadOnlyReactiveProperty<Stats> Stats { get; }

        public IReadOnlyReactiveProperty<int> Encumbrance { get; }
        
        public Player() {
            BaseStats = new Stats();
            Armor = new ReactiveProperty<Item>();
            PrimaryHand = new ReactiveProperty<Item>();
            SecondaryHand = new ReactiveProperty<Item>();
            Shield = new ReactiveProperty<Item>();
            Accessory1 = new ReactiveProperty<Item>();
            Accessory2 = new ReactiveProperty<Item>();
            Inventory = new ReactiveCollection<Item>();

            Encumbrance = Inventory.ObserveCountChanged()
                .Select(_ => Inventory.Aggregate(0, (collector, next) => collector + next.Weight))
                .ToReadOnlyReactiveProperty();

            Stats = AllItemSlots
                .Merge()
                .Select(_ => BaseStats + EquippedItemModifiers() + new Stats(0, 0, -Encumbrance.Value))
                .ToReadOnlyReactiveProperty();
        }

        private Stats EquippedItemModifiers() {
            return AllItemSlots
                .Where(x => x.HasValue && x.Value != null)
                .Select(x => x.Value.Stats)
                .Aggregate(new Stats(), (collector, next) => collector + next);
        }

        public override string ToString() {
            return $"{nameof(Level)}: {Level}, {nameof(BaseStats)}: {BaseStats}, {nameof(Armor)}: {Armor}, {nameof(PrimaryHand)}: {PrimaryHand}, {nameof(SecondaryHand)}: {SecondaryHand}, {nameof(Shield)}: {Shield}, {nameof(Accessory1)}: {Accessory1}, {nameof(Accessory2)}: {Accessory2}, {nameof(Inventory)}: {Inventory}, {nameof(Stats)}: {Stats}, {nameof(Encumbrance)}: {Encumbrance}, {nameof(AllItemSlots)}: {AllItemSlots}";
        }
    }
}