using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.FormModels;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public class ModelWithBinaryFileFormModel : IRMapperCustom
{
    #region IRMapperCustom implementation
    public Task MapFromCustomAsync<T>(T other)
    {
        var modelWithBinaryFile = (IHaveBinaryFile)other!;
        Title = modelWithBinaryFile.GetTitle();
        BinaryFile = new BinaryFileFormModel { FileName = modelWithBinaryFile.GetBinaryFile().FileName, BinaryContent = modelWithBinaryFile.GetBinaryFile().BinaryContent };
        return this.MapFromCustomBaseAsync(other);
    }
    public Task<T> MapToCustomAsync<T>(T other)
    {
        var modelWithBinaryFile = (IHaveBinaryFile)other!;
        modelWithBinaryFile.SetTitle(Title);
        modelWithBinaryFile.SetBinaryFile(new BinaryFile { FileName = BinaryFile!.FileName, BinaryContent = BinaryFile.BinaryContent });
        return this.MapToCustomBaseAsync(other);
    }
    #endregion

    #region Properties
    public long Id { get; set; }
    [NotRMapped] public string Title { get; set; } = "";
    [NotRMapped] public BinaryFileFormModel? BinaryFile { get; set; }
    #endregion
}