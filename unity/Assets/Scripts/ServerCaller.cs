using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using System.IO;

using UnityEngine;

namespace malvra
{
    [System.Serializable]
    public class EmployeeTask
    {
        public int block;
        public bool completed;
        public string completion_time;
        public string date;
        public string employee_id;
        public string employee_name;
        public string task;

        public override string ToString()
        {
            return employee_id + "\n"
                + employee_name + "\n"
                + task + "\n"
                + block + "\n"
                + completion_time;
        }
    }

    [System.Serializable]
    public class Employee
    {
        public string _id;
        public string email;
        public string firstname;
        public string lastname;
        public string username;

        public override string ToString()
        {
            return username;
        }
    }

    public class ServerCaller : MonoBehaviour
    {
        private static string baseURL = "http://malvra.dis.eafit.edu.co/api";
        // private static string baseURL = "http://localhost:3000/";

        #region Nice functions that didn't work in hololens but may in the future

        private static HttpClient client = new HttpClient();
        // This is the simple ideal way but it doesn't work with the HoloLens
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

        // This is the simple ideal way but it doesn't work with the HoloLens
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

        // This is the simple ideal way but it doesn't work with the HoloLens
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

        #endregion

        // TODO: Refactor methods bellow
        public static Employee[] GetEmployees()
        {
            // Ugly but its the only thing that worked
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseURL + "/workers/all");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string jsonResponse = reader.ReadToEnd();
            jsonResponse = "{\"Items\":" + jsonResponse.Trim() + "}";
            
            Employee[] employees = JsonHelper.FromJson<Employee>(jsonResponse);
            return employees;
        }
        public static EmployeeTask[] GetEmployeeTasks()
        {
            // Ugly but its the only thing that worked
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseURL + "/temp/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string jsonResponse = reader.ReadToEnd();
            jsonResponse = "{\"Items\":" + jsonResponse.Trim() + "}";
            
            EmployeeTask[] employeeTasks = JsonHelper.FromJson<EmployeeTask>(jsonResponse);
            return employeeTasks;
        }
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

}
