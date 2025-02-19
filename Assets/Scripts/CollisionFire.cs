using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFire : MonoBehaviour
{
    public DirectionMovement8 obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            DisableScript.DisableForSeconds(obj, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
