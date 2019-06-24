using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NewMenuPrincipalController : MonoBehaviour {

    public AudioManagerMenuPrincipal audio_player;

    public enum states { Jugar, Nivel, Salir };
    public GameObject[] GO_Jugar;
    public GameObject[] GO_Nivel;
    public GameObject[] GO_Salir;

    public class Estado
    {
        public states estado;
        public Estado next;
        public Estado back;
        public GameObject OpToSelect;
        public GameObject opToDisSelect;

        public Estado(states estado, GameObject[] OPs, Estado next, Estado back)
        {
            this.estado = estado;
            this.OpToSelect = OPs[0];
            this.opToDisSelect = OPs[1];
            this.next = next;
            this.back = back;
        }
    }

    public Estado FirstState;
    public Estado SecondState;
    public Estado ThirdState;
    public Estado actual;

    public GameObject MapaInstrucciones;
    public GameObject FondoNegro;
    public GameObject LogoNegro;

    public bool ReadyToGo;

    public string tutorial;
    public string selectLevel;
    public string lvl1tag;

    public Image black;
    public Animator anim;

    public static bool [] lvlPasado = new bool [7];
    public static float[] timeToBeatLvls = new float[7];
    public static int[] coinsCollected = new int[7];
    public static bool playLogo = true;

    float inputForce = 0f;
    bool press;

    // Use this for initialization
    void Start () {
        FirstState = new Estado(states.Jugar, GO_Jugar, SecondState, ThirdState);
        SecondState = new Estado(states.Nivel, GO_Nivel, FirstState, ThirdState);
        ThirdState = new Estado(states.Salir, GO_Salir, FirstState, SecondState);

        FirstState.next = SecondState;
        FirstState.back = ThirdState;

        SecondState.next = ThirdState;
        SecondState.back = FirstState;

        ThirdState.next = FirstState;
        ThirdState.back = SecondState;

        actual = SecondState;
        ChangeState();
        ChangeState();

        ReadyToGo = false;
        LogoNegro.SetActive(playLogo);
    }
	
	// Update is called once per frame
	void Update () {
        //move = ;
        if (playLogo)
        {
            StartCoroutine(IniciarLogo());
        }
        if (!playLogo)
        {
            if (ReadyToGo && Input.GetButtonDown("Select"))
            {
                SwitchScene(actual.estado);
                return;
            }
            inputForce = Input.GetAxisRaw("Vertical_Select");
            if (!press && (inputForce >= 0.25f || inputForce <= -0.25f)) ChangeState();
            else if (press && (inputForce < 0.25f && inputForce > -0.25f)) press = false;
            if (Input.GetButtonDown("Select")) SwitchScene(actual.estado);
        }
        

    }

    IEnumerator IniciarLogo()
    {
        LogoNegro.SetActive(true);
        SetTimeScore();
        CoinsScore();
        yield return new WaitForSeconds(2.0f);
        LogoNegro.SetActive(false);
        playLogo = false;
    }

    void SetTimeScore()
    {
        timeToBeatLvls[0] = 150f;
        timeToBeatLvls[1] = 180f;
        timeToBeatLvls[2] = 180f;
        timeToBeatLvls[3] = 210f;
        timeToBeatLvls[4] = 300f;
        timeToBeatLvls[5] = 300f;
        timeToBeatLvls[6] = 500f;
    }
    
    void CoinsScore()
    {
        coinsCollected[0] = 27;
        coinsCollected[1] = 24;
        coinsCollected[2] = 37;
        coinsCollected[3] = 21;
        coinsCollected[4] = 26;
        coinsCollected[5] = 70;
        coinsCollected[6] = 44;

    }         
    
    void ChangeState()
    {
        audio_player.PlayFoley(0);
        press = false;

        SetSpriteStates();

        if (inputForce >= 0.25f) actual = actual.back;
        else actual = actual.next;
        press = true;

        SetSpriteStates();
    }

    void SetSpriteStates()
    {
        actual.OpToSelect.SetActive(press);
        actual.opToDisSelect.SetActive(!press);
    }

    void SwitchScene(states s)
    {
        audio_player.PlayFoley(0);
        switch (s)
        {
            case states.Jugar:
                if (!ReadyToGo)
                {
                    ReadyToGo = true;
                    MapaInstrucciones.SetActive(true);
                    FondoNegro.SetActive(true);
                }
                else if(ReadyToGo)
                    StartCoroutine(Fade(tutorial));
                break;
            case states.Nivel:
                StartCoroutine(Fade(selectLevel));
                break;
            case states.Salir:
                StartCoroutine(Fade());
                break;
        }
    }

    IEnumerator Fade(string loadLevel = null)
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        if (loadLevel == null) Application.Quit();
        SceneManager.LoadScene(loadLevel);
    }
}
