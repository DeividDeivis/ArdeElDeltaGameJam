using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class humo : MonoBehaviour
{
    public float velocidadHumo; // velocidad con la que se achica la visibilidad.

    public RectTransform Humo;

    public bool gameover = false; 
    [SerializeField] public string NextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 theScale = transform.localScale;
		theScale.x -= 1/velocidadHumo;
        theScale.y -= 1/velocidadHumo;
        transform.localScale =  theScale;

        if(theScale.x <= 0 || theScale.y <= 0){
            if(gameover == false){
                FindObjectOfType<SistemaPuntaje>().GameOver();
            } 
            gameover = true;
        }

        Humo.localPosition += Vector3.left * 0.1f;
    }
}
