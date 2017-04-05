using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAllianceApp.Helpers;
using XamarinAllianceApp.Views;

namespace XamarinAllianceApp
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }

    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new CharacterListPage());
        }

        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
            Client = new MobileServiceClient(Constants.MobileServiceClientUrl);
        }

        public static IMobileServiceClient Client { get; private set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

