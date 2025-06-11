namespace Supermodel.Client.Maui.Frontend.XForms.UIComponents.Base;

public interface IModelWithBinaryFile
{
    long Id { get; set; }
    string GetTitle();
    void SetTitle(string value);
    BinaryFile GetBinaryFile();
    void SetBinaryFile(BinaryFile value);
}