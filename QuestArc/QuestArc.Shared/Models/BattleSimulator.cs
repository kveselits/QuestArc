using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestArc.Views;

namespace QuestArc.Models
{
    class BattleSimulator
    {

        /* 
         * 
         * 1) Get Main Character battle stats. (Item damage, added modifiers from stats/buffs/ailments)
         * 2) Build enemy
         * 3) Present fighting options USING DIALOG
             * a) Character on the TOP LEFT with relevant stats:
             *      - Player Level and Name
             *      - Current HP/Max HP
             *      - Weapon Damage
             * b) Monster on the TOP RIGHT with relevant stats:
             *      - Monster Name
             *      - Current HP/Max HP
             *      - Damage
             * c) On the BOTTOM CENTER should be fight options:
             *      - Fight
             *      - Inventory
             *      - Run
         * 4) Battle till one falls or flees
         * 
         * */


        public async Task RandomBattle()
        {
            // Get Character stats for view: Name, Level, HP, Damage
            Character SimCharacter = App.Database.GetCharacterAsync(1).Result;

            // Make Random Monster

            // Create Combat Dialog
            CombatDialog dialog = new CombatDialog(SimCharacter);
            await dialog.ShowAsync();

        }

        private class Monster
        {
            string name;
            int health;
            int damage;

            public Monster(int health, int damage)
            {
                this.name = "Gorm Defaulty";
                this.health = health;
                this.damage = damage;
            }

            public void TakeDamage(int damage)
            {
                this.health = this.health - damage;
                if (this.health <= 0)
                {
                    // Temporary
                    return;
                }
                return;
            }

            public void IsSlain()
            {
                
            }

            public void Attack()
            {
                // Deal monsters damage to the players HP pool
            }

        }

    }
}