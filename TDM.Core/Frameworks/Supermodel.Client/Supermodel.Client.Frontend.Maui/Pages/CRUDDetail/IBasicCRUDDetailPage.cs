using Supermodel.Client.Frontend.Maui.ViewModels;
using ILayout = Microsoft.Maui.Controls.ILayout;

namespace Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;

public interface IBasicCRUDDetailPage : ILayout, IPageController, IElementConfiguration<Page>
{
    void InitContent();

    CRUDDetailView? DetailView { get; set; }
    ViewModelForMaui? GetViewModel();
    T? GetXFModel<T>() where T : ViewModelForMaui;

    Task DisplayAlert(string title, string message, string cancel);
    Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
}