using Supermodel.Client.Maui.Frontend.XForms.ViewModels;

namespace Supermodel.Client.Maui.Frontend.XForms.Pages.CRUDDetail;

public interface IBasicCRUDDetailPage : ILayout, IPageController, IElementConfiguration<Page>
{
    void InitContent();

    CRUDDetailView DetailView { get; set; }
    XFModel GetXFModel();
    T GetXFModel<T>() where T : XFModel;

    Task DisplayAlert(string title, string message, string cancel);
    Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
}