#nullable enable

using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Supermodel.Persistence
{
    public static class DataSeeder
    {
        public static Task SeedDataAsync()
        {
            var users = new[]
            {
                new TDMUser { FirstName="Ilya", LastName="Basin", Username="ilya.basin@noblis.org", Password="0" },
                new TDMUser { FirstName="Mariya", LastName="Basin", Username="mariya.basin@noblis.org", Password="0" },
                new TDMUser { FirstName="Andrew", LastName="Basin", Username="andrew.basin@noblis.org", Password="0" },
                new TDMUser { FirstName="Natalie", LastName="Basin", Username="natalie.basin@noblis.org", Password="0" },
            };
            foreach (var user in users) user.Add();

            var firstUser = users[0];

            firstUser.ToDoLists.Add(new ToDoList
            {
                Name = "List #1",
                ToDoItems = new List<ToDoItem>
                {
                    new() { Name = "Item 1"},
                    new() { Name = "Item 2"},
                }
            });

            firstUser.ToDoLists.Add(new ToDoList
            {
                Name = "Groceries",
                ToDoItems = new List<ToDoItem>
                {
                    new() { Name = "Bread"},
                    new() { Name = "Eggs"},
                    new() { Name = "Milk"},
                }
            });

            firstUser.ToDoLists.Add(new ToDoList
            {
                Name = "Supplies",
                ToDoItems = new List<ToDoItem>
                {
                    new() { Name = "Pens"},
                    new() { Name = "Pencils"},
                    new() { Name = "Staplers"},
                }
            });

            return Task.CompletedTask;
        }
    }
}
