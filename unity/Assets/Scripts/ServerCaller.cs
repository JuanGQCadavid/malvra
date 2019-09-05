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
        public string employee_id { get; set; }
        public string employee_name { get; set; }
        public string task { get; set; }
        public int block { get; set; }
        public string date { get; set; }
        public bool completed { get; set; }
        public string completion_time { get; set; }

        public override string ToString()
        {
            return employee_id + "\n"
                + employee_name + "\n"
                + task + "\n"
                + block + "\n"
                + completion_time;
        }
    }

    public class ServerCaller : MonoBehaviour
    {
        private static HttpClient client = new HttpClient();
        private static string baseURL = "http://3.222.66.178:3000/";

        public static async Task<EmployeeTask[]> GetEmployeeTasksAsync()
        {
            EmployeeTask[] tasks = null;
            HttpResponseMessage response = await client.GetAsync(baseURL + "/tasks");
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadAsAsync<EmployeeTask[]>();
            }
            return tasks;
        }

        public static async Task<EmployeeTask[]> GetEmployeeTasksAsync(string employeeId)
        {
            EmployeeTask[] tasks = null;
            HttpResponseMessage response = await client.GetAsync(baseURL + "tasks?employee_id=" + employeeId);
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadAsAsync<EmployeeTask[]>();
            }
            return tasks;

        }
    }
}
