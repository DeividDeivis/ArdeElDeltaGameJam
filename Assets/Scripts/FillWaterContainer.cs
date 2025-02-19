using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillWaterContainer : MonoBehaviour
{
    bool isfilling = false;
    [HideInInspector]
    public Health health;
    // Start is called before the first frame update
    private void Awake()
    {
        health = GetComponent<Health>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isfilling)
        {
            health.Heal(Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="River")
        {
            isfilling = true;
        }
        if (collision.gameObject.tag =="Fire")
        {
            if (health.Currentlife >=1)
            {
                
                health.RecieveDamage(1);
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "River")
        {
            isfilling = false;
        }
        
    }
}
