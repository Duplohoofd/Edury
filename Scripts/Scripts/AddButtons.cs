using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    //class voor positie van het memory Veld, deze is zichtbaar in de unity editor.
    [SerializeField] private Transform MemoryVeld;

    //maak for loop en zorg ervoor dat de parent het memoryveld is. (line 16-23)
    [SerializeField] private GameObject btn;



    void Awake()
    {   //Loop die ervoor zorgt dat er een kopie gemaakt wordt van gameobject als deze niet 8 is.
        for(int i = 1; i < 24; i++)
        {   
            GameObject button = Instantiate(btn);          
            //geef naam aan nieuwe knop in Unity editor.
            button.name = "" + i;
            button.transform.SetParent(MemoryVeld, false);
        }
    }
}
