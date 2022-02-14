using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] images;

    public List<Sprite> gameImages = new List<Sprite>();

    public List<Button> btns = new List<Button>();
    
    private bool firstGuess, secondGuess;

    private int firstGuessIndex, secondGuessIndex;

    private int countGuesses, countCorrectGuesses, gameGuesses;

    private string firstGuessImage, secondGuessImage;

    void Awake()
    {
        images = Resources.LoadAll<Sprite>("MemoryStuff/spritesheet");
    }

    void Start()
    {
        GetButtons();
        AddGameImages();
        AddListeners();
        Shuffle(gameImages);
        gameGuesses = gameImages.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameButton");
        
        for(int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGameImages()
    {
        int looper = btns.Count;
        int index = 0;

        for(int i = 0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }
            gameImages.Add(images[index]);
            index++;
        }
        /* adding images to half of the buttons, then setting the index to 0 
           so that we can add their pair images for the other half */
    }

    void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => ClickButton());
            // adding the click function to the buttons (after generating them)
        }
    }

    public void ClickButton()
    {        
        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessImage = gameImages[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gameImages[firstGuessIndex];

        }
        else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessImage = gameImages[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gameImages[secondGuessIndex];  
            countGuesses++;
            StartCoroutine(CheckIfTheImagesMatch());
        }
    } 

    IEnumerator CheckIfTheImagesMatch()
    {
        yield return new WaitForSeconds (0.2f);

        if(firstGuessImage == secondGuessImage)
        {
            yield return new WaitForSeconds (.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color (0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color (0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds (.5f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds (.35f);

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses)
        {
            Debug.Log("You finished the game.");
            Debug.Log("It took you " + countGuesses + " guesses to finish the game.");
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
            // randomizing the places of the images using an index and a temp variable
        }
    }
}
