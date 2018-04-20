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
        //ObservableCollection<CartDB> list = new ObservableCollection<CartDB>(); 
        string spUserName;
        public CartPage ()
		{
			InitializeComponent ();
            this.BackgroundImage = "background.jpg";
            NavigationPage.SetHasBackButton(this, false);
            this.Title = "My Cart";
            spUserName = Convert.ToString(Application.Current.Properties["USERNAME"]);
            CartQuery cartQuery = new CartQuery();
            //list = (ObservableCollection<CartDB>)cartQuery.GetList(spUserName);
            cart.ItemsSource = cartQuery.GetList(spUserName);
            total.Text = cartQuery.GetTotal() + "";
        }

        public async void Cart_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = e.Item as CartDB;
            var ans = await DisplayAlert("My Cart", "Do to want to delete " +menu.Name, "Yes", "No");
            if (ans)
            {
                CartQuery cartQuery1 = new CartQuery();
                cartQuery1.DeleteNote(menu.Id);
            }
        }

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