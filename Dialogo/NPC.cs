using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogo dialogo;

    private void Start()
    {
        ativaDialogo();
    }

    public void ativaDialogo()
    {
        FindObjectOfType<ManagerDialogo>().iniciaDialogo(dialogo);
    }
}
