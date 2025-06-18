using Supermodel.Client.Frontend.Maui.ViewModels;
using Supermodel.Client.Backend.DataContext.Sqlite;
using Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.Client.Frontend.Maui.UIComponents;

namespace MauiTestApp
{
    public class TestPage : CRUDDetailPage<TestMauiModel, TestMauiViewModel, TestSqliteDataContext>
    {

    }
    
    public class TestMauiViewModel : MauiViewModelFor<TestMauiModel>
    {
        public string FirstName { get; set; } = "";
        public TextBoxReadOnlyViewModel LastName { get; set; } = new();
        public TextBoxViewModel Position { get; set; } = new();
        public ToggleSwitchViewModel Active { get; set; } = new();
    }

    public class TestMauiModel : MauiModel
    {
        public string FirstName { get; set; } = "Ilya";
        public string LastName { get; set; } = "Basin";
        public string Position { get; set; } = "Computer Sceince Fellow";
        public bool Active { get; set; }
    }

    public class TestSqliteDataContext : SqliteDataContext
    {
        #region Overrides
        //Put your Database file location and name here.
        //Good options are:
        //- for MAUI apps return Path.Combine(FileSystem.Current.AppDataDirectory, "<filename>.db");
        //- for .Net clients return Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule!.FileName)!, "<filename>.db");
        public override string DatabaseFilePath => Path.Combine(FileSystem.Current.AppDataDirectory, "Test.db");

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
