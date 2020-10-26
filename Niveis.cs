using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Niveis : MonoBehaviour
{
    public GameObject canvasFade;
    public Image fadeInOut;

    /*    static bool holograma1;
        static bool holograma2;
        static bool videosecreto;

        public GameObject videoA;
        public GameObject videoB;*/

    public AudioClip porta;

    public void Start()
    {
        canvasFade.SetActive(true);
        fadeInOut.canvasRenderer.SetAlpha(1f);
        fadeIO();

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = porta;
        DontDestroyOnLoad(porta);
        /*holograma1 = false;
        holograma2 = false;
        videosecreto = false;*/
    }

       public void fadeIO()
       {
            fadeInOut.CrossFadeAlpha(0f, 2f, false);
       }

        /*public void OnTriggerEnter(Collider colisao)
        {
            if (SceneManager.GetActiveScene().buildIndex != 1)
            {
                StartCoroutine(EsperaFade());
            }
        }*/

        IEnumerator EsperaFade()
        {
            GetComponent<AudioSource>().Play();
            fadeInOut.CrossFadeAlpha(1f, 1f, false);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            fadeInOut.CrossFadeAlpha(0f, 1f, false);
            yield return new WaitForSeconds(2f);
        }

    public void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 7 || SceneManager.GetActiveScene().buildIndex == 9)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OnTriggerEnter(Collider colisao)
    {
        //GetComponent<AudioSource>().Play();

        StartCoroutine(EsperaFade());

        CenaSeguinte();
    }
    
    public void CenaSeguinte()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            GetComponent<AudioManager>().Toca("Porta");
        }

        /*if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }*/
    }

    public void CenaSeguinteVideos()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DeVolta()
    {
        if(SceneManager.GetActiveScene().buildIndex == 9)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);

        }
        if(SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
        }
    }

    public void SairJogo()
    {
        Application.Quit();
    }

}
