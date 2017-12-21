using System;
using System.Collections.Generic;
using ICT13580028EndB.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

using Xamarin.Forms;


namespace ICT13580028EndB
{
    public partial class Newcar : ContentPage
    {

        Product product;

        public Newcar(Product product = null)
        {
            InitializeComponent();
            this.product = product;
            titleLabel.Text = product == null ? "เพิ่มข้อมูลรถ":"แก้ไขข้อมูลรถ";
            maiSlider.ValueChanged +=MaiSlider_ValueChanged;
            ageStepper.ValueChanged += AgeStepper_ValueChanged;

            typePicker.Items.Add("ครอบครัว");
            typePicker.Items.Add("ยนต์");
            typePicker.Items.Add("ตู้");

            branPicker.Items.Add("โตโยต้า");
            branPicker.Items.Add("อีซูซุ");

            colorPicker.Items.Add("ขาว");
            colorPicker.Items.Add("ดำ");

            conPicker.Items.Add("กรุงเทพ");
            conPicker.Items.Add("เชียงใหม่");

			cancelButton.Clicked += CancelButton_Clicked;
			saveButton.Clicked += SaveButton_Clicked;

			if (product != null)
			{
                typePicker.SelectedItem = product.Typecar;
                branPicker.SelectedItem = product.Bran;
				classEntry.Text = product.Classi;
                ageLabel.Text = product.Agecar.ToString();
                maiLabel.Text= product.Maicar.ToString();
                colorPicker.SelectedItem = product.Color;
				cardEntry.IsToggled = product.Card;
                partEditor.Text = product.Parts;
                priceEntry.Text = product.Price.ToString();
                conPicker.SelectedItem = product.Contr;
                phoneEntry.Text = product.Phones.ToString();
			}

        }
		async void SaveButton_Clicked(object sender, EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
			if (isOk)
			{
				if (product == null)
				{

					product.Typecar = typePicker.SelectedItem.ToString();
					product.Bran = branPicker.SelectedItem.ToString();
					product.Classi = classEntry.Text;
					product.Agecar = int.Parse(ageLabel.Text);
					product.Maicar = int.Parse(maiLabel.Text);
					product.Color = colorPicker.SelectedItem.ToString();
					product.Card = cardEntry.IsToggled;
					product.Parts = partEditor.Text;
                    product.Price = int.Parse(priceEntry.Text);
					product.Contr = conPicker.SelectedItem.ToString();
					product.Phones = int.Parse(phoneEntry.Text);

                    var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
				}
				else
				{
					product.Typecar = typePicker.SelectedItem.ToString();
					product.Bran = branPicker.SelectedItem.ToString();
					product.Classi = classEntry.Text;
					product.Agecar = int.Parse(ageLabel.Text);
					product.Maicar = int.Parse(maiLabel.Text);
					product.Color = colorPicker.SelectedItem.ToString();
					product.Card = cardEntry.IsToggled;
					product.Parts = partEditor.Text;
					product.Price = int.Parse(priceEntry.Text);
					product.Contr = conPicker.SelectedItem.ToString();
					product.Phones = int.Parse(phoneEntry.Text);

                    var id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
				}
				await Navigation.PopModalAsync();
			}
		}

        void MaiSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
			int value = (int)e.NewValue;
            maiLabel.Text = value.ToString();
        }

        void AgeStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
			int value = (int)e.NewValue;
            ageLabel.Text = value.ToString();
        }
		void CancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}
    }
}
