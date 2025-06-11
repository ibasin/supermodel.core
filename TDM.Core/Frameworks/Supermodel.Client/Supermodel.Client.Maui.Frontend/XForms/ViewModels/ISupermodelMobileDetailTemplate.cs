namespace Supermodel.Client.Maui.Frontend.XForms.ViewModels;

public interface ISupermodelMobileDetailTemplate
{
    List<Cell> RenderDetail(Page parentPage, int screenOrderFrom = int.MinValue, int screenOrderTo = int.MaxValue);
}