using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Aspit.CheckPorts.Entities;
using Aspit.CheckPorts.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace Aspit.CheckPorts.MobileUI.AndroidTest

{
    [Activity(Label = "Main", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<Port> mItems = new List<Port>();
        private ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Data
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            listView = FindViewById<ListView>(Resource.Id.myListView);
            mItems.Add(new Port("g", 3, true));
            mItems.Add(new Port("g", 3, true));

            MyListViewAdapter adapter = new MyListViewAdapter(mItems, this);
            listView.Adapter = adapter;
        }
    }
}

