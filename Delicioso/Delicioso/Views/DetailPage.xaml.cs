using Delicioso.Models;
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
	public partial class DetailPage : ContentPage
	{
        string selImage;

        public DetailPage(string image, string name, string description, string price)
        {
            InitializeComponent();
            this.BackgroundImage = "background.jpg";
            this.Title = name;
            Name.Text = name;            
            Image.Source = image;
            selImage = image;
            Description.Text = description;
            Price.Text = price;
        }

        public async void Add_btn_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("USERNAME"))
            {
                var getUserName = Convert.ToString(Application.Current.Properties["USERNAME"]);
                if (getUserName.Equals("As Guest"))
                {
                    int quantity1 = Convert.ToInt32(Qty.Text);
                    await Navigation.PushAsync(new LoginPage(selImage,Name.Text,Price.Text,quantity1));
                }
                else
                {
                    var getUsername = Convert.ToString(Application.Current.Properties["USERNAME"]);
                    CartDB cartDB = new CartDB();
                    int quantity = Convert.ToInt32(Qty.Text);
                    string[] exPrice = Price.Text.Split('.');
                    int total = Convert.ToInt32(exPrice[1]);
                    cartDB.Username = getUsername;
                    cartDB.Name = Name.Text;
                    cartDB.Price = Price.Text;
                    cartDB.Qty = quantity.ToString();
                    cartDB.Total = (quantity * total).ToString();
                    cartDB.Image = selImage;
                    CartQuery cartQuery = new CartQuery();
                    cartQuery.InsertDetails(cartDB);
                    await Navigation.PushAsync(new CartPage());
                }
            }
        }
    }
}