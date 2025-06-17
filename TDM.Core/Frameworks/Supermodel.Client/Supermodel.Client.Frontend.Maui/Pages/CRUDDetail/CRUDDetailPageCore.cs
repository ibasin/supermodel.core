using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.App;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.Client.Frontend.Maui.ViewModels;
using Supermodel.Encryptor;

namespace Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;

public abstract class CRUDDetailPageCore<TModel, TMauiModel> : ContentPage, IBasicCRUDDetailPage
    where TModel : class, ISupermodelNotifyPropertyChanged, IModel, new()
    where TMauiModel : MauiModel, new()
{
    #region Overrides
    protected virtual void AddCancelButton()
    {
        // ReSharper disable once AsyncVoidLambda
        var cancelToolbarItem = new ToolbarItem("Cancel", CancelBtnIconFilename, async () => {
            DisappearingBecauseOfCancellation = true;
            await Navigation.PopAsync(true);
        });
        ToolbarItems.Add(cancelToolbarItem);
    }
    protected virtual void UnauthorizedHandler()
    {
        ApplicationContext.GetRunningApp().HandleUnauthorized();
    }
    // ReSharper disable once UnusedParameter.Global
    protected virtual string ComputeModelHash(TModel model)
    {
        //We hash Json to ignore changes that do not get persisted
        //return JsonConvert.SerializeObject(Model).GetMD5Hash();
        return JsonConvert.SerializeObject(model).GetMD5Hash();
    }
    #endregion

    #region Methods
    //override this method to affect the entire view
    public virtual void InitContent()
    {
        //If we use the commented out code below list of children does not get updated when a child is updated
            
        //if (DetailView == null)
        //{
        //    DetailView = new CRUDDetailView();
        //    Content = StackLayout = new StackLayout { Children = { DetailView } };

        //    OnLoad();
        //    InitDetailView();
        //}
        DetailView = new CRUDDetailView();
        Content = Grid = [DetailView];

        OnLoad();
        InitDetailView();
    }
    //Override this method to create sections
    public virtual void InitDetailView()
    {
        // ReSharper disable once SuspiciousTypeConversion.Global
        var sectionResolver = MauiModel as IHaveSectionNames;

        var lastCell = MauiModel!.RenderDetail(this).LastOrDefault();
        if (lastCell != null)
        {
            var sectionNum = 0;
            while (true)
            {
                var cells = MauiModel.RenderDetail(this, sectionNum, sectionNum + 99);
                if (cells.Any())
                {
                    var sectionName = sectionResolver?.GetSectionName(sectionNum);
                    var section = string.IsNullOrEmpty(sectionName) ? new TableSection() : new TableSection(sectionName);
                    DetailView!.ContentView.Root.Add(section);
                    foreach (var cell in cells) section.Add(cell);
                }
                if (cells.Contains(lastCell)) break;
                sectionNum += 100;
            }
        }
    }
    public virtual void OnLoad(){}
    #endregion

    #region Properties
    public Grid? Grid { get; set; }
    public CRUDDetailView? DetailView { get; set; }
    public ObservableCollection<TModel>? Models { get; set; } 
    public TModel? Model { get; set; }
    public TMauiModel? MauiModel { get; set; }
    public MauiModel? GetMauiModel() { return MauiModel; }

    public T? GetXFModel<T>() where T : MauiModel { return (T?)(MauiModel?)MauiModel; } //This is property in spirit

    public TMauiModel? OriginalMauiModel { get; set; }

    protected virtual bool CancelButton => false;
    protected virtual string? CancelBtnIconFilename => null;
    protected bool DisappearingBecauseOfCancellation { get; set; } //default is false
    #endregion
}