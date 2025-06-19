namespace Supermodel.Client.Frontend.Maui.FormModels;

public interface ISupermodelMobileDetailTemplate
{
    List<Cell> RenderDetail(Page parentPage, int screenOrderFrom = int.MinValue, int screenOrderTo = int.MaxValue);
}