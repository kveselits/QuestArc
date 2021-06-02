using Microsoft.Toolkit.Mvvm.ComponentModel;
using QuestArc.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using QuestArc.ViewModels;
using System;

namespace QuestArc.Services
{
    //TODO: Use generics to limit duplicate code
    public class SQLiteDatabase : ObservableObject
    {
        private Character currentCharacter;
        private ObservableCollection<Character> characters;

        public Quest defaultQuest { get; set; } = new Quest()
        {
            Title = "Default Quest",
            Description = "This is an example quest that can be safely deleted",
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddDays(1)
        };

        public SQLiteAsyncConnection Database { get; }

        public Character CurrentCharacter { get => currentCharacter; set => SetProperty(ref currentCharacter, value); }

        public ObservableCollection<Character> Characters { get => characters; set => SetProperty(ref characters, value); }

        public SQLiteDatabase(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath, false);
            Database.CreateTableAsync<Character>().Wait();
            Database.CreateTableAsync<Arc>().Wait();
            Database.CreateTableAsync<Quest>().Wait();
            Database.CreateTableAsync<Item>().Wait();

            if (!GetCharactersAsync().Result.Any())
            {
                CurrentCharacter = new Character()
                {
                    Name = "Default Character",
                    Arcs = new ObservableCollection<Arc>(),
                    Items = new ObservableCollection<Item>(),
                    TempQuests = new ObservableCollection<Quest>(),
                    TempArcs = new ObservableCollection<Arc>()
                };

                
            }
            else
            {
                CurrentCharacter = GetCharacterAsync(1).Result;
            }

            if (!GetArcsAsync().Result.Any())
            {
                

                Arc defaultArc = new Arc()
                {
                    Title = "Default Arc",
                    Quests = new ObservableCollection<Quest>()
                };

                defaultArc.Quests.Add(defaultQuest);
                CurrentCharacter.Arcs.Add(defaultArc);
                Database.InsertWithChildrenAsync(CurrentCharacter, recursive:true);
            }

            Characters = new ObservableCollection<Character>();
            Characters.Add(CurrentCharacter);
            CurrentCharacter.TempQuests.Add(defaultQuest);
        }

        #region Character

        public Task<List<Character>> GetCharactersAsync()
        {
            //Get all Characters.
            return Database.GetAllWithChildrenAsync<Character>(recursive: true);
        }

        internal Task SaveQuestsAsync(ObservableCollection<Quest> quests)
        {
            foreach(Quest quest in quests)
            {
                return Database.UpdateWithChildrenAsync(quest);
            }
            return Database.UpdateWithChildrenAsync(quests);

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
                if (character.Arcs == null)
                {
                    character.Arcs = new ObservableCollection<Arc>();
                }
                return Database.InsertWithChildrenAsync(character, recursive:true);
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
                    CurrentCharacter.Arcs = new ObservableCollection<Arc>();
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
                // Update an existing Quest
                
                return Database.UpdateWithChildrenAsync(quest);
            }
            else
            {
                // Save a new Quest.
                if (arc.Quests == null)
                {
                    arc.Quests = new ObservableCollection<Quest>();
                }
                Database.InsertAsync(quest);
                arc.Quests.Add(quest);
                SaveArcAsync(arc);
                return SaveCharacterAsync(CurrentCharacter);
            }
        }

        public Task DeleteQuestAsync(Quest quest)
        {
            // Delete a Quest.
            return Database.DeleteAsync(quest);
        }

        public ObservableCollection<Quest> GetQuestsOnDateAsync(DateTime date)
        {
            /* Get all Quests on a specific date.
            Equivalent to string sqlQuery = "SELECT Title FROM Quest WHERE EndTime LIKE '%" + date + "%'"*/

            var results = GetQuestsAsync().Result.Where(t => t.EndTime.Date >= date)
                            .OrderBy(t => t.EndTime);
            ObservableCollection<Quest> quests = new ObservableCollection<Quest>(results);
            return quests;
        }

        #endregion

        #region Item
        public Task<List<Item>> GetItemsAsync()
        {
            //Get all Items.
            return Database.GetAllWithChildrenAsync<Item>(recursive: true);
        }

        public Task<Item> GetItemAsync(int id)
        {
            return Database.GetWithChildrenAsync<Item>(id, recursive: true);
        }

        public Task UpdateItemAsync(Item item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }

        public Task SaveItemAsync(Item item, Character character)
        {
            if (item.Id != 0)
            {
                // Update an existing Item

                return Database.UpdateWithChildrenAsync(item);
            }
            else
            {
                // Save a new Item.
                if (character.Items == null)
                {
                    character.Items = new ObservableCollection<Item>();
                }
                Database.InsertAsync(item);
                character.Items.Add(item);
                return SaveCharacterAsync(CurrentCharacter);
            }
        }

        public Task DeleteItemAsync(Item item)
        {
            // Delete a Item.
            return Database.DeleteAsync(item);
        }
        #endregion
    }
}
