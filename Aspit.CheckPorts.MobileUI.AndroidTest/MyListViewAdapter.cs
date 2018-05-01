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
using Aspit.CheckPorts.Entities;

namespace Aspit.CheckPorts.MobileUI.AndroidTest
{
    class MyListViewAdapter : BaseAdapter<Port>
    {
        public List<Port> ports;
        private Context context;

        public MyListViewAdapter(List<Port> ports, Context context)
        {
            this.ports = ports;
            this.context = context;
        }

        public override int Count => ports.Count;
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Port this[int position]
        {
            get { return ports[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.listview_row, null, false);
            }
            TextView txtPortSpecifier = row.FindViewById<TextView>(Resource.Id.txtPortSpecifier);
            txtPortSpecifier.Text = ports[position].PortSpecifier;

            TextView txtPortNumber = row.FindViewById<TextView>(Resource.Id.txtPortNumber);
            txtPortNumber.Text = ports[position].PortNumber.ToString();

            TextView txtPortActivity = row.FindViewById<TextView>(Resource.Id.txtPortActivity);
            txtPortActivity.Text = ports[position].Activity.ToString();

            return row;
        }
    }
}