using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] int playerLife = 10;
    [SerializeField] int damageCount = 1;
    [SerializeField] Text textHP;

    void Start(){
        textHP.text = playerLife.ToString();
    }

    public void DamageCastle()
    {
        playerLife -= damageCount;
        textHP.text = playerLife.ToString();
    }
    
}
