using Android.App;
using Android.Runtime;
using Firebase;

namespace mobilepush.client
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override void OnCreate()
        {
            // Initialize Firebase BEFORE base.OnCreate()
            try
            {
                if (FirebaseApp.GetApps(this).Count == 0)
                {
                    var app = FirebaseApp.InitializeApp(this);
                    System.Diagnostics.Debug.WriteLine($"Firebase initialized: {app?.Name ?? "null"}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Firebase init error: {ex}");
            }

            base.OnCreate();
        }
    }
}
