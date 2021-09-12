using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minForX = 1.5f;
        //This was set at 1f but now is 1.25f since paddle width is changed from 1 to 1.25 so it should only hit edge of screen now.
    [SerializeField] float maxForX = 14.5f;
        //This was set at 15f but now is 14.75f since paddle width is changed from 1 to 1.25 so it should only hit edge of screen now.


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePositionInUnits, minForX, maxForX);
        transform.position = paddlePosition;
    }
}