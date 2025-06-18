using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.App;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.Client.Frontend.Maui.ViewModels;
using Supermodel.Encryptor;

namespace Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;

public abstract class CRUDDetailPageCore<TMauiModel, TMauiViewModel> : ContentPage, IBasicCRUDDetailPage
    where TMauiModel : class, ISupermodelNotifyPropertyChanged, IModel, new()
    where TMauiViewModel : MauiViewModel, new()
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
    protected virtual string ComputeModelHash(TMauiModel model)
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
        var sectionResolver = ViewModel as IHaveSectionNames;
        var sectionNum = 0;

        var totalCellCount = ViewModel!.RenderDetail(this).Count;
        while (totalCellCount > 0)
        {
            var cells = ViewModel.RenderDetail(this, sectionNum, sectionNum + 99);
            if (cells.Any())
            {
                var sectionName = sectionResolver?.GetSectionName(sectionNum);
                var section = string.IsNullOrEmpty(sectionName) ? new TableSection() : new TableSection(sectionName);
                DetailView!.ContentView.Root.Add(section);
                foreach (var cell in cells)
                {
                    section.Add(cell);
                    totalCellCount--;
                }
            }
            sectionNum += 100;
        }
    }
    public virtual void OnLoad(){}
    #endregion

    #region Properties
    public Grid? Grid { get; set; }
    public CRUDDetailView? DetailView { get; set; }
    public ObservableCollection<TMauiModel>? Models { get; set; } 
    public TMauiModel? Model { get; set; }
    public TMauiViewModel? ViewModel { get; set; }
    public MauiViewModel? GetViewModel() { return ViewModel; }

    public T? GetViewModel<T>() where T : MauiViewModel { return (T?)(MauiViewModel?)ViewModel; } //This is property in spirit

    public TMauiViewModel? OriginalViewModel { get; set; }

    protected virtual bool CancelButton => false;
    protected virtual string? CancelBtnIconFilename => null;
    protected bool DisappearingBecauseOfCancellation { get; set; } //default is false
    #endregion
}