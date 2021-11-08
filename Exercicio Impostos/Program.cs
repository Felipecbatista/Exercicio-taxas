using System;
using System.Globalization;
using System.Collections.Generic;
using Exercicio_Impostos.Entities;

namespace Exercicio_Impostos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for(int i=1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double income = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if(type == 'i')
                {
                    Console.Write("Healt expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, income, healthExpenditures));
                }
                else
                {
                    Console.Write("number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, income, numberOfEmployees));
                }

            }

            double sum = 0.0;
            Console.WriteLine("\nTAXES PAID: ");
            foreach(TaxPayer tp in list)
            {
                double tax = tp.Tax();
                Console.WriteLine(tp.Name + ": $ " + tax.ToString("F2", CultureInfo.InvariantCulture));
                sum += tax;
            }

            Console.WriteLine("\nTOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
