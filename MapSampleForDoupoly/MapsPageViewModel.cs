using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapSampleForDoupoly
{
    public class MapsPageViewModel:INotifyPropertyChanged
    {
        #region Getter Setters 
        public event PropertyChangedEventHandler PropertyChanged;
        private Location _currentLocation = null;
        public MapsPage CurrentPage = null; 
      
        public ObservableCollection<History> _histories = new ObservableCollection<History>();
        public ObservableCollection<History> Histories
        {
            set
            {

                _histories = value;
                OnPropertyChanged("Histories");
            }
            get
            {
                return _histories;
            }
        }

        #endregion


        public MapsPageViewModel()
        {
            GetLocationPeriodically();
        }

        #region Helper functions

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        void GetLocationPeriodically()
        {
            Device.StartTimer(new TimeSpan(0, 0, 10), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(async() =>
                {
                    // interact with UI elements
                    await GetCurrentLocationAsync();
                });
                return true; // runs again, or false to stop
            });
        }


       async Task GetCurrentLocationAsync()
       {

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    if (location != null)
                    {
                        if (!location.IsFromMockProvider)
                        {
                            // location is original
                            Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                            if (_currentLocation == null)
                            {
                                _currentLocation = location;
                                //setting location first time
                                SetupCurrentLocation();
                            }
                            else
                            {
                                double distance = CheckDistanceBetweenTwoLocations(location, _currentLocation);
                                if (distance >= 20)
                                {
                                    CurrentPage?.DisplayAlert("Move Alert", $"You have moved {(int)distance} meters from your previous position", "Ok");
                                    //setting up location after as current one
                                    SetupCurrentLocation();
                                }
                            }
                        }

                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        double CheckDistanceBetweenTwoLocations(Location current, Location previous)
        {
            Distance distance = Distance.BetweenPositions(new Position(current.Latitude, current.Longitude), new Position(previous.Latitude, previous.Longitude));
            return distance.Meters;
        }

        async void SetupCurrentLocation()
        {

            var placemarks = await Geocoding.GetPlacemarksAsync(_currentLocation. Latitude, _currentLocation.Longitude);
            var placemark = placemarks?.FirstOrDefault();
            string address = String.Empty;
            if (placemark != null)
            {
                address = $"{placemark.Thoroughfare}, {placemark.SubThoroughfare}, {placemark.SubAdminArea}, {placemark.AdminArea}, {placemark.PostalCode} ,  {placemark.CountryName}";
            }
            var histories = new ObservableCollection<History>();
            histories.Add(new History() { Position = new Position(_currentLocation.Latitude, _currentLocation. Longitude), Address = address });
            Histories = histories;

        }
    }

    #endregion

    //Simple class to bind with Maps properties 
    public class History
    {
        public Position Position { get; set; }
        public string Address { get; set; }
    }

}
