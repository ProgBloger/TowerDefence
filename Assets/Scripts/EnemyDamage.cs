using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem castleDamageParticles;
    [SerializeField] Text scoreText;
    int currentScore;
    
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            DestroyEnemy(deathParticles);
            CountFrag();
        }
    }

    private void ProcessHit()
    {
        hitParticles.Play();
        hitPoints -= 1;
        Debug.Log(hitPoints + " left");
    }

    public void BlowUpCastle()
    {
        DestroyEnemy(castleDamageParticles);
    }

    private void CountFrag()
    {
        currentScore = int.Parse(scoreText.text);
        currentScore++;
        scoreText.text = currentScore.ToString();
    }

    public void DestroyEnemy(ParticleSystem fx)
    {
        var vector = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        var destroyFX = Instantiate(fx, vector, Quaternion.identity);
        destroyFX.Play();

        float destroyFX_Duration = destroyFX.main.duration;
        Destroy(destroyFX.gameObject, destroyFX_Duration);
        Destroy(gameObject);
    }
}
