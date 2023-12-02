using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    // 지속 시간
    public float destroyTime = 1.5f;
    // 경과 시간
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 경과 시간이 지속 시간을 초과하면
        if (currentTime > destroyTime)
        {
            // 이펙트 제거
            Destroy(gameObject);
        }
        // 경과 시간 누적
        currentTime += Time.deltaTime;
    }
}
