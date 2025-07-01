using Supermodel.Client.Backend.DataContext.WebApi;

namespace BatchApiClientWM.Supermodel.Persistence;

public class XXYXXWebApiDataContext: WebApiDataContext
{
    #region Overrides
    public override string BaseUrl => "http://10.211.55.9:54208/api/"; //this one is for WM

    // set timeout to 10 min, so we can debug if starting server and client simultaneously 
    //protected override HttpClient CreateHttpClient()
    //{
    //    var httpClient = base.CreateHttpClient();
    //    httpClient.Timeout = new TimeSpan(0, 10, 0);
    //    return httpClient;
    //}
    #endregion
}