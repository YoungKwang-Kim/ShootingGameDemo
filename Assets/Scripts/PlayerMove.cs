using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 이동속도
    public float moveSpeed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 키보드 입력
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 이동 방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        // 카메라를 기준으로 이동
        dir = Camera.main.transform.TransformDirection(dir);

        // 이동
         transform.position += moveSpeed * dir * Time.deltaTime;

    }
}
