using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    public GameObject deathVFX;
    public GameObject gameObjectWithSR;

    public float damageColorDelay = 0.5f;

    private void Start()
    {
        health *= PlayerPrefsController.GetDifficultyMultiplier();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(ColorCo());
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) // Checks if the deathVfX object is not set to null to prevent bugs
            return;
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }

    IEnumerator ColorCo() // Having issues finding the Sprite Renderer with gameObjects that have a Body
    {
        if (GetComponent<Attacker>())
        {
            gameObjectWithSR.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(damageColorDelay);
            gameObjectWithSR.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
