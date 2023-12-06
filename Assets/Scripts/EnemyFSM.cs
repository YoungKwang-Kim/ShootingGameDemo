using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    // �� ���� ���
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }
    // �� ���� ����
    EnemyState m_State;
    // �÷��̾� �߰� ����
    public float findDistance = 8f;
    // �÷��̾� Ʈ������ ������Ʈ
    Transform player;
    // ���� ����
    public float attackDitance = 2f;
    // �� �̵� �ӵ�
    public float moveSpeed = 5f;
    // ĳ���� ��Ʈ�ѷ� ������Ʈ
    CharacterController cc;
    // ���� �ð�
    float currentTime = 0;
    // ���� ������ �ð�
    float attackDelay = 2f; 

    // Start is called before the first frame update
    void Start()
    {
        // �÷��̾� Ʈ������ ������Ʈ �Ҵ�
        player = GameObject.Find("Player").transform;
        // ������ �� ���¸� ���� ����
        m_State = EnemyState.Idle;
        // ĳ���� ��Ʈ�ѷ� ������Ʈ �Ҵ�
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // �� ���¸� üũ�ؼ� ���º��� ������ ��� ����
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    void Idle()
    {
        // ���� �÷��̾�� ���� �Ÿ��� �߰� ���� �̳���� Move ���·� ��ȯ
        if (Vector3.Distance(player.position, transform.position) < findDistance)
        {
            m_State = EnemyState.Move;
            Debug.Log("���� ��ȯ : Idle -> Move");
        }
    }

    void Move()
    {
        // ���� �÷��̾�� ���� �Ÿ��� ���� �������� ũ�ٸ� �÷��̾ ���� �̵�
        if (Vector3.Distance(player.position, transform.position) > attackDitance)
        {
            // �̵� ����
            Vector3 dir = (player.position - transform.position).normalized;
            // �̵�
            cc.Move(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            m_State = EnemyState.Attack;
            Debug.Log("���� ��ȯ : Move -> Attack");
            // ���� �ð��� ���� ������ �ð���ŭ �̸� ����
            currentTime = attackDelay;
        }
    }
    void Attack()
    {
        // ���� �÷��̾�� ���� �Ÿ��� ���� ���� �̳���� ����
        if (Vector3.Distance(player.position, transform.position) < attackDitance)
        {
            // ���� �ð����� �÷��̾ ����
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                Debug.Log("����");
                currentTime = 0;
            }
        }
        // �׷��� �ʴٸ�, �̵�(Move)
        else
        {
            m_State = EnemyState.Move;
            Debug.Log("���� ��ȯ : Attack -> Move");
            currentTime = 0;
        }
    }
}
