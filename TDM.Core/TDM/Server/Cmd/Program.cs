using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Supermodel.Persistence;
using Supermodel.Persistence.EFCore;
using Supermodel.Persistence.Repository;
using Supermodel.Persistence.UnitOfWork;

namespace Cmd;

public class Program
{
    public static async Task Main(string[] args)
    {
        if (Debugger.IsAttached || !await EFCoreUnitOfWorkContext.Database.CanConnectAsync())
        {
            Console.Write("Recreating the database... ");
            await using (new UnitOfWork<DataContext>())
            {
                await EFCoreUnitOfWorkContext.Database.EnsureDeletedAsync();
                await EFCoreUnitOfWorkContext.Database.EnsureCreatedAsync();
                await UnitOfWorkContext.SeedDataAsync();
            }
            Console.WriteLine("Done!");
        }

        await using(new UnitOfWork<DataContext>())
        {
            var repo = (EFCoreSimpleDataRepo<TDMUser>)RepoFactory.Create<TDMUser>();
            var user = repo.Items.Single(x => x.Username == "ilya.basin@noblis.org");

            user.ToDoLists.Add(new ToDoList
            {
                Name = "List #1",
                ToDoItems =
                [
                    new() { Name = "Item 1" },
                    new() { Name = "Item 2" }
                ]
            });

            user.ToDoLists.Add(new ToDoList
            {
                Name = "Groceries",
                ToDoItems =
                [
                    new() { Name = "Bread" },
                    new() { Name = "Eggs" },
                    new() { Name = "Milk" }
                ]
            });

            user.ToDoLists.Add(new ToDoList
            {
                Name = "Supplies",
                ToDoItems =
                [
                    new() { Name = "Pens" },
                    new() { Name = "Pencils" },
                    new() { Name = "Staplers" }
                ]
            });
        }
    }
}