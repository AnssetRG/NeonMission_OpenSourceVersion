using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    public GameObject currentCheckPoint;


    public GameObject deathParticle;
    public GameObject respawnParticle;

    private CameraController cameras;

    public int PointPenaltyOnDeath;
    public float respawnDelay;

    public HealthManager healthManager;

    private float gravityStore;
	// Use this for initialization

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

	void Start () {
        cameras = FindObjectOfType<CameraController>();
        healthManager = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer(PlayerController player)
    {
        StartCoroutine(RespawnPlayerCo(player));
    }

    public IEnumerator RespawnPlayerCo(PlayerController player)
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<CircleCollider2D>().enabled = false;
        cameras.IsFollowing = false;GetComponent<Rigidbody2D>();
        ScoreManager.AddPoints(-PointPenaltyOnDeath);
        //Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        player.GetComponent<CircleCollider2D>().enabled = true;
        player.knockBackCount = 0f;
        player.prepara = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = currentCheckPoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.fullHealth();
        //player.isDead = false;
        cameras.IsFollowing = true;
        Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
        
    }

    
}
