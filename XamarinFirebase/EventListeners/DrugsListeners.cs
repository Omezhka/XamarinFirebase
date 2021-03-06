﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using XamarinFirebase.Data_Models;
using XamarinFirebase.Helpers;

namespace XamarinFirebase.EventListeners
{
    public class DrugsListeners : Java.Lang.Object, IValueEventListener
    {

        List<Drugs> drugsList = new List<Drugs>();

        public event EventHandler<DrugsDataEventArgs> DrugsRetrived;

        public class DrugsDataEventArgs : EventArgs
        {
            public List<Drugs> Drugs { get; set; }
        }

        public void OnCancelled(DatabaseError error)
        {
            
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
           if(snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                drugsList.Clear();
                foreach (DataSnapshot drugsData in child)
                {
                    Drugs drug = new Drugs
                    {
                        ID = drugsData.Key,
                        Name = drugsData.Child("fullname").Value.ToString(),
                        ActiveSubstance = drugsData.Child("activeSubstance").Value.ToString(),
                        Form = drugsData.Child("form").Value.ToString(),
                        Group = drugsData.Child("group").Value.ToString()
                    };

                    drugsList.Add(drug);
                }
                DrugsRetrived.Invoke(this, new DrugsDataEventArgs { Drugs = drugsList });
            }
        }

        public void Create()
        {
            DatabaseReference drugsRef = AppDataHelper.GetDatabase().GetReference("drug");
            drugsRef.AddValueEventListener(this);
        }

        public void DeleteDrug(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("drug/" + key);
            reference.RemoveValue();
        }
    }
}