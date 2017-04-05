
using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System;


namespace XamarinAllianceApp.Droid
{
    [Activity(Label = "Xamarin Alliance",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, IAuthenticate
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Initialize Xamarin Forms
            global::Xamarin.Forms.Forms.Init(this, bundle);

            // Initialize the authenticator before loading the app.
            App.Init((IAuthenticate)this);


            // Load the main application
            LoadApplication(new App());
        }

        //Define an authenticated user.
        private MobileServiceUser user;

        public async Task<bool> Authenticate()
        {
            var success = false;
            var message = string.Empty;
           
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                user = await App.Client.LoginAsync(this,
                    MobileServiceAuthenticationProvider.Facebook);
                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.",
                        user.UserId);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Sign-in result");
            builder.Create().Show();

            return success;
        }
    }
}
