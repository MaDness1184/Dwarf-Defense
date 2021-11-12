using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        
        if(otherObj.GetComponent<Barricade>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (otherObj.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObj);
        }
    }
}
