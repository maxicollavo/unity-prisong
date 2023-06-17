using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTips : MonoBehaviour
{
    public GameObject useMirror;
    public float timeCount;

    private void Start()
    {
        timeCount = 0;
    }

    private void Update()
    {
        timeCount += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MirrorTrigger"))
        {
            timeCount = 0;
            if (timeCount >= 1f)
            {
                useMirror.SetActive(true);
            }
            if (timeCount >= 4f)
            {
                useMirror.SetActive(false);
            }
        }
    }
}
