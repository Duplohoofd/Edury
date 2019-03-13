using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVeranderen : MonoBehaviour
{

    // Verwijzing naar audiobroncomponent
    private AudioSource audioSrc;

    // Muziekvolumevariabele die wordt gewijzigd door de schuifregelknop te verslepen
    private float musicVolume = 0.148f;

    void Start()
    {

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        // Instellen van de volume-optie van Audio Source om gelijk te zijn aan musicVolume
        audioSrc.volume = musicVolume;
    }

    //Methode die wordt aangeroepen door de slider gameobject.
    // Deze methode neemt een vol-waarde die doorgegeven wordt door de schuifregelaar
    // en stelt het in als musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}