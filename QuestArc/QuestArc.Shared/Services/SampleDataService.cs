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
                            Id = 10643,
                            CreatedOn = new DateTime(1997, 8, 25),
                            StartTime = new DateTime(1997, 9, 22),
                            EndTime = new DateTime(1997, 9, 22),
                            Title = "Graduate College",
                            Difficulty = "Easy",
                            Status = "Todo",
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                },
                                new Quest()
                                {
                                    Id = 9,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                },
                                new Quest()
                                {
                                    Id = 30,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                }
                            }
                        },
                        new Arc()
                        {
                            Id = 10835,
                            CreatedOn = new DateTime(1998, 1, 15),
                            StartTime = new DateTime(1998, 2, 12),
                            EndTime = new DateTime(1998, 1, 21),
                            Title = "Graduate College",
                            Difficulty = "Easy",
                            Status = "Todo",
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                },
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                }
                            }
                        },
                        new Arc()
                        {
                            Id = 10952,
                            CreatedOn = new DateTime(1998, 3, 16),
                            StartTime = new DateTime(1998, 4, 27),
                            EndTime = new DateTime(1998, 3, 24),
                            Title = "Graduate College",
                            Difficulty = "Easy",
                            Status = "Todo",
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                },
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
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
                            Id = 10625,
                            CreatedOn = new DateTime(1997, 8, 8),
                            StartTime = new DateTime(1997, 9, 5),
                            EndTime = new DateTime(1997, 8, 14),
                            Title = "Graduate College",
                            Difficulty = "Easy",
                            Status = "Todo",
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                },
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                },
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                }
                            }
                        },
                        new Arc()
                        {
                            Id = 10926,
                            CreatedOn = new DateTime(1998, 3, 4),
                            StartTime = new DateTime(1998, 4, 1),
                            EndTime = new DateTime(1998, 3, 11),
                            Title = "Graduate College",
                            Difficulty = "Easy",
                            Status = "Todo",
                            Quests = new List<Quest>()
                            {
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                },
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                },
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
                                },
                                new Quest()
                                {
                                    Id = 28,
                                    Title = "Generic Quest Name",
                                    CreatedOn = DateTime.Now,
                                    StartTime = DateTime.MinValue,
                                    EndTime = DateTime.MaxValue,
                                    Description = "Generic Quest Description",
                                    Difficulty = "Normal",
                                    Status = "Underway"
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
