namespace Exercise002
{
    using System;
    using System.Collections.Generic;

    public class LotteryRow
    {
        public List<int> numbers { get; set; }

        public LotteryRow()
        {
            this.RandomizeNumbers();
            
        }
        public bool ContainsNumber(int number)
        {
            // Tests whether the number is already among the randomized numbers
            if(this.numbers.Contains(number))
            {
                return true;
            }
            return false;
        }
        public void RandomizeNumbers()
        {
            // initialize the list for numbers
            this.numbers = new List<int>();
            // Implement the randomization of the numbers by using the method ContainsNumber() here
            Random random = new Random();
            while(this.numbers.Count < 7)
            {
                int number = random.Next(1,41);
                if(!ContainsNumber(number))
                {
                    this.numbers.Add(number);
                }
            }
            this.numbers.Sort();
        }
    }
}