using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteVideoTiraSom : MonoBehaviour
{
    public GameObject video;
    public GameObject camaraVideo;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.pause = false;
        
        if(video.activeInHierarchy == true)
        {
            AudioListener.pause = true;
        }
    }

    public void SaltaVideo()
    {
        Destroy(video);
        Destroy(camaraVideo);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
