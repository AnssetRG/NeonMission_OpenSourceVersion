using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganar : MonoBehaviour {

    private SpriteRenderer myS;
    public Sprite nwS1;
    public Sprite nwS2;
    Sprite temp;

    bool finish;

    int ganar, necesario;
	// Use this for initialization
	void Start () {
        myS = GetComponent<SpriteRenderer>();
        temp = myS.sprite;
        ganar = 2;
        necesario = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
        if(necesario == ganar)
        {
            //youWin.SetActive(true);
            //Debug.Log("Ganaste");
            myS.sprite = nwS2;
            finish = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other1)
    {
        if(other1.tag == "Player" && !finish)
        {
            necesario = necesario + 1;
            myS.sprite = nwS1;
        }
    }
    void OnTriggerExit2D(Collider2D other1)
    {
        if (other1.tag == "Player" && !finish)
        {
            necesario = necesario - 1;
            myS.sprite = temp;

        }
    }
}
