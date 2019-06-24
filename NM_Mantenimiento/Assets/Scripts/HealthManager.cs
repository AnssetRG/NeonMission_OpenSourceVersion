using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;
    public int playerHealth;

    Text text;

    //private LevelManager levelManager;

    public bool isDead;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        //levelManager = FindObjectOfType<LevelManager>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0 && !isDead)
        {
            //levelManager.RespawnPlayer();
            isDead = true;
        }

        text.text = "" + playerHealth;
    }

    public void hurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
        if(playerHealth <=0)
            playerHealth = 0;
    }

    public void fullHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
