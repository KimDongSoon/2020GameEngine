using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    // 아이템이 스폰 될 위치
    public Transform[] points;

    // 아이템 프리팹
    public GameObject item;

    // 생성 주기
    public float createTime = 1.0f;                     // 나중에 수정 // 테스트용

    // 최대 생성 개수
    public int maxItem = 10;                                 // 나중에 수정 // 테스트용

    // 지금까지 총 만들어진 아이템 개수
    public int totalItem = 0;

    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("아이템 스폰 스타트 불림");

        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        
        if (points.Length > 0)
        {
            StartCoroutine(this.CreateItem());
        }

        if(totalItem == 30)
        {
            isGameOver = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator CreateItem()
    {
        while (!isGameOver)
        {
            // 현재 생성된 아이템 개수 산출
            int itemCount = (int)GameObject.FindGameObjectsWithTag("Item").Length;      

            // 최대 생성 개수보다 작을때만 생성
            if (itemCount < maxItem)
            {
                // 생성 주기 시간만큼 대기
                yield return new WaitForSeconds(createTime);

                // 불규칙적인 위치 산출
                int idx = Random.Range(1, points.Length);
                // 아이템 동적 생성
                Instantiate(item, points[idx].position, points[idx].rotation);

                ++totalItem;
            }

            else
                yield return null;
        }

        Debug.Log("아이템 스폰 불림");
    }
}
