using System.Collections.ObjectModel;
using System.Net;
using Supermodel.Client.Backend.Exceptions;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Backend.Utils;
using Supermodel.Client.Maui.Frontend.Models;
using Supermodel.Client.Maui.Frontend.XForms.App;
using Supermodel.Client.Maui.Frontend.XForms.Views;

namespace Supermodel.Client.Maui.Frontend.XForms.Pages.CRUDList;

public abstract class CRUDListPageCore<TModel> : ContentPage, IHaveActivityIndicator where TModel : class, ISupermodelListTemplate, IModel, new()
{
    #region Initializers
    public virtual Task<CRUDListPageCore<TModel>> InitAsync(string title, int take = 25, bool readOnly = false)
    {
        InitContent(readOnly);

        Title = title;
        Take = take;
            
        ListView.ListPanel.ContentView.ItemSelected += ItemSelectedHandler;
        ListView.ListPanel.ContentView.ItemAppearing += ItemAppearingHandler;

        if (!readOnly) ToolbarItems.Add(new ToolbarItem("New", NewBtnIconFilename, NewBtnClickedHandler));

        return Task.FromResult(this);
    }
    #endregion

    #region Event Handlers
    public abstract void ItemAppearingHandler(object sender, ItemVisibilityEventArgs args);
    public virtual async void ItemSelectedHandler(object sender, SelectedItemChangedEventArgs args)
    {
        if (args.SelectedItem == null) return;
        var model = (TModel)args.SelectedItem;
        await SelectItem(model);
    }
    protected virtual async Task SelectItem(TModel model)
    {
        await OpenDetailInternalAsync(model);
        ListView.ListPanel.ContentView.SelectedItem = null; //deselect row
    }
    public virtual async void DeleteItemHandler(object sender, EventArgs args)
    {
        bool connectionLost;
        var model = (TModel)((MenuItem)sender).CommandParameter;

        do
        {
            connectionLost = false;
            try
            {
                using(new ActivityIndicatorFor(ListView.ListPanel))
                {
                    if (await DeleteItemInternalAsync(model)) Models.RemoveAllWhere(x => x.Id == model.Id);
                }
            }
            catch (SupermodelWebApiException ex1)
            {
                if (ex1.StatusCode == HttpStatusCode.Unauthorized)
                {
                    UnauthorizedHandler();
                }
                else if (ex1.StatusCode == HttpStatusCode.NotFound)
                {
                    Models.RemoveAllWhere(x => x.Id == model.Id);
                    await DisplayAlert("Not Found", "Item you are trying to delete no longer exists.", "Ok");
                }
                else if (ex1.StatusCode == HttpStatusCode.Conflict)
                {
                    await DisplayAlert("Unable to Delete", ex1.ContentJsonMessage, "Ok");
                }
                else if (ex1.StatusCode == HttpStatusCode.InternalServerError)
                {
                    connectionLost = true;
                    await DisplayAlert("Internal Server Error", ex1.ContentJsonMessage, "Ok");
                }
                else
                {
                    connectionLost = true;
                    await DisplayAlert("Connection Lost", "Connection to the cloud cannot be established.", "Try again");
                }
            }
            catch (Exception netEx) when (netEx is HttpRequestException || netEx is IOException || netEx is WebException)
            {
                connectionLost = true;
                await DisplayAlert("Connection Lost", "Connection to the cloud cannot be established.", "Try again");
            }
            catch (Exception ex2)
            {
                connectionLost = true;
                await DisplayAlert("Unexpected Error", ex2.Message, "Try again");
            }
        } 
        while (connectionLost);            
    }
    public virtual async void NewBtnClickedHandler()
    {
        var blankModel = new TModel();
        await OpenDetailInternalAsync(blankModel);
    }
    #endregion

    #region IHaveActivityIndicator implementation
    public async Task WaitForPageToBecomeActiveAsync()
    {
        while(!PageActive) await Task.Delay(25);
    }
    public bool ActivityIndicatorOn
    {
        get => ListView.ListPanel.ActivityIndicatorOn;
        set => ListView.ListPanel.ActivityIndicatorOn = value;
    }
    public string Message
    {
        get => ListView.ListPanel.Message;
        set => ListView.ListPanel.Message = value;
    }
    #endregion

    #region Overrides
    protected abstract void InitContent(bool readOnly);
    protected abstract Task OpenDetailInternalAsync(TModel model);
    protected abstract Task<bool> DeleteItemInternalAsync(TModel model);
    protected virtual void UnauthorizedHandler()
    {
        FormsApplication.GetRunningApp().HandleUnauthorized();
    }
    protected virtual string NewBtnIconFilename => null;

    protected override void OnAppearing()
    {
        base.OnAppearing();
        PageActive = true;
    }
    protected override void OnDisappearing()
    {
        PageActive = false;
        base.OnDisappearing();
    }
    #endregion

    #region Properties
    public StackLayout StackLayout { get; set; }
    public CRUDListView<TModel> ListView { get; set; }
    public ObservableCollection<TModel> Models { get; set; }
    public int? Take { get; set; }

    protected bool LoadingInProgress { get; set; }
    protected bool LoadedAll { get; set; }

    protected bool PageActive { get; set;}
    #endregion
}