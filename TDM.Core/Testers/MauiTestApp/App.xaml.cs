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
            TestModel model = new();
            ObservableCollection<TestModel> models = [model];

            var testPage = new TestPage();
            AsyncHelper.RunSync(() => testPage.InitAsync(models, model.IsNew ? "New List" : "Edit List", model));
            return new Window(testPage);
        }
    }
}