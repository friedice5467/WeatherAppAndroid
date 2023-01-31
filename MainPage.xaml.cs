namespace MobileApps;

public partial class MainPage : ContentPage
{
	private RestService _restService;
	private CurrentLocation _currentLocation;
	private WeatherData _weatherData;

	public MainPage()
	{
		InitializeComponent();
		_restService = new RestService();
		_currentLocation= new CurrentLocation();
		Task.Run(async () =>
			{
				await _currentLocation.CheckAndRequestLocationPermission();
				_currentLocation.IsCheckingLocation = true;
				await _currentLocation.GetCurrentLocation();
			}
		);
		GetWeatherData();
    }

	public async void OnGetWeatherButtonClicked(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(_cityEntry.Text))
		{
			await GetWeatherData();
        }

	}

	private async Task GetWeatherData()
	{
        _currentLocation.IsCheckingLocation = true;
        await _currentLocation.GetCurrentLocation();
        _weatherData = await _restService.GetWeatherData(GenerateRequestURL(Constants.OpenWeatherMapEndpoint));

        BindingContext = _weatherData;
    }

	string GenerateRequestURL(string endPoint)
	{
		string requestUri = endPoint;
        requestUri += $"?lat={_currentLocation.Latitude}&lon={_currentLocation.Longitude}&appid={Constants.OpenWeatherMapAPIKey}&units=imperial";
		return requestUri;
	}

    public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTime;
    }

}

