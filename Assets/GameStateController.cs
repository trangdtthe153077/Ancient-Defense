using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    // Start is called before the first frame update

    public enum GameState { Waiting, Playing }
    public GameState currentState;
    public int gameLevel = 1;
    SpawnManager spawnManager;
    public TextMeshProUGUI levelText;
    public Button playBtn;
    Timer timer;
    public Canvas winOrLooseCanvas;
    public TextMeshProUGUI stateGameText;
    public Canvas updateManager;

    bool isWin;
    bool isLoose;
    bool finnishedGame;
    bool toggleCanvas;
    void Start()
    {
        timer = gameObject.GetComponent<Timer>();
        timer.Duration = 2;

        //readgamelvfromfile;
        //set game level;
        winOrLooseCanvas.gameObject.SetActive(false);
        Debug.Log("Set active=false");
        currentState = GameState.Waiting;

        spawnManager = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>();
        levelText.text = "Level: " + gameLevel;
    }


    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case GameState.Waiting:
                if (finnishedGame == true && toggleCanvas == false && (isWin == true || isLoose == true))
                {
                    var list = GameObject.FindGameObjectsWithTag("Ally");
                    foreach (var a in list)
                    {
                        Destroy(a);
                    }
                    if (isWin == true)
                    {
                        stateGameText.text = "You win the game ^^!";
                    }
                    else if (isLoose == true)
                    {
                        stateGameText.text = "You loose this game T_T!";
                    }
                    winOrLooseCanvas.gameObject.SetActive(true);

                    timer.Run();
                    toggleCanvas = true;
                    isWin = false;
                    isLoose = false;
                }


                else if (toggleCanvas == true && timer.Finished)
                {
                    winOrLooseCanvas.gameObject.SetActive(false);
                    toggleCanvas = false;

                    finnishedGame = false;
                }

                break;
            case GameState.Playing:
                spawnManager.SetLevelOfGame(gameLevel);
                break;
        }


    }

    public void StartPlaying()
    {
        // Change state to Playing when user clicks play button


        if (playBtn.GetComponentInChildren<Text>().text == "Stop")
        {
            playBtn.GetComponentInChildren<Text>().text = "Play";
            Debug.Log("Stop game");
            Debug.Log(currentState + "Playing");
        }
        else
        {
            playBtn.GetComponentInChildren<Text>().text = "Stop";
            playBtn.interactable = false;
            currentState = GameState.Playing;
            Debug.Log("Playing");
        }
        updateManager.gameObject.SetActive(false);

    }
    public void ReturnWaiting()
    {
        // Change state to Playing when user clicks play button
        Debug.Log("Return waiting");
        currentState = GameState.Waiting;
        playBtn.interactable = true;
        playBtn.GetComponentInChildren<Text>().text = "Play";
        //can tang quai lv nua
        isWin = true;

        finnishedGame = true;
        gameLevel++;

        levelText.text = "Level: " + gameLevel;
        updateManager.gameObject.SetActive(true);

      var list=  GameObject.FindGameObjectsWithTag("Ally");
        foreach(var item in list)
        {
            Destroy(item);
        }    
    }
    public void ReturnLoose()
    {
        // Change state to Playing when user clicks play button
        Debug.Log("Return Loose");
        currentState = GameState.Waiting;
        playBtn.interactable = true;
        playBtn.GetComponentInChildren<Text>().text = "Play";

        isWin = false;
        isLoose = true;
        finnishedGame = true;
        updateManager.gameObject.SetActive(true);

        levelText.text = "Level: " + gameLevel;
        var list = GameObject.FindGameObjectsWithTag("Ally");
        foreach (var item in list)
        {
            Destroy(item);
        }
    }

    public GameState GetGameState()
    {

        return currentState;
    }
    public void SetGameState(GameState gameState)
    {

        currentState = gameState;
    }
    /**/

}
