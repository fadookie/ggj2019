using System;

namespace Data.Model
{
    [Serializable]
    public class Stats 
    {
        public int Hp { get; }
        public int Mp { get; }
        public float Speed { get; }

        public Stats() {
        }

        public Stats(int hp, int mp, float speed) {
            Hp = hp;
            Mp = mp;
            Speed = speed;
        }

        public Stats(Stats stats) {
            Hp = stats.Hp;
            Mp = stats.Mp;
            Speed = stats.Speed;
        }
        
        public static Stats operator+(Stats s1, Stats s2) { return s1.Add(s2); }

        public Stats Add(Stats s2) {
            return new Stats(Hp + s2.Hp, Mp + s2.Mp, Speed + s2.Speed);
        } 
        
        public override string ToString() {
            return $"{nameof(Hp)}: {Hp}, {nameof(Mp)}: {Mp}, {nameof(Speed)}: {Speed}";
        }
    }
}