using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float drop = 20f;

    public void TakeDamage (float amount)
    {
        drop -= amount;
        if (drop<= 0f)
        {
            Go();
        }
    }

    void Go ()
    {
        Destroy(gameObject);
    }   
}
