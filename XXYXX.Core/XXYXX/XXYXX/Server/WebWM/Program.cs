using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Domain.Supermodel.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Supermodel.Persistence.EFCore;
using Supermodel.Persistence.UnitOfWork;
using WebWM.Mvc.Layouts;
using WebWM.Services;
using WebWM.Supermodel.Auth;

namespace WebWM;

public class Program
{
    static async Task Main(params string[] args)
    {
        #region Run as a windows service if used with "/s" argument
        if (args is ["/s"])
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddWindowsService(options => { options.ServiceName = "XXYXX Web App"; });
            builder.Services.AddHostedService<XXYXXWindowsService>();

            var host = builder.Build();
            await host.RunAsync();
            return;
        }
        #endregion

        #region Re-seeding database code.
        bool AskUserWhetherToReseedDb()
        {
            Console.Write("Do you want to re-seed the database (if not sure, answer no or press enter) [yes/no]? ");
            return Console.ReadLine()!.Trim().ToLower() == "yes";
        }
        await using (new UnitOfWork<DataContext>())
        {
            if (!await EFCoreUnitOfWorkContext.Database.CanConnectAsync() || AskUserWhetherToReseedDb())
            {
                Console.Write("Recreating the database... ");
                await EFCoreUnitOfWorkContext.Database.EnsureDeletedAsync();
                await EFCoreUnitOfWorkContext.Database.EnsureCreatedAsync();
                await UnitOfWorkContext.SeedDataAsync();
                Console.WriteLine("Done!");
                Console.WriteLine();
            }
        }
        #endregion

        #region Create Web Server and register global filters 
        var webServer = new XXYXXWebServer(HttpPort, $"http://localhost:{HttpPort}")
        {
            LoginUrl = "/Auth/Login",
            DefaultLayout = new MasterMvcLayout()
        };
        //webServer.GlobalFilters.Add(new ApiSecureAuthenticateAttribute());
        webServer.GlobalFilters.Add(new ApiBasicAuthenticateAttribute());
        #endregion

        #region Start Web Server. If in Debug open the browser, otherwise just sit and listen for web requests
        if (Debugger.IsAttached)
        {
            await webServer.RunAsync("/");
            //await webServer.RunAsync();
        }
        else
        {
            await webServer.RunAsync();
        }
        #endregion
    }

    #region Constatnts
    public const int HttpPort = 54208;
    #endregion
}