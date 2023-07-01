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
    public bool crouch = false;
    public bool walking = false;

    public float timeCount;
    [SerializeField] public int speed;
    [SerializeField] public int crouchSpeed;
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
        currentSpeed = speed;
    }

    public void Crouch()
    {
        container.transform.position += new Vector3(0, crouch ? 1 : -1, 0);
        transform.position += new Vector3(0, crouch ? 0.3f : -0.3f, 0);
        _cc.height = crouch ? 1.96f : 1.5f;
        currentSpeed = crouchSpeed;
        if (crouch)
        {
            currentSpeed = crouchSpeed;
            steps.Stop();
            crouchSteps.Play();
        }
        else 
        {
            currentSpeed = speed;
            crouch = false;
        }
    }

    public void Move()
    {
        _rb.velocity = _movement * currentSpeed * Time.deltaTime;
        if (currentSpeed > 400)
        {
            walking = !walking;
        }
        else walking = !walking;
    }

    public void Animations()
    {
        playerAnim.SetBool("PlayerWalking", false);
        playerAnim.SetBool("PlayerCrouch", false);

        if (walking)
        {
            if (crouch)
            {
                playerAnim.SetBool("PlayerCrouch", true);
                playerAnim.SetBool("PlayerWalking", true);
            }
            else
            {
                playerAnim.SetBool("PlayerWalking", true);
                playerAnim.SetBool("PlayerCrouch", false);

            }
        }
        else if (crouch)
        {
            if (walking)
            {
                playerAnim.SetBool("PlayerWalking", true);
                playerAnim.SetBool("PlayerCrouch", true);
            }
            else
            {
                playerAnim.SetBool("PlayerWalking", false);
                playerAnim.SetBool("PlayerCrouch", true);
            }
        }
    }

    public void Update()
    {
        Animations();
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

