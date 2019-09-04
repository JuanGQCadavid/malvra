using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using UnityEngine;
using Newtonsoft.Json;

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

    public GameObject CorteButton;
    public GameObject SiembraEnBancaButton;
    public GameObject SiembraEnCamaButton;
    public GameObject DesbotonarButton;

    private EmployeeTask[] tasks;

    // Start is called before the first frame update
    async void Start()
    {
        // TODO: Refactor. Move button instantiation to a different script
        try
        {
            await RunAsync();
            float x = 0;
            float y = 0;
            float z = 0.3f;
            int n = 0;
            foreach(var task in tasks)
            {
                if (task.task.Equals("Desbotonar"))
                {
                    Instantiate(DesbotonarButton, new Vector3(x, y, z), Quaternion.identity);
                }
                else if (task.task.Equals("Siembra en Banca"))
                {
                    Instantiate(SiembraEnBancaButton, new Vector3(x, y, z), Quaternion.identity);
                }
                else if (task.task.Equals("Siembra en Cama"))
                {
                    Instantiate(SiembraEnCamaButton, new Vector3(x, y, z), Quaternion.identity);
                }
                else
                {
                    // Corte
                    Instantiate(CorteButton, new Vector3(x, y, z), Quaternion.identity);
                }

                x += 0.035f;

                // Rows of 4 buttons
                if (++n == 4)
                {
                    y += 0.035f;
                    x = 0;
                    n = 0;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async Task<EmployeeTask[]> GetEmployeeTasksAsync()
    {
        EmployeeTask[] tasks = null;
        HttpResponseMessage response = await client.GetAsync("http://localhost:3000/tasks");
        if (response.IsSuccessStatusCode)
        {
            tasks = await response.Content.ReadAsAsync<EmployeeTask[]>();
        }
        return tasks;
    }

    private async Task RunAsync()
    {
        client.BaseAddress = new System.Uri("http://localhost:3000/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );

        try
        {
            tasks = await GetEmployeeTasksAsync();
            foreach(var task in tasks)
            {
                Debug.Log(task.ToString());
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
