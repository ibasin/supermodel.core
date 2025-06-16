using Supermodel.Client.Frontend.Maui.Views;

namespace Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;

public class CRUDDetailView : ViewWithActivityIndicator<TableView>
{
    public CRUDDetailView() : base(new TableView { Intent = TableIntent.Form, HasUnevenRows = true, Root = new TableRoot()}){}
}