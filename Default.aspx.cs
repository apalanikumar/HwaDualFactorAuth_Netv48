﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Web.Script.Serialization;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HwaDualFactorAuth_Netv48
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GetWeatherInfo(object sender, EventArgs e)
        {
            if (txtCity.Text.Trim().Length == 0 || txtCity.Text.IsNullOrEmpty())
            {
                lbl_alert.Visible = true;
                lbl_alert.Text = "Please enter the city name and then proceed...";
                return;
            }
            try
            {
                string appId = ConfigurationManager.AppSettings["WeatherInfoKey"];
                string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt=1&APPID={1}", txtCity.Text.Trim(), appId);
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);

                    WeatherInfo1 weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo1>(json);
                    lblCity_Country.Text = weatherInfo.city.name + "," + weatherInfo.city.country;
                    imgCountryFlag.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfo.city.country.ToLower());
                    lblDescription.Text = weatherInfo.list[0].weather[0].description;
                    imgWeatherIcon.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfo.list[0].weather[0].icon);
                    lblTempMin.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.min, 1));
                    lblTempMax.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.max, 1));
                    lblTempDay.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.day, 1));
                    lblTempNight.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.night, 1));
                    lblHumidity.Text = weatherInfo.list[0].humidity.ToString();
                    tblWeather.Visible = true;
                    lbl_alert.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lbl_alert.Visible = true;
                lbl_alert.Text = ex.Message.ToString();
            }            
        }
        public class WeatherInfo1
        {
            public City city { get; set; }
            public List<List> list { get; set; }
        }

        public class City
        {
            public string name { get; set; }
            public string country { get; set; }
        }

        public class Temp
        {
            public double day { get; set; }
            public double min { get; set; }
            public double max { get; set; }
            public double night { get; set; }
        }

        public class Weather
        {
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class List
        {
            public Temp temp { get; set; }
            public int humidity { get; set; }
            public List<Weather> weather { get; set; }
        }
    }
}