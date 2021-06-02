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
            // Make Random Monster

            // Create Combat Dialog
            CombatDialog dialog = new CombatDialog();
            await dialog.ShowAsync();

        }

        

    /*        public void IsSlain()
            {
                
            }

            public void Attack()
            {
                // Deal monsters damage to the players HP pool
            }

        }*/

    }
}