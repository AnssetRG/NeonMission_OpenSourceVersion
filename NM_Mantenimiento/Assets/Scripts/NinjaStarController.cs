using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{

    public float speed;

    public PlayerController player;

    public GameObject enemyDeathEffect;

    public GameObject impactEffect;

    public int pointsForKill;

    public float rotationSpeed;

    public int damageToGive;

    private Rigidbody2D ballRGB;

    // Use this for initialization
    void Start()
    {
        ballRGB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ballRGB.velocity = new Vector2(speed * transform.localScale.x, ballRGB.velocity.y);

        ballRGB.angularVelocity = rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            /*Instant Destroy
            Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ScoreManager.AddPoints(pointsForKill);*/
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);

        }
        Instantiate(impactEffect, other.transform.position, other.transform.rotation);
        Destroy(gameObject);
    }
}