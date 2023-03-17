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
    public int gameLevel=5;
    SpawnManager spawnManager;
    public TextMeshProUGUI levelText;
    public Button playBtn;
    Timer timer;
    public Canvas winOrLooseCanvas;
    public TextMeshProUGUI stateGameText;
    public Canvas updateManager;

    bool isWin;
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
        levelText.text = "Level: "+gameLevel;
    }


    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case GameState.Waiting:
            if(isWin==true&&toggleCanvas==false)
                {
                    winOrLooseCanvas.gameObject.SetActive(true);
                    stateGameText.text = "You win the game^^!";
                    timer.Run();
                    toggleCanvas=true;
                } 
            else if (isWin == true && toggleCanvas == true&& timer.Finished)
                {
                    winOrLooseCanvas.gameObject.SetActive(false);
                    toggleCanvas=false;
                    isWin = false;
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
     
    
      if(playBtn.GetComponentInChildren<Text>().text =="Stop")
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
        
     
        gameLevel++;

        levelText.text = "Level: " + gameLevel;
        updateManager.gameObject.SetActive(true);
    }

    public GameState GetGameState()
    {
        
        return currentState;
    }
    public void SetGameState(GameState gameState)
    {

        currentState = gameState;
    }


}
