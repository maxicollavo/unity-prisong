using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorAttack : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public LifeController lifeController;
    public Animator armorAnim;
    public GameObject EscapeX;

    public static bool armorTrigger;
    public static bool armorTriggerUse;

    public List<GameObject> deactivatedArmors = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger") && deactivatedArmors.IndexOf(other.gameObject) == -1)
        {
            if (!armorTriggerUse)
            {
                Debug.LogWarning("Entro");
                armorTrigger = true;
                StartCoroutine(WaitAndAttack(other.gameObject));
            }
        }
    }

    public IEnumerator WaitAndAttack(GameObject armor)
    {
        while (armorTrigger)
        {
            armorAnim.SetBool("ArmorAttack", true);
            EscapeX.SetActive(true);
            Debug.LogWarning("Speed 0");
            yield return new WaitForSeconds(2);
            if (armorTrigger)
            {
                armorAnim.SetBool("ArmorAttack", false);
                //sword.Play();
                lifeController.Hit(2);
                yield return new WaitForSeconds(2);
            }
        }
        EscapeX.SetActive(false);
        //deactivateBomb.Play();
        //bombTick.Stop();
        deactivatedArmors.Add(armor);
    }

    private void Update()
    {
        if (armorTrigger == false)
        {
            armorAnim.SetBool("ArmorAttack", false);
        }
        if (Input.GetKey(KeyCode.X))
        {
            armorTrigger = false;
            armorTriggerUse = true;
        }
    }
}
