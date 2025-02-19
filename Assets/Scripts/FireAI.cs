using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAI : MonoBehaviour
{
    public float vidaFire = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 theScale = transform.localScale;
		theScale.x = vidaFire/10f;
        theScale.y = vidaFire/10f;
        transform.localScale =  theScale;

        if(vidaFire <= 0){
            Destroy(gameObject);
        }
    if(vidaFire < 10)
        vidaFire += 0.01f;
    }
}
