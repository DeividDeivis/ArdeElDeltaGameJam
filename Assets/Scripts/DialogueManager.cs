using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image avatar;
    public Text nombreText;
    public Text dialogText;

    public Animator DialogAnim;

    private Queue<string> sentences;

    public bool finDialogo = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void Dialogar(Dialogo dialogo){

        avatar.overrideSprite = dialogo.iconoAnimal;

        nombreText.text = dialogo.nombre;

        sentences.Clear();

        foreach(string sentence in dialogo.sentences){
            sentences.Enqueue(sentence);
        }

        StartCoroutine(CargarFrase());
    }

    IEnumerator CargarFrase(){
        DialogAnim.SetBool("Activo", true);
        Time.timeScale = 0;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        dialogText.text = sentence;

        while (finDialogo == false) {
            yield return null;
        }
    }

    public void FinConversar(){
        Time.timeScale = 1;
        DialogAnim.SetBool("Activo", false);
        finDialogo = true;
    }
}
