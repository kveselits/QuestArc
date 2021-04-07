using QuestArc.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace QuestArc.Services
{
    //TODO: Use generics to limit duplicate code
    public class SQLiteDatabase
    {
        public ObservableCollection<Character> Characters { get; }

        public Character CurrentCharacter { get; }

        public Arc DefaultArc { get; }

        public SQLiteAsyncConnection Database { get; }

        public SQLiteDatabase(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath, false);
            Database.CreateTableAsync<Character>().Wait();
            Database.CreateTableAsync<Arc>().Wait();
            Database.CreateTableAsync<Quest>().Wait();

            if (!GetCharactersAsync().Result.Any())
            {
                CurrentCharacter = new Character()
                {
                    Name = "Default Character",
                    Arcs = new List<Arc>()
                };
                Database.InsertWithChildrenAsync(CurrentCharacter);
            }
            else
            {
                CurrentCharacter = GetCharacterAsync(1).Result;
            }

            if (!GetArcsAsync().Result.Any())
            {
                DefaultArc = new Arc()
                {
                    Title = "Default Arc"
                };
                CurrentCharacter.Arcs.Add(DefaultArc);
                Database.UpdateWithChildrenAsync(CurrentCharacter);
            }
            else
            {
                DefaultArc = Database.GetAsync<Arc>(1).Result;
            }
            Characters = new ObservableCollection<Character> { CurrentCharacter };
        }

        #region Character

        public Task<List<Character>> GetCharactersAsync()
        {
            //Get all Characters.
            return Database.GetAllWithChildrenAsync<Character>(recursive: true);
        }

        public Task<Character> GetCharacterAsync(int id)
        {
            return Database.GetWithChildrenAsync<Character>(id);
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
                if (character.Arcs == null)
                {
                    character.Arcs = new List<Arc>();
                }
                return Database.InsertAsync(character);
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
                if (CurrentCharacter.Arcs == null)
                {
                    CurrentCharacter.Arcs = new List<Arc>();
                }
                Database.InsertAsync(arc);
                CurrentCharacter.Arcs.Add(arc);
                return Database.UpdateWithChildrenAsync(CurrentCharacter);
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

        public Task SaveQuestAsync(Quest quest, Arc arc)
        {
            if (quest.Id != 0)
            {
                // Update an existing Quest.

                Database.UpdateWithChildrenAsync(quest);
                Characters.RemoveAt(0);
                Characters.Insert(0, Database.GetAsync<Character>(1).Result);
                return Database.UpdateWithChildrenAsync(quest);
            }
            else
            {
                // Save a new Quest.
                if (arc.Quests == null)
                {
                    arc.Quests = new List<Quest>();
                }
                Database.InsertAsync(quest);
                arc.Quests.Add(quest);
                Database.UpdateWithChildrenAsync(arc);
                return Database.UpdateWithChildrenAsync(Database.GetWithChildrenAsync<Character>(1).Result);
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
