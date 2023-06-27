using System;
using System.Collections.Generic;

namespace T07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] array = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = array[0];
                string number = array[1];

                if (command == "IN")
                {
                    parkingLot.Add(number);
                }
                else
                {
                    parkingLot.Remove(number);
                }

                input = Console.ReadLine();
            }

            int count = 0;
            foreach (string cars in parkingLot)
            {
                count++;
            }

            if (count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var item in parkingLot)
            {
                Console.WriteLine(item);
            }
        }
    }
}
