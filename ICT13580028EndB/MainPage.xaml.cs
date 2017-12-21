using System;
using System.Collections.Generic;
using ICT13580028EndB.Model;
using Xamarin.Forms;
using System.Text;

namespace ICT13580028EndB
{
    
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			newButton.Clicked += NewButton_Clicked;

		}

		protected override void OnAppearing()
		{
			LoadData();
		}

		void LoadData()
		{
                productListView.ItemsSource = App.DbHelper.GetProducts();
		}

		void NewButton_Clicked(object sender, EventArgs e)
		{
            Navigation.PushModalAsync(new Newcar());
		}

		void Edit_Clicked(object sender, EventArgs e)
		{
			var button = sender as MenuItem;
			var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new Newcar(product));
		}

		async void Delete_Clicked(object sender, EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");

			if (isOk)
			{
				var button = sender as MenuItem;
				var product = button.CommandParameter as Product;
				App.DbHelper.DeleteProduct(product);

				await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลเรียบร้อย", "ตกลง");
				LoadData();
			}
		}
	}
}
