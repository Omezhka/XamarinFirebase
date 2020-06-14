using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using XamarinFirebase.Adapter;
using System.Collections.Generic;
using XamarinFirebase.Data_Models;
using XamarinFirebase.Fragments;

namespace XamarinFirebase
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageView addButton;
        ImageView searchButton;
        EditText searchText;
        RecyclerView myRecycleView;
        List<Drugs> DrugsList;
        AddDrugFragment addDrugFragment;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            myRecycleView = (RecyclerView)FindViewById(Resource.Id.myRecycleView);
            searchButton = (ImageView)FindViewById(Resource.Id.searchButton);
            addButton = (ImageView)FindViewById(Resource.Id.addButton);
            searchText = (EditText)FindViewById(Resource.Id.searchText);

            searchButton.Click += SearchButton_Click;

            addButton.Click += AddButton_Click;
            CreateData();

            SetupRecycleView();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            addDrugFragment = new AddDrugFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            addDrugFragment.Show(trans, "Новый препарат");
        }

        private void SetupRecycleView()
        {
            myRecycleView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecycleView.Context));
            AdapterDrugs adapter = new AdapterDrugs(DrugsList);
            myRecycleView.SetAdapter(adapter);
        }

        public void CreateData()
        {
            DrugsList = new List<Drugs>();
            DrugsList.Add(new Drugs { ActiveSubstance = "Department 111", Name = "Name 111", ID = "1", Form = "2011", Group = "Status 111" });
            DrugsList.Add(new Drugs { ActiveSubstance = "Department 222", Name = "Name 222", ID = "2", Form = "2012", Group = "Status 222" });
            DrugsList.Add(new Drugs { ActiveSubstance = "Department 333", Name = "Name 333", ID = "3", Form = "2013", Group = "Status 333" });
            DrugsList.Add(new Drugs { ActiveSubstance = "Department 444", Name = "Name 444", ID = "4", Form = "2014", Group = "Status 444" });
            DrugsList.Add(new Drugs { ActiveSubstance = "Department 555", Name = "Name 555", ID = "5", Form = "2015", Group = "Status 555" });
            DrugsList.Add(new Drugs { ActiveSubstance = "Department 666", Name = "Name 666", ID = "6", Form = "2016", Group = "Status 666" });
            DrugsList.Add(new Drugs { ActiveSubstance = "Department 666", Name = "Name 777", ID = "7", Form = "2017", Group = "Status 777" });
        }

        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            if(searchText.Visibility == Android.Views.ViewStates.Gone)
            {
                searchText.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                searchText.ClearFocus();
                searchText.Visibility = Android.Views.ViewStates.Gone;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}