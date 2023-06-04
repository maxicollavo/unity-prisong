using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip InteractSource;
    public bool Audio;
    AudioSource Audiosource;
    float timeCount = 0;    

    private void Start()
    {
        Audio = false;
        Audiosource = GetComponent<AudioSource>();
     

    }
    private void Update()
    {

        if (Config.picksCount >= 1)
        {
            Audio = true;
            if (Audio == true)
            {
                Audiosource.PlayOneShot(InteractSource);
            }
            else Audio = false; 
           
        } 
    }
   


}
