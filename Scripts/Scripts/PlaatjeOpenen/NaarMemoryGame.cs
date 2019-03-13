using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//SceneSwitcher (naar memory game)
public class NaarMemoryGame : MonoBehaviour
{
    public void VerderGaan()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
