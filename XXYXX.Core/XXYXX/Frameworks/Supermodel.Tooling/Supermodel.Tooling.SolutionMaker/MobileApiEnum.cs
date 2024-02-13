using System.ComponentModel;

namespace Supermodel.Tooling.SolutionMaker;

public enum MobileApiEnum 
{ 
    [Description("Xamarin.Forms")] XamarinForms, 
    [Description("Platform's Native API")] Native 
}