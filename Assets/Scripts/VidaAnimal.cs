using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaAnimal : MonoBehaviour
{
    public string animal;
    public float puntajeMaximo, puntaje;

    public float targetTime = 0.0f;
    private float TiempoVida;
    public Image Corazon;

    // Start is called before the first frame update
    void Start()
    {
        TiempoVida = targetTime;
        puntaje = puntajeMaximo;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime = targetTime - Time.deltaTime; 

        float Porcentaje = 1 / TiempoVida;

        float PorPuntaje = puntajeMaximo / TiempoVida;

        if (Corazon.fillAmount != 0)
            Corazon.fillAmount -= Porcentaje * Time.deltaTime;

        if (puntaje > 0)
            puntaje -= PorPuntaje * Time.deltaTime;

        if(targetTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            FindObjectOfType<SistemaPuntaje>().puntajeAcumulada += puntaje;
            FindObjectOfType<SistemaPuntaje>().SalvarAnimal(animal);
        }       
    }
}
