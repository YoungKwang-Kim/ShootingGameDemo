using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �̵��ӵ�
    public float moveSpeed = 7f;
    // ĳ���� ��Ʈ�ѷ� ������Ʈ ����
    CharacterController cc;
    // �߷� ����
    float gravity = -20f;
    // ���� �ӷ� ����
    float yVelocity = 0;
    // �����Ŀ�
    public float jumpPower = 7f;
    // ���� �Ŀ� ���� ����
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ű���� �Է�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �̵� ���� ����
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        // ī�޶� �������� �̵�
        dir = Camera.main.transform.TransformDirection(dir);

        // �ٴڿ� �����ߴٸ�
        if (cc.collisionFlags == CollisionFlags.Below && isJumping)
        {
            isJumping = false;
            yVelocity = 0;
            
        }

        // �����̽��� ��ư�� ������ ����
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
            Debug.Log(yVelocity);
        }

        // �̵�
        // transform.position += moveSpeed * dir * Time.deltaTime;

        // ���� �ӵ��� �߷� �� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // �̵�
        cc.Move(dir * moveSpeed * Time.deltaTime);
        

    }
}
