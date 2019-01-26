using System;
using FileHelpers;
using JetBrains.Annotations;

namespace Data.Model
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class Item
    {
        public int Id;
        public string Name;
        public string Art;
        public int? IntegrityPoints;
        public int Value;
        public int Weight;
        public int HpMod;
        public int MpMod;
        public int SpeedMod;
        [FieldQuoted] [CanBeNull] public string DropText;

        public override string ToString() {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Art)}: {Art}, {nameof(IntegrityPoints)}: {IntegrityPoints}, {nameof(Value)}: {Value}, {nameof(Weight)}: {Weight}";
        }
    }
}