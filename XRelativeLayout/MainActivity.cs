using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace XRelativeLayout
{
    [Activity(Label = "XRelativeLayout", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double IngresosC, IngresosV, EgresosC, EgresosV, CapitalC, CapitalV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Button btnConvertir = FindViewById<Button>
                (Resource.Id.btnconvertir);
            EditText txtIngresosC = FindViewById<EditText>
                (Resource.Id.txtingresosC);
            EditText txtEgresosC = FindViewById<EditText>
                (Resource.Id.txtegresosC);
            EditText txtIngresoV = FindViewById<EditText>
                (Resource.Id.txtingresoV);
            EditText txtEgresoV = FindViewById<EditText>
                (Resource.Id.txtegresoV);
            
            btnConvertir.Click += delegate
            {
                try
                {
                    IngresosC = double.Parse(txtIngresosC.Text);
                    IngresosV = double.Parse(txtIngresoV.Text);
                    EgresosC = double.Parse(txtEgresosC.Text);
                    EgresosV = double.Parse(txtEgresoV.Text);
                    CapitalC = IngresosC - EgresosC;
                    CapitalV = IngresosV - EgresosV;
                    Cargar();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }
            };

        }

        public void Cargar()
        {
            Intent objIntent = new Intent(this, typeof(VistaCapital));
            objIntent.PutExtra("CapitalC", CapitalC);
            objIntent.PutExtra("CapitalV", CapitalV);
            StartActivity(objIntent);
        }
    }
}

