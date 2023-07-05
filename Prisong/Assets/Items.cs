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
        noDisk.SetActive(!playerPickManager.haveDisk);
        diskC.SetActive(playerPickManager.haveDisk);

        noPick.SetActive(pickCount == 0);
        pickC.SetActive(pickCount == 1);
        pickC2.SetActive(pickCount == 2);
        pickC3.SetActive(pickCount == 3);
        pickC4.SetActive(pickCount == 4);

        noRock.SetActive(rockCount == 0);
        rockC1.SetActive(rockCount == 1);
        rockC2.SetActive(rockCount == 2);
    }
}
