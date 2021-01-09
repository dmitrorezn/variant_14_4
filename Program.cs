using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using variant_14_4.Context;

namespace ConsoleApp15
{
    /*
     Написати метод, що поверне усі доступні спеціалізації лікарів 
     у конкретному місті. Оптимізувати код щоб у базу надсилався лише один запит
    */
    class Program
    {

        public static List<string> GetDocsSpecByCytyID(int id)
        {
            List<string> specs = new List<string>();

            using (var ctx = new FluentContext())
            {

                var doctors = from d in ctx.Doctors
                              join c in ctx.Cities on d.CityId equals c.Id
                              where c.Id == id
                              select new { Spesialisation = d.Spesialisation } ;

                if (doctors.Count() > 0)
                {
                    foreach ( var d in doctors)
                    {
                        specs.Add(d.Spesialisation);
                    }
                    return specs; 
                }
                return null;
            }
        }

        static void Main(string[] args)
        {

            int id = Convert.ToInt32(Console.ReadLine());

            var s = GetDocsSpecByCytyID(id);

            if (s == null){
                Console.WriteLine("empty");
            }
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
