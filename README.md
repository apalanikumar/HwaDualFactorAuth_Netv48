This application is using the demonstrate the Two Factor Authentication by ASP.NET v4.8 framework
Technology stack: <br/>
  Visual Studio 2022 Professional<br/>
  ASP.NET and C#<br/>
  Twilio for SMS (https://console.twilio.com/)<br/>
  Weather API (https://home.openweathermap.org/api_keys)<br/>

Need to update the below setting in the Web.config file from Twilio account<br/>
  <!-- Twilio Credentials--><br/>
  <add key="SMSSID" value="**********" /><br/>
  <add key="SMSAuthToken" value="*********" /><br/>
  <add key="SMSPhoneNumber" value="+**********" /><br/>
  <!-- Weather API Credentials - https://home.openweathermap.org/--><br/>
  <add key="WeatherInfoKey" value="**********" />	<br/>
