using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void NewGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void CreditButton(){
        Application.OpenURL("https://github.com/OptimusDrift/IA_Integrador_MATUSITA");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
