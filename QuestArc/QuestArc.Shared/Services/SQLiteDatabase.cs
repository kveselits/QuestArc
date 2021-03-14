using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestArc.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

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

        public Task<List<Character>> GetCharactersAsync()
        {
            //Get all Characters.
            return Database.Table<Character>().ToListAsync();
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
                return Database.InsertWithChildrenAsync(character, recursive:true);
            }
        }

        public Task<int> DeleteCharacterAsync(Character character)
        {
            // Delete a Character.
            return Database.DeleteAsync(character);
        }

        public Task<List<Arc>> GetArcsAsync()
        {
            //Get all Arcs.
            return Database.Table<Arc>().ToListAsync();
        }

        public Task<Arc> GetArcAsync(int id)
        {
            // Get a specific Arc.
            return Database.Table<Arc>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveArcAsync(Arc arc)
        {
            if (arc.Id != 0)
            {
                // Update an existing Arc.
                return Database.UpdateAsync(arc);
            }
            else
            {
                // Save a new Arc.
                return Database.InsertAsync(arc);
            }
        }

        public Task<int> DeleteArcAsync(Arc arc)
        {
            // Delete a Arc.
            return Database.DeleteAsync(arc);
        }public Task<List<Quest>> GetQuestsAsync()
        {
            //Get all Quests.
            return Database.Table<Quest>().ToListAsync();
        }

        public Task<Quest> GetQuestAsync(int id)
        {
            // Get a specific Quest.
            return Database.Table<Quest>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveQuestAsync(Quest quest)
        {
            if (quest.Id != 0)
            {
                // Update an existing Quest.
                return Database.UpdateAsync(quest);
            }
            else
            {
                // Save a new Quest.
                //Database.InsertAsync(quest);
                //var arc = GetCharacters
                //euro.Valuations = new List<Valuation> { valuation };
                return (Task<int>)Database.InsertWithChildrenAsync(quest);
            }
        }

        public Task<int> DeleteQuestAsync(Quest quest)
        {
            // Delete a Quest.
            return Database.DeleteAsync(quest);
        }
    }
}
