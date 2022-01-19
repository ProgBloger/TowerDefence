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
    AudioSource audioSource;
    [SerializeField] AudioClip hitEnemySoundFx;
    [SerializeField] AudioClip deathEnemySoundFX;
    Vector3 targetPosition;
    
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(hitEnemySoundFx);
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

        AudioSource.PlayClipAtPoint(deathEnemySoundFX, Camera.main.transform.position);
        Destroy(destroyFX.gameObject, destroyFX_Duration);
        Destroy(gameObject);
    }

    void Update()
    {

    }
}
