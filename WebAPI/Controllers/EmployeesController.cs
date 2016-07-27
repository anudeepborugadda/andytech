using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        //To keep it simple, Employees are stored in a fixed array inside the controller class.

        Employee[] Employees = new Employee[]
         {
               new Employee {id =100, empName="Tim", empEmail="tim@gmail.com"},
            
               new Employee { id = 101, empName = "Nathan", empEmail ="nathan@gmail.com" },

               new Employee { id =102, empName = "Anudeep", empEmail = "anudeep@gmail.com" }
        };


        public IEnumerable<Employee> GetEmployees()
        {

            
            return Employees;
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var Employee = Employees.FirstOrDefault((p) => p.id == id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }

    }
}
