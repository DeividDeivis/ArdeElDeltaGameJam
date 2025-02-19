using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoDialogo : MonoBehaviour 
{
    public Dialogo dialogo;

    public void TriggerDialogo(){
        FindObjectOfType<DialogueManager>().Dialogar(dialogo);
        Destroy(gameObject,0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
            TriggerDialogo();
    }
}
