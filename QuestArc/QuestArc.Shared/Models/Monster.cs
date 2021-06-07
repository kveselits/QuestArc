using System;
using System.Collections.Generic;
using System.Text;

namespace QuestArc.Models
{
    public class Monster
    {
        string name;
        int health;
        int currentHealth;
        int damage;

        public Monster(string name, int health, int damage)
        {
            this.Name = name;
            this.Health = health;
            this.CurrentHealth = health;
            this.Damage = damage;
        }

        public int Damage { get => damage; set => damage = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public int Health { get => health; set => health = value; }
        public string Name { get => name; set => name = value; }
    }
}
