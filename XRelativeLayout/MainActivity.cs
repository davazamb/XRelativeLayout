using Android.App;
using Android.Widget;
using Android.OS;

namespace XRelativeLayout
{
    [Activity(Label = "XRelativeLayout", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button btnConvertir = FindViewById<Button>
                (Resource.Id.btnconvertir);
            EditText txtDolares = FindViewById<EditText>
                (Resource.Id.txtdolares);
            EditText txtBolivares = FindViewById<EditText>
                (Resource.Id.txtbolos);
            double bolivar, dolares;
            btnConvertir.Click += delegate
            {
                try
                {
                    dolares = double.Parse(txtDolares.Text);
                    bolivar = dolares * 1758;
                    txtBolivares.Text = bolivar.ToString();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                    throw;
                }
            };

        }
    }
}

