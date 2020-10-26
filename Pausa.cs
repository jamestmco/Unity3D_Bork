using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static bool jogoPausado = false;
    public GameObject menuPausa;
    public GameObject menuOpcoes;
    public GameObject menuControlo;
    public GameObject menuVolume;
    private GameObject dialogo;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (menuPausa.activeInHierarchy == false && menuOpcoes.activeInHierarchy == false && menuControlo.activeInHierarchy == false && menuVolume.activeInHierarchy == false) 
            { 
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (jogoPausado)
                    {
                        RetomarJogo();
                    }
                    else
                    {
                        Pausar();
                    }
                }
            }
        }

        dialogo = GameObject.FindGameObjectWithTag("Dialogo");

        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (dialogo.activeInHierarchy == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void RetomarJogo()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        jogoPausado = false;
        AudioListener.pause = false;
    }

    public void Pausar()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        jogoPausado = true;
        AudioListener.pause = true;
    }

    public void SairJogo()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            AudioListener.pause = false;
            Destroy(menuPausa);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            AudioListener.pause = false;
            Destroy(menuPausa);
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
            AudioListener.pause = false;
            Destroy(menuPausa);
        }
    }
}
