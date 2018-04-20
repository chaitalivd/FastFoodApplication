using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Delicioso.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyOrderPage : ContentPage
	{
		public MyOrderPage ()
		{
			InitializeComponent ();
		}

        protected override bool OnBackButtonPressed()
        {
            //I have changed here
            Navigation.PushAsync(new HomePage());
            return true;
        }
    }
}