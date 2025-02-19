using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public float daño;
    public float tiempoVida;
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.up * velocidad;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Destroy(gameObject, tiempoVida); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Fire"){
            other.GetComponent<FireAI>().vidaFire -= daño;
            Destroy(gameObject);
        }
    }
}
