using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderEvents : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public bool selected = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selected = false;

        // Detect cursor release on slider if dragged during play, then continue playing data
        if (!gameManager.paused)
        {
            StartCoroutine(gameManager.PlayData(gameManager.totalDays, (int) gameManager.mainSlider.value));
        }
    }
}
