using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerPickManager playerPickManager;
    public PauseManager pauseManager;
    Rigidbody _rb;
    Vector3 _movement;
    public int speed = 100;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerPickManager.Picks();
            playerPickManager.EscapeDoor();
            playerPickManager.PianoInteract();
            playerPickManager.StoneInteract();
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


}

