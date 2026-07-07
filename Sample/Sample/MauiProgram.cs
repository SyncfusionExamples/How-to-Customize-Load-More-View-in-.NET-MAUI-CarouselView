using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
namespace Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
#if DEBUG
		builder.Logging.AddDebug();
#endif

#if MACCATALYST
		UIKit.UITextField.Appearance.TintColor = UIKit.UIColor.Green;
#endif

        return builder.Build();
	}
}
