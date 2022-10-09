using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55854/api/");
                //HTTP GET
                var responseTask = client.GetAsync("values");
                //var responseTask = client.PutAsync("values/5", null);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var students = readTask.Result;

                    Console.WriteLine(students.ToString());
                }
            }
            Console.ReadLine();
        }
    }
}
