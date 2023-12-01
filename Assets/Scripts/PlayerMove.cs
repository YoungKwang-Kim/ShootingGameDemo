using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 이동속도
    public float moveSpeed = 7f;
    // 캐릭터 컨트롤러 컴포넌트 변수
    CharacterController cc;
    // 중력 변수
    float gravity = -20f;
    // 수직 속력 변수
    float yVelocity = 0;
    // 점프파워
    public float jumpPower = 7f;
    // 점프 파워 상태 변수
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
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

        // 바닥에 착지했다면
        if (cc.collisionFlags == CollisionFlags.Below && isJumping)
        {
            isJumping = false;
            yVelocity = 0;
            
        }

        // 스페이스바 버튼을 누르면 점프
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
            Debug.Log(yVelocity);
        }

        // 이동
        // transform.position += moveSpeed * dir * Time.deltaTime;

        // 수직 속도에 중력 값 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 이동
        cc.Move(dir * moveSpeed * Time.deltaTime);
        

    }
}
