namespace Supermodel.Client.Backend.Models;

public abstract class DirectChildModel : ChildModel
{
    protected DirectChildModel()
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        ParentGuidIdentities = [];
    }
}