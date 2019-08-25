using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void bt_Iniciar()
    {
        SceneManager.LoadScene("Fase 1");
    }

    public void bt_Quit()
    {
        Application.Quit();
    }
}
