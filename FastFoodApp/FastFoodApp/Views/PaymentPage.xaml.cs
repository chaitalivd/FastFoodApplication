using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastFoodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentPage : ContentPage
	{
        public PaymentPage()
        {
            InitializeComponent();
            this.Title = "Pay Now";
            //this.BackgroundImage = "background.png";

        }
        public void PayNow_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThankYou());

        }
    }
}
