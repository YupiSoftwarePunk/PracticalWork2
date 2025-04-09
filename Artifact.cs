using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork2
{
    public abstract class Artifact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PowerLevel { get; set; }
        public enum Rarity
        {
            Common, Rare, Epic, Legendary
        }
        public abstract void Serialize();


        public Artifact(int id, string name, int powerLevel)
        {
            Id = id;
            Name = name;
            PowerLevel = powerLevel;
        }
    }
}
