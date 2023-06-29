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
    [SerializeField] public int speed;
    public int speedRun = 100;
    public GameObject rock;
    public GameObject gameBeginningSign;
    public float timeCount;
    public GameObject container;
    public bool crouch = false;
    private int currentSpeed;
    public int LoadingScreenScene;
    public GameObject loadingScreen;
    public bool loading;
    public AudioSource steps;
    public AudioSource crouchSteps;

    public void Start()
    {
        StartCoroutine(LoadingScreen());
        _rb = GetComponent<Rigidbody>();
        _cc = GetComponent<CapsuleCollider>();
        timeCount = 0f;
        speed = Config.playerSpeed;
        currentSpeed = speed;
    }

    public void Crouch()
    {
        container.transform.position += new Vector3(0, crouch ? 1 : -1, 0);
        transform.position += new Vector3(0, crouch ? 0.3f : -0.3f, 0);
        _cc.height = crouch ? 1.96f : 1.5f;
        currentSpeed = Config.playerSpeedCrouched;
        crouch = !crouch;
        if (crouch)
        {
            crouchSteps.Play();
            steps.Stop();
        }
    }

    public void Move()
    {
        _rb.velocity = _movement * currentSpeed * Time.deltaTime;
        if (_movement.magnitude > 0 && !crouch)
        {
            if (!steps.isPlaying)
            {
                crouchSteps.Stop();
                steps.Play();
            }
        }
        else
        {
            steps.Stop();
        }
    }

    public void Update()
    {
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

