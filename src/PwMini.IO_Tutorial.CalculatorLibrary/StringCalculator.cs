using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwMini.IO_Tutorial.CalculatorLibrary
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if(numbers == "") return 0;
            var arrayOfStrings = numbers.Split(',','\n');
            var arrayOfInts = new int[arrayOfStrings.Length];

            for(int i=0; i<arrayOfStrings.Length; i++)
            {
                var number = int.Parse(arrayOfStrings[i]);
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if(number >= 1000)
                {

                }
                else
                {
                    arrayOfInts[i] = int.Parse(arrayOfStrings[i]);
                }            
            }
            int sum = 0;
            foreach (var number in arrayOfInts)
            {
                sum += number;
            }
            return sum;
        }
    }
}
