using CommunityToolkit.Maui;
using CraftUI.Presentation.Pages.Entry;
using CraftUI_Components;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace CraftUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .AddBlogComponents() 
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            ApplyStyleCustomization();

            Routing.RegisterRoute(RouteConstants.EntryPage, typeof(EntryPage));

            return builder.Build();
        }

        private static void ApplyStyleCustomization()
        {
            EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
            {
            #if __ANDROID__
                // Remove the underline from the EditText
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            #endif
            });

            EntryHandler.Mapper.AppendToMapping("SetUpEntry", (handler, view) =>
            {
            #if ANDROID

            #elif IOS || MACCATALYST
            // Remove outline from the UITextField
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
            #elif WINDOWS

            #endif
            });
        }
    }

    public static class RouteConstants
    {
        public const string EntryPage = "EntryPage";
    }
}
