using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public GameObject start;
    public GameObject end;
    public float monster_speed = 5;

    bool isForward = true;
    void Update()
    {
        if (transform.localPosition.x >= end.transform.localPosition.x)
        {
            isForward = false;
        }
        if (transform.localPosition.x <= start.transform.localPosition.x)
        {
            isForward = true;
        }
        if (isForward)
        {
            moveToEnd();
        }
        else
        {
            moveToStart();
        }
    }

    public void moveToEnd()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, end.transform.localPosition, Time.deltaTime * monster_speed);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void moveToStart()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, start.transform.localPosition, Time.deltaTime * monster_speed);
        transform.eulerAngles = new Vector3(0, 180, 0);

    }
}
