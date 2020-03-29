using System;

namespace currencyApi.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string UseInMemoryDatabase { get; set; }

        public string UpdateReverseRate { get; set; }


        public bool getUpdateReverseRateSetting(){
            return getBoolValueFromSetting(UpdateReverseRate);
        }

        public bool getUseInMemoryDatabaseSetting(){
            return getBoolValueFromSetting(UseInMemoryDatabase);
        }
        private bool getBoolValueFromSetting(string setting)
        {
            if (String.IsNullOrWhiteSpace(setting))
                return false;
            if (setting.ToLower() == "yes" || setting.ToLower() == "true")
                return true;

            return false;
        }
    }
}