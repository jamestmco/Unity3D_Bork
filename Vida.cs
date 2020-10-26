using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Slider preenchimento;

    public void DefinirHPMaxima(int vida)
    {
        preenchimento.maxValue = vida;
        preenchimento.value = vida;
    }

    public void DefinirHP(int vida)
    {
        preenchimento.value = vida;
    }
}
