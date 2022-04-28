using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecyclerView7.Model;
using Android.Graphics;

namespace RecyclerView7.Adapter
{
    class KitchenDisplayItemViewHolder : RecyclerView.ViewHolder, View.IOnClickListener, View.IOnLongClickListener
    {
        public TextView OrderDetailId;
        public TextView ProductName;
        public TextView FireDate;
        public TextView Quantity;
        public TextView FulfillmentStatus;
        private ItemClickListener itemClickListener;

        public KitchenDisplayItemViewHolder(View itemView) : base(itemView)
        {
            OrderDetailId = itemView.FindViewById<TextView>(Resource.Id.tv_order_detail_id);
            ProductName = itemView.FindViewById<TextView>(Resource.Id.tv_product_name);
            FireDate = itemView.FindViewById<TextView>(Resource.Id.tv_fire_date);
            Quantity = itemView.FindViewById<TextView>(Resource.Id.tv_quantity);
            FulfillmentStatus = itemView.FindViewById<TextView>(Resource.Id.tv_fullfillment_status);

            itemView.SetOnClickListener(this);
            itemView.SetOnLongClickListener(this);
        }
        public void SetItemClickListener(ItemClickListener itemClickListener)
        {
            this.itemClickListener = itemClickListener;
        }
        public void OnClick(View v)
        {
            itemClickListener.OnClick(v, AdapterPosition, false);
        }

        public bool OnLongClick(View v)
        {
            itemClickListener.OnClick(v, AdapterPosition, true);
            return true;
        }
    }

    class KitchenDisplayItemAdapter : RecyclerView.Adapter, ItemClickListener
    {
        public List<KitchenDisplayItemModel> listData = new List<KitchenDisplayItemModel>();
        public Context context;

        public KitchenDisplayItemAdapter(List<KitchenDisplayItemModel> listData, Context context)
        {
            this.listData = listData;
            this.context = context;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.item_kitchen_display, parent, false);
            return new KitchenDisplayItemViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            KitchenDisplayItemViewHolder viewHolder = holder as KitchenDisplayItemViewHolder;
            viewHolder.OrderDetailId.Text = listData[position].OrderDetailId;
            viewHolder.ProductName.Text = listData[position].ProductName;
            viewHolder.FireDate.Text = listData[position].FireDate;
            viewHolder.Quantity.Text = listData[position].Quantity;
            viewHolder.FulfillmentStatus.Text = listData[position].FullfillmentStatus;
            
            viewHolder.SetItemClickListener(this);

            if(viewHolder.FireDate.Text != null)
            {
                viewHolder.FireDate.Visibility = ViewStates.Visible;
            }

        }

        public override int ItemCount
        {
            get
            {
                return listData.Count;
            }
        }

        public void OnClick(View itemView, int position, bool isLongClick)
        {
            if (isLongClick)
                Toast.MakeText(context, "Long Click : " + listData[position].ProductName, ToastLength.Short).Show();
            else
                Toast.MakeText(context, " " + listData[position].ProductName, ToastLength.Short).Show();
        }
    }
}