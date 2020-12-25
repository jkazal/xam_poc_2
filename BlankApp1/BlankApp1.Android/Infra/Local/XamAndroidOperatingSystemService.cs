using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BlankApp1.Infra.Local.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlankApp1.Droid.Infra.Local
{
    class XamAndroidOperatingSystemService : IMobileOs
    {
        public string GetOSName()
        {
            return "Android";
        }
    }
}