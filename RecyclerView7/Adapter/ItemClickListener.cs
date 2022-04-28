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

namespace RecyclerView7.Adapter
{
    public interface ItemClickListener
    {
        void OnClick(View itemView, int position, bool isLongClick);
    }
}