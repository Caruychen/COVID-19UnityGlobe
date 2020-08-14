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
    private DateTime baseDate = new DateTime(2020, 1, 22);
    private DateTime currentDate;
    public Slider mainSlider;

    
    // Start is called before the first frame update
    void Start()
    {
        updateDate(baseDate);
        mainSlider.onValueChanged.AddListener(delegate { updateDate(baseDate); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateDate(DateTime baseDateInput)
    {
        currentDate = baseDateInput.AddDays(mainSlider.value);
        dateText.text = currentDate.ToString("dd MMMM yyyy");
        visualizer.ActivateSeries((int)mainSlider.value);
  
    }


}

