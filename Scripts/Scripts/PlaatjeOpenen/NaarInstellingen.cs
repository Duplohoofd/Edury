using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Sceneswitcher (MainMenu)
public class NaarInstellingen : MonoBehaviour{

    public GameObject HoofdMenuKnoppen;
    public GameObject InstellingenMenu;

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    public void NaarInstellingenMenu()
    {
        HoofdMenuKnoppen.SetActive(false);
        InstellingenMenu.SetActive(true);

    }

    public void NaarHoofdMenu()
    {
        HoofdMenuKnoppen.SetActive(true);
        InstellingenMenu.SetActive(false);
    }



}//einde script
