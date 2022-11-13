using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] private List<Transform> transforms;
    [SerializeField] private int _waitingTime;
    [SerializeField] private int _howLongDoesItLeave;
    [SerializeField] private int _speed;
    private float timer = 0;
    private int index = 0;
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        Turn();
        if (index == 0)
        {
            if (timer >= _waitingTime)
            {
                DestinationCheck();
                Move();
                
            }
        }
        else
        { 
            if (timer >= _howLongDoesItLeave)
            {
                DestinationCheck();
                Move();
                
            }
        }
    }
    private void Move()
    {        
        transform.position = Vector3.MoveTowards(transform.position, transforms[index].transform.position, _speed * Time.deltaTime);
    }
    private void Turn()
    {
        transform.LookAt(transforms[index].transform);
    }
    private void DestinationCheck()
    {
        if (transform.position == transforms[index].transform.position)
        {
            if (index >= transforms.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }        
            timer = 0;
        }
    }
}
