using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public LifeController lifeController;
    public float time;
    public bool alarmActive;
    public List <GameObject> deactivatedAlarms = new List<GameObject>();

    private void Start()
    {
        time = Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 18 && deactivatedAlarms.IndexOf(other.gameObject) == -1 && playerInputManager.crouch == false)
        {
            StartCoroutine(WaitAndAttack(other.gameObject));
            playerInputManager.speed = 0;
        }
        if (other.gameObject.layer == 19)
        {
            lifeController.Hit(4);
        }
    }

    public IEnumerator WaitAndAttack(GameObject alarm)
    {
        Debug.Log("Se activo");
        alarmActive = true;
        yield return new WaitForSeconds(2);
        if (alarmActive == true)
        {
            alarmActive = false;
            lifeController.Hit(2);
            Debug.Log("Exploto");
            playerInputManager.speed = Config.playerSpeed;
        }
        else
        {
            Debug.Log("Se desactivo");
            deactivatedAlarms.Add(alarm);
            playerInputManager.speed = Config.playerSpeed;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            alarmActive = false;
        }
    }
}
