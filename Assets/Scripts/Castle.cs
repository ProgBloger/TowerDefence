using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] int playerLife = 10;
    [SerializeField] int damageCount = 1;
    [SerializeField] Text textHP;
    [SerializeField] AudioClip castleDamage;
    AudioSource audioSource;

    void Start(){
        textHP.text = playerLife.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    public void DamageCastle()
    {
        audioSource.PlayOneShot(castleDamage);
        playerLife -= damageCount;
        textHP.text = playerLife.ToString();
    }
    
}
