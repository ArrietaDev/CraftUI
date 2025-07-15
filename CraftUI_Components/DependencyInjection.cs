using SkiaSharp.Views.Maui.Controls.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftUI_Components
{
    public static class DependencyInjection
    {
        public static MauiAppBuilder AddBlogComponents(this MauiAppBuilder builder)
        {
            builder.UseSkiaSharp();
            return builder;
        }
    }
}
