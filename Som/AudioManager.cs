using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sonzito[] som;

    //public GameObject elVideo;

    void Awake()
    {
        foreach (Sonzito s in som)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            //s.source.clip = s.clip;
            //s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        /*if(SceneManager.GetActiveScene().buildIndex.ToString() == "2")
        {
            DontDestroyOnLoad(gameObject);
        }
        if(SceneManager.GetActiveScene().buildIndex.ToString() == "4")
        {
            Destroy(gameObject);
        }*/

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void Start()
    {
        foreach (Sonzito s in som)
        {
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    } 

    public void Update()
    {
/*        elVideo = GameObject.FindGameObjectWithTag("VideoSecreto");

        if (elVideo.activeInHierarchy == true)
        {
            AudioListener.pause = true;
        }
        else if(elVideo.activeInHierarchy == false)
        {
            AudioListener.pause = false;
        }*/
    }

    public void Toca (string name)
    {
        Sonzito s = Array.Find(som, sonzito => sonzito.name == name);
        s.source.Play /*Toca*/();
    }

    public void Para(string name)
    {
        Sonzito s = Array.Find(som, sonzito => sonzito.name == name);
        s.source.Stop();
    }

    void OnSceneLoaded(Scene cena, LoadSceneMode modo)
    {
        Debug.Log("Estou aqui" + SceneManager.GetActiveScene().buildIndex.ToString());
        /*if(SceneManager.GetActiveScene().buildIndex.ToString() == "3")
        {
            Debug.Log("Para em nome da lei");
            Para("Gameplay");
        }*/
        if(SceneManager.GetActiveScene().buildIndex.ToString() == "3")
        {
            //StartCoroutine(CalmaAi);
        }

        if (SceneManager.GetActiveScene().buildIndex.ToString() == "2")
        {
            Toca("Gameplay");
        }
        else if (SceneManager.GetActiveScene().buildIndex.ToString() == "0")
        {
            Toca("Início");
        }
    }
}
