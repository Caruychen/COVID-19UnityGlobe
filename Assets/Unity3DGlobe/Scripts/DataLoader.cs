using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using System;

public class DataLoader : MonoBehaviour {

    public DataVisualizer Visualizer;
    public TextMeshProUGUI endDateText;
    public Slider mainSlider;
    private DateTime baseDate = new DateTime(2020, 1, 22);

    // Use this for initialization
    void Start () {

        // Load Data
        TextAsset jsonData = Resources.Load<TextAsset>("covidGeoData");
        string json = jsonData.text;
        SeriesArray data = JsonUtility.FromJson<SeriesArray>(json);
        Visualizer.CreateMeshes(data.AllData);
        Visualizer.CollateTotals(data.AllData);

        // Update date display
        endDateText.text = baseDate.AddDays(Visualizer.seriesObjects.Length - 1).ToString("dd MMMM");

        // Update slider value
        mainSlider.maxValue = Visualizer.seriesObjects.Length - 1;

        

    }
	
	void Update () {
	
	}

}

[System.Serializable]
public class SeriesArray
{
    public SeriesData[] AllData;
}