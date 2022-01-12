using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        DestroyEnemy();
    }

    private void ProcessHit()
    {
        hitPoints -= 1;
        print($"Enemy got damage HP is {hitPoints}");
    }

    private void DestroyEnemy()
    {
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}