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

    public Transform tutorialPosition;
    public Transform noTutorialPosition;
    public Transform player;

    public bool loading;
    public bool crouch;
    public bool walking;
    public bool running;
    public bool inventory;

    public float timeCount;
    [SerializeField] public int speed;
    [SerializeField] public int crouchSpeed;
    [SerializeField] public int runningSpeed;
    public int speedRun = 100;
    public int currentSpeed;
    public int LoadingScreenScene;

    public AudioSource walkingSteps;
    public AudioSource runningSteps;
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
        playerAnim.SetBool("PlayerRunning", false);
        crouch = false;
        walking = false;
        running = false;
        inventory = false;
        if (Config.tutorial)
        {
            player.position = tutorialPosition.position;

        }
        else
        {
            player.position = noTutorialPosition.position;
        }
    }

    public void Crouch()
    {
        container.transform.position += new Vector3(0, crouch ? 1 : -1, 0);
        transform.position += new Vector3(0, crouch ? 0.3f : -0.3f, 0);
        _cc.height = crouch ? 1.96f : 1.5f;
        currentSpeed = crouchSpeed;
        crouch = !crouch;
    }

    public void Speed()
    {
        currentSpeed = runningSpeed;
        running = !running;
    }

    public void Move()
    {
        _rb.velocity = _movement * currentSpeed * Time.deltaTime;
    }

    public void Update()
    {
        if (walking && !crouch && !running)
        {
            if (!walkingSteps.isPlaying)
            {
                walkingSteps.Play();
            }
        }
        else walkingSteps.Stop();

        if (walking && crouch && !running)
        {
            if (!crouchSteps.isPlaying)
            {
                crouchSteps.Play();
            }
        }
        else crouchSteps.Stop();

        if (running)
        {
            if (!runningSteps.isPlaying)
            {
                runningSteps.Play();
            }
        }
        else runningSteps.Stop();
        if (running == false && crouch == false)
        {
            currentSpeed = speed;
        }
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
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyUp(KeyCode.Tab))
        {
            inventory = !inventory;
        }
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
            playerPickManager.Button();
            playerPickManager.LaserDeactivate();
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
            if (!running)
            {
                Crouch();
            }
        }
        walking = Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.S);

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (!crouch)
            {
                Speed();
            }
        }
        playerAnim.SetBool("PlayerWalking", walking);
        playerAnim.SetBool("PlayerCrouch", crouch);
        playerAnim.SetBool("PlayerRunning", running);
    }

    private void FixedUpdate()
    {
        if (!ArmorAttack.armorTrigger && !Traps.alarmActive)
        {
            Move();
        }
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

