/// <summary>
/// Child "Pizza" class that inherits from Main "Food" class 
/// </summary>

namespace PizzaProject
{
    public class Pizza : Food
    {
        public Pizza(
            string typeOfFood,
            string name,
            string description,
            double price
        ) : base(typeOfFood, name, price)
        {
            PizzaCrust = PizzaCrust;
            PizzaSize = PizzaSize;
            TypeOfFood = typeOfFood;
            Description = description;
        }

        public PizzaCrust PizzaCrust { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public string Description { get; set; }
    }
}