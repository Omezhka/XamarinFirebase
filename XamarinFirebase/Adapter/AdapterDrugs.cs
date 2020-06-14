using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using XamarinFirebase.Data_Models;

namespace XamarinFirebase.Adapter
{
    class AdapterDrugs : RecyclerView.Adapter
    {
        public event EventHandler<AdapterDrugsClickEventArgs> ItemClick;
        public event EventHandler<AdapterDrugsClickEventArgs> ItemLongClick;
        public event EventHandler<AdapterDrugsClickEventArgs> DeleteItemClick;

        List<Drugs> Items;

        public AdapterDrugs(List<Drugs> Data)
        {
            Items = Data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListDrugs, parent, false); ;

            var vh = new AdapterDrugsViewHolder(itemView, OnClick, OnLongClick,OnDeleteClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as AdapterDrugsViewHolder;
            //holder.TextView.Text = items[position];
            holder.nameText.Text = Items[position].Name;
            holder.activeSubstanceText.Text = Items[position].ActiveSubstance;
            holder.groupText.Text = Items[position].Group;
            holder.formText.Text = Items[position].Form;
        }

        public override int ItemCount => Items.Count;

        void OnClick(AdapterDrugsClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(AdapterDrugsClickEventArgs args) => ItemLongClick?.Invoke(this, args);
        void OnDeleteClick(AdapterDrugsClickEventArgs args) => DeleteItemClick(this, args);

    }

    public class AdapterDrugsViewHolder : RecyclerView.ViewHolder
    {
        public TextView nameText { get; set; }
        public TextView activeSubstanceText { get; set; }
        public TextView groupText { get; set; }
        public TextView formText { get; set; }
        public ImageView deleteButton { get; set; }

        public AdapterDrugsViewHolder(View itemView, 
            Action<AdapterDrugsClickEventArgs> clickListener,
            Action<AdapterDrugsClickEventArgs> longClickListener, 
            Action<AdapterDrugsClickEventArgs> deleteClickListener) : base(itemView)
        {
            //TextView = v;
            nameText = (TextView)itemView.FindViewById(Resource.Id.nameText);
            activeSubstanceText = (TextView)itemView.FindViewById(Resource.Id.activeSubstanceText);
            groupText = (TextView)itemView.FindViewById(Resource.Id.groupText);
            formText = (TextView)itemView.FindViewById(Resource.Id.formText);
            deleteButton = (ImageView)itemView.FindViewById(Resource.Id.deleteButton);



            itemView.Click += (sender, e) => clickListener(new AdapterDrugsClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new AdapterDrugsClickEventArgs { View = itemView, Position = AdapterPosition });
           deleteButton.Click += (sender, e) =>  deleteClickListener(new AdapterDrugsClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class AdapterDrugsClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}