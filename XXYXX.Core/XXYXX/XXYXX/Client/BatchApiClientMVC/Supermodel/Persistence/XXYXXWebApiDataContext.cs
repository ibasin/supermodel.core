using Supermodel.Client.Backend.DataContext.WebApi;

namespace BatchApiClientMVC.Supermodel.Persistence;

public class XXYXXWebApiDataContext: WebApiDataContext
{
    #region Overrides
    public override string BaseUrl => "http://10.211.55.9:54208/"; //this one is for MVC

    // set timeout to 10 min, so we can debug if starting server and client simultaneously 
    //protected override HttpClient CreateHttpClient()
    //{
    //    var httpClient = base.CreateHttpClient();
    //    httpClient.Timeout = new TimeSpan(0, 10, 0);
    //    return httpClient;
    //}
    #endregion
}