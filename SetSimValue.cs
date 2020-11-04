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
                    switch (command.Key.ToUpper())
                    {
                        case "AVIONICS_MASTER":
                            MainWindow.AVIONICS_MASTER.Value = (uint)(command.Value);
                            break;
                        case "GEAR_HANDLE_POSITION":
                            var gearHandleValue = (uint)command.Value == 0 ? 0 : (uint)16383;
                            MainWindow.GEAR_HANDLE_POSITION.Value = gearHandleValue;
                            break;
                    }

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
