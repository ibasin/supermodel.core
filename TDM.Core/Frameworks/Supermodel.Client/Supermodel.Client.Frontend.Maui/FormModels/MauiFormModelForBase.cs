using System.ComponentModel.DataAnnotations;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.DataAnnotations.Validations;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.FormModels;

public abstract class MauiFormModelForBase<TModel> : MauiFormModel, IRMapperCustom where TModel : class, IModel, ISupermodelNotifyPropertyChanged, new()
{
    #region ICustomMapper implementation
    public virtual Task MapFromCustomAsync<T>(T other)
    {
        return this.MapFromCustomBaseAsync(other);
    }
    public virtual Task<T> MapToCustomAsync<T>(T other)
    {
        return this.MapToCustomBaseAsync(other);
    }
    #endregion

    #region Methods
    //public virtual List<Cell> RenderChildCells<TChildModel>(Page page, List<TChildModel> childModels, Func<Page, TChildModel, Task> onTappedAsync = null)
    //    where TChildModel : ChildModel, new()
    //{
    //    var cells = new List<Cell>();
    //    foreach (var childModel in childModels)
    //    {
    //        DataTemplate dataTemplate;
    //        // ReSharper disable once AsyncVoidLambda
    //        if (onTappedAsync != null) dataTemplate = childModel.GetListCellDataTemplate(async (_, _) => { await onTappedAsync(page, childModel); }, null);
    //        else dataTemplate = childModel.GetListCellDataTemplate(null, null);

    //        var cell = dataTemplate.CreateContent() as Cell;
    //        // ReSharper disable once PossibleNullReferenceException
    //        cell.BindingContext = childModel;

    //        if (onTappedAsync != null)
    //        {
    //            cell.Tapped += async (_, _) =>
    //            {
    //                await onTappedAsync(page, childModel);
    //            };
    //        }

    //        cells.Add(cell);
    //    }
    //    return cells;
    //}
    //public virtual List<Cell> RenderDeletableChildCells<TChildModel, TDataContext>(Page page, List<TChildModel> childModels, ObservableCollection<TModel> parentModels, Func<Page, TChildModel, Task> onTappedAsync = null)
    //    where TChildModel : ChildModel, new()
    //    where TDataContext : class, IDataContext, new()
    //{
    //    var crudPage = (IBasicCRUDDetailPage)page;

    //    var cells = new List<Cell>();
    //    foreach (var childModel in childModels)
    //    {
    //        //var dataTemplate = childModel.GetListCellDataTemplate(null);

    //        // ReSharper disable once AsyncVoidLambda
    //        var dataTemplate = childModel.GetListCellDataTemplate(onTappedAsync == null ? null : async (_, _) => { await onTappedAsync(page, childModel); }, 
    //            // ReSharper disable once AsyncVoidLambda
    //            async (sender, _) =>
    //            {
    //                bool connectionLost;
    //                do
    //                {
    //                    connectionLost = false;
    //                    try
    //                    {
    //                        using (new ActivityIndicatorFor(crudPage.DetailView))
    //                        {
    //                            var deletingCell = (Cell)((MenuItem)sender).Parent;

    //                            await using (FormsApplication.GetRunningApp().NewUnitOfWork<TDataContext>())
    //                            {
    //                                //var oldToDoItems = Model.ToDoItems;
    //                                var index = Model.DeleteChild(childModel);
    //                                Model.Update();
    //                                try
    //                                {
    //                                    await UnitOfWorkContext.FinalSaveChangesAsync();
    //                                }
    //                                catch (Exception)
    //                                {
    //                                    Model.AddChild(childModel, index);
    //                                    throw;
    //                                }
    //                            }

    //                            //If no issues, remove the cell from the screen (from all sections)
    //                            foreach (var section in crudPage.DetailView.ContentView.Root) section.Remove(deletingCell);

    //                            //And mark all properties as changed. This way the list will always update
    //                            foreach (var property in Model.GetType().GetTypeInfo().DeclaredProperties) Model.OnPropertyChanged(property.Name);
    //                        }
    //                    }
    //                    catch (SupermodelWebApiException ex1)
    //                    {
    //                        if (ex1.StatusCode == HttpStatusCode.Unauthorized)
    //                        {
    //                            FormsApplication.GetRunningApp().HandleUnauthorized();
    //                        }
    //                        else if (ex1.StatusCode == HttpStatusCode.NotFound)
    //                        {
    //                            parentModels.RemoveAll(x => x == Model);
    //                            await crudPage.DisplayAlert("Not Found", "Item you are trying to update no longer exists.", "Ok");
    //                        }
    //                        else if (ex1.StatusCode == HttpStatusCode.Conflict)
    //                        {
    //                            await crudPage.DisplayAlert("Unable to Delete", ex1.ContentJsonMessage, "Ok");
    //                        }
    //                        else if (ex1.StatusCode == HttpStatusCode.InternalServerError)
    //                        {
    //                            await crudPage.DisplayAlert("Internal Server Error", ex1.ContentJsonMessage, "Ok");
    //                        }
    //                        else
    //                        {
    //                            connectionLost = true;
    //                            await crudPage.DisplayAlert("Connection Lost", "Connection to the cloud cannot be established.", "Try again");
    //                        }
    //                    }
    //                    catch (SupermodelDataContextValidationException ex2)
    //                    {
    //                        var vrl = ex2.ValidationErrors;
    //                        if (vrl.Count != 1) throw new SupermodelException("vrl.Count != 1. This should never happen!");
    //                        //Model = OriginalFormModel.MapTo(Model); //This is where we would normally restore model to the original, but not here
    //                        if (!vrl[0].Any()) throw new SupermodelException("!vrl[0].Any(): Server returned validation error with no validation results");
    //                        crudPage.GetFormModel().ShowValidationErrors(vrl[0]);
    //                    }
    //                    catch (Exception netEx) when (netEx is HttpRequestException || netEx is IOException || netEx is WebException)
    //                    {
    //                        connectionLost = true;
    //                        await crudPage.DisplayAlert("Connection Lost", "Connection to the cloud cannot be established.", "Try again");
    //                    }
    //                    catch (Exception ex3)
    //                    {
    //                        await crudPage.DisplayAlert("Unexpected Error", ex3.Message, "Try again");
    //                        connectionLost = true;
    //                    }
    //                }
    //                while (connectionLost);
    //            });

    //        var cell = dataTemplate.CreateContent() as Cell;
    //        // ReSharper disable once PossibleNullReferenceException
    //        cell.BindingContext = childModel;

    //        if (onTappedAsync != null)
    //        {
    //            cell.Tapped += async (_, _) =>
    //            {
    //                await onTappedAsync((Page)crudPage, childModel);
    //            };
    //        }

    //        cells.Add(cell);
    //    }
    //    return cells;
    //}
    #endregion

    #region Validation
    public override async Task<ValidationResultList> ValidateAsync(ValidationContext validationContext)
    {
        // ReSharper disable once ConstantNullCoalescingCondition
        var vr = await base.ValidateAsync(validationContext);
        var tempEntityForValidation = CreateTempValidationEntity();
        await AsyncValidator.TryValidateObjectAsync(tempEntityForValidation, new ValidationContext(tempEntityForValidation), vr); 
        return vr;
    }
    #endregion

    #region Private Helper Methods
    protected virtual Task<TModel> CreateTempValidationEntity()
    {
        return this.MapToAsync(new TModel());
    }
    #endregion

    #region Standard Properties
    [ScaffoldColumn(false), NotRMapped, NotRCompared] public TModel? Model { get; protected set; }
    #endregion
}