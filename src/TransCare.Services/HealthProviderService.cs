using Geocoding;
using Geocoding.Google;
using Geolocation;
using Microsoft.Extensions.Options;
using TransCare.Interfaces;
using TransCare.Models;
using TransCare.Services.Abstractions;

namespace TransCare.Services
{
    public class HealthProviderService : IHealthProviderService
    {
        private readonly ApiKeyOptions _options;
        private readonly IHealthProviderRepository _healthProviderRepository;

        public HealthProviderService(
            IHealthProviderRepository healthProviderRepository,
            IOptionsMonitor<ApiKeyOptions> optionsMonitor)
        {
            _options = optionsMonitor.CurrentValue;
            _healthProviderRepository = healthProviderRepository;
        }

        public async Task DeleteAsync(int id) =>
            await _healthProviderRepository.DeleteAsync(id);

        public async Task<HealthProvider> GetAsync(int id) =>
            await _healthProviderRepository.GetAsync(id);

        public async Task<IEnumerable<HealthProvider>> GetAllAsync() =>
            await _healthProviderRepository.GetAllAsync();

        public async Task<IEnumerable<HealthProvider>> GetFilteredAsync(string query, double latitude, double longitude)
        {
            var providers = await _healthProviderRepository.GetFilteredAsync(query);
            providers.ForEach(p => p.Distance = GeoCalculator.GetDistance(latitude, longitude, p.Latitude, p.Longitude));
            return providers.OrderBy(x => x.Distance);
        }

        public async Task<IEnumerable<HealthProvider>> GetNearestAsync(int take, double latitude, double longitude)
        {
            var providers = await _healthProviderRepository.GetAllAsync();
            providers.ForEach(p => p.Distance = GeoCalculator.GetDistance(latitude, longitude, p.Latitude, p.Longitude));
            return providers.OrderBy(x => x.Distance).Take(take);
        }

        public async Task<HealthProvider> SaveAsync(HealthProvider provider)
        {
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = _options.GoogleMaps };
            IEnumerable<Address> addresses = await geocoder.GeocodeAsync($"{provider.Street}, {provider.City}, {provider.State} {provider.ZipCode}");
            var normalizedAddress = addresses.FirstOrDefault();
            if (normalizedAddress != null)
            {
                provider.Latitude = normalizedAddress.Coordinates.Latitude;
                provider.Longitude = normalizedAddress.Coordinates.Longitude;
            }

            return await _healthProviderRepository.SaveAsync(provider);
        }
    }
}