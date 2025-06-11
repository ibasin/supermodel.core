using Supermodel.Client.Maui.Frontend.XForms.ViewModels;

namespace Supermodel.Client.Maui.Frontend.XForms.UIComponents.Base;

public interface  IReadOnlyUIComponentXFModel : ISupermodelMobileDetailTemplate
{
    bool ShowDisplayNameIfApplies { get; set; }
    string DisplayNameIfApplies { get; set; }
    TextAlignment TextAlignmentIfApplies { get; set; }
}