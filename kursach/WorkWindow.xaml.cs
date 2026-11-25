using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace kursach
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public WorkWindow()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void BtnAddCar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegNumber.Text) || cmbBrand.SelectedItem == null || cmbOwner.SelectedItem == null)
            {
                MessageBox.Show("Заполните номер, выберите марку и владельца!");
                return;
            }

            using (var db = new ApplicationContext())
            {
                Car newCar = new Car();

                newCar.RegNumber = txtRegNumber.Text;
                newCar.Color = txtColor.Text;

                if (int.TryParse(txtYear.Text, out int yearResult))
                {
                    newCar.Year = yearResult;
                }
                else
                {
                    MessageBox.Show("Год должен быть числом!");
                    return; 
                }
 
                newCar.IdBrand = (int)cmbBrand.SelectedValue;
                newCar.IdOwner = (int)cmbOwner.SelectedValue;

                string digits = "";
                foreach (char c in txtRegNumber.Text)
                {
                    if (char.IsDigit(c)) digits += c;
                }
                newCar.DigitPart = digits;

                db.Cars.Add(newCar);
                db.SaveChanges();

                LoadData(); 
            }
        }

        private void BtnAddOwner_Click(object sender, RoutedEventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(txtOwnerName.Text) ||
                string.IsNullOrWhiteSpace(txtOwnerAddress.Text) ||
                string.IsNullOrWhiteSpace(txtOwnerPhone.Text) ||
                string.IsNullOrWhiteSpace(txtOwnerPassport.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }
            using (var db = new ApplicationContext())
            {

                Owner newOwner = new Owner();

                newOwner.FullName = txtOwnerName.Text;
                newOwner.Address = txtOwnerAddress.Text;
                newOwner.Phone = txtOwnerPhone.Text;
                newOwner.Passport = txtOwnerPassport.Text;

                db.Owners.Add(newOwner);
                db.SaveChanges();
                LoadData();
            }
        }

        private void BtnAddFine_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFineCar.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtFineAmount.Text) ||
                string.IsNullOrWhiteSpace(txtFineDate.Text))
            {
                MessageBox.Show("Выберите автомобиль, укажите дату и сумму штрафа!");
                return;
            }

            using (var db = new ApplicationContext())
            {
                if (!decimal.TryParse(txtFineAmount.Text, out decimal amountResult))
                {
                    MessageBox.Show("Сумма должна быть числом!");
                    return;
                }

                Fine newFine = new Fine
                {
                    IdCar = (int)cmbFineCar.SelectedValue, 
                    FineDate = txtFineDate.Text,           
                    Amount = amountResult,
                    Reason = txtFineReason.Text,
                    Status = txtFineStatus.Text
                };

                db.Fines.Add(newFine);
                db.SaveChanges();

                LoadData();

                txtFineAmount.Clear();
                txtFineDate.Clear();
                txtFineReason.Clear();
                txtFineStatus.Clear();
            }
        }

        private void BtnSearchGeneral_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnSearchD_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnSearchE_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnSearchJ_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void LoadData()
        {
            using (var db = new ApplicationContext())
            {
                var cars = db.Cars
                             .Include(c => c.Brand)
                             .Include(c => c.Owner)
                             .ToList();
                CarsGrid.ItemsSource = cars;

                cmbBrand.ItemsSource = db.Brands.ToList();
                cmbOwner.ItemsSource = db.Owners.ToList();
                OwnersGrid.ItemsSource = db.Owners.ToList();

                var fines = db.Fines.Include(f => f.Car).ToList();
                FinesGrid.ItemsSource = fines;
                cmbFineCar.ItemsSource = db.Cars.ToList();
            }
        }
    }
}
