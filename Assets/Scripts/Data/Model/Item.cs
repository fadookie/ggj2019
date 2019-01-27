﻿using System;
using CsvHelper.Configuration.Attributes;

namespace Data.Model
{
    [Serializable]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Art { get; set; }
        public int sprite;
        public int type;
        [NullValues("")]
        public int? IntegrityPoints { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }
        public int HpMod { get; set; }
        public int MpMod { get; set; }
        public int SpeedMod { get; set; }
        public string DropText { get; set; }

    

        public Stats Stats => new Stats(HpMod, MpMod, SpeedMod);

        public override string ToString() {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Art)}: {Art}, {nameof(IntegrityPoints)}: {IntegrityPoints}, {nameof(Value)}: {Value}, {nameof(Weight)}: {Weight}, {nameof(DropText)}: {DropText}";
        }

    public Item getItem() {
      Item i = new Item();
      i.Id = Id;
      i.Name = Name;
      i.Art = Art;
      //Int32.TryParse(Art, out i.sprite);
      i.Value = Value;
      i.Weight = Weight;
      i.HpMod = HpMod;
      i.MpMod = MpMod;
      i.SpeedMod = SpeedMod;
      i.DropText = DropText;
      return i;

    }
    }
}