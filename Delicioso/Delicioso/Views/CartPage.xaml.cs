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
    public partial class CartPage : ContentPage
    {
        string spUserName;
        public CartPage()
        {
            InitializeComponent();
            this.BackgroundImage = "background.jpg";
            NavigationPage.SetHasBackButton(this, false);
            this.Title = "My Cart";
            cart.ItemsSource = null;
            spUserName = Convert.ToString(Application.Current.Properties["USERNAME"]);
            CartQuery cartQuery = new CartQuery();
            cart.ItemsSource = cartQuery.GetList(spUserName);
            total.Text = cartQuery.GetTotal(spUserName) + "";
        }

        public void Pay_btn_Clicked(object sender, EventArgs eventArgs)
        {
            Navigation.PushAsync(new PaymentPage());
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new HomePage());
            return true;
        }
    }
}