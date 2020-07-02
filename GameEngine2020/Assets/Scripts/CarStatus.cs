using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStatus : MonoBehaviour
{
    // 받아올 오브젝트
    [SerializeField]
    public StatusController go_Status;

    // Start is called before the first frame update
    void Start()
    {
        //go_Status = FindObjectOfType<StatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            // 파괴 시키고 차의 연료를 채워줄 것
            go_Status.IncreaseGas(30);
        }
        Destroy(other.gameObject);
    }

    

}
