namespace Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

public abstract class SingleCellWritableUIComponentForTextViewModel : SingleCellWritableUIComponentViewModel, IHaveTextProperty
{
    #region ICustomMapper implemtation
    public override Task MapFromCustomAsync<T>(T other)
    {
        return SingleCellUIComponentForTextMauiModelCommonLibrary.MapFromCustomAsync(this, other);
    }

    public override Task<T> MapToCustomAsync<T>(T other)
    {
        return SingleCellUIComponentForTextMauiModelCommonLibrary.MapToCustomAsync(this, other);
    }
    #endregion

    #region Properties
    public abstract string Text { get; set; }
    public override object WrappedValue => Text;
    #endregion
}