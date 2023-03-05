using System.Configuration;

namespace BookWriter.src
{
    internal class ConfigManager
    {
        public string SChatGPTKey { get; private set; }
        public string SScenesFilePath { get; private set; }
        public string SResponseFilePath { get; private set; }
        private Configuration SConfiguration { get; }
        public ConfigManager()
        {
            SConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            getKeys();
            checkKeys();
        }

        private void getKeys()
        {
            SChatGPTKey = ConfigurationManager.AppSettings.Get("ChatGPTKey");
            SScenesFilePath = ConfigurationManager.AppSettings.Get("ScenesFilePath");
            SResponseFilePath = ConfigurationManager.AppSettings.Get("ResponseFilePath");
        }

        private void checkKeys()
        {
            if (null == SChatGPTKey || "" == SChatGPTKey)
            {
                Console.WriteLine("print you ChatGPTKey");
                SChatGPTKey = Console.ReadLine();
                SConfiguration.AppSettings.Settings.Add("ChatGPTkey", SChatGPTKey);
            }

            if (null == SScenesFilePath || "" == SScenesFilePath)
            {
                Console.WriteLine("print you ScenesFilePath");
                SScenesFilePath = Console.ReadLine();
                SConfiguration.AppSettings.Settings.Add("ScenesFilePath", SScenesFilePath);
            }

            if (null == SResponseFilePath || "" == SResponseFilePath)
            {
                Console.WriteLine("print you ResponseFilePath");
                SResponseFilePath = Console.ReadLine();
                SConfiguration.AppSettings.Settings.Add("ResponseFilePath", SResponseFilePath);
            }

            SConfiguration.Save(ConfigurationSaveMode.Modified);
        }
    }
}
