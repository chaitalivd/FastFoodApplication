using FastFoodApp.MenuItems;
using FastFoodApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FastFoodApp
{
	public partial class MainPage : MasterDetailPage
	{
        public List<MasterPageItem> menuList { get; set; }
		public MainPage()
		{
			InitializeComponent();
            menuList = new List<MasterPageItem>();

            var loginPage = new MasterPageItem() { Title = "Login", Icon = "ic_account_circle_black_24dp.png", TargetType = typeof(LoginPage) };
            var myOrder = new MasterPageItem() { Title = "My Order", Icon = "ic_book_black_24dp.png", TargetType = typeof(MyOrderPage) };
            var signOut = new MasterPageItem() { Title = "Sign Out", Icon = "ic_exit_to_app_black_24dp.png", TargetType = typeof(SignOutClass) };

            menuList.Add(loginPage);
            menuList.Add(myOrder);
            menuList.Add(signOut);

            navigationDrawerList.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));

            this.BindingContext = new
            {
                Header = "",
                Image = "ff_orange.jpg",
                Name = "You are a Guest, Please Login..",
                Footer = ""
            };
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
            return true;
        }
    }
}
