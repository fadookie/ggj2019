using System;
using CsvHelper.Configuration.Attributes;

namespace Data.Model
{
    [Serializable]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Art { get; set; }
        public int Type { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }
        public int HpMod { get; set; }
        public int MpMod { get; set; }
        public int SpeedMod { get; set; }
        public string DropText { get; set; }


        public Stats Stats => new Stats(HpMod, MpMod, SpeedMod);

        public override string ToString() {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Art)}: {Art}, {nameof(Type)}: {Type}, {nameof(Value)}: {Value}, {nameof(Weight)}: {Weight}, {nameof(HpMod)}: {HpMod}, {nameof(MpMod)}: {MpMod}, {nameof(SpeedMod)}: {SpeedMod}, {nameof(DropText)}: {DropText}, {nameof(Stats)}: {Stats}";
        }

        public Item getItem() {
            var i = new Item {
                Id = Id,
                Name = Name,
                Art = Art,
                Type = Type,
                Value = Value,
                Weight = Weight,
                HpMod = HpMod,
                MpMod = MpMod,
                SpeedMod = SpeedMod,
                DropText = DropText
            };
            return i;
        }
    }
}