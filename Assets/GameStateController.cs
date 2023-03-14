using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    // Start is called before the first frame update

    public enum GameState { Waiting, Playing }
    public GameState currentState;
    public int gameLevel=5;
    SpawnManager spawnManager;

    public Button playBtn;
    void Start()
    {
        //readgamelvfromfile;
        //set game level;

        currentState = GameState.Waiting;

        spawnManager = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>();
    }


    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case GameState.Waiting:
                // Handle Waiting state logic
                break;
            case GameState.Playing:
                spawnManager.SetLevelOfGame(gameLevel);
                break;
        }


    }

    public void StartPlaying()
    {
        // Change state to Playing when user clicks play button
        currentState = GameState.Playing;
        Debug.Log(currentState+"Playing");
        playBtn.GetComponentInChildren<Text>().text = "Stop";
    }

    public GameState GetGameState()
    {
        
        return currentState;
    }
}
