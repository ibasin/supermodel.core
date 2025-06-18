using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

public abstract class SingleCellReadOnlyUIComponentViewModel : SingleCellReadOnlyUIComponentWithoutBackingViewModel, IRMapperCustom
{
    #region ICustomMapper implementation
    public abstract Task MapFromCustomAsync<T>(T other);
    public abstract Task<T> MapToCustomAsync<T>(T other);
    #endregion
}