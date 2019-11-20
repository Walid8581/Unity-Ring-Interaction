// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRend;
    private Vector2 mousePos;
    private Vector2 startMousePos;
    

    [SerializeField]
    private Text distanceText;

    private float distance;

    void start() {

        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, position: new Vector3(startMousePos.x,
                                                          startMousePos.y,
                                                          0f));
            lineRend.SetPosition(1, position: new Vector3(mousePos.x,
                                                          mousePos.y,
                                                          0f));
            distance= (mousePos-startMousePos).magnitude;
            distanceText.text = distance.ToString("F2") + "meters";
        }
    }
}
