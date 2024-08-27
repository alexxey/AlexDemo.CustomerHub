using AlexDemo.CustomerHub.Presentation.WebUI.Contracts;
using Hanssens.Net;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Services
{
    /// <summary>
    /// additional level of abstraction over added LocalStorage Nuget
    /// </summary>
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage _storage;

        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "AL.CustomerHub"
            };

            _storage = new LocalStorage(config);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _storage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _storage.Store(key, value);
        }
    }
}
