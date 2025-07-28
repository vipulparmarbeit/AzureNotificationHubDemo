using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;
using mobilepush.client.Services;
using Plugin.Firebase.CloudMessaging;
#if ANDROID
using Plugin.Firebase.Core.Platforms.Android;
#endif

namespace mobilepush.client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterFirebaseServices(); // Add this line



#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<INotificationService, NotificationService>();
            return builder.Build();
        }

        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
           

//            builder.ConfigureLifecycleEvents(events => {
//#if ANDROID
//                events.AddAndroid(android => android.OnCreate((activity, _) =>
//                CrossFirebase.Initialize(activity)));
//#endif
//            });

            // Register Firebase services
            builder.Services.AddSingleton(_ => CrossFirebaseCloudMessaging.Current);


            // Platform-specific initialization
//            builder.ConfigureMauiHandlers(handlers =>
//            {
//#if ANDROID
//                // Initialize Firebase for Android
//              //  handlers.AddHandler<Microsoft.Maui.Controls.ContentPage, FirebaseInitializationHandler>();
//#endif
//            });

            return builder;
        }

#if ANDROID
        // Custom handler for Android Firebase initialization
        public class FirebaseInitializationHandler : Microsoft.Maui.Handlers.PageHandler
        {
            protected override ContentViewGroup CreatePlatformView()
            {
                //var context = Context;
                //if (context != null && FirebaseApp.GetApps(context).Count == 0)
                //{
                //    FirebaseApp.InitializeApp(context);
                //}

                return base.CreatePlatformView();
            }
            protected override void ConnectHandler(ContentViewGroup platformView)
            {
                base.ConnectHandler(platformView);
              //  Firebase.FirebaseApp.InitializeApp(Platform.AppContext);
            }
        }
#endif
    }
}
