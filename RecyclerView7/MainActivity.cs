using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using RecyclerView7.Adapter;
using RecyclerView7.Model;
using System.Collections.Generic;

namespace RecyclerView7
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView recyclerView;
        private KitchenDisplayAdapter adapter;
        private RecyclerView.LayoutManager layoutManager;

        private List<KitchenDisplayModel> listKitchenData = new List<KitchenDisplayModel>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_kitchen);
            recyclerView.HasFixedSize = true;
            layoutManager = new GridLayoutManager(this, 3);
            recyclerView.SetLayoutManager(layoutManager);
            adapter = new KitchenDisplayAdapter(listKitchenData);
            recyclerView.SetAdapter(adapter);

            listKitchenData.Add(new KitchenDisplayModel() { OrderReference = "001", CategoryProduct = "Western, Juice", TableName = "C2", PartialPropertyPercentage = 33 });
            listKitchenData.Add(new KitchenDisplayModel() { OrderReference = "002", CategoryProduct = "Soft Drink, Asian", TableName = "C3", PartialPropertyPercentage = 34 });
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}