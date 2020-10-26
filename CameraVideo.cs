using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;

public class CameraVideo : MonoBehaviour
{
    public GameObject videoSecreto;
    public GameObject camaraVideo;
    public bool video;

    void Start()
    {
        camaraVideo.SetActive(true);
        videoSecreto.SetActive(false);
        video = false;
    }


    void OnTriggerEnter(Collider colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            FindObjectOfType<VideoManager>().videosecreto = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            video = true;
            videoSecreto.SetActive(true);
            Destroy(videoSecreto, 66f);
            Destroy(camaraVideo);
        }

        if (videoSecreto.activeInHierarchy == true)
        {
            Debug.Log("Estou a ver um video");
            FindObjectOfType<AudioManager>().Para("Gameplay");
        }
    }

    void OnTriggerExit(Collider colisao)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
