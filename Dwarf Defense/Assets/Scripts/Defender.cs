using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public int resourceCost = 100;

    public int getResourceCost() // Returns resource cost so that we can access it in other scripts
    {
        return resourceCost;
    }

    public void AddResources(int amount)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(amount);
    }
}
