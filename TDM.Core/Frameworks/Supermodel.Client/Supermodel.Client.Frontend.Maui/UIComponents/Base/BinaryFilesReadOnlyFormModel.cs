using System.Collections.ObjectModel;
using Supermodel.DataAnnotations.Exceptions;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public abstract class BinaryFilesReadOnlyFormModel : IReadOnlyUIComponentFormModel, IRMapperCustom
{
    #region Constructors
    protected BinaryFilesReadOnlyFormModel()
    {
        ModelsWithBinaryFileFormModels = new ObservableCollection<ModelWithBinaryFileFormModel>();
    }
    #endregion

    #region Custom Mapper implementation
    public virtual async Task MapFromCustomAsync<T>(T other)
    {
        if (!(other is IEnumerable<IHaveBinaryFile>)) throw new SupermodelException(GetType().Name + " can only map to Lists of type that implements IHaveBinaryFile");
        var modelsWithImage = (IEnumerable<IHaveBinaryFile>)other;

        ModelsWithBinaryFileFormModels.Clear();
        foreach (var modelWithImage in modelsWithImage) ModelsWithBinaryFileFormModels.Add(await new ModelWithBinaryFileFormModel().MapFromAsync(modelWithImage));
    }

    public virtual Task<T> MapToCustomAsync<T>(T other)
    {
        //its read-only, so we do nothing
        return Task.FromResult(other); 
    }
    #endregion

    #region Methods
    public abstract List<Cell> RenderDetail(Page parentPage, int screenOrderFrom = int.MinValue, int screenOrderTo = int.MaxValue);
    #endregion

    #region Properties
    public ObservableCollection<ModelWithBinaryFileFormModel> ModelsWithBinaryFileFormModels { get; private set; }

    public abstract bool ShowDisplayNameIfApplies { get; set; }
    public abstract string DisplayNameIfApplies { get; set; }
    public abstract TextAlignment TextAlignmentIfApplies { get; set; }
    #endregion
}