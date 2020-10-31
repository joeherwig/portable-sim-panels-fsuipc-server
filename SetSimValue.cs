using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace portableSimPanelsFsuipcServer
{
    class SetSimValue
    {
        public static void Update(string json)
        {
            try
            {
                var jObj = JObject.Parse(json);
                foreach (var command in jObj.Cast<KeyValuePair<string, JToken>>().ToList())
                {
                    Console.WriteLine(command.Key + ": " + command.Value);
                    MainWindow.avionicsMaster.Value = Convert.ToUInt32(command.Value);
                    FSUIPC.FSUIPCConnection.Process();
                    Console.WriteLine(command.Key + ": " + command.Value);
                }
                //Console.WriteLine(command.key + ": " + command.value);
            }
            catch
            {

            }
        }
    }
}
