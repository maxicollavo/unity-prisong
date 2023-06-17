using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickCount : MonoBehaviour
{
    public TextMeshPro textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshPro>();
        textComponent.SetText("Hola");
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "Picks: " + Config.picksCount;
    }
}
