using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public string NextScene;
    private bool Inicio = false;

    public void Iniciar()
    {
        if(Inicio == false)
            StartCoroutine(LoadScene());
    }

    public void Salir(){
        Application.Quit();
    }

    IEnumerator LoadScene() {
        Inicio = true;
        Scene currentScene = SceneManager.GetActiveScene(); // Guarda la Escena activa Actualmente.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NextScene, LoadSceneMode.Additive); // Carga la NextScene en paralelo.

        while (!asyncLoad.isDone) {
            yield return null;      // Termina la rutina solo cuando se termino de cargar la nueva Escena.
        }
        SceneManager.UnloadSceneAsync(currentScene); // Deja de cargar la Escena anterior.
    }
}
