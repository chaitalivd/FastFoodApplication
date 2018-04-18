using FastFoodApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastFoodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        public HomePage()
        {
            InitializeComponent();
            //this.BackgroundImage = "background.png";
            //this.Icon = "ic_fastfood.jpg";
            this.Title = "Menu";

            ObservableCollection<data> myList = new ObservableCollection<data>();
            ProductsQuery pq = new ProductsQuery();

            if (pq.GetNoOfProducts() < 1)
            {
                ProductsQuery newProduct = new ProductsQuery();

                ProductsDB product = new ProductsDB();
                product.Image = "sq_burger.jpg";
                product.Name = "Burger";
                product.Description = "Thick, juicy and bursting with flavor! With mayo, mustard and ketchup.";
                product.Price = "Rs.50";
                newProduct.InsertDetails(product);

                ProductsDB product1 = new ProductsDB();
                product1.Image = "sq_Sandwich.jpg";
                product1.Name = "Sandwich";
                product1.Description = "Sandwich having both being healthy and tasty at same time!!";
                product1.Price = "Rs.40";
                newProduct.InsertDetails(product1);

                ProductsDB product2 = new ProductsDB();
                product2.Image = "sq_cool_drinks.jpg";
                product2.Name = "Rose Mocktail";
                product2.Description = "Juicy and Refreshing!!";
                product2.Price = "Rs.40";
                newProduct.InsertDetails(product2);
            }

            listview.ItemsSource = pq.GetProductList();
            listview.ItemTapped += async (o, e) => {
                var mList = (ListView)o;
                var pro = (mList.SelectedItem as ProductsDB);
                await Navigation.PushAsync(new DetailsPage(pro.Image, pro.Name, pro.Description, pro.Price));
                mList.SelectedItem = null; // de-select the row
            };
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            var closer = DependencyService.Get<ICloseApplication>();
            closer?.closeApplication();
            return false;
        }
    }
}