using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinFirebase.Data_Models
{
    public class Drugs
    {
        public string Name { get; set; }
        public string ActiveSubstance { get; set; }
        public string Group { get; set; }
        public string Form { get; set; }
        public string ID { get; set; }
    }
}