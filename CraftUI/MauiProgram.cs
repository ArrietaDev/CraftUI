using Microsoft.Extensions.Logging;

namespace CraftUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .AddBlogComponents()
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            Routing.RegisterRoute(RouteConstants.EntryPage, typeof(EntryPage));

            return builder.Build();
        }

        private static void ApplyStyleCustomization()
        {
            // We will implement this method in the next section
        }
    }
}
