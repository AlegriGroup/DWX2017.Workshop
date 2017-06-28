using Microsoft.Extensions.Configuration;

namespace DWX17.Workshop.WebApp.Services
{
    public class ConfigTextService : ITextService

    {
        private readonly IConfigurationSection _section;

        public ConfigTextService(IConfigurationSection section)
        {
            _section = section;
        }

        public string GetText()
        {
            return _section["Text"];
        }
    }
}