using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorAttack : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public LifeController lifeController;
    public Animator armorAnim;
    public GameObject EscapeX;

    public bool armorTrigger;
    public bool armorTriggerUse;

    public List<GameObject> deactivatedArmors = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger") && deactivatedArmors.IndexOf(other.gameObject) == -1 && playerInputManager.crouch == false)
        {
            if (!armorTriggerUse)
            {
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
            playerInputManager.speed = 0;
            yield return new WaitForSeconds(2);
            armorAnim.SetBool("ArmorAttack", false);
            //sword.Play();
            lifeController.Hit(2);
            yield return new WaitForSeconds(2);
        }
        if (armorTrigger == false)
        {
            EscapeX.SetActive(false);
            //deactivateBomb.Play();
            //bombTick.Stop();
            deactivatedArmors.Add(armor);
            playerInputManager.speed = Config.playerSpeed;
        }
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
