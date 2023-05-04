using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCount : MonoBehaviour
{
    public GameObject player;
    public int picksCounter;
    public PlayerPickManager playerPickManager;
    public int inventary;

    void Update()
    {
        Inventary();
    }

    void Inventary()
    {
        if (Config.picksCount <= 1)
        {
            inventary++;
        }
    }
}
