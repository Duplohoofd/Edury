using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//SceneSwitcher
public class NaarAdminPanel : MonoBehaviour{

   


    public void LaadAdminPanel()
    {
        SceneManager.LoadScene("Wachtwoord_invullen");
    }

    public void NaarHoofdMenu()
    {
        SceneManager.LoadScene("Hoofdmenu");
    }

    public void GameAfsluiten()
    {
        Application.Quit();
    }

    public void NaarMemoryGame()
    {
        SceneManager.LoadScene("MemoryGame");
    }

    public void NaarSpelUitleg()
    {
        SceneManager.LoadScene("SpelUitleg");
    }

}//einde script