using SQLite;
using System;

namespace DinnerChooser
{
    public class Searches
    {
        [PrimaryKey]
        public int Id { get; set; }
        public  string FoodGenre { get; set; }
        public double Distance {get; set;}

        public Searches()
        {
            FoodGenre = "Food near me";
            Distance = 15;
        }

        public Searches(string FoodGenre, double Distance)
        {
            this.FoodGenre = FoodGenre;
            this.Distance = Distance;
        }

        public Searches(String FoodGenre)
        {
            this.FoodGenre = FoodGenre;
            Distance = 15;
        }

        public Searches(double Distance)
        {
            this.Distance = Distance;
            FoodGenre = "Food near me";
        }
   
    }
}
