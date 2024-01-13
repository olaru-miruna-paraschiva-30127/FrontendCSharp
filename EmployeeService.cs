using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class EmployeeService
    {
         static HttpClient client = new HttpClient();

        public void createConnection()
        {
            // Update port # in the following line.
           String a = "1";
            client.BaseAddress = new Uri("http://localhost:8080/employee/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Employee> GetEmployees(String id)
        {
            List<Employee> employees = null;
            HttpResponseMessage response = client.GetAsync("depid/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("gata : " + resultString);
                
                employees = JsonConvert.DeserializeObject<List<Employee>>(resultString);
                return employees;

            }
            return null;
        }

        public List<Employee> GetManagers(String id)
        {
            List<Employee> employees = null;
            HttpResponseMessage response = client.GetAsync("depidman/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("gata : " + resultString);

                employees = JsonConvert.DeserializeObject<List<Employee>>(resultString);
                return employees;

            }
            return null;
        }

    }
}
