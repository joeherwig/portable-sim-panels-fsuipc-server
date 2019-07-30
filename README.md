# portable-sim-panels-FSUIPC-server

FSUIPC Websocket-Server.
Connects to the Simulator via FSUIPC / XPUIPC and offers the ability to subscribe to the changed values via websocket procotol.

# Prerequesities
You just need
- FSUIPC compatible simulator (Tested with Prepar3D 3.x and 4.x (32 / 64 Bit)
- a registered and properly setup version of FSUIPC
- .Net Framework redistributables Version 4.7.2

# How to start
- [download the zip](https://gitlab.com/joeherwig/portable-sim-panels-fsuipc-server/-/archive/master/portable-sim-panels-fsuipc-server-master.zip) and unpack it where ever you desire it.
- goto `bin\Release\config.json` and assign your preffered settings. I'm using port 82 instead of Port 80 for my portable-sim-panels (default HTTP-Port for Websites) because some Addons bring their own webbased gauges and you cannot run two applications listening on the same port on the same network device.
The default settings are shown [here](https://gitlab.com/joeherwig/portable-sim-panels-fsuipc-server/blob/master/bin/Release/config.json).
- execute `bin/Release/portable-sim-panels-FSUIPC-server.exe` within your extracted folder to run the FSUIPC2WebSocket Server.

It will connect to your registered FSUIPC and start broadcasting the monitored variables on the `websocket.port` as [configured](https://gitlab.com/joeherwig/portable-sim-panels-fsuipc-server/blob/master/bin/Release/config.json) in your system (Default websocket port: 8080). [Check here](https://gitlab.com/joeherwig/portable-sim-panels-fsuipc-server/blob/master/FSUIPC.vb) which variables are currently available.

By setting the checkboxes to "_**send all data**_" you can skip the function which reduces the sent date to the changed ones only. In this case the subscribed clients will receive everything on each transmission, no matter whether some gauge value needs to be updated or not. For performance optimizations it is set to default "updates only (off)"

By activating "**_show values_**" you can monitor the which are currently being received from FSUIPC and being sent via the websocket.port.  For performance optimizations it is set to default "(off)".

# Implementation
A simple javascript example that can be run within your browsers console as well:
```
var fsuipcSocket = new WebSocket("wss://HostnameWhereYouRunTheServerOn/fsuipc");

fsuipcSocket.onopen = (event) => {
  console.log('connection to fsuipcSocket established ... awaiting data');
};

fsuipcSocket.onmessage = (event) => {
  console.log(event.data);
}
```