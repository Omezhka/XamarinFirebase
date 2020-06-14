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
using Firebase;
using Firebase.Database;

namespace XamarinFirebase.Helpers
{
   public static class AppDataHelper
   {
        public static FirebaseDatabase GetDatabase()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseDatabase database;

            if (app == null)
            {
                var option = new FirebaseOptions.Builder()
                    .SetApplicationId("drug-reference-b6127")
                    .SetApiKey("AIzaSyC0z4IEa1F4gfyNRS3y8baEq0EFbWp7OVU")
                    .SetDatabaseUrl("https://drug-reference-b6127.firebaseio.com")
                    .SetStorageBucket("drug-reference-b6127.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, option);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }

            return database;
        }  
   }
}