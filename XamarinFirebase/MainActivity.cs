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

namespace XamarinFirebase
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageView addButton;
        ImageView searchButton;
        EditText searchText;
        RecyclerView myRecycleView;
        List<Preparations> PreparationsList;
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
            CreateData();

            SetupRecycleView();
        }

        private void SetupRecycleView()
        {
            myRecycleView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecycleView.Context));
            AdapterPreparations adapter = new AdapterPreparations(PreparationsList);
            myRecycleView.SetAdapter(adapter);
        }

        public void CreateData()
        {
            PreparationsList = new List<Preparations>();
            PreparationsList.Add(new Preparations { Department = "Department 111", Name = "Name 111", ID = "1", Set = "2011", Status = "Status 111" });
            PreparationsList.Add(new Preparations { Department = "Department 222", Name = "Name 222", ID = "2", Set = "2012", Status = "Status 111" });
            PreparationsList.Add(new Preparations { Department = "Department 333", Name = "Name 333", ID = "3", Set = "2013", Status = "Status 111" });
            PreparationsList.Add(new Preparations { Department = "Department 444", Name = "Name 444", ID = "4", Set = "2014", Status = "Status 111" });
            PreparationsList.Add(new Preparations { Department = "Department 555", Name = "Name 555", ID = "5", Set = "2015", Status = "Status 111" });
            PreparationsList.Add(new Preparations { Department = "Department 666", Name = "Name 666", ID = "6", Set = "2016", Status = "Status 111" });
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