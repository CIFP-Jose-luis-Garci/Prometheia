using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelMuerte : MonoBehaviour
{
    public GameObject muertoPanel;



    // Start is called before the first frame update
    void Start()
    {
        muertoPanel.SetActive(false);
    }

    public void controlPanel()
    {
        if (muertoPanel.activeSelf)
        {
            muertoPanel.SetActive(false);
        } else
        {
            muertoPanel.SetActive(true);
        }
    }
    public void goMenu()
    {
        SceneManager.LoadScene("UI");
    }
    public void goJugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("escenariosPasillo");
    }
    public void goSalir()
    {
        Application.Quit();
    }
}
