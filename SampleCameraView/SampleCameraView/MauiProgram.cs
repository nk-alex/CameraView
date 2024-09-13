using CommunityToolkit.Maui;
using SampleCameraView.ViewModels;
using SampleCameraView.Views;

namespace SampleCameraView;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(
                prism => prism.RegisterTypes(
                    containerRegistry =>
                    {
                        containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
                        containerRegistry.RegisterInstance(SemanticScreenReader.Default);
                    })
                .CreateWindow(async navigationService =>
                {
                    await navigationService.NavigateAsync("/MainPage");
                })
            )
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMauiCommunityToolkitCamera()
            .UseMauiCommunityToolkit();

        return builder.Build();
    }
}
