using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace malvra
{
    public class LoginButtonFactory : MonoBehaviour
    {
        public GameObject BaseButton;

        private Employee[] employees;

        void Start()
        {
            try
            {
                //employees = await ServerCaller.GetEmployeesAsync();
                employees = ServerCaller.GetEmployees();
                float x = 0;
                float y = 0;
                float z = 0.3f;
                int n = 0;
                foreach (var employee in employees)
                {
                    GameObject corteButton = Instantiate(BaseButton, new Vector3(x, y, z), Quaternion.identity) as GameObject;
                    UpdateText(employee, corteButton);
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

        private void UpdateText(Employee employee, GameObject button)
        {
            TMP_Text buttonText = button.transform.GetChild(4).GetComponentInChildren<TMP_Text>();
            buttonText.text = employee.username;
        }
    }
}
