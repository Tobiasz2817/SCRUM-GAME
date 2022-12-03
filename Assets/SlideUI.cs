using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUI : MonoBehaviour
{
    [Range(0.0000001f,0.2f)]
    public float speed = 0.1f;
    public Vector2 startPoint;
    Vector2 goal;

    private void Start()
    {
        goal = startPoint;
        transform.localPosition = startPoint;
    }

    [ContextMenu("On()")]
    public void On()
    {
        goal = Vector2.zero;
    }

    [ContextMenu("Off()")]
    public void Off() {
        goal = startPoint;
    }

    private void Update()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, goal, speed);
    }
}
