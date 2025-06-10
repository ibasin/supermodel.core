namespace Supermodel.Mobile.Runtime.Backend.Models;

public abstract class DirectChildModel : ChildModel
{
    protected DirectChildModel()
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        ParentGuidIdentities = [];
    }
}