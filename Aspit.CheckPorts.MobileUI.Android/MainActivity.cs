using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Aspit.CheckPorts.Entities;
using Aspit.CheckPorts.DataAccess;
using System.Data;
using System.Data.SqlClient;
using Aspit.CheckPorts.WcfService;

namespace Aspit.CheckPorts.MobileUI.Android

{
    [Activity(Label = "Main", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<Port> mItems = new List<Port>();
        private ListView listView;
        private Service1 service = new Service1();
        private MockDataProvider mock = new MockDataProvider();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Data
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            listView = FindViewById<ListView>(Resource.Id.myListView);
            foreach (Port port in mock.GetPeople(5))
            {
                mItems.Add(new Port(port.PortSpecifier, port.PortNumber, port.Activity));
            }
            mItems.Add(new Port("g", 3, true));
            mItems.Add(new Port("g", 3, true));

            MyListViewAdapter adapter = new MyListViewAdapter(mItems, this);
            listView.Adapter = adapter;
        }
    }
}

