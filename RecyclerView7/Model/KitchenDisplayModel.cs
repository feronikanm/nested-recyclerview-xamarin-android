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
    public class KitchenDisplayModel
    {
        public string OrderReference { get; set; }
        public string TableName { get; set; }
        public string CategoryProduct { get; set; }
        public int PartialPropertyPercentage { get; set; }
    }
}