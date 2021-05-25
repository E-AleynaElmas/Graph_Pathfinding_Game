using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetection : MonoBehaviour
{
    public static event GameController.OnClickListener Click;
    private void OnMouseDown()
    {
        Click?.Invoke(new Vector2(transform.position.x, transform.position.y));
    }
}
