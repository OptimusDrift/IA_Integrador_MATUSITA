using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wining : MonoBehaviour
{
    public GameObject win;
   void OnTriggerEnter(Collider other)
   {
    if (win.GetComponent<Win>().win)
    {
        Application.OpenURL("https://github.com/OptimusDrift/IA_Integrador_MATUSITA");
        SceneManager.LoadScene("Menu");
    }
   }
}
