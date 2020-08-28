using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public DataVisualizer visualizer;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI total;
    private DateTime baseDate = new DateTime(2020, 1, 22);
    public DateTime currentDate;
    public Slider mainSlider;
    public Button playButton;
    public Button pauseButton;
    public Button replayButton;
    public bool paused = true;
    public int totalDays;
    private int startDay;
    public float timeDelay = 0.05f;
    public SliderEvents slider;


    // Start is called before the first frame update
    void Start()
    {
        updateDate(baseDate);
        mainSlider.onValueChanged.AddListener(delegate {
                updateDate(baseDate);
                updateTotal();
        });

        // Button controller
        playButton.onClick.AddListener(delegate
        {
            BeginPlay(playButton, (int)mainSlider.value);
        });
        replayButton.onClick.AddListener(delegate
        {
            BeginPlay(replayButton, 0);
        });
        pauseButton.onClick.AddListener(PausePlay);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Updates current date text display
    public void updateDate(DateTime baseDateInput)
    {
        currentDate = baseDateInput.AddDays(mainSlider.value);
        dateText.text = currentDate.ToString("dd MMMM yyyy");
        visualizer.ActivateSeries((int)mainSlider.value);
  
    }

    // Displays total count
    public void updateTotal()
    {
        total.text = visualizer.totalSeries[(int)mainSlider.value].ToString("N0");
    }

    // Start playing data
    void BeginPlay(Button button, int startValue)
    {
        button.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        paused = !paused;
        totalDays = visualizer.seriesObjects.Length;
        startDay = startValue;
        StartCoroutine(PlayData(totalDays, startDay));
    }

    // Begin playing data over time

    void PausePlay()
    {
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        paused = !paused;
    }

    // Starts counting days towards the end
    public IEnumerator PlayData(int endAt, int startAt)
    {
        int currentValue = startAt;
        do
        {
            mainSlider.value = currentValue;
            currentValue++;

            yield return new WaitForSeconds(timeDelay);

        } while (currentValue < endAt && paused == false && !slider.selected);

        // Detect if player reached end of data
        if (paused == false && !slider.selected)
        {
            paused = !paused;
            pauseButton.gameObject.SetActive(false);
            replayButton.gameObject.SetActive(true);
        }

    }

}

