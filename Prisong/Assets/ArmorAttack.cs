using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorAttack : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public LifeController lifeController;
    public Animator armorAnim;
    public GameObject EscapeX;

    public AudioSource sword;
    public AudioSource armorSound;

    public static bool armorTrigger;

    public List<GameObject> deactivatedArmors = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger") && deactivatedArmors.IndexOf(other.gameObject) == -1)
        {
            armorTrigger = true;
            StartCoroutine(WaitAndAttack(other.gameObject));
        }
    }

    public IEnumerator WaitAndAttack(GameObject armor)
    {
        while (armorTrigger)
        {
            armorSound.Play();
            armorAnim.SetBool("ArmorAttack", true);
            EscapeX.SetActive(true);
            yield return new WaitForSeconds(1f);
            if (armorTrigger)
            {
                sword.Play();
                lifeController.Hit(2);
                armorAnim.SetBool("ArmorAttack", false);
                yield return new WaitForSeconds(2);
            }
        }
        deactivatedArmors.Add(armor);
    }

    private void Update()
    {
        if (armorTrigger == false)
        {
            armorAnim.SetBool("ArmorAttack", false);
        }
        if (Input.GetKey(KeyCode.X) && armorTrigger)
        {
            EscapeX.SetActive(false);
            //deactivateArmor.Play();
            armorTrigger = false;
        }
    }
}
