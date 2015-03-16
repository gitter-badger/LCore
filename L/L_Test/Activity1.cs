using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using L;
using System.Threading;

namespace L_Test
{
    [Activity(Label = "L_Test", MainLauncher = true)]
    public class Activity1 : Activity
    {
        int count = 1;
        
        static Button button = null;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button>(Resource.Id.myButton);

            Toast.MakeText(this.BaseContext, "test", ToastLength.Long);
            button.Click += delegate
            {
                Thread Current = Thread.CurrentThread;
                button.Text = string.Format("{0} clicks!", count++);

                String[] Strs = new String[10].CollectI((i, s) => { return i.ToString(); });

                L.L.A(()=>
                    {
                        Strs.Each<String>((s) =>
                            {
                                button.Text += s;
                            });
                    })();
            };
        }


    }
}