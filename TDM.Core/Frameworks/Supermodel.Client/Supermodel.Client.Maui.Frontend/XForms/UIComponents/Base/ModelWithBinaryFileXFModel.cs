using Supermodel.Client.Backend.Models;
using Supermodel.Client.Maui.Frontend.XForms.ViewModels;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Maui.Frontend.XForms.UIComponents.Base;

public class ModelWithBinaryFileXFModel : IRMapperCustom
{
    #region IRMapperCustom implementation
    public Task MapFromCustomAsync<T>(T other)
    {
        var modelWithBinaryFile = (IModelWithBinaryFile)other;
        Title = modelWithBinaryFile.GetTitle();
        BinaryFile = new BinaryFileXFModel { FileName = modelWithBinaryFile.GetBinaryFile().FileName, BinaryContent = modelWithBinaryFile.GetBinaryFile().BinaryContent };
        return this.MapFromCustomBaseAsync(other);
    }
    public Task<T> MapToCustomAsync<T>(T other)
    {
        var modelWithBinaryFile = (IModelWithBinaryFile)other;
        modelWithBinaryFile.SetTitle(Title);
        modelWithBinaryFile.SetBinaryFile(new BinaryFile { FileName = BinaryFile.FileName, BinaryContent = BinaryFile.BinaryContent });
        return this.MapToCustomBaseAsync(other);
    }
    #endregion

    #region Properties
    public long Id { get; set; }
    [NotRMapped] public string Title { get; set; }
    [NotRMapped] public BinaryFileXFModel BinaryFile { get; set; }
    #endregion
}