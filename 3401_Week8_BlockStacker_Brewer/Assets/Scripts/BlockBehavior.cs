using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    Transform _leftBoundary;
    Transform _rightBoundary;
    public float blockSpeed = 8;
    bool _isGoingRight = true;
  
    void Start()
    {
        _leftBoundary = GameObject.Find("LeftBoundary").transform;
        _rightBoundary = GameObject.Find("RightBoundary").transform;

    }

 
    void Update()
    {
        if (_isGoingRight)
        {
            //function call
            MoveRightTick();
        }
        else
        {
            //fuction call
            MoveLeftTick();
        }



       
    }
    //functions to move left or right
    void MoveRightTick()
    {
        //moves right by speed and delta time
        transform.Translate(Vector3.right * blockSpeed * Time.deltaTime);

        //if block is too far right, set false, go left
        if(transform.position.x > _rightBoundary.position.x)
        {
            _isGoingRight = false;

        }
    }

    void MoveLeftTick()
    {
        //moves left by speed and delta time
        transform.Translate(Vector3.left * blockSpeed * Time.deltaTime);
        //if x pos is less than left bound, set going left to true, go right
        if (transform.position.x < _leftBoundary.position.x)
        {
            _isGoingRight = true;

        }
    }
}
