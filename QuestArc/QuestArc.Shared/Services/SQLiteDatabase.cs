using QuestArc.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestArc.Services
{
    //TODO: Use generics to limit duplicate code
    public class SQLiteDatabase
    {
        public SQLiteAsyncConnection Database { get; }

        public SQLiteDatabase(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath, false);
            Database.CreateTableAsync<Character>().Wait();
            Database.CreateTableAsync<Arc>().Wait();
            Database.CreateTableAsync<Quest>().Wait();

            if (GetCharacterAsync(0).Result is null)
            {
                Character defaultCharacter = new Character();
                SaveCharacterAsync(defaultCharacter);
            }
        }

        #region Character

        public Task<List<Character>> GetCharactersAsync()
        {
            //Get all Characters.
            return Database.GetAllWithChildrenAsync<Character>(recursive: true);
        }

        public Task<Character> GetCharacterAsync(int id)
        {
            return Database.GetWithChildrenAsync<Character>(id, recursive: true);
        }

        public Task SaveCharacterAsync(Character character)
        {
            if (character.Id != 0)
            {
                // Update an existing Character.
                return Database.UpdateWithChildrenAsync(character);
            }
            else
            {
                // Save a new Character.
                return Database.InsertWithChildrenAsync(character, recursive: true);
            }
        }

        public Task DeleteCharacterAsync(Character character)
        {
            // Delete a Character.
            return Database.DeleteAsync(character, recursive: true);
        }

        #endregion

        #region Arc

        public Task<List<Arc>> GetArcsAsync()
        {
            //Get all Arcs.
            return Database.GetAllWithChildrenAsync<Arc>(recursive: true);
        }

        public Task<Arc> GetArcAsync(int id)
        {
            return Database.GetWithChildrenAsync<Arc>(id, recursive: true);
        }

        public Task SaveArcAsync(Arc arc)
        {
            if (arc.Id != 0)
            {
                // Update an existing Arc.
                return Database.UpdateWithChildrenAsync(arc);
            }
            else
            {
                // Save a new Arc.
                return Database.InsertWithChildrenAsync(arc, recursive: true);
            }
        }

        public Task DeleteArcAsync(Arc arc)
        {
            // Delete a Arc.
            return Database.DeleteAsync(arc, recursive: true);
        }

        #endregion

        #region Quest

        public Task<List<Quest>> GetQuestsAsync()
        {
            //Get all Quests.
            return Database.GetAllWithChildrenAsync<Quest>(recursive: true);
        }

        public Task<Quest> GetQuestAsync(int id)
        {
            return Database.GetWithChildrenAsync<Quest>(id, recursive: true);
        }

        public Task SaveQuestAsync(Quest quest)
        {
            if (quest.Id != 0)
            {
                // Update an existing Quest.
                return Database.UpdateWithChildrenAsync(quest);
            }
            else
            {
                // Save a new Quest.
                return Database.InsertWithChildrenAsync(quest, recursive: true);
            }
        }

        public Task DeleteQuestAsync(Quest quest)
        {
            // Delete a Quest.
            return Database.DeleteAsync(quest, recursive: true);
        }

        #endregion
    }
}
