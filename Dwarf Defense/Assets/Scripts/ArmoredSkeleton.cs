using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredSkeleton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;

        if(otherObj.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObj);
        }
    }
}
