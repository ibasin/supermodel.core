using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public abstract class BinaryFilesWritableFormModel : BinaryFilesReadOnlyFormModel, IWritableUIComponentFormModel
{
    #region Custom Mapper implementation
    public override async Task<T> MapToCustomAsync<T>(T other)
    {
        var modelsWithImage = (IEnumerable<IHaveBinaryFile>?)other;

        // modelsWithImages == null during validation
        if (modelsWithImage != null)
        {
            //remove all
            modelsWithImage.ExecuteMethod("Clear");

            //add all the images for which an exact match was not found
            foreach (var modelWithBinaryFileXFModel in ModelsWithBinaryFileFormModels)
            {
                var modelsWithImageUnderlyingType = other!.GetType().GenericTypeArguments[0];
                var modelWithImage = (IHaveBinaryFile)ReflectionHelper.CreateType(modelsWithImageUnderlyingType);
                modelsWithImage.ExecuteMethod("Add", modelWithImage);

                //update BinaryFile
                await modelWithBinaryFileXFModel.MapToAsync(modelWithImage);
            }
        }
        return other;
    }
    #endregion

    #region Properties
    public abstract string? ErrorMessage { get; set; }
    public abstract bool Required { get; set; }
    public object? WrappedValue => ModelsWithBinaryFileFormModels.FirstOrDefault();
    #endregion
}