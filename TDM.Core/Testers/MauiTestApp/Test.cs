using Supermodel.Client.Backend.DataContext.Sqlite;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;
using Supermodel.Client.Frontend.Maui.UIComponents;
using Supermodel.Client.Frontend.Maui.FormModels;
using Supermodel.DataAnnotations.Attributes;

namespace MauiTestApp
{
    public class TestPage : CRUDDetailPage<TestMauiModel, TestMauiFormModel, TestSqliteDataContext>
    {

    }
    
    public class TestMauiFormModel : MauiFormModelFor<TestMauiModel>, IHaveSectionNames
    {
        public string GetSectionName(int sectionScreenNumber)
        {
            if (sectionScreenNumber == 100) return "Section 1";
            if (sectionScreenNumber == 200) return "Section 2";

            return "None!";
        }

        public MultiLineTextBoxReadOnlyFormModel LongText { get; set; } = new();
        public string FirstName { get; set; } = "";
        public TextBoxReadOnlyFormModel LastName { get; set; } = new();
        public TextBoxFormModel Position { get; set; } = new();
        
        [ScreenOrder(200)] public ToggleSwitchFormModel Active { get; set; } = new();
    }

    public class TestMauiModel : MauiModel
    {
        public string LongText { get; set; } = "The only downside?\nSo many products are on sale right now that you might be scratching your head over what’s actually worth buying. Fret not; I’ve been tracking Apple deals and reviewing everything from iPhones to Apple Watches for more than a decade and have whittled things down to a list of true essentials.The only downside?\nSo many products are on sale right now that you might be scratching your head over what’s actually worth buying. Fret not; I’ve been tracking Apple deals and reviewing everything from iPhones to Apple Watches for more than a decade and have whittled things down to a list of true essentials.The only downside?\nSo many products are on sale right now that you might be scratching your head over what’s actually worth buying. Fret not; I’ve been tracking Apple deals and reviewing everything from iPhones to Apple Watches for more than a decade and have whittled things down to a list of true essentials.";
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
