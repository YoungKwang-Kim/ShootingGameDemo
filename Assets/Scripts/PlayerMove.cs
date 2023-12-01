using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �̵��ӵ�
    public float moveSpeed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
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

        // �̵�
         transform.position += moveSpeed * dir * Time.deltaTime;

    }
}
