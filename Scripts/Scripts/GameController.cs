using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
using System.IO;


public class GameController : MonoBehaviour
{

    GameObject[] gameObj;
    Texture2D[] textList;
    string[] files;
    string pathPreFix;

    [SerializeField] private Sprite bgImage;
    public Sprite[] puzzles;

    public List<Sprite> GamePuzzles = new List<Sprite>();

    //list
    public List<Button> btns = new List<Button>();

    private bool firstGeuss, secondGeuss;

    public int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;
    private TextMeshProUGUI scoreLabel;

    private int _score = 0;
    
    void Awake()
    {
        //pak alle plaatjes uit folder en laad ze in de game.
        puzzles = Resources.LoadAll<Sprite>("Sprites/Cards");
        ///puzzles = Path.Combine(Application.streamingAssetsPath, "cardClubs4.png");
    }

    void Start()
    {
        //scoreLabel = GetComponent<TextMeshProUGUI>();
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(GamePuzzles);
        CheckifTheGameIsFinished();
    }



    //haal de buttons op uit de unity editor. Dit wordt gedaan doormiddel van een tag die op de object staat.
    //Verander vervolgens de achtergrond van de kaarten (geplaats in unity editor).
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("MemoryButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }




    //zorg ervoor dat er niet meer dan max kaarten worden ingeladen in de game.
    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            //plaatje wordt ingleaden 
            //GamePuzzles.Add(puzzles[index]);
            GamePuzzles.Add(puzzles[index]);
            index++;


        }
    }

    //Toevoegen dat functie PickAPuzzle wordt toegevoegd aan knop (listener is een functie die aan knop wordt toegevoegd).
    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }


    //functie die uitgevoerd wordt wanneer kaart wordt geselecteerd.
    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        //als we niet raden voor de eerste keer.
        if (!firstGeuss)
        {

            firstGeuss = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = GamePuzzles[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = GamePuzzles[firstGuessIndex];

        }
        else if (!secondGeuss)
        {
            secondGeuss = true;

            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = GamePuzzles[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = GamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckifThePuzzlesMatch());
        }

    }

    IEnumerator CheckifThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            _score++;
            scoreLabel = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            scoreLabel.text = "Score: " + _score;
            Debug.Log(countGuesses);
            
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckifTheGameIsFinished();
        }
        else
        {
            
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }
        if (_score == 12)
        {
            SceneManager.LoadScene("PostGame");
            PlayerPrefs.SetInt("Kansen", countGuesses);
            PlayerPrefs.SetInt("MemoryScore", _score); 
        }

        yield return new WaitForSeconds(.5f);

        firstGeuss = secondGeuss = false;
    }


    void CheckifTheGameIsFinished()
    {
        countCorrectGuesses++;
        
        if(countCorrectGuesses == gameGuesses)
        {
            SceneManager.LoadScene("PostGame");
            
        }
    }


    //zet kaarten in wilikeurige volgorde

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }


    }






} // gamecontroller
