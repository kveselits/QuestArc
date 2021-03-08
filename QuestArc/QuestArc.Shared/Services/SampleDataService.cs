using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestArc.Models;

namespace QuestArc.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // TODO WTS: Delete this file once your app is using real data.
    public static class SampleDataService
    {
        private static IEnumerable<Arc> AllOrders()
        {
            // Summary of characters
            var characters = AllCharacters();
            return characters.SelectMany(c => c.Arcs);
        }

        private static IEnumerable<Character> AllCharacters()
        {
            return new List<Character>()
            {
                new Character()
                {
                    Id = 0,
                    Name = "Kris and Cooper",
                    Health = 100,
                    Strength= 10,
                    Stamina = 10,
                    Intelligence = 10,
                    Level = 10,
                    Arcs = new List<Arc>()
                    {
                        new Arc()
                        {
                            ArcId = 10643,
                            CreatedTime = new DateTime(1997, 8, 25),
                            StartTime = new DateTime(1997, 9, 22),
                            EndTime = new DateTime(1997, 9, 22),
                            Title = "Graduate College",
                            Difficulty = Difficulty.Easy,
                            Status = Status.Todo,
                            SymbolCode = 57643, // Symbol Globe
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                },
                                new Quest()
                                {
                                    QuestId = 9,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                },
                                new Quest()
                                {
                                    QuestId = 30,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                }
                            }
                        },
                        new Arc()
                        {
                            ArcId = 10835,
                            CreatedTime = new DateTime(1998, 1, 15),
                            StartTime = new DateTime(1998, 2, 12),
                            EndTime = new DateTime(1998, 1, 21),
                            Title = "Graduate College",
                            Difficulty = Difficulty.Easy,
                            Status = Status.Todo,
                            SymbolCode = 57737, // Symbol Audio
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                },
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                }
                            }
                        },
                        new Arc()
                        {
                            ArcId = 10952,
                            CreatedTime = new DateTime(1998, 3, 16),
                            StartTime = new DateTime(1998, 4, 27),
                            EndTime = new DateTime(1998, 3, 24),
                            Title = "Graduate College",
                            Difficulty = Difficulty.Easy,
                            Status = Status.Todo,
                            SymbolCode = 57699, // Symbol Calendar
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                },
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                }
                            }
                        }
                    }
                },
                new Character()
                {
                    Id = 1,
                    Name = "Austin and James",
                    Health = 100,
                    Strength= 10,
                    Stamina = 10,
                    Intelligence = 10,
                    Level = 10,
                    Arcs = new List<Arc>()
                    {
                        new Arc()
                        {
                            ArcId = 10625,
                            CreatedTime = new DateTime(1997, 8, 8),
                            StartTime = new DateTime(1997, 9, 5),
                            EndTime = new DateTime(1997, 8, 14),
                            Title = "Graduate College",
                            Difficulty = Difficulty.Easy,
                            Status = Status.Todo,
                            SymbolCode = 57620, // Symbol Camera
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                },
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                },
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                }
                            }
                        },
                        new Arc()
                        {
                            ArcId = 10926,
                            CreatedTime = new DateTime(1998, 3, 4),
                            StartTime = new DateTime(1998, 4, 1),
                            EndTime = new DateTime(1998, 3, 11),
                            Title = "Graduate College",
                            Difficulty = Difficulty.Easy,
                            Status = Status.Todo,
                            SymbolCode = 57633, // Symbol Clock
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                },
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                },
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                },
                                new Quest()
                                {
                                    QuestId = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = Difficulty.Normal,
                                    Status = Status.Underway
                                }
                            }
                        }
                    }
                },
                
            };
        }

        // TODO WTS: Remove this once your TreeView page is displaying real data.
        public static async Task<IEnumerable<Character>> GetTreeViewDataAsync()
        {
            await Task.CompletedTask;
            return AllCharacters();
        }
    }
}
