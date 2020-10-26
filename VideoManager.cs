using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public /*static*/ bool holograma1;
    public /*static*/ bool holograma2;
    public /*static*/ bool videosecreto;
    //public GameObject holo1;
    public GameObject video;
    public GameObject audioVideo;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        holograma1 = false;
        holograma2 = false;
        videosecreto = false;
    }

    public void Update()
    {
        //holo1 = GameObject.FindGameObjectWithTag("Holo1");

        /*if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if(holo1 == null)
            holograma1 = true;
        }*/
        /*if(GetComponent<Holograma>().holo1 == true)
        {
            holograma1 = true;
        }

        if (GetComponent<Holograma>().holo2 == true)
        {
            holograma2 = true;
        }
        if (GetComponent<CameraVideo>().video == true)
        {
            videosecreto = true;
        }*/
    }

    public void Final()
    {
        if (holograma1 == true && holograma2 == true && videosecreto == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
    }
}
