using Supermodel.Client.Backend.Models;

namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public interface IHaveBinaryFile
{
    long Id { get; set; }
    string GetTitle();
    void SetTitle(string value);
    BinaryFile GetBinaryFile();
    void SetBinaryFile(BinaryFile value);
}