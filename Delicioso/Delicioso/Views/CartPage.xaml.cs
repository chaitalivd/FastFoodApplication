using Delicioso.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public CartPage ()
		{
			InitializeComponent ();
            this.BackgroundImage = "background.jpg";  
            NavigationPage.SetHasBackButton(this, false);
            this.Title = "My Cart";
            cart.ItemsSource = null;
            spUserName = Convert.ToString(Application.Current.Properties["USERNAME"]);
            CartQuery cartQuery = new CartQuery();
            cart.ItemsSource = cartQuery.GetList(spUserName);
            total.Text = cartQuery.GetTotal() + "";
        }

        /*public async void Cart_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = e.Item as CartDB;
            var ans = await DisplayAlert("My Cart", "Do to want to delete " +menu.Name, "Yes", "No");
            if (ans)
            {
                CartQuery cartQuery1 = new CartQuery();
                var i = cartQuery1.DeleteNote(menu.Id);
                Console.WriteLine("No. of rows deleted: {0}", i);
                cart.ItemsSource = cartQuery1.GetList(spUserName);
                total.Text = cartQuery1.GetTotal() + "";
                //await Navigation.PushAsync(new CartPage());
            }
            else
            {
                await Navigation.PushAsync(new CartPage());
            }
        }*/

        public void pay_btn_Clicked(object sender, EventArgs eventArgs)
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