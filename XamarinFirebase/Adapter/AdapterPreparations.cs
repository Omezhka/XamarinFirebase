using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using XamarinFirebase.Data_Models;

namespace XamarinFirebase.Adapter
{
    class AdapterPreparations : RecyclerView.Adapter
    {
        public event EventHandler<AdapterPreparationsClickEventArgs> ItemClick;
        public event EventHandler<AdapterPreparationsClickEventArgs> ItemLongClick;
        List<Preparations> Items;

        public AdapterPreparations(List<Preparations>Data)
        {
            Items = Data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListRow, parent, false); ;

            var vh = new AdapterPreparationsViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as AdapterPreparationsViewHolder;
            //holder.TextView.Text = items[position];
            holder.nameText.Text = Items[position].Name;
            holder.departmentText.Text = Items[position].Department;
            holder.statusText.Text = Items[position].Status;
            holder.setText.Text = Items[position].Set;
        }

        public override int ItemCount => Items.Count;

        void OnClick(AdapterPreparationsClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(AdapterPreparationsClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class AdapterPreparationsViewHolder : RecyclerView.ViewHolder
    {
        public TextView nameText { get; set; }
        public TextView statusText { get; set; }
        public TextView setText { get; set; }
        public TextView departmentText { get; set; }
        public ImageView deleteButton { get; set; }

        public AdapterPreparationsViewHolder(View itemView, Action<AdapterPreparationsClickEventArgs> clickListener,
                            Action<AdapterPreparationsClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            nameText = (TextView)itemView.FindViewById(Resource.Id.nameText);
            statusText = (TextView)itemView.FindViewById(Resource.Id.statusText);
            setText = (TextView)itemView.FindViewById(Resource.Id.setText);
            departmentText = (TextView)itemView.FindViewById(Resource.Id.departmentText);
            deleteButton = (ImageView)itemView.FindViewById(Resource.Id.deleteButton);



            itemView.Click += (sender, e) => clickListener(new AdapterPreparationsClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new AdapterPreparationsClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class AdapterPreparationsClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}