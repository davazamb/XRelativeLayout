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
using System.IO;
using SQLite;

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
                //Conexion a base de datos SQLite
                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                path = Path.Combine(path, "Base.db3");
                var conn = new SQLiteConnection(path);
                var elementos = from s in conn.Table<Informacion>()
                                select s;
                foreach (var fila in elementos)
                {
                    Toast.MakeText(this, fila.IngresosColombia.ToString(), ToastLength.Short).Show();
                    Toast.MakeText(this, fila.IngresosVenezuela.ToString(), ToastLength.Short).Show();
                    Toast.MakeText(this, fila.EgresosColombia.ToString(), ToastLength.Short).Show();
                    Toast.MakeText(this, fila.EgresosVenezuela.ToString(), ToastLength.Short).Show();

                }

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