using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNetapi4.Controllers
{
    public class EmployeesDataController : ApiController 
    {
    
        public string[] myEmployee = { "vishal", "adi", "pk" };

        [HttpGet]
        public string[] GetEmployees()
        {
            return myEmployee;
        }
        [HttpGet]
        public string  GetEmployeeByIndex(int id)
        {
            return myEmployee[id];
        }
    }
}
