using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using System.IO;
using SQLite;

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
            //Conexion de Base de datos SQLite
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "Base.db3");
            var conn = new SQLiteConnection(path);
            conn.CreateTable<Informacion>();

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
                    //Datos guardar en SQLite
                    var Insertar = new Informacion();
                    Insertar.IngresosColombia = IngresosC;
                    Insertar.IngresosVenezuela = IngresosV;
                    Insertar.EgresosColombia = EgresosC;
                    Insertar.EgresosVenezuela = EgresosV;
                    //Variable de conexion
                    conn.Insert(Insertar);
                    //Mensaje
                    Toast.MakeText(this, "Guardado en SQLite", ToastLength.Short).Show();
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
    public class Informacion
    {
        public double IngresosColombia { get; set; }
        public double IngresosVenezuela { get; set; }
        public double EgresosColombia { get; set; }
        public double EgresosVenezuela { get; set; }
    }
}

