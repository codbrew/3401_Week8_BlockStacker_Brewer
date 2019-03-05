using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float moveSpeed = 5;
    float _targetYPosition;

    void Start()
    {
        _targetYPosition = transform.position.y;
    }


    void Update()
    {
        //change y position
        Vector3 targetPosition = new Vector3(transform.position.x, _targetYPosition, transform.position.z);
        //lerp between starting point and new point
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void OnBlockDrop()
    {
        _targetYPosition += 1;
    }
}
