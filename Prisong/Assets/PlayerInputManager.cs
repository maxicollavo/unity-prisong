using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerPickManager playerPickManager;
    public Mechanics mechanics;
    public PauseManager pauseManager;
    public EnemyDetect enemyDetect;
    Rigidbody _rb;
    CapsuleCollider _cc;
    Vector3 _movement;
    [SerializeField] public int speed;
    public int speedRun = 100;
    public Animator anim;
    public GameObject rock;
    public GameObject gameBeginningSign;
    public float timeCount;
    public GameObject container;
    public bool crouch = false;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _cc = GetComponent<CapsuleCollider>();
        timeCount = 0f;
        speed = Config.playerSpeed;
    }

    public void Crouch() //Necesito que el CapsuleCollider achique Height y mueva su position al piso para poder pasar por obstaculos
    {
        container.transform.position += new Vector3(0, crouch ? 1 : -1, 0);
        _cc.transform.position += new Vector3(0, crouch ? 0.81f : 0.40f, 0);
        _cc.height = new Vector3(0, crouch ? 1.96f : 1, 0);
        speed = Config.playerSpeedCrouched;
        crouch = !crouch;
    }

    public void Move()
    {
        _rb.velocity = _movement * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
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
        anim.SetFloat("X", x);
        anim.SetFloat("Z", z);
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
            speed = Config.playerSpeed;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
}

