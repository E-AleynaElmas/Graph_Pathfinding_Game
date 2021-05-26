using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public delegate void CountListener(int counter);
    public delegate void FinishGame(int counter);

    [SerializeField]
    private Text counterText, finishText;
    [SerializeField]
    private GameObject finishPanel;

    private void OnEnable()
    {
        ClickDetection.Counter += OnCount;
        ClickDetection.Finish += OnFinish;
    }
    private void OnDisable()
    {
        ClickDetection.Counter -= OnCount;
        ClickDetection.Finish -= OnFinish;
    }

    private void OnCount(int counter)
    {
        counterText.text = "STEP: " + counter;
    }

    private void OnFinish(int counter)
    {
        finishText.text = counter + " Adımda Ulaştın !";
        finishPanel.SetActive(true);
    }

    public void Restart()
    {
        finishPanel.SetActive(false);
    }
}
