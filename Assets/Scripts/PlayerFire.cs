using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // �߻� ��ġ
    public GameObject firePosition;
    // ��ź ������Ʈ
    public GameObject bombFactory;
    // ��ô �Ŀ�
    public float throwPower = 15f;
    // �Ѿ� ����Ʈ
    public GameObject bulletEffect;
    // ��ƼŬ �ý���
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 ������ ��ư �Է�
        if (Input.GetMouseButtonDown(1))
        {
            // ��ź ����
            GameObject bomb = Instantiate(bombFactory);
            // ��ź�� ��ġ�� �߻� ��ġ�� �̵�
            bomb.transform.position = firePosition.transform.position;
            // ��ź�� ������ �ٵ� �޾ƿ�
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            // ī�޶��� �������� ��ź�� ���� ����
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }

        // ���콺 ���� ��ư �Է�
        if (Input.GetMouseButtonDown(0))
        {
            // ���� ���� �� ��ġ�� ���� ����
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            // ���̰� �ε��� ��� ����
            RaycastHit hitInfo = new RaycastHit();
            // ���̸� �߻��� ��, �ε��� ��ü�� ������
            if (Physics.Raycast(ray, out hitInfo))
            {
                bulletEffect.transform.position = hitInfo.point;
                ps.Play();
            }
        }

    }
}
