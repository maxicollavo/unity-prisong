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
    Vector3 _movement;
    [SerializeField] public int speed;
    public int speedRun = 100;
    public Animator anim;
    public GameObject rock;
    public GameObject gameBeginningSign;
    public float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        timeCount = 0f;
        speed = Config.playerSpeed;
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
           // playerPickManager.StoneInteract();
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
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void MakeNoise()
    {
        enemyDetect.DetectNoise();
    }
}

