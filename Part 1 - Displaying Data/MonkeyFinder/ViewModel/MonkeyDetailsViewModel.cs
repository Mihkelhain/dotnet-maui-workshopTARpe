namespace MonkeyFinder.ViewModel;
using MonkeyFinder.Model;
[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    IMap map;
    public MonkeyDetailsViewModel(IMap map)
    {
        this.map = map;

    }
    [ObservableProperty]
    Monkey monkey;

    [RelayCommand]
    async Task OpenMap()
    {
        try
        {
            await map.OpenAsync(monkey.Latitude, monkey.Longitude, new MapLaunchOptions
            {
                Name = monkey.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to launch maps: {ex.Message}");
            await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
        }
    }
}