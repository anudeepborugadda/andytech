using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
//using System.Net.Http.Formatting;
using Newtonsoft.Json;


namespace ConsoleAppHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World");

            Console.WriteLine("--------------------------------------------------------------");

            //Selfhosting and testing the WEBAPI through the console Appln.

            HttpClient cons = new HttpClient();
            cons.BaseAddress = new Uri("http://localhost:41618/");// This can be changed according the machine you are running the program.
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            MyAPIGet(cons).Wait();
        }

        static async Task MyAPIGet(HttpClient cons)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/Employees");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {

                    var responseAsString = await res.Content.ReadAsStringAsync();
                    var responseAsConcreteType = JsonConvert.DeserializeObject<List<Employee>>(responseAsString);

                    for (int i = 0; i < responseAsConcreteType.Count; i++)
                    {
                        Employee objEmp = responseAsConcreteType[i];

                        Console.WriteLine(objEmp.id + " || " + objEmp.empName + " || " + objEmp.empEmail);

                    }

                    Console.ReadLine();
                }
            }
        }

    }

    /// <summary>
    /// This Class has been created to jus for the formatting sake..
    /// </summary>
    public class Employee
    {
        public int id { get; set; }
        public string empName { get; set; }
        public string empEmail { get; set; }

    }

}
