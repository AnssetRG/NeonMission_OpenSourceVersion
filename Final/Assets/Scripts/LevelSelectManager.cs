using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour {


    public CircleCollider2D myRigidBodyCircle;
    private Rigidbody2D myrigidbody2D;
    private int level;
    public bool setLvl1;
    public bool setLvl2;
    public bool setLvl3;
    public bool setLvl4;
    private float move;
    private int contX;
    private int contY;
    private bool presionado;

    public string[] levelName;

    public Image black;
    public Animator anim;
    private bool isPressed;

    void Start()
    {
        level = 0;
        myRigidBodyCircle = GetComponent<CircleCollider2D>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
        contX = 0;
        contY = 0;
        presionado = false;
        setLvl1=true;
        setLvl2=false;
        setLvl3=false;
        setLvl4=false;
        myrigidbody2D.transform.position = new Vector2(-7,0);
    }

    void Update()
    {

        if (!presionado)
        {
            if (Input.GetAxis("Vertical_Select") < -0.15f)
            {
                contY++;
                if (contY >= 1)
                {
                    contY = 1;
                }
                presionado = true;

            }
            if (Input.GetAxis("Vertical_Select") > 0.15f)
            {
                contY--;
                if (contY <= 0)
                {
                    contY = 0;
                }
                presionado = true;
            }
            if (Input.GetAxis("Horizontal_Select") < -0.15f)
            {
                contX--;
                if (contX <=0)
                {
                    contX = 0;
                }
                presionado = true;

            }
            if (Input.GetAxis("Horizontal_Select") > 0.15f)
            {
                contX++;
                if (contX >=1 )
                {
                    contX = 1;
                }
                presionado = true;

            }
         }
        if (presionado)
        {
            if (((Input.GetAxis("Vertical_Select") > -0.15 && Input.GetAxis("Vertical_Select") < 0.15f)) || ((Input.GetAxis("Horizontal_Select") > -0.15 && Input.GetAxis("Horizontal_Select") < 0.15f)))
            {
                presionado = false;
            }
        }
        if(contX == 0 && contY == 0)
        {
            setLvl1 = true;
            setLvl2 = false;
            setLvl3 = false;
            setLvl4 = false;
            myrigidbody2D.transform.position = new Vector2(-7, 0);
            level = 0;
        }
        if (contX == 0 && contY == 1)
        {
            setLvl1 = false;
            setLvl2 = true;
            setLvl3 = false;
            setLvl4 = false;
            myrigidbody2D.transform.position = new Vector2(-7, -2.5f);
            level = 1;
        }
        if (contX == 1 && contY == 0)
        {
            setLvl1 = false;
            setLvl2 = false;
            setLvl3 = true;
            setLvl4 = false;
            myrigidbody2D.transform.position = new Vector2(0, 0);
            level = 2;
        }
        if (contX == 1 && contY == 1)
        {
            setLvl1 = false;
            setLvl2 = false;
            setLvl3 = false;
            setLvl4 = true;
            myrigidbody2D.transform.position = new Vector2(0, -2.5f);
            level = 3;
        }
        if (Input.GetButtonDown("Select"))
        {
            StartCoroutine(IniciarNivel(level));
        }
    }


    IEnumerator IniciarNivel(int level)
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(levelName[level]);
    }
}
