using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using TMPro;

namespace malvra
{
    public class ButtonFactory : MonoBehaviour
    {
        public GameObject CorteButton;
        public GameObject SiembraEnBancaButton;
        public GameObject SiembraEnCamaButton;
        public GameObject DesbotonarButton;

        public static string employeeId = "1234";

        private EmployeeTask[] tasks;

        // Start is called before the first frame update
        async void Start()
        {
            try
            {
                await GetTasksAsync(employeeId);
                float x = 0;
                float y = 0;
                float z = 0.3f;
                int n = 0;
                foreach (var task in tasks)
                {
                    if (task.task.Equals("Desbotonar"))
                    {
                        GameObject desbotonarButton = Instantiate(DesbotonarButton, new Vector3(x, y, z), Quaternion.identity) as GameObject;
                        UpdateText(task, desbotonarButton);
                    }
                    else if (task.task.Equals("Siembra en Banca"))
                    {
                        GameObject siembraEnBancaButton = Instantiate(SiembraEnBancaButton, new Vector3(x, y, z), Quaternion.identity) as GameObject;
                        UpdateText(task, siembraEnBancaButton);
                    }
                    else if (task.task.Equals("Siembra en Cama"))
                    {
                        GameObject siembraEnCamaButton = Instantiate(SiembraEnCamaButton, new Vector3(x, y, z), Quaternion.identity) as GameObject;
                        UpdateText(task, siembraEnCamaButton);
                    }
                    else // Corte
                    {
                        GameObject corteButton = Instantiate(CorteButton, new Vector3(x, y, z), Quaternion.identity) as GameObject;
                        UpdateText(task, corteButton);
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

                TMP_Text employeeName = GetComponentInChildren<TMP_Text>();
                employeeName.text = tasks[0].employee_name + " estas son tus tareas para el día de hoy:";
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

        private async Task GetTasksAsync(string employeeId)
        {
            tasks = await ServerCaller.GetEmployeeTasksAsync(employeeId);
        }
        private void UpdateText(EmployeeTask task, GameObject button)
        {
            DateTime date = DateTime.Parse(task.date);

            TMP_Text buttonText = button.transform.GetChild(4).GetComponentInChildren<TMP_Text>();
            buttonText.text = buttonText.text + "\nBloque: " + task.block + "\n" + date.ToString("hh:mm tt");
        }
    }
}
