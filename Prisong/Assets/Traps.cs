using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public LifeController lifeController;
    public LightConfig lightConfig;
    public float time;
    public bool alarmActive;
    public List <GameObject> deactivatedAlarms = new List<GameObject>();

    private void Start()
    {
        time = Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 18 && deactivatedAlarms.IndexOf(other.gameObject) == -1)
        {
            StartCoroutine(WaitAndAttack(other.gameObject));
        }
    }

    public IEnumerator WaitAndAttack(GameObject alarm)
    {
        Debug.Log("Se activo");
        alarmActive = true;
        yield return new WaitForSeconds(2);
        if (alarmActive == true)
        {
            lifeController.Hit(2);
            alarmActive = false;
            Debug.Log("Exploto");
        }
        else
        {
            Debug.Log("Se desactivo");
            deactivatedAlarms.Add(alarm);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            alarmActive = false;
        }
    }
}
