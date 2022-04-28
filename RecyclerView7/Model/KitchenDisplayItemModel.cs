using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecyclerView7.Model
{
    public class KitchenDisplayItemModel
    {
        public string OrderDetailId { get; set; }
        public string ProductName { get; set; }
        public string FireDate { get; set; }
        public string Quantity { get; set; }
        public string FullfillmentStatus { get; set; }
    }
}