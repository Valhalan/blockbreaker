﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 0.75f;
    [SerializeField] float maxX = 15.25f;

    // cached references
    GameStatus theGameStatus;
    Ball theBall;
    
    // Use this for initialization
    void Start ()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float mouseXPosition = Input.mousePosition.x / Screen.width * screenWidthInUnits; ;

        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;
	}

    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits; ;
        }
    }
}
