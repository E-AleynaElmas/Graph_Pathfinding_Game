using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetection : MonoBehaviour
{
    public static event GameController.OnClickListener Click;
    public static event MenuController.CountListener Counter;
    public static event MenuController.FinishGame Finish;

    public static int clickCounter = 0;

    private void OnMouseDown()
    {
        clickCounter++;
        Counter?.Invoke(clickCounter);
        if (transform.position == CreateGraph.Instance.lastNode.transform.position)
        {
            Debug.Log("oyun bitti");
            Finish?.Invoke(clickCounter);
        }
        else
        {            
            Click?.Invoke(new Vector2(transform.position.x, transform.position.y));           
            SetActiveChild();
        }       
    }
        
    private void SetActiveChild()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
