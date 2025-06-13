using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public abstract class SingleCellReadOnlyUIComponentMauiModel : SingleCellReadOnlyUIComponentWithoutBackingMauiModel, IRMapperCustom
{
    #region ICustomMapper implementation
    public abstract Task MapFromCustomAsync<T>(T other);
    public abstract Task<T> MapToCustomAsync<T>(T other);
    #endregion
}