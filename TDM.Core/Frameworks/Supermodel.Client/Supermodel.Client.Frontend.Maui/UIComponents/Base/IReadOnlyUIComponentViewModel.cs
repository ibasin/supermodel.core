using Supermodel.Client.Frontend.Maui.FormModels;

namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public interface  IReadOnlyUIComponentFormModel : ISupermodelMobileDetailTemplate
{
    bool ShowDisplayNameIfApplies { get; set; }
    string DisplayNameIfApplies { get; set; }
    TextAlignment TextAlignmentIfApplies { get; set; }
}