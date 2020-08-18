using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    private DateTime baseDate = new DateTime(2020, 7, 22);
    public float timeDelay = 0.05f;
    private int totalDays;

    

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartPlay);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartPlay()
    {
        totalDays = gameManager.visualizer.seriesObjects.Length;
        StartCoroutine(Countdown(totalDays));
       
    }


    // Starts counting days towards the end
    IEnumerator Countdown(int endAt)
    {
        int duration = 0;
        do
        {
            gameManager.mainSlider.value = duration;
            duration++;

            yield return new WaitForSeconds(timeDelay);

        } while (duration < endAt);


    }
}
