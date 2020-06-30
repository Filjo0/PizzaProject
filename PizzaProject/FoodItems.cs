/// <summary>
/// Child "FoodItem" class that inherits from Main "Food" class 
/// Contains constructors of FoodItems that are inclubed in DataGrid
/// </summary>

namespace PizzaProject
{
    public class FoodItems : Food
    {
        public FoodItems(string typeOfFood, string name, double price, int quantity) : base(typeOfFood, name, price,
            quantity)
        {
        }

        public FoodItems(string typeOfFood, string name, string description, double price) : base(typeOfFood, name,
            price)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}