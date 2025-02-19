using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyHealthEvent : UnityEvent<int, Vector3>
{
}

//no permite vida menos de 0b
public class Health : MonoBehaviour
{
    public float life;
    public float Currentlife;

    public event Action<float> OnBeingHealed;
    public event Action<float> OnBeingAttacked;
    public event Action OnUpgrade;
    public event Action OnNoHealth;
    public event Action OnBeingInitialize;
    public MyHealthEvent OnBeingAtacked;

    public bool initializeEmpty;
    public void Start()
    {
        OnBeingHealed += Health_OnBeingHealed;
        if (!initializeEmpty)
        {
            Currentlife = life;
        }
        
    }
    private void OnDisable()
    {
        OnBeingHealed -= Health_OnBeingHealed;
    }

    private void Health_OnBeingHealed(float obj)
    {
        //5.1
        //4.9
        //5-4 =1
        if (Mathf.FloorToInt(Currentlife+obj)- Mathf.FloorToInt( Currentlife)  ==1 )
        {
            print("subio 1");
        }
    }

    public void Initialize(int life)
    {
        Currentlife = this.life = life;
        OnBeingInitialize?.Invoke();
    }
    private void AddPermanentLife(int amount)
    {
        life += amount;
        Currentlife += amount;
    }

    public void Heal(float amount)
    {
        OnBeingHealed?.Invoke(amount);
        Currentlife += amount;
        if (Currentlife > life)
        {
            Currentlife = life;
        }
        
    }

    public void RecieveDamage(int amount)
    {
        Currentlife -= amount;
        OnBeingAtacked?.Invoke(amount, transform.position);
        OnBeingAttacked?.Invoke(amount);
        if (Currentlife <= 0)
        {
            Currentlife = 0;
            OnNoHealth?.Invoke();
        }
    }

    public void Upgrade(int value)
    {
        life += value;
        Currentlife += value;
    }
}
