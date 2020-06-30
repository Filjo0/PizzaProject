using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace PizzaProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly List<string> _nextItemsComboList = new List<string>();
        private readonly List<string> _pizzaCrustComboList = new List<string>();
        private readonly List<string> _pizzaSizeComboList = new List<string>();
        private readonly List<Food> _foodItems = new List<Food>();
        private readonly List<Food> _menuItems = new List<Food>();
        private double _price;
        private int _quantity;
        private double _totalPrice;
        private string _name;
        private string _size;
        private string _crust;
        private Food[] mycart = new Food[99];
        private double _deliveryPrice = 0;
        private bool _orderConfirmed;
        private bool _buttonPressWasClicked;

        public MainWindow()
        {
            InitializeComponent();
            FillMenu();
        }

        // filling in the menu with food items
        public void FillMenu()
        {
            try
            {
                var pizzaMarg = new Pizza("Pizza", "Margherita",
                    "Mozzarella, tomato sauce, oregano, evoo & fresh basil", 16);
                var pizzaHaw = new Pizza("Pizza", "Hawaiian", "Premium leg ham, pineapple, mozzarella & tomato sauce",
                    18);
                var pizzaMeat = new Pizza("Pizza", "Meat Lovers",
                    "Chorizo sausage, premium leg ham, rolled pancetta, mild sopressa salami, mushrooms, mozzarella, tomato sauce & oregano",
                    22);
                var tiramisu = new FoodItems("Dessert", "Tiramisu",
                    "Fresh mascarpone cheese, Savoiardi biscuits, eggs, marsala, cacao powder & espresso coffee", 10);
                var chocolate = new FoodItems("Dessert", "Philadelphia cheesecake",
                    "Homemade with fresh Philadelphia cream cheese", 11);
                var water = new FoodItems("Beverage", "Water", "Cool ridge water 600ML", 2);
                var juice = new FoodItems("Beverage", "Juice",
                    "Apple, Orange, Pineapple, Tomato, Apple and Blackcurrant, Cranberry", 4);


                _menuItems.Add(pizzaMarg);
                _menuItems.Add(pizzaHaw);
                _menuItems.Add(pizzaMeat);
                _menuItems.Add(tiramisu);
                _menuItems.Add(chocolate);
                _menuItems.Add(water);
                _menuItems.Add(juice);

                FoodItemsGrid.ItemsSource = null;
                FoodItemsGrid.ItemsSource = _menuItems;

                DeliveryBlock.Text = _deliveryPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            }
            catch (Exception ex)
            {
                // Some other error occurred.
                // Report the error to the user.
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // adding food items when "Add" button is clicked, only if every box has been filled in
        public void AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TypeItems.SelectedItem?.ToString() != null
                && NextItemsCombo.SelectedItem?.ToString() != null
                && QuantityBox.Text != ""
                && NameBox.Text != "")
                {
                    switch (_size)
                    {
                        case "Small":
                            _price *= 0.75;
                            break;
                        case "Large":
                            _price *= 1.25;
                            break;
                    }

                    _price *= _quantity;
                    _totalPrice += _price;
                    TotalBlock.Text = _totalPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));

                    DeliveryBlock.Text = _deliveryPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));

                    var foodItem = new FoodItems(
                    TypeItems.SelectionBoxItem.ToString(),
                    NextItemsCombo.SelectedItem.ToString(),
                    _price,
                    _quantity
                );
                    _foodItems.Add(foodItem);


                    DataGridOrderFood.ItemsSource = null;
                    DataGridOrderFood.ItemsSource = _foodItems;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Invalid Input Values");
            }
            catch (Exception ex)
            {
                // Some other error occurred.
                // Report the error to the user.
                MessageBox.Show(ex.Message, "Error");
            }

            // clearing all the boxes

            QuantityBox.Clear();
            AddItem.IsEnabled = false;
            _price = 0;
            _quantity = 0;
            _size = "";
            NextItemsCombo.ItemsSource = null;
            PizzaCrustCombo.SelectedIndex = -1;
            NextItemsCombo.Visibility = Visibility.Hidden;
            PizzaCrustCombo.Visibility = Visibility.Hidden;
            PizzaSizeCombo.Visibility = Visibility.Hidden;
            PizzaCrustBlock.Text = "";
            PizzaSizeBlock.Text = "";
            PizzaSizeCombo.SelectedIndex = -1;
            TypeItems.SelectedIndex = -1;
            FoodBlock.Text = "";
            NameBox.Text = _name;
            NameBox.IsEnabled = false;
        }

        // if selection of combobox changed -> filling in next combobox in regards of the choice 
        public void foodItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //pizza -> pizza items
            if (Equals(TypeItems.SelectedItem, PizzaCombo))
            {
                _nextItemsComboList.Clear();
                FoodBlock.Text = "Pizza:";
                _nextItemsComboList.Add(nameof(TypeOfPizza.Hawaiian));
                _nextItemsComboList.Add(nameof(TypeOfPizza.Margherita));
                _nextItemsComboList.Add(nameof(TypeOfPizza.MeatLover));

                NextItemsCombo.ItemsSource = null;
                NextItemsCombo.ItemsSource = _nextItemsComboList;

                _pizzaCrustComboList.Clear();
                _pizzaCrustComboList.Add(nameof(PizzaCrust.Thick));
                _pizzaCrustComboList.Add(nameof(PizzaCrust.Thin));

                PizzaCrustCombo.ItemsSource = null;
                PizzaCrustCombo.ItemsSource = _pizzaCrustComboList;

                _pizzaSizeComboList.Clear();
                _pizzaSizeComboList.Add(nameof(PizzaSize.Small));
                _pizzaSizeComboList.Add(nameof(PizzaSize.Medium));
                _pizzaSizeComboList.Add(nameof(PizzaSize.Large));

                PizzaSizeCombo.ItemsSource = null;
                PizzaSizeCombo.ItemsSource = _pizzaSizeComboList;

                NextItemsCombo.Visibility = Visibility.Visible;
            }
            // dessert -> dessert items
            if (Equals(TypeItems.SelectedItem, DesertCombo))
            {
                _nextItemsComboList.Clear();
                _pizzaCrustComboList.Clear();
                _pizzaSizeComboList.Clear();
                PizzaCrustCombo.ItemsSource = null;
                PizzaSizeCombo.ItemsSource = null;

                FoodBlock.Text = "Desert:";
                _nextItemsComboList.Add(nameof(Desserts.Tiramisu));
                _nextItemsComboList.Add(nameof(Desserts.Cheesecake));

                NextItemsCombo.ItemsSource = null;
                NextItemsCombo.ItemsSource = _nextItemsComboList;
                NextItemsCombo.Visibility = Visibility.Visible;

                PizzaCrustBlock.Text = "";
                PizzaSizeBlock.Text = "";
                PizzaCrustCombo.Visibility = Visibility.Hidden;
                PizzaSizeCombo.Visibility = Visibility.Hidden;
            }

            // beverage -> beverage items
            if (Equals(TypeItems.SelectedItem, BeverageCombo))
            {
                _nextItemsComboList.Clear();
                FoodBlock.Text = "Beverage:";
                _nextItemsComboList.Add(nameof(Beverages.Juice));
                _nextItemsComboList.Add(nameof(Beverages.Water));

                NextItemsCombo.ItemsSource = null;
                NextItemsCombo.ItemsSource = _nextItemsComboList;
                NextItemsCombo.Visibility = Visibility.Visible;

                PizzaCrustBlock.Text = "";
                PizzaSizeBlock.Text = "";
                PizzaCrustCombo.Visibility = Visibility.Hidden;
                PizzaSizeCombo.Visibility = Visibility.Hidden;
            }
        }

        // removing item when "Delete" button is clicked
        public void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < _foodItems.Count; i++)
            {
                if (DataGridOrderFood.SelectedItem != _foodItems[i]) continue;
                _totalPrice -= _foodItems[i].Price;
                TotalBlock.Text = _totalPrice.ToString();
                _foodItems.Remove(_foodItems[i]);
            }

            DataGridOrderFood.ItemsSource = null;
            DataGridOrderFood.ItemsSource = _foodItems;
        }

        // placing order when "Place order" button is clicked and filling in the confirmList Data Grid
        public void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!_buttonPressWasClicked)
            {
                if (DataGridOrderFood.ItemsSource != null)
                {
                    mycart.ToList().Clear();
                    StatusBlock.Text = "Order Placed. Thank you :)";

                    for (int i = 0; i < _foodItems.Count; i++)
                    {
                        mycart[i] = _foodItems[i];
                        ConfirmList.ItemsSource = null;
                        ConfirmList.Items.Add(mycart[i].Name + "  -  " + mycart[i].Price.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "  -  " + mycart[i].Quantity.ToString());
                    }
                    _totalPrice += _deliveryPrice;
                    ConfirmList.Items.Add("Delivery: " + _deliveryPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US")));
                    ConfirmList.Items.Add("Total: " + _totalPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US")));
                    _buttonPressWasClicked = true;
                }
                else
                {
                    StatusBlock.Text = "No Food Items Added to List";
                }
            }
            else
            {
                StatusBlock.Text = "Order already placed. Thank you :)";
            }
        }

        // if selection of combobox changed -> filling in next combobox in regards of the choice (pizza size, pizza crust, etc)
        // price is set here
        public void nextItemsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (NextItemsCombo.SelectedItem?.ToString())
                {
                    case nameof(TypeOfPizza.Hawaiian):
                        _price = 18;
                        PizzaCrustCombo.Visibility = Visibility.Visible;
                        PizzaSizeCombo.Visibility = Visibility.Visible;
                        PizzaSizeBlock.Text = "Pizza Size:";
                        PizzaCrustBlock.Text = "Pizza Crust:";
                        break;
                    case nameof(TypeOfPizza.Margherita):
                        _price = 16;
                        PizzaCrustCombo.Visibility = Visibility.Visible;
                        PizzaSizeCombo.Visibility = Visibility.Visible;
                        PizzaSizeBlock.Text = "Pizza Size:";
                        PizzaCrustBlock.Text = "Pizza Crust:";
                        break;
                    case nameof(TypeOfPizza.MeatLover):
                        _price = 22;
                        PizzaCrustCombo.Visibility = Visibility.Visible;
                        PizzaSizeCombo.Visibility = Visibility.Visible;
                        PizzaSizeBlock.Text = "Pizza Size:";
                        PizzaCrustBlock.Text = "Pizza Crust:";
                        break;
                    case nameof(Desserts.Tiramisu):
                        _price = 10;
                        break;
                    case nameof(Desserts.Cheesecake):
                        _price = 11;
                        break;
                    case nameof(Beverages.Water):
                        _price = 2;
                        break;
                    case nameof(Beverages.Juice):
                        _price = 4;
                        break;
                }
            }
            catch (NullReferenceException ex)
            {
                // Some other error occurred.
                // Report the error to the user.
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // allowing user to chose quantity of items in numbers (quantity box)
        public void QuantityBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = QuantityBox.Text;

            if (!string.IsNullOrEmpty(value))
            {
                int.TryParse(value, out _quantity);
                if (_quantity > 0)
                {
                    _quantity = int.Parse(QuantityBox.Text);
                }
                if (_quantity > 10)
                {
                    MessageBox.Show(
                        "Quantity is too high. \nIf you would like to order more than 10 items - contact our manager");
                    QuantityBox.Clear();
                }
                if (_quantity < 1)
                {
                    MessageBox.Show(
                        "Quantity cannot be less than 1");
                    QuantityBox.Clear();
                }
                if (!int.TryParse(value, out _quantity))
                {
                    MessageBox.Show("Invalid input. Use numbers");
                    QuantityBox.Clear();
                }
            }
            AddButtonIsEnabled();
        }

        // allowing user to print his/her name in letters
        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = NameBox.Text;

            if (!string.IsNullOrEmpty(value))
            {
                if (!Regex.IsMatch(value, "^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Invalid input. Use letters");
                    NameBox.Clear();
                    NameBox.Focus();
                }
                else
                {
                    _name = NameBox.Text;
                }
            }
            AddButtonIsEnabled();
        }

        // pizza size selection 
        public void PizzaSizeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (PizzaSizeCombo.SelectedItem?.ToString())
            {
                case nameof(PizzaSize.Small):
                    _size = nameof(PizzaSize.Small);
                    break;
                case nameof(PizzaSize.Medium):
                    _size = nameof(PizzaSize.Medium);
                    break;
                case nameof(PizzaSize.Large):
                    _size = nameof(PizzaSize.Large);
                    break;
            }
        }

        // pizza crust selection 
        public void PizzaCrustCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (PizzaCrustCombo.SelectedItem?.ToString())
            {
                case nameof(PizzaCrust.Thin):
                    _crust = nameof(PizzaCrust.Thin);
                    break;
                case nameof(PizzaCrust.Thick):
                    _crust = nameof(PizzaCrust.Thick);
                    break;
            }
        }

        // checking if "Add" button is enabled when all the forms/boxes are filled in with the right input
        public void AddButtonIsEnabled()
        {
            if (TypeItems.SelectedItem?.ToString() != null
                && NextItemsCombo.SelectedItem?.ToString() != null
                && QuantityBox.Text != ""
                && NameBox.Text != "")
            {
                AddItem.IsEnabled = true;
            }
            else
            {
                QuantityBox.BorderBrush = System.Windows.Media.Brushes.Red;
                NameBox.BorderBrush = System.Windows.Media.Brushes.Red;
                AddItem.IsEnabled = false;
            }
        }

        public void TakeAwayButton_Checked(object sender, RoutedEventArgs e)
        {
            if (TakeAwayButton.IsChecked == true)
            {
                _deliveryPrice = 0;
            }
        }

        public void DeliverButton_Checked(object sender, RoutedEventArgs e)
        {
            if (DeliverButton.IsChecked == true)
            {
                _deliveryPrice = 5;
            }
        }

        public void ConfrimOrder_Click(object sender, RoutedEventArgs e)
        {
            _orderConfirmed = true;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }


        // generating an order invoice when "Generate" button is clicked
        // creating a txt file with the following information (order invoice)
        public void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            using (var fileStream = new FileStream(string.Format("Bill.txt"), FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(fileStream)) { 
                GenerateBlock.Text += "--- CENTRAL CANTEEN ORDER INVOICE --- \n";
                writer.WriteLine("--- CENTRAL CANTEEN ORDER INVOICE-- - \n");

                for (int i = 0; i < _foodItems.Count; i++)
                {
                    mycart[i] = _foodItems[i];
                    GenerateBlock.Text += ("\n" + mycart[i].Name + "  -  " + mycart[i].Price.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "  -  " + mycart[i].Quantity.ToString());
                    writer.WriteLine("\n" + mycart[i].Name + "  -  " + mycart[i].Price.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "  -  " + mycart[i].Quantity.ToString());
                }
                GenerateBlock.Text += "\n\nDELIVERY FEE: " + _deliveryPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                writer.WriteLine("\n\nDELIVERY FEE: " + _deliveryPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US")));

                GenerateBlock.Text += "\n\n TOTAL: " + _totalPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                writer.WriteLine("\n\nTOTAL: " + _totalPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US")));

                GenerateBlock.Text += "\n\n\n --- THANK YOU " + _name.ToUpper() + "! ENJOY YOUR MEAL! : ) ---";
                writer.WriteLine("\n\n\n--- THANK YOU " + _name.ToUpper() + "! ENJOY YOUR MEAL! : ) ---");

            }
        }

        private void foodItemsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}