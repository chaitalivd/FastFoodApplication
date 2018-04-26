using Delicioso.Model;
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
	public partial class PaymentPage : ContentPage
	{
        public PaymentPage()
        {
            InitializeComponent();
            this.Title = "Payment";
            this.BackgroundImage = "background.png";
        }
        public void PayNow_btn_Clicked(object sender, EventArgs e)
        {
            if (cn.Text == null || name.Text == null || number.Text == null || cvv.Text == null)
            {
                Error.Text = "All fields are mandatory";
            }
            else
            {
                var username = Convert.ToString(Application.Current.Properties["USERNAME"]);
                CartQuery cartQuery = new CartQuery();
                var i = cartQuery.DeleteCart(username);
                if (i > 0)
                {
                    DisplayAlert("Paymet", "Success", "Yes");
                    Navigation.PushAsync(new HomePage());
                }
                else
                {
                    DisplayAlert("Paymet", "Something wenr wrong..", "Yes");
                }
            }
        }
    }
}