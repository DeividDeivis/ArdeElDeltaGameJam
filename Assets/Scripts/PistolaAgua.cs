using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class PistolaAgua : MonoBehaviour
{
    public bool Pistola = false;
    public float Carga;
    public Image CargaUI;
    public GameObject PistolaUI;

    public string path;

    public bool EnAgua;

    public GameObject particulaAgua;
    public GameObject Player;
    public float playerX;
    public float playerY;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        playerX = Input.GetAxisRaw("Horizontal");    
        playerY = Input.GetAxisRaw("Vertical");   
    }

    void FixedUpdate() {
        if(Pistola){
            CargaUI.fillAmount = Carga / 100;
            GetComponent<Animator>().SetBool("PistolaAgua", true);
            GetComponent<Animator>().SetBool("Nadando", EnAgua);

            if(Input.GetButton("Fire1") && Carga > 0){
                if(!EnAgua){
                    Player.GetComponent<DirectionMovement8>().enabled = false;

                    if(playerX == 1){
                        Instantiate(particulaAgua, Player.GetComponent<Transform>().position, Quaternion.Euler(0,0,-90));
                    }else if(playerX == -1){
                        Instantiate(particulaAgua, Player.GetComponent<Transform>().position, Quaternion.Euler(0,0,90));
                    }else if(playerY == 1){
                        Instantiate(particulaAgua, Player.GetComponent<Transform>().position, Quaternion.Euler(0,0,0));
                    }else if(playerY == -1){
                        Instantiate(particulaAgua, Player.GetComponent<Transform>().position, Quaternion.Euler(0,0,180));
                    }
                    
                    if(playerX != 0 || playerY != 0){
                        Carga -= 1;
                        GetComponent<Animator>().SetTrigger("Disparo");
                        GetComponent<Animator>().SetFloat("X", playerX);
                        GetComponent<Animator>().SetFloat("Y", playerY);
                    }
                    
                }
            }

            if(Input.GetButton("Fire1") && EnAgua){
                Carga += 1;
            }

            Player.GetComponent<DirectionMovement8>().enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {

        switch(other.tag){
            case "PistolaAgua" : 
                Pistola = true;
                PistolaUI.SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
                Destroy(other.gameObject);
                break;

            case "River" : 
                EnAgua = true;
                break;

            case "Suelo" : 
                EnAgua = false;
                break;
        }
    }

    /*private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "River")
            EnAgua = false;
    }*/
}
