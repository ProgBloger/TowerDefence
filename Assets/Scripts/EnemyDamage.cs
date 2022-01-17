using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem deathParticles;
    
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            DestroyEnemy();
        }
    }

    private void ProcessHit()
    {
        hitParticles.Play();
        hitPoints -= 1;
        Debug.Log(hitPoints + " left");
    }

    private void DestroyEnemy()
    {
        var destroyFX = Instantiate(deathParticles, transform.position, Quaternion.identity);
        destroyFX.Play();
        Destroy(gameObject);
    }
}
