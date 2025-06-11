using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Maui.Frontend.XForms.UIComponents.Base;

public abstract class SingleCellReadOnlyUIComponentXFModel : SingleCellReadOnlyUIComponentWithoutBackingXFModel, IRMapperCustom
{
    #region ICustomMapper implementation
    public abstract Task MapFromCustomAsync<T>(T other);
    public abstract Task<T> MapToCustomAsync<T>(T other);
    #endregion
}