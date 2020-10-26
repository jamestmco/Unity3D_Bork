using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogo
{
    public string nome;

    [TextArea(1, 4)]
    public string[] frases;
}
