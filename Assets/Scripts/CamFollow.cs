using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // CamPositionÀÇ Æ®·£½ºÆû ÄÄÆ÷³ÍÆ®
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
    }
}
