using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using RecyclerView7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecyclerView7.Adapter
{
    class KitchenDisplayViewHolder : RecyclerView.ViewHolder
    {
        public TextView OrderReference;
        public TextView TableName;
        public TextView CategoryProduct;
        public TextView PartialPropertyPercentage;
        public RecyclerView ItemKitchenRecyclerView;

        public KitchenDisplayViewHolder(View itemView) : base(itemView)
        {
            OrderReference = itemView.FindViewById<TextView>(Resource.Id.tv_order_reference);
            TableName = itemView.FindViewById<TextView>(Resource.Id.tv_table_name);
            CategoryProduct = itemView.FindViewById<TextView>(Resource.Id.tv_category_product);
            PartialPropertyPercentage = itemView.FindViewById<TextView>(Resource.Id.tv_partial_property_percentage);
            ItemKitchenRecyclerView = itemView.FindViewById<RecyclerView>(Resource.Id.rv_item_kitchen);
        }
    }
    class KitchenDisplayAdapter : RecyclerView.Adapter
    {
        private List<KitchenDisplayModel> listDataKitchen = new List<KitchenDisplayModel>();

        public KitchenDisplayAdapter(List<KitchenDisplayModel> listDataKitchen)
        {
            this.listDataKitchen = listDataKitchen;
    }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.kitchen_display, parent, false);
            return new KitchenDisplayViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            KitchenDisplayViewHolder viewHolder = holder as KitchenDisplayViewHolder;
            List<KitchenDisplayItemModel> listData = new List<KitchenDisplayItemModel>();

            RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(viewHolder.ItemKitchenRecyclerView.Context, LinearLayoutManager.Vertical, false);
            viewHolder.ItemKitchenRecyclerView.SetLayoutManager(layoutManager);
            viewHolder.ItemKitchenRecyclerView.HasFixedSize = true;

            KitchenDisplayItemAdapter kitchenDisplayItemAdapter = new KitchenDisplayItemAdapter(listData, viewHolder.ItemKitchenRecyclerView.Context);
            viewHolder.ItemKitchenRecyclerView.SetAdapter(kitchenDisplayItemAdapter);

            viewHolder.OrderReference.Text = listDataKitchen[position].OrderReference;
            viewHolder.TableName.Text = listDataKitchen[position].TableName;
            viewHolder.CategoryProduct.Text = listDataKitchen[position].CategoryProduct;
            viewHolder.PartialPropertyPercentage.Text = listDataKitchen[position].PartialPropertyPercentage.ToString();

           

            if (listDataKitchen[position].OrderReference == "001")
            {
                listData.Add(new KitchenDisplayItemModel() { OrderDetailId = "1", ProductName = "Prawn Red", FullfillmentStatus = "Undo", FireDate = "10 min", Quantity = "Undo" });
                listData.Add(new KitchenDisplayItemModel() { OrderDetailId = "2", ProductName = "Prawn Red", FullfillmentStatus = "", FireDate = "11 min", Quantity = "1" });
                listData.Add(new KitchenDisplayItemModel() { OrderDetailId = "3", ProductName = "Prawn Red", FullfillmentStatus = "", FireDate = "12 min", Quantity = "1" });
            }

            if (listDataKitchen[position].OrderReference == "002")
            {
                listData.Add(new KitchenDisplayItemModel() { OrderDetailId = "5", ProductName = "Soda Water", FullfillmentStatus = "Done", FireDate = "15 min", Quantity = "1" });
                listData.Add(new KitchenDisplayItemModel() { OrderDetailId = "6", ProductName = "Soda Water", FullfillmentStatus = "", FireDate = "11 min", Quantity = "1" });
                listData.Add(new KitchenDisplayItemModel() { OrderDetailId = "7", ProductName = "Soda Water", FullfillmentStatus = "", FireDate = "12 min", Quantity = "1" });
                listData.Add(new KitchenDisplayItemModel() { OrderDetailId = "8", ProductName = "Soda Water", FullfillmentStatus = "Refire", FireDate = "13 min", Quantity = "1" });
            }

        }


        public override int ItemCount
        {
            get
            {
                return listDataKitchen.Count;
            }

        }

    }
}