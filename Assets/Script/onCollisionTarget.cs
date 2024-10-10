using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionTarget : MonoBehaviour
{
    public int point = 10;

    private void OnCollisionEnter(Collision collision)
    {
        ScoreScript.instance.ScoreManager(point);
    }
}
