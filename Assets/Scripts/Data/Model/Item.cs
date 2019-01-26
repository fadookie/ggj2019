using System;
using CsvHelper.Configuration.Attributes;

namespace Data.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Art { get; set; }
        [NullValues("")]
        public int? IntegrityPoints { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }
        public int HpMod { get; set; }
        public int MpMod { get; set; }
        public int SpeedMod { get; set; }
        public string DropText { get; set; }

        public override string ToString() {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Art)}: {Art}, {nameof(IntegrityPoints)}: {IntegrityPoints}, {nameof(Value)}: {Value}, {nameof(Weight)}: {Weight}, {nameof(DropText)}: {DropText}";
        }
    }
}