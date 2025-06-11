using Supermodel.Client.Maui.Frontend.XForms.Views;

namespace Supermodel.Client.Maui.Frontend.XForms.Pages.CRUDDetail;

public class CRUDDetailView : ViewWithActivityIndicator<TableView>
{
    public CRUDDetailView() : base(new TableView { Intent = TableIntent.Form, HasUnevenRows = true, Root = new TableRoot()}){}
}