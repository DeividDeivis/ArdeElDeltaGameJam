using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogo
{
   public Sprite iconoAnimal;
   public string nombre;
   [TextArea(3, 10)]
   public string[] sentences;
}
