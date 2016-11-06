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

namespace XRelativeLayout
{
    [Activity(Label = "VistaCapital")]
    public class VistaCapital : Activity
    {
        double defaultValue;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.VistaCapital);
            EditText txtCapitalC = FindViewById<EditText>
                (Resource.Id.txtcapitalC);
            EditText txtCapitalV = FindViewById<EditText>
                (Resource.Id.txtcapitalV);
            ImageView ImageCol = FindViewById<ImageView>
                (Resource.Id.imageCol);
            ImageView ImageVen = FindViewById<ImageView>
                (Resource.Id.imageVen);
            Button btnSalir = FindViewById<Button>
                (Resource.Id.btnsalir);

            btnSalir.Click += delegate
            {
                Salir();
            };

            try
            {
                txtCapitalC.Text = Intent.GetDoubleExtra("CapitalC", defaultValue).ToString();
                txtCapitalV.Text = Intent.GetDoubleExtra("CapitalV", defaultValue).ToString();
                ImageCol.SetImageResource(Resource.Drawable.Colombia);
                ImageVen.SetImageResource(Resource.Drawable.venezuela);
                
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
            

            }

        public void Salir()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}