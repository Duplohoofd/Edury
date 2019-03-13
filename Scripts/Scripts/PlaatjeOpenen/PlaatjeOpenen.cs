using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// Zorg ervoor dat de asset bundler geopend kan worden om illustraties aan te passen.
public class PlaatjeOpenen : MonoBehaviour
{
    public void VoegMijToeGino()
    {
        //will open if exe is in same directory as launchers exe file.
        System.Diagnostics.Process.Start("Plaatjeaanpassen\\AssetBundleExtractor.exe");
    }
}
