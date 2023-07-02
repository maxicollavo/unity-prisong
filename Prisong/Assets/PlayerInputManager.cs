using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public GameSceneManager gameSceneManager;
    public Traps traps;
    public LightConfig lightConfig;
    public PlayerPickManager playerPickManager;
    public Mechanics mechanics;
    public PauseManager pauseManager;
    Rigidbody _rb;
    CapsuleCollider _cc;
    Vector3 _movement;
    public Animator playerAnim;

    public GameObject rock;
    public GameObject gameBeginningSign;
    public GameObject container;
    public GameObject loadingScreen;

    public bool loading;
    public bool crouch;
    public bool walking;
    public bool running;

    public float timeCount;
    [SerializeField] public int speed;
    [SerializeField] public int crouchSpeed;
    [SerializeField] public int runningSpeed;
    public int speedRun = 100;
    private int currentSpeed;
    public int LoadingScreenScene;

    public AudioSource steps;
    public AudioSource crouchSteps;

    public void Start()
    {
        StartCoroutine(LoadingScreen());
        Animator WalkingPlayer = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _cc = GetComponent<CapsuleCollider>();
        timeCount = 0f;
        speed = Config.playerSpeed;
        crouchSpeed = Config.playerSpeedCrouched;
        runningSpeed = Config.playerRunSpeed;
        playerAnim.SetBool("PlayerWalking", false);
        playerAnim.SetBool("PlayerCrouch", false);
        crouch = false;
        walking = false;
        running = false;
    }

    public void Crouch()
    {
        container.transform.position += new Vector3(0, crouch ? 1 : -1, 0);
        transform.position += new Vector3(0, crouch ? 0.3f : -0.3f, 0);
        _cc.height = crouch ? 1.96f : 1.5f;
        currentSpeed = crouchSpeed;
        crouch = !crouch;
        if (walking && crouch)
        {
            playerAnim.SetBool("PlayerWalking", true);
            playerAnim.SetBool("PlayerCrouch", true);
        }
        else if (crouch && walking == false)
        {
            playerAnim.SetBool("PlayerWalking", false);
            playerAnim.SetBool("PlayerCrouch", true);
        }
    }

    public void Move()
    {
        _rb.velocity = _movement * currentSpeed * Time.deltaTime;
        if (crouch && walking && running == false)
        {
            playerAnim.SetBool("PlayerWalking", true);
            playerAnim.SetBool("PlayerCrouch", true);
           //playerAnim.SetBool("PlayerRunning", false);
        }
        else if (walking && crouch == false && running == false)
        {
            playerAnim.SetBool("PlayerWalking", true);
            playerAnim.SetBool("PlayerCrouch", false);
            //playerAnim.SetBool("PlayerRunning", false);
        }
        else if (running && walking == false && crouch == false)
        {
            playerAnim.SetBool("PlayerWalking", false);
            playerAnim.SetBool("PlayerCrouch", false);
            //playerAnim.SetBool("PlayerRunning", true);
        }
    }

    public void IdleAnim()
    {
        if (walking == false && crouch == false && running == false)
        {
            playerAnim.SetBool("PlayerWalking", false);
            playerAnim.SetBool("PlayerCrouch", false);
            //playerAnim.SetBool("PlayerRunning", false);
        }
    }

    public void Update()
    {
        if (running == false && crouch == false)
        {
            currentSpeed = speed;
        }
        IdleAnim();
        timeCount += Time.deltaTime;
        if (timeCount >= 1f)
        {
            gameBeginningSign.SetActive(true);
        }
        if (timeCount >= 4f)
        {
            gameBeginningSign.SetActive(false);
        }
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        _movement = transform.forward * z;
        _movement += transform.right * x;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (mechanics.invisibility == false)
            {
                mechanics.Invisibility();
            }
            else mechanics.InvisibilityOff();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerPickManager.Picks();
            playerPickManager.EscapeDoor();
            playerPickManager.PianoInteract();
            playerPickManager.StoneInteract();
            playerPickManager.NotePick();
            playerPickManager.Disk();
            playerPickManager.PlayRecord();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerPickManager.ChestInteract();
            lightConfig.noLights = !lightConfig.noLights;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseManager.ActivatePause();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            Crouch();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.W))
        {
            walking = !walking;
            if (walking == false)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftControl))
                {
                    Crouch();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = !running;
            if (running)
            {
                currentSpeed = runningSpeed;
                Debug.Log("Corre");
            }
            else
            {
                currentSpeed = speed;
                Debug.Log("No corre");
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.A))
        {
            walking = !walking;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.D))
        {
            walking = !walking;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.S))
        {
            walking = !walking;
        }
        if (crouch == false)
        {
            currentSpeed = speed;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private IEnumerator LoadingScreen()
    {
        loading = !loading;
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        loadingScreen.SetActive(false);
        loading = !loading;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 20)
        {
            gameSceneManager.LoadMainMenu();
        }
    }
}

