using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace malvra
{
    public class SceneChanger : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadDesbotonar()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadSiembraEnBanca()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadSiembraEnCama()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadCorte()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadCalendar()
        {
            SceneManager.LoadScene(2);
        }
    }
}
