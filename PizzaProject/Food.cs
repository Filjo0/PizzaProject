/// <summary>
/// Main abstract "Food" class
/// It is a base class of other classes
/// </summary>

namespace PizzaProject
{
    public abstract class Food
    {
        protected Food(string typeOfFood, string name, double price)
        {
            Name = name;
            Price = price;
            TypeOfFood = typeOfFood;
        }

        protected Food(string typeOfFood, string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            TypeOfFood = typeOfFood;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public string TypeOfFood { get; set; }
        public int Quantity { get; set; }
    }
}