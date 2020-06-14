using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using FR.Ganfra.Materialspinner;

namespace XamarinFirebase.Fragments
{
    public class AddDrugFragment : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout newFullnameText;
        TextInputLayout newActiveSubstanceText;
        TextInputLayout newFormText;
        MaterialSpinner newGroupSpinner;
        Button addDrugButton;

        List<string> groupList;
        ArrayAdapter<string> adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.NewDrug, container, false);

            newFullnameText = (TextInputLayout)view.FindViewById(Resource.Id.newFullnameText);
            newActiveSubstanceText = (TextInputLayout)view.FindViewById(Resource.Id.newActiveSubstanceText);
            newFormText = (TextInputLayout)view.FindViewById(Resource.Id.newFormText);
            newGroupSpinner = (MaterialSpinner)view.FindViewById(Resource.Id.newGroupSpinner);
            addDrugButton = (Button)view.FindViewById(Resource.Id.addButton);
            SetupFormSpinner();
            return view;
        }

        public void SetupFormSpinner()
        {
            groupList = new List<string>();
            groupList.Add("Группа такая-то");
            groupList.Add("Группа эдакая");
            groupList.Add("Группа какая-то");

            adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, groupList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            newGroupSpinner.Adapter = adapter;
        }
    }
}