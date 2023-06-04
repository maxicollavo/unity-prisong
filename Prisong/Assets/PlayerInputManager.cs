using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerPickManager playerPickManager;
    public Mechanics mechanics;
    public PauseManager pauseManager;
    public Animator anim;
    public GameObject rock;
    public GameObject gameBeginningSign;
    public float timeCount;
    public bool isSprinting;
    public float walkSpeed;
    public float sprintSpeed;
    public float realSpeed;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0f;
        walkSpeed = 8f;
        sprintSpeed = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        realSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

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
        if (Input.GetKeyDown(KeyCode.X))
        {

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
        Look();
        transform.Translate(realSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, realSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }

    private void Look()
    {

    }
}

