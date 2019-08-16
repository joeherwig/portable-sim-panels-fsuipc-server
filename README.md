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
- goto `bin\Release\config.json` and assign your preffered settings. I'm using port 82 instead of Port 80 for my [portable-sim-panels](https://github.com/joeherwig/portable-sim-panels/) (default HTTP-Port for Websites) because some Addons bring their own webbased gauges and you cannot run two applications listening on the same port on the same network device.
The default settings are shown [here](https://gitlab.com/joeherwig/portable-sim-panels-fsuipc-server/blob/master/bin/Release/config.json).
- execute `bin/Release/portable-sim-panels-FSUIPC-server.exe` within your extracted folder to run the FSUIPC2WebSocket Server.

It will connect to your registered FSUIPC and start broadcasting the monitored variables on the `websocket.port` as [configured](https://gitlab.com/joeherwig/portable-sim-panels-fsuipc-server/blob/master/bin/Release/config.json) in your system (Default websocket port: 8080). [Check here](https://gitlab.com/joeherwig/portable-sim-panels-fsuipc-server/blob/master/FSUIPC.vb) which variables are currently available.

By setting the checkboxes to "_**send all data**_" you can skip the function which reduces the sent date to the changed ones only. In this case the subscribed clients will receive everything on each transmission, no matter whether some gauge value needs to be updated or not. For performance optimizations it is set to default "updates only (off)"

By activating "**_show values_**" you can monitor the which are currently being received from FSUIPC and being sent via the websocket.port.  For performance optimizations it is set to default "(off)".

# Implementation
A simple javascript example that can be run within your browsers console as well. Just open a new Tab and paste the below code to the console to check how to receive the data from FSUIPC within your browser.
```
// replace in the following line 'localhost' and `8080` with the settings you setup before if you don't use the defaults.
fsuipcSocket = new WebSocket('ws://localhost:8080/fsuipc');

fsuipcSocket.onopen = (event) => {
  console.log('connection to fsuipcSocket established ... awaiting data');
};

fsuipcSocket.onmessage = (event) => {
  console.log(JSON.parse(event.data));
  document.getElementsByTagName('body')[0].innerHTML = event.data.replace(/,/g,',<br>');
}

```
It just connects to the server and prints the JSON Data into the body and as JSON Object to the console.

# What can i do with it?
See the corresponding gauges at [portable-sim-panels](https://github.com/joeherwig/portable-sim-panels) to check what you can do with this FSUIPC to Websocket API.

<img src="https://joeherwig.github.io/EDST-Flightsim-Scenery_Hahnweide-Kirchheim-unter-Teck/images/JOE-Simtech-Logo.svg" width="100px">

This Application is available as FOSS (Free and open source Software) under The the following license:
<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/"><img alt="Creative Commons Lizenzvertrag" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-sa/4.0/88x31.png" /></a>
