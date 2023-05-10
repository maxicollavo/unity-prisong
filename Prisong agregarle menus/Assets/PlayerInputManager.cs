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
    public GameObject partiture;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        _rb.velocity = _movement * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
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
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerPickManager.PartiturePick();
            //playerPickManager.EnemyKill();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseManager.ActivatePause();
        }
        /*if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += speedRun; //Sumarle al speed del Move playerInputManager.speedRun;
        }*/

    }

    private void FixedUpdate()
    {
        Move();
    }


}

