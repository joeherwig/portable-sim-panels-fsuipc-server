using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace portableSimPanelsFsuipcServer
{
    class Config
    {
        public static string GetConfig()
        {
            try
            {
                string text = System.IO.File.ReadAllText("config.json");
                return text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on loading config.json" + ex);
                return "{\"webRootPath\": \"..\\\\portable-sim-panels\\\\public\", \"serverPort\": 8080, \"openWebsiteOnStart\": true}";
            }
        }
    }
}
