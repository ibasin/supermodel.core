using System.Collections.ObjectModel;
using Supermodel.DataAnnotations.Async;

namespace MauiTestApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            TestMauiModel mauiModel = new();
            ObservableCollection<TestMauiModel> models = [mauiModel];

            var testPage = new TestPage();
            AsyncHelper.RunSync(() => testPage.InitAsync(models, mauiModel.IsNew ? "New List" : "Edit List", mauiModel));
            return new Window(testPage);
        }
    }
}