using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    // 적 상태 상수
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }
    // 적 상태 변수
    EnemyState m_State;
    // 플레이어 발견 범위
    public float findDistance = 8f;
    // 플레이어 트랜스폼 컴포넌트
    Transform player;
    // 공격 범위
    public float attackDitance = 2f;
    // 적 이동 속도
    public float moveSpeed = 5f;
    // 캐릭터 컨트롤러 컴포넌트
    CharacterController cc;
    // 누적 시간
    float currentTime = 0;
    // 공격 딜레이 시간
    float attackDelay = 2f; 

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 트랜스폼 컴포넌트 할당
        player = GameObject.Find("Player").transform;
        // 최초의 적 상태를 대기로 설정
        m_State = EnemyState.Idle;
        // 캐릭터 컨트롤러 컴포넌트 할당
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 적 상태를 체크해서 상태별로 정해진 기능 수행
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
        // 만약 플레이어와 적의 거리가 발견 범위 이내라면 Move 상태로 전환
        if (Vector3.Distance(player.position, transform.position) < findDistance)
        {
            m_State = EnemyState.Move;
            Debug.Log("상태 전환 : Idle -> Move");
        }
    }

    void Move()
    {
        // 만약 플레이어와 적의 거리가 공격 범위보다 크다면 플레이어를 향해 이동
        if (Vector3.Distance(player.position, transform.position) > attackDitance)
        {
            // 이동 방향
            Vector3 dir = (player.position - transform.position).normalized;
            // 이동
            cc.Move(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            m_State = EnemyState.Attack;
            Debug.Log("상태 전환 : Move -> Attack");
            // 누적 시간을 공격 딜레이 시간만큼 미리 진행
            currentTime = attackDelay;
        }
    }
    void Attack()
    {
        // 만약 플레이어와 적의 거리가 공격 범위 이내라면 공격
        if (Vector3.Distance(player.position, transform.position) < attackDitance)
        {
            // 일정 시간마다 플레이어를 공격
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                Debug.Log("공격");
                currentTime = 0;
            }
        }
        // 그렇지 않다면, 이동(Move)
        else
        {
            m_State = EnemyState.Move;
            Debug.Log("상태 전환 : Attack -> Move");
            currentTime = 0;
        }
    }
}
