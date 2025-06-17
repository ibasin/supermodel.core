using Supermodel.Client.Frontend.Maui.ViewModels;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Backend.DataContext.Sqlite;
using Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;

namespace MauiTestApp
{
    public class TestPage : CRUDDetailPage<TestModel, TestViewModelForMaui, TestSqliteDataContext>
    {

    }
    
    public class TestViewModelForMaui : ViewModelForMauiFor<TestModel>
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }

    public class TestModel : Model
    {
        public string FirstName { get; set; } = "Ilya";
        public string LastName { get; set; } = "Basin";
    }

    public class TestSqliteDataContext : SqliteDataContext
    {
        #region Overrides
        //Optionally: Put your DbFileName here. For exmample if you need use multiple dbs 
        // ReSharper disable once RedundantOverriddenMember
        //public override string DbFileName => base.DbFileName;
        public override string DatabaseFilePath => Path.Combine(FileSystem.Current.AppDataDirectory, "<filename>.db");

        //Optionally: Put your schema version here 
        // ReSharper disable once RedundantOverriddenMember
        public override int ContextSchemaVersion => base.ContextSchemaVersion;

        //Optionally: Put your schema migration code here
        // ReSharper disable once RedundantOverriddenMember
        public override Task MigrateDbAsync(int? fromVersion, int toVersion)
        {
            return base.MigrateDbAsync(fromVersion, toVersion);
        }
        #endregion
    }
}
