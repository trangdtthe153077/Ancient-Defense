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
    void Start()
    {
        //readgamelvfromfile;
        //set game level;

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
      
    }
    public void ReturnWaiting()
    {
        // Change state to Playing when user clicks play button
        Debug.Log("Return waiting");
        currentState = GameState.Waiting;
        playBtn.interactable = true;
        playBtn.GetComponentInChildren<Text>().text = "Play";
        //can tang quai lv nua
        gameLevel++;
        levelText.text = "Level: " + gameLevel;
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
