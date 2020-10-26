using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //AQUI

public class EditeVida : MonoBehaviour
{
    public int vidaTotal = 100;
    public int vidaAtual;
    public Vida vida;
    public AudioClip punch;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaTotal;
        vida.DefinirHPMaxima(vidaTotal);
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = punch;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SofreDanos(10);
        }
    }*/

    void Update() //DAQUI
    {
        if(vidaAtual <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            FindObjectOfType<AudioManager>().Toca("Game Over");
        }
    } //ATÉ AQUI

    public void SofreDanos(int danos)
    {
        vidaAtual -= danos;
        GetComponent<AudioSource>().Play();

        vida.DefinirHP(vidaAtual);
        
    }
}
