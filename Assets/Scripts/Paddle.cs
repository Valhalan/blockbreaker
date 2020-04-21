using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 0.75f;
    [SerializeField] float maxX = 15.25f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float mouseXPosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Debug.Log(mouseXPosition);
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mouseXPosition, minX, maxX);
        transform.position = paddlePosition;
	}
}
