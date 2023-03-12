using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    // timer duration
    float totalSeconds = 0;
    // eXeCUtiOn
    float elapsedSeconds = 0;
    bool running = false;
    // support for Finished property
    bool started = false;
    // Start is called before the first frame update
    public void Run()
    {
        if (totalSeconds > 0)
        {
            running = true;
            started = true;
            elapsedSeconds = 0;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
                running = false;
        }
    }

    public float Duration
    {
        set
        {
            if (!running)
                totalSeconds = value;
        }
    }

    public bool Finished
    {
        get
        { return started && !running; }

    }

    public bool Completed
    {
        get
        { return !running; }

    }
    public bool Running
    {
        get { return running; }
    }
}
