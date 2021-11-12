using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    GameObject projectileParent;

    public GameObject arrow;
    // public GameObject projectileParticles;
    public GameObject shootPosition;
    AttackerSpawner myLaneSpawner;
    Animator anim;

    private void Start()
    {
        SetLaneSpawner();
        anim = GetComponent<Animator>();
        CreateProjectileParent();
    }

    public void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
            return true;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(arrow, shootPosition.transform.position, transform.rotation) as GameObject;
        // Instantiate(projectileParticles, shootPosition.transform.position, transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
