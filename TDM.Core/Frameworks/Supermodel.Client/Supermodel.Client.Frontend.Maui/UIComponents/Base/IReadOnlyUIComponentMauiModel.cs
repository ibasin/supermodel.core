using Supermodel.Client.Frontend.Maui.ViewModels;

namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public interface  IReadOnlyUIComponentMauiModel : ISupermodelMobileDetailTemplate
{
    bool ShowDisplayNameIfApplies { get; set; }
    string DisplayNameIfApplies { get; set; }
    TextAlignment TextAlignmentIfApplies { get; set; }
}