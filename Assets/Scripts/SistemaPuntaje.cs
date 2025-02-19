using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SistemaPuntaje : MonoBehaviour
{
    public Image Carpincho, Pecari, Comadreja, AguaraGuazu, Lagarto, Ciervo, GatoMontes;   // Imagen mostrada en puntaje.
    public bool carpi, pecari, comadreja, aguara, lagarto, ciervo, gato;   // Rescatados?

    public Text Puntaje;
    public float puntajeAcumulada;

    public GameObject UI, GOScreen;


    public void GameOver(){
        UI.SetActive(false);
        GOScreen.SetActive(true);

        Puntaje.text = Mathf.Round(puntajeAcumulada).ToString();

        if(carpi)
            Carpincho.color = new Color32(255,255,255,255);
        if(pecari)
            Pecari.color = new Color32(255,255,255,255);
        if(comadreja)
            Comadreja.color = new Color32(255,255,255,255);
        if(aguara)
            AguaraGuazu.color = new Color32(255,255,255,255);
        if(lagarto)
            Lagarto.color = new Color32(255,255,255,255);
        if(ciervo)
            Ciervo.color = new Color32(255,255,255,255);
        if(gato)
            GatoMontes.color = new Color32(255,255,255,255);

        Time.timeScale = 0;
    }

    public void MenuPpal(){
        StartCoroutine(LoadScene());
        Time.timeScale = 1;
    }

    IEnumerator LoadScene(){
        Scene currentScene = SceneManager.GetActiveScene(); // Guarda la Escena activa Actualmente.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive); // Carga la NextScene en paralelo.

        while (!asyncLoad.isDone) {
            yield return null;      // Termina la rutina solo cuando se termino de cargar la nueva Escena.
        }
        SceneManager.UnloadSceneAsync(currentScene); // Deja de cargar la Escena anterior.
    }

    public void SalvarAnimal(string animal){
        switch(animal){
            case "carpincho": carpi = true; break;
            case "pecari": pecari = true; break;
            case "comadreja": comadreja = true; break;
            case "aguara": aguara = true; break;
            case "lagarto": lagarto = true; break;
            case "ciervo": ciervo = true; break;
            case "gato": gato = true; break;
            default: break;
        }
    }
}
