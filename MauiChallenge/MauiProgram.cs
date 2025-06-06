using CommunityToolkit.Maui;
using MauiChallenge.Services;
using MauiChallenge.Services.Interface;
using MauiChallenge.ViewModels.Pages;
using Microsoft.Extensions.Logging;

namespace MauiChallenge;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddScoped<IContactApi, ContactApi>();
        builder.Services.AddScoped(sp => new HttpClient { });
        builder.Services.AddTransient<ContactsPageViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
