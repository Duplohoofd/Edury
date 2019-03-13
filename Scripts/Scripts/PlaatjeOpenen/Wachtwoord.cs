using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Wachtwoordscherm voor de admin panel
public class Wachtwoord : MonoBehaviour
{
    public void PassWordCheck(string incomingPassword)
    {
        if (incomingPassword == "password123")
        {
            SceneManager.LoadScene("Admin Panel");
        }
    }
}
