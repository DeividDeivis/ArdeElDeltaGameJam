using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    
    public const int initialvalue = 10000;
    public float currentvalue;
    
    public int seconds;
    public event Action OnSecondPass;
    public event Action OnTimeToDie;
    bool dead = false;

    public const int timetodie = 2;
    public bool triggersec = true;
    public float DamagexSecond => initialvalue/timetodie;

    private void Awake()
    {
        currentvalue = initialvalue;
        OnSecondPass += ScoreController_OnSecondPass;
    }
    private void OnDisable()
    {
        OnSecondPass -= ScoreController_OnSecondPass;
    }

    private void ScoreController_OnSecondPass()
    {
        currentvalue -= Mathf.FloorToInt(DamagexSecond);
        print(currentvalue.ToString());
    }

    public async void TriggerEventFor1Sec()
    {
        if (seconds < timetodie)
        {
            triggersec = false;
            await Task.Delay(TimeSpan.FromSeconds(1));
            seconds += 1;
            OnSecondPass();
            triggersec = true;
        }
        else
        {
            triggersec = false;
        }

        
        
    }
    void Update()
    {
        if (triggersec)
        {
            TriggerEventFor1Sec();
        }
    }
}
