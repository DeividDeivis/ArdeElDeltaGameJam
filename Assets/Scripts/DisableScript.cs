using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DisableScript : MonoBehaviour
{
    public static async void  DisableForSeconds(MonoBehaviour obj, int second) {
        obj.enabled = false;
        await Task.Delay(TimeSpan.FromSeconds(second));
        obj.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
