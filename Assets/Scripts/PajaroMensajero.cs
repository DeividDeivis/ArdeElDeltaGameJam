using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PajaroMensajero : MonoBehaviour
{
    public Image avatar;
    public Text nombreText;
    public Text dialogText;

    public Animator DialogAnim;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void Dialogar(Dialogo dialogo){

        DialogAnim.SetBool("Activo", true);

        avatar.overrideSprite = dialogo.iconoAnimal;

        nombreText.text = dialogo.nombre;

        sentences.Clear();

        foreach(string sentence in dialogo.sentences){
            sentences.Enqueue(sentence);
        }

        StartCoroutine(SiguienteFrase());
    }

    IEnumerator SiguienteFrase(){
       

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Carga_Texto(sentence));

        while (!Input.GetKey(KeyCode.Space)) {
            yield return null;
        }
    }

    IEnumerator Carga_Texto(string sentence) {      
        dialogText.text = "";

        foreach (char letter in sentence.ToCharArray()) {
            dialogText.text += letter;
            yield return null;
        }
        yield return null;     
    }

   public void FinConversar(){
       DialogAnim.SetBool("Activo", false);
   }
}
