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
        StartCoroutine(Countdown());
       
    }


    // Starts countdown timer, then initiates target spawning after
    IEnumerator Countdown()
    {
        int duration = 0;
        do
        {
            gameManager.mainSlider.value = duration;
            duration++;

            yield return new WaitForSeconds(timeDelay);

        } while (duration < 195);


    }
}
