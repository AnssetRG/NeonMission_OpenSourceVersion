using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    public float jumpHeight;
    private float moveVelocity;

    public AudioSource trampolin;
    //private float moveVelocity;
    //private float fallVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
    public bool plataformed;

    //private bool doubleJumped;

    public CircleCollider2D myC;
    public BoxCollider2D myB;

    private Animator anim;

    public Transform firePoint;
    public GameObject ninjaStar;

    public float shotDelay;
    private float shotDelayCounter;

    public float knockBack;
    public float knockBackLength;
    public float knockBackCount;
    public bool knockFromRight;
    public bool JumpOther;


    public string horizontalMove = "Horizontal_P1";
    public string verticalMove = "Vertical_P1";
    public string jumpButton = "Jump_P1";
    public string carryButton = "Carry_P1";
    public string prepareButton = "Prepare_P1";
    public string downButton = "Down_P1";

    public int maxPlayerHealth;
    public int playerHealth;
    public bool isDead;

    private Rigidbody2D myrigidbody2D;

    //public string player;
    
    private float moveStore;

    //Empujar
    public float distance = 0.55f;
    public LayerMask boxMask;
    public LayerMask PlayerMask;

    public bool pushed;
    GameObject box;
    GameObject tracar;

    //Escalera
    public bool climbed;
    public bool apoyer; 
    public bool ladder;
    public bool trepar;
    public bool movil;
    public bool noY;
    public float climbSpeed;
    private float gravityStore;

    public float velocityAd;

    //PataGallo
    public bool prepara;
    public bool preparaC;
    //Ocupado
    public bool ready;
    public bool hard;
    public bool hard2;
    public bool right;
    public bool derecha;
    public bool walk;

    int c;
    void Start()
    {
        myC = GetComponent<CircleCollider2D>();

        myB = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
        playerHealth = maxPlayerHealth;
        gravityStore = myrigidbody2D.gravityScale;
        ready = true;
        hard = true;
        hard2 = true;
        apoyer = false;
        derecha = true;
        trepar = false;
        movil = false;
        prepara = false;
        preparaC = false;
        moveVelocity = 0f;
        velocityAd = 0f;
        moveStore = movespeed;
        JumpOther = false;
        walk = false;
        plataformed = false;
        myC.isTrigger = false;
        c = 0;
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        plataformed = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (grounded == false)
            grounded = plataformed;

        anim.SetBool("Grounded", grounded);
        anim.SetBool("SpringReady", prepara);
        anim.SetBool("JumpOther", JumpOther);
        anim.SetBool("Pushed", pushed);
        anim.SetBool("Walk", walk);
        anim.SetBool("Climb", climbed);
        anim.SetBool("Ladder", ladder);
        anim.SetBool("NoY", noY);

        if (prepara == false && preparaC == false)
        {
            if(!pushed)
                moveVelocity =  velocityAd + movespeed * Input.GetAxis(horizontalMove);
            else{
                moveVelocity =  velocityAd + (movespeed - 2) * Input.GetAxis(horizontalMove);
            }
           if (((Input.GetButtonDown(jumpButton)) && grounded && !pushed))
            {
                myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, jumpHeight);
            }
        }
        JumpOther = false;
        //Transformación Recorte
        if ((Input.GetButtonDown(prepareButton)) && ready && grounded && !pushed && !preparaC)
        {
            moveVelocity = 0;
            ready = false;
            prepara = true;
            myC.enabled = false;
            myB.enabled = true;
            myB.size = new Vector2(1.119104f, 0.4746513f);
            myB.offset = new Vector2(-0.04022324f, -0.3901272f);
            myrigidbody2D.mass = 100;
            
        }
        else if ((Input.GetButtonUp(prepareButton)) || !grounded)
        {
            ready = true;
            prepara = false;
            movespeed = moveStore;
            myC.enabled = true;
            myB.enabled = false;
            myrigidbody2D.mass = 1;
        }
        //Transformación Cuadrado
        //if ((/*Input.GetButtonDown(prepareButton) || */Input.GetKeyDown(preparedC)) && ready && !pushed && !prepara)
        //{
        //    moveVelocity = 0;
        //    ready = false;
        //    preparaC = true;
        //    myC.enabled = false;
        //    myB.enabled = true;
        //    myB.size = new Vector2(1.28f, 1.28f);
        //    myB.offset = new Vector2(0f, 0f);
        //    myrigidbody2D.bodyType = RigidbodyType2D.Static;
        //    gameObject.layer = 8;
        //}
        //else if ((/*Input.GetButtonUp(prepareButton) || */Input.GetKeyUp(preparedC)))
        //{
        //    ready = true;
        //    preparaC = false;
        //    movespeed = moveStore;
        //    myC.enabled = true;
        //    myB.enabled = false;
        //    myrigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        //    gameObject.layer = 9;
        //}
        
        if(!preparaC && !prepara)
            myrigidbody2D.velocity = new Vector2(moveVelocity, myrigidbody2D.velocity.y);

        if (grounded)
        {
            hard = true;
            hard2 = true;
            climbed = false;
            apoyer = false;
        }
        //fallVelocity = myrigidbody2D.velocity.y;
        if (velocityAd == 0 || (velocityAd != 0 && Input.GetAxis(horizontalMove) != 0))
            movil = true;
        else
        {
            walk = false;
            anim.SetFloat("Speed", 0f);
            movil = false;
        }

        if(movil)
            anim.SetFloat("Speed", Mathf.Abs(myrigidbody2D.velocity.x));

        anim.SetFloat("Speedy", Mathf.Abs(myrigidbody2D.velocity.y));
        if (Mathf.Abs(myrigidbody2D.velocity.y) == 0)
        {
            noY = true;
        }else
        {
            noY = false;
        }
       
        if (!preparaC && !prepara)
        {
            if (Input.GetAxis(horizontalMove) > 0)
            {
                walk = true;
                if (!pushed)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    right = true;
                }
            }
            else if (Input.GetAxis(horizontalMove) < 0)
            {
                walk = true;
                if (!pushed)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    right = false;
                }
            }
            else
                walk = false;
        }
        /*if (Input.GetButtonDown(throwButton))
        {
            GameObject starClone = (GameObject)Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
            starClone.transform.localScale = transform.localScale;
            shotDelayCounter = shotDelay;
        }
        if (Input.GetButtonDown(throwButton))
        {
            shotDelayCounter -= Time.deltaTime;
            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                GameObject starClone = (GameObject)Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
                starClone.transform.localScale = transform.localScale;
                //Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
            }
        }*/

        if (playerHealth <= 0 && !isDead)
        {
            LevelManager.instance.RespawnPlayer(this);
            myC.isTrigger = true;
            isDead = true;
        }
        Movible();
        Escalera();
        Aplastador();
        //Apoyo();
        Sujet();
        Trepar();
        SaltoE();
        if (isDead)
        {
            c++;
            if (c == 2)
            {
                myC.enabled = true;
                myB.enabled = false;
                hard = true;
                hard2 = true;
                climbed = false;
                apoyer = false;
                pushed = false;
                JumpOther = false;
                walk = false;
                preparaC = false;
                velocityAd = 0f;
                isDead = false;
                myC.isTrigger = false;
                c = 0;
            }
        }
    }


    public void hurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
        if (playerHealth <= 0)
            playerHealth = 0;
    }

    public void fullHealth()
    {
        playerHealth = maxPlayerHealth;
    }
    public void SaltoE()
    {
        //if (prepara == false)
        //{
        //    Physics2D.queriesStartInColliders = false;
        //    RaycastHit2D Salt = Physics2D.Raycast(myrigidbody2D.position, new Vector2(0,-1), 1f, boxMask);

        //    if (Salt.collider != null && (Salt.collider.gameObject.tag == "Player" || Salt.collider.gameObject.tag == "Pushable")/*&& Input.GetKeyDown(jump)*/ && Salt.collider.gameObject.GetComponent<PlayerController>().prepara /*&& grounded*/ && ready)
        //    {
        //        myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, jumpHeight * (1.25f));
        //    }
        //}

        //if(prepara == true)
        //{
        //    Physics2D.queriesStartInColliders = false;
        //    RaycastHit2D Salt = Physics2D.Raycast(myrigidbody2D.position, new Vector2(0, 1), 0.20f, boxMask);

        //    if (Salt.collider != null && (Salt.collider.gameObject.tag == "Player" || Salt.collider.gameObject.tag == "Pushable")/*&& Input.GetKeyDown(jump)*/ /*&& Salt.collider.gameObject.GetComponent<PlayerController>().prepara /*&& grounded*/ /*&& ready*/)
        //    {
        //        Salt.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Salt.collider.gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpHeight * (1.25f));
        //    }
        //}
    }
    public void Aplastador()
    {
        Physics2D.queriesStartInColliders = false;

        RaycastHit2D Der = Physics2D.Raycast(myrigidbody2D.position, Vector2.right * myrigidbody2D.transform.localScale.x, 0.3f, boxMask);
        RaycastHit2D Izq = Physics2D.Raycast(myrigidbody2D.position, Vector2.left * myrigidbody2D.transform.localScale.x, 0.3f, boxMask);
        RaycastHit2D Ar = Physics2D.Raycast(myrigidbody2D.position, Vector2.up , 0.45f, boxMask);
        RaycastHit2D Ab = Physics2D.Raycast(myrigidbody2D.position, Vector2.down, 0.45f, boxMask);

        if(prepara)
        {
            Ar = Physics2D.Raycast(myrigidbody2D.position, Vector2.up, 0.10f, boxMask);
            Ab = Physics2D.Raycast(myrigidbody2D.position, Vector2.down, 0.10f, boxMask);
        }

        //Debug.Log(Ar.collider.tag);
        //Debug.Log(Ab.collider.tag);
        //if (Der.collider != null)
        //{
        //    Debug.Log(Der.collider.tag);
        //    Debug.Log(Der.collider.isTrigger);
        //}
        //if (Izq.collider != null)
        //{
        //    Debug.Log(Izq.collider.tag);
        //    Debug.Log(Izq.collider.isTrigger);
        //}
        if ((Der.collider != null && Izq.collider != null) && (!Der.collider.isTrigger && !Izq.collider.isTrigger))
        {
            if ((Der.collider.tag != "Player" && Izq.collider.tag != "Player"))
            {
                LevelManager.instance.RespawnPlayer(this);
                isDead = true;

                myC.enabled = true;
                myB.enabled = false;
                hard = true;
                hard2 = true;
                climbed = false;
                apoyer = false;
                pushed = false;
                myC.isTrigger = true;
            }
        }
        if ((Ar.collider != null && Ab.collider != null) && (!Ar.collider.isTrigger && !Ab.collider.isTrigger))
        {
            if ((Ar.collider.tag != "Player" && Ab.collider.tag != "Player"))
            {
                LevelManager.instance.RespawnPlayer(this);
                isDead = true;
                myC.isTrigger = true;

                myC.enabled = true;
                myB.enabled = false;
                hard = true;
                hard2 = true;
                climbed = false;
                apoyer = false;
                pushed = false;
                myC.isTrigger = true;
            }
        }

    }
    public void Movible()
    {
        Physics2D.queriesStartInColliders = false;

        RaycastHit2D MOV;

        MOV = Physics2D.Raycast(myrigidbody2D.position, Vector2.right * transform.localScale.x, 0.5f, boxMask);

        //RaycastHit2D validador = Physics2D.Raycast(myrigidbody2D.position, Vector2.left * myrigidbody2D.transform.localScale.x, 0.5f, boxMask);
        if (MOV.collider != null && MOV.collider.gameObject.tag == "Pushable" && (Input.GetButton(carryButton) /*&& grounded*/ && ready))
        {
            ready = false;
            pushed = true;
            box = MOV.collider.gameObject;
        }else
        {
            ready = true;
            pushed = false;
        }

        if(pushed)
        {
            if (myrigidbody2D.velocity.x > 0.0f && right)
                box.GetComponent<Rigidbody2D>().velocity = new Vector2((movespeed - 2f) * Input.GetAxis(horizontalMove), 0);
            else
                if (myrigidbody2D.velocity.x > 0.0f && !right)
                    box.GetComponent<Rigidbody2D>().velocity = new Vector2((movespeed - 1.5f) * Input.GetAxis(horizontalMove), 0);
                else
                    if (myrigidbody2D.velocity.x < 0.0f && !right)
                        box.GetComponent<Rigidbody2D>().velocity = new Vector2((movespeed - 2f) * Input.GetAxis(horizontalMove), 0);
                    else
                        if (myrigidbody2D.velocity.x < 0.0f && right)
                            box.GetComponent<Rigidbody2D>().velocity = new Vector2((movespeed - 1.5f) * Input.GetAxis(horizontalMove), 0);
                        else
                            box.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
        //if (MOV.collider == null /*|| (validador.collider != null && ((myrigidbody2D.velocity.x < 0 && right) || (myrigidbody2D.velocity.x > 0 && !right))))*/ && box && box.tag == "Pushable")
        //{
        //    //Debug.Log("MMM");
        //    Debug.Log("Izi2");
        //    box.GetComponent<Rigidbody2D>().velocity = new Vector2(0, box.GetComponent<Rigidbody2D>().velocity.y);
        //    pushed = false;   
        //    ready = true;
        //}

        if ((Input.GetButtonUp(carryButton))  && box && box.tag == "Pushable")
        {
            ready = true;
            pushed = false;

            box.GetComponent<Rigidbody2D>().velocity = new Vector2(0, box.GetComponent<Rigidbody2D>().velocity.y);
        }

   
    }
    public void Escalera()
    {
        if (!climbed && !apoyer && !trepar  )
        {
            if (ladder)
            {
                myrigidbody2D.gravityScale = 0f;

                if (Input.GetAxis(verticalMove) > 0)
                {
                    myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, climbSpeed);
                }
                else
                {
                    if (Input.GetAxis(verticalMove) < 0)
                    {
                        myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, -climbSpeed);
                    }
                    else
                    {
                        myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, 0f);
                    }
                }

            }
            if (!ladder)
            {
                myrigidbody2D.gravityScale = gravityStore;
            }
        }
    }

    public void Sujet()
    {
        //Vector2 climbPos;
        //    //Physics2D.queriesStartInColliders = false;
        //Physics2D.queriesStartInColliders = false;

        //RaycastHit2D hit = Physics2D.Raycast(myrigidbody2D.position, Vector2.right * myrigidbody2D.transform.localScale.x, 1f, boxMask);
        
        //if (hit.collider != null && hit.collider.gameObject.tag == "Climbed" && hard)
        //    {
                
        //        climbed = true;
        //        //Debug.Log("SALIO");
        //        box = hit.collider.gameObject;
        //        myrigidbody2D.velocity = new Vector2(0, 0);
        //        myrigidbody2D.gravityScale = 0;
        //        //anim.SetBool("Climbed", climbed);
        //    }

        //if (climbed)
        //{
        //    climbPos = myrigidbody2D.transform.position;
        //    if (box.transform.position.x > climbPos.x)
        //    {
        //        right = true;
        //        myrigidbody2D.transform.position = new Vector2(box.transform.position.x - 1, box.transform.position.y);
        //    }
        //    else
        //        if (box.transform.position.x < climbPos.x)
        //        {
        //            right = false;
        //            myrigidbody2D.transform.position = new Vector2(box.transform.position.x + 1, box.transform.position.y);
        //        }
        //    if (Input.GetAxis(verticalMove) > 0)
        //    {
        //        if (right)
        //            myrigidbody2D.transform.position = new Vector2(climbPos.x + 1, climbPos.y + 1);
        //        else
        //            myrigidbody2D.transform.position = new Vector2(climbPos.x - 1, climbPos.y + 1);
        //        climbed = false;
        //        hard = false;
        //    }
        //    if ((Input.GetAxis(verticalMove) < 0) || (Input.GetAxis(horizontalMove) < 0)|| (Input.GetAxis(horizontalMove) > 0))
        //    {
        //        climbed = false;
        //        hard = false;
        //    }
        //}
    }
    public void Trepar()
    {
        //Vector2 climbPos;
        //Physics2D.queriesStartInColliders = false;
        Physics2D.queriesStartInColliders = false;

        RaycastHit2D hita = Physics2D.Raycast(myrigidbody2D.position, Vector2.up, 0.45f, boxMask);

        if (hita.collider != null && hita.collider.gameObject.tag == "Trepar" && (Input.GetAxis(verticalMove) >= 0)/*&& (Input.GetButton(carryButton) || Input.GetKey(agarrar)*/ && ready)
        {
                ready = false;
                //Debug.Log("tree");
                myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, 0);
                myrigidbody2D.gravityScale = 0;
                climbed = true;
        }
        else
        {
            ready = true;
            climbed = false;
        }
    }
    public void Apoyo()
    {
        //Vector2 climbPosF;
        //Physics2D.queriesStartInColliders = false;

        ///*localscale : tamaño del abajo*/
        //RaycastHit2D hit = Physics2D.Raycast(myrigidbody2D.position, Vector2.up, 1f, boxMask);


        //if (hit.collider != null && hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<PlayerController>().climbed && hard2)
        //{
        //    apoyer = true;
        //    //Debug.Log("PLOX");

        //    box = hit.collider.gameObject;
        //    myrigidbody2D.gravityScale = 0;
        //    myrigidbody2D.velocity = new Vector2(0, 0);
        //    transform.position = new Vector2(box.transform.position.x, box.transform.position.y - 1f);


        //    derecha = hit.collider.gameObject.GetComponent<PlayerController>().right;
        //    //anim.SetBool("Climbed", climbed);

        //}
        //if (apoyer)
        //{
        //    climbPosF = transform.position;
        //    if (Input.GetAxis(verticalMove) > 0)
        //    {
        //        if (derecha)
        //            transform.position = new Vector2(climbPosF.x + 1, climbPosF.y + 2);
        //        else
        //            transform.position = new Vector2(climbPosF.x - 1, climbPosF.y + 2);
        //        apoyer = false;
        //        hard2 = false;
        //    }
        //    if ((Input.GetAxis(verticalMove) < 0) || (Input.GetAxis(horizontalMove) < 0) || (Input.GetAxis(horizontalMove) > 0))
        //    {
        //        hard2 = false;
        //        apoyer = false;
        //    }
        //}
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(!prepara)
        if (other != null && other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().prepara && (myrigidbody2D.transform.position.y > other.transform.position.y) && !grounded)
        {
            other.gameObject.GetComponent<PlayerController>().JumpOther = true;
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, jumpHeight * (1.3f));
            trampolin.Play();
        }
    }
}


