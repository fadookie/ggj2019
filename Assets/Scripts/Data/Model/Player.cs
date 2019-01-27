using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace Data.Model
{
    [Serializable]
    public class Player
    {
        public int Level { get; }
        
        public Stats BaseStats { get; }
        
        public ReactiveProperty<Item> Armor { get; }
        public ReactiveProperty<Item> Weapon { get; }
        public ReactiveProperty<Item> Shield { get; }
        public ReactiveProperty<Item> Accessory { get; }
        
        public IEnumerable<ReactiveProperty<Item>> AllItemSlots => new[]
            {Armor, Weapon, Shield, Accessory };
        
        public ReactiveCollection<Item> Inventory { get; }

        public IReadOnlyReactiveProperty<Stats> Stats { get; }

        public IReadOnlyReactiveProperty<int> Encumbrance { get; }

        public bool SlotHasItemEquipped(IReadOnlyReactiveProperty<Item> item) {
         return item.HasValue && item.Value != null;   
        }
        
        public Player() {
            BaseStats = new Stats();
            Armor = new ReactiveProperty<Item>();
            Weapon = new ReactiveProperty<Item>();
            Shield = new ReactiveProperty<Item>();
            Accessory = new ReactiveProperty<Item>();
            Inventory = new ReactiveCollection<Item>();

            Encumbrance = Observable.Merge(new[] {
                    AllItemSlots.Merge().Select(_ => new Unit()),
                    Inventory.ObserveCountChanged().Select(_ => new Unit()),
                })
                .StartWith(new Unit())
                .Select(_ => 
                    Inventory
                        .Concat(AllItemSlots.Where(SlotHasItemEquipped).Select(x => x.Value))
                        .Aggregate(0, (collector, next) => collector + next.Weight)
                )
                .ToReadOnlyReactiveProperty();

            Stats = AllItemSlots
                .Merge()
                .Select(_ => BaseStats + EquippedItemModifiers() + new Stats(0, 0, -Encumbrance.Value))
                .ToReadOnlyReactiveProperty();
        }

        private Stats EquippedItemModifiers() {
            return AllItemSlots
                .Where(SlotHasItemEquipped)
                .Select(x => x.Value.Stats)
                .Aggregate(new Stats(), (collector, next) => collector + next);
        }

        public override string ToString() {
            return $"{nameof(Level)}: {Level}, {nameof(BaseStats)}: {BaseStats}, {nameof(Armor)}: {Armor}, {nameof(Weapon)}: {Weapon}, {nameof(Shield)}: {Shield}, {nameof(Accessory)}: {Accessory}, {nameof(AllItemSlots)}: {AllItemSlots}, {nameof(Inventory)}: {Inventory}, {nameof(Stats)}: {Stats}, {nameof(Encumbrance)}: {Encumbrance}";
        }
    }
}