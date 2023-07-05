using UnityEngine;

public class Items : MonoBehaviour
{
    public PlayerPickManager playerPickManager;
    public PlayerInputManager playerInputManager;

    int pickCount;
    int rockCount;

    public GameObject inventory;
    public GameObject noDisk;
    public GameObject noPick;
    public GameObject noRock;
    public GameObject diskC;
    public GameObject pickC;
    public GameObject pickC2;
    public GameObject pickC3;
    public GameObject pickC4;
    public GameObject rockC1;
    public GameObject rockC2;

    private void Start()
    {
        pickCount = Config.picksCountInv;
        rockCount = Config.rockPickCount;

        inventory.SetActive(false);

        noDisk.SetActive(true);
        noPick.SetActive(true);
        noRock.SetActive(true);

        diskC.SetActive(false);

        pickC.SetActive(false);
        pickC2.SetActive(false);
        pickC3.SetActive(false);
        pickC4.SetActive(false);

        rockC1.SetActive(false);
        rockC2.SetActive(false);
    }

    private void Update()
    {
        if (playerInputManager.inventory)
        {
            Inventory();
        }
        else inventory.SetActive(false);
    }

    public void Inventory()
    {
        inventory.SetActive(true);
        Item();
    }

    public void Item()
    {
        if (playerPickManager.haveDisk)
        {
            noDisk.SetActive(false);
            diskC.SetActive(true);
        }
        else
        {
            noDisk.SetActive(true);
            diskC.SetActive(false);
        }

        if (pickCount == 1)
        {
            noPick.SetActive(false);
            pickC.SetActive(true);
        }
        else if (pickCount == 2)
        {
            pickC.SetActive(false);
            pickC2.SetActive(true);
        }
        else if (pickCount == 3)
        {
            pickC2.SetActive(false);
            pickC3.SetActive(true);
        }
        else if (pickCount == 4)
        {
            pickC3.SetActive(false);
            pickC4.SetActive(true);
        }
        else if (pickCount == 0)
        {
            noPick.SetActive(true);
            pickC4.SetActive(false);
        }

        if (rockCount == 1)
        {
            noRock.SetActive(false);
            rockC1.SetActive(true);
        }
        else if (rockCount == 2)
        {
            rockC1.SetActive(false);
            rockC2.SetActive(true);
        }
        else if (rockCount == 0)
        {
            noRock.SetActive(true);
            rockC2.SetActive(false);
        }
    }
}
