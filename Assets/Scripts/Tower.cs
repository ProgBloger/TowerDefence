using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform towerTop;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float shootRange;
    [SerializeField] ParticleSystem bulletParticles;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        bool enemyIsAlive = targetEnemy;
        if(enemyIsAlive)
        {
            Aim();
            Fire();
        }
        else
        {
            Shoot(enemyIsAlive);
        }
    }

    // Choose the nearest enemy
        void SetTargetEnemy()
        {
            // Get all enemies
            var sceneEnemies = FindObjectsOfType<EnemyDamage>();
            
            if(sceneEnemies.Length == 0)
            { return; }
            // Find nearest enemy
            var closest = sceneEnemies[0].transform;
            foreach(var ed in sceneEnemies)
            {
                // Compare all the enemies and choose the nearest
                closest = GetClosestEnemy(closest.transform, ed.transform);
            }

            // Return the nearest enemy as target
            targetEnemy = closest;
        }

    private Transform GetClosestEnemy(Transform enemy1, Transform enemy2)
    {
        var distTo1 = Vector3.Distance(enemy1.position, transform.position);
        var distTo2 = Vector3.Distance(enemy2.position, transform.position);

        if(distTo1 < distTo2)
        {
            return enemy1;
        }
        return enemy2;
    }

    private void Aim()
    {
        Vector3 lookPos = targetEnemy.position - towerTop.position;
        var lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        var eulerY = lookRot.eulerAngles.y;

        var rotation = Quaternion.Euler(0, eulerY, 0);

        towerTop.rotation = rotation;
    }

    private void Fire()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);
        bool toShootOrNotToShoot = distanceToEnemy <= shootRange;
        Shoot(toShootOrNotToShoot);
    }

    private void Shoot(bool isActive)
    {
        var em = bulletParticles.emission;
        em.enabled = isActive;
        
    }
}
