using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using UnityEngine;
using Newtonsoft.Json;

namespace malvra
{
    public class EmployeeTask
    {
        public int block { get; set; }
        public bool completed { get; set; }
        public string completion_time { get; set; }
        public string date { get; set; }
        public string employee_id { get; set; }
        public string employee_name { get; set; }
        public string task { get; set; }

        public override string ToString()
        {
            return employee_id + "\n"
                + employee_name + "\n"
                + task + "\n"
                + block + "\n"
                + completion_time;
        }
    }

    public class Employee
    {
        public string _id { get; set;  }
        public string email { get; set;  }
        public string firstname { get; set;  }
        public string lastname { get; set;  }
        public string username { get; set;  }
    }

    public class ServerCaller : MonoBehaviour
    {
        private static HttpClient client = new HttpClient();
        private static string baseURL = "http://malvra.dis.eafit.edu.co/api";
        // private static string baseURL = "http://localhost:3000/";

        public static async Task<EmployeeTask[]> GetEmployeeTasksAsync()
        {
            EmployeeTask[] tasks = null;
            HttpResponseMessage response = await client.GetAsync(baseURL + "/temp/");
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadAsAsync<EmployeeTask[]>();
            }
            return tasks;
        }

        public static async Task<EmployeeTask[]> GetEmployeeTasksAsync(string employeeId)
        {
            EmployeeTask[] tasks = null;
            HttpResponseMessage response = await client.GetAsync(baseURL + "temp?employee_id=" + employeeId);
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadAsAsync<EmployeeTask[]>();
            }
            return tasks;

        }

        public static async Task<Employee[]> GetEmployeesAsync()
        {
            Employee[] employees = null;
            HttpResponseMessage response = await client.GetAsync(baseURL + "/workers/all");
            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadAsAsync<Employee[]>();
            }
            return employees;
        }
    }
}
