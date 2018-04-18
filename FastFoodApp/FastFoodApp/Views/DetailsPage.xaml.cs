using FastFoodApp.Models;
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
	public partial class DetailsPage : ContentPage
    {
        string pimage;
        string pprice;

        public DetailsPage(String image, String name, String description, String price)
        {
           // this.BackgroundImage = "background.png";
            this.Title = "Food Details";
            InitializeComponent();
            Name.Text = name;
            Description.Text = description;
            Price.Text = price;
            Image.Source = image;
            pimage = image;
            pprice = price;
        }
        public void Add_btn_Clicked(object sender, EventArgs e)
        {
            CartRecord pd = new CartRecord();
            int qty = Convert.ToInt32(Qty.Text);
            Console.WriteLine("Price :{0}", pprice);
            string[] exPrice = pprice.Split('.');
            Console.WriteLine("int Price :{0}", exPrice[1]);
            int total = Convert.ToInt32(exPrice[1]);
            pd.Name = Name.Text;
            pd.Price = Price.Text;
            pd.Total = (qty * total).ToString();
            pd.Qty = qty + "";
            pd.Image = pimage;
            CartQuery c = new CartQuery();
            c.InsertDetails(pd);
            Navigation.PushAsync(new CartPage());
        }
    }
}