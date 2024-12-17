using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class RandomNumberGenerator
    {
        public static List<int> GetUniqueRandomNumbersShuffle(int min, int max, int count)
        {
            List<int> numbers = Enumerable.Range(min, max - min + 1).ToList();
            Random random = new Random();
        
            for (int i = numbers.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }

            return numbers.Take(count).ToList();
        }
    }
}
