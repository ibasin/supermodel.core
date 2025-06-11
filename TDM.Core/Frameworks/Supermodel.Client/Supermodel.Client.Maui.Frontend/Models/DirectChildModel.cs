namespace Supermodel.Client.Maui.Frontend.Models;

public abstract class DirectChildModel : ChildModel
{
    protected DirectChildModel()
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        ParentGuidIdentities = [];
    }
}