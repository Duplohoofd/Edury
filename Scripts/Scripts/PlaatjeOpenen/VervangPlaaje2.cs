using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SFB;

public class VervangPlaaje2 : MonoBehaviour
{
    public GameObject foutmelding;
    public GameObject AdminPanelKnoppen;
    void start()
    {


    }
    //Zorg ervoor dat het pad kan worden geselecteerd (d.m.v SFB)
    private string _path;

    public void WriteResult(string[] paths)
    {
        if (paths.Length == 0)
        {
            return;
        }

        _path = "";
        foreach (var p in paths)
        {
            _path += p;
        }
    }




    public void WriteResult(string path)
    {
        _path = path;
    }



    //vervang het resources.assets bestand in de gamefolder.
    //Verwijder bestand, verplaats bestand dat gekozen in windows explorer.  
    public void VervangBestand()
    {
        try
        {
            WriteResult(StandaloneFileBrowser.OpenFilePanel("Kies je resources.assets bestand.", "", "assets", false));
            File.Delete("C:\\Edury\\Klein Project_Data\\resources.assets");
            File.Move(_path, "C:\\Edury\\Klein Project_Data\\resources.assets");
        }                      

        //Als er zich een fout voordoet bij het uploaden van de illustratie
        catch (Exception e)
        {
            //Activeer foutmelding gameobject.
            foutmelding.SetActive(true);
        }
    }

    public void FoutmeldingAfsluiten()
    {
        foutmelding.SetActive(false);
    }



}//einde script