using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 1f)] public float currentSpeed = 0.7f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController lvlContrl = FindObjectOfType<LevelController>();
        if(lvlContrl != null)
            lvlContrl.AttackerKilled();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime); // Moves the character to the left every frame of Update
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void setMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void strikeCurrentTarget(float damage)
    {
        if (!currentTarget)
            return;
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        { 
            health.DealDamage(damage);
        }
    }
}
