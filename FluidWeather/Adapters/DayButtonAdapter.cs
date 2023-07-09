﻿using FluidWeather.Models;
using FluidWeather.Utils;
using System;
using System.Globalization;
using Windows.UI.Xaml.Media.Imaging;

namespace FluidWeather.Adapters
{
    internal class DayButtonAdapter
    {
        public readonly V3WxForecastDaily CurrentObject;

        public readonly int ItemIndex;

        public string Temperature
        {
            get
            {
                return CurrentObject.temperatureMax[ItemIndex] + "°" + " / " + CurrentObject.temperatureMin[ItemIndex] + "°";
            }
        }

        public SvgImageSource svgImageIcon
        {
            get
            {
                return new SvgImageSource
                {
                    UriSource = new Uri("ms-appx:///Assets/weticons/" + CurrentObject.daypart[0].iconCode[ItemIndex*2] + ".svg")
                };
            }
        }

        public string PrecipitationChance
        {
            get
            {
                return CurrentObject.daypart[0].precipChance[ItemIndex*2] + "%";
            }
        }

        public SvgImageSource svgPrecipIcon
        {
            get
            {
                return new SvgImageSource
                {
                    UriSource = new Uri("ms-appx:///Assets/varicons/" + "blur" + ".svg")
                };
            }
        }

        public string ShortEventName
        {
            get
            {
                if (ItemIndex == 0)
                {
                    return "Oggi";
                }
                else
                {
                    //get windows current culture\language
                    var language = Windows.System.UserProfile.GlobalizationPreferences.Languages[0];


                    var abbname =  new CultureInfo(language).DateTimeFormat.GetAbbreviatedDayName(CurrentObject.validTimeLocal[ItemIndex]
                        .DayOfWeek);

                        //VariousUtils.UppercaseFirst(CurrentObject.dayOfWeek[ItemIndex]);


                        //return short day name + day complete date
                    return VariousUtils.UppercaseFirst(abbname) + " " + CurrentObject.validTimeLocal[ItemIndex].Day;


                }
            }
        }


        public DayButtonAdapter(V3WxForecastDaily fcst, int itemIndex)
        {
            CurrentObject = fcst;
            ItemIndex = itemIndex;
        }
    }
}