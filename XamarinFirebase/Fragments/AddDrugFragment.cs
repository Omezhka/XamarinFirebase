﻿using System;
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
using Firebase.Database;
using FR.Ganfra.Materialspinner;
using Java.Util;
using XamarinFirebase.Helpers;
using SupportV7 = Android.Support.V7.App;

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
        string group;

        SupportV7.AlertDialog.Builder saveDataAlert;

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
            addDrugButton = (Button)view.FindViewById(Resource.Id.addDrugButton);

            
            SetupFormSpinner();
           
            addDrugButton.Click += AddDrugButton_Click;

           

            return view;
        }

        private void AddDrugButton_Click(object sender, EventArgs e)
        {
            string fullname = newFullnameText.EditText.Text;
            string activeSubstance = newActiveSubstanceText.EditText.Text;
            string form = newFormText.EditText.Text;

            HashMap drugInfo = new HashMap();

            drugInfo.Put("fullname", fullname);
            drugInfo.Put("activeSubstance", activeSubstance);
            drugInfo.Put("form", form);
            drugInfo.Put("group", group);

            saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);

            saveDataAlert.SetTitle("СОХРАНИТЬ НОВЫЙ ПРЕПАРАТ");
            saveDataAlert.SetMessage("Вы уверены?");
            saveDataAlert.SetPositiveButton("Продолжить", (senderAlert, args) =>
            {
                DatabaseReference newDrugRef = AppDataHelper.GetDatabase().GetReference("drug").Push();
                newDrugRef.SetValue(drugInfo);
                this.Dismiss();
            });
            saveDataAlert.SetNegativeButton("Закрыть", (senderAlert, args) =>
             {
                 saveDataAlert.Dispose();
             });

            

            bool firstFieldValid = CheckValid(fullname, newFullnameText);
            bool secondFieldValid = CheckValid(activeSubstance, newActiveSubstanceText);
            bool thirdFieldValid = CheckValid(form, newFormText);


            if (firstFieldValid && secondFieldValid && thirdFieldValid)
            {
                saveDataAlert.Show();
            }

            //saveDataAlert.Show();
        }

        private bool CheckValid(string fieldText,TextInputLayout inputLayout)
        {

            inputLayout.ErrorEnabled = true;

            if (fieldText.Length == 0)
            {
                inputLayout.ErrorEnabled = true;
                inputLayout.Error = "Напишите что-нибудь";
            }
            else
            {
                inputLayout.ErrorEnabled = false;
                return true;
            }
            return false;
        }

        public void SetupFormSpinner()
        {
            groupList = new List<string>
            {
                "Цефалоспорины – АБ",
                "Азалиды – АБ",
                "Регидратирующее",
                "Линкозамиды – АБ",
                "Пр. фосфоновой кислоты – АБ",
                "Рифаксимин – АБ",
                "Хлорамфеникол – АБ",
                "Тетрациклины – АБ",
                "Хинолоны – противомикробное",
                "Противоподагрическое",
                "Противогрибковое",
                "Вазодилатирующее",
                "Метаболическое"
            };

            groupList.Sort();
            adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, groupList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            newGroupSpinner.SetSelection(1);
            

            newGroupSpinner.Adapter = adapter;

            newGroupSpinner.ItemSelected += NewGroupSpinner_ItemSelected;
        }

        private void NewGroupSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                group = groupList[e.Position];
            }
        }
    }
}