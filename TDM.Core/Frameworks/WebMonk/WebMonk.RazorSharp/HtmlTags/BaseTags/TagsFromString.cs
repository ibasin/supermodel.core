using WebMonk.RazorSharp.Html2RazorSharp;

namespace WebMonk.RazorSharp.HtmlTags.BaseTags;

//Use with caution: improper use may create XSS vulnerability
public class TagsFromString : Tags
{
    #region Constructors
    public TagsFromString(string htmlString)
    {
        Add(TranslatorBase.CreateMnemonic(htmlString, false, true).ToRazorSharp());
    }
    #endregion
}