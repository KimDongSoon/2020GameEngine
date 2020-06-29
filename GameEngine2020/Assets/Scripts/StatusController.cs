using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    [SerializeField]
    private int gas;        // 연료의 최대 양
    private int currentGas; // 현재 연료의 양

    // 연료 증가량
    [SerializeField]
    private int gasIncreaseSpeed;   // 연료 증가량

    // 연료 회복 딜레이
    private int gasRechargeTime;
    private int currentGasRechargeTime;

    // 연료가 줄어드는 속도
    [SerializeField]
    private int gasDecreaseTime;
    private int currentGasDecreaseTime;

    // 연료 감소 여부
    private bool gasUsed;

    // 필요한 이미지
    [SerializeField]
    private Image image_Gas;

    // Start is called before the first frame update
    void Start()
    {
        currentGas = gas;       
    }

    // Update is called once per frame
    void Update()
    {
        Gas();
        //DecreaseGas();
        GasUpdate();
    }

    private void Gas()              // 연료가 닳는 함수
    {
        if(currentGas > 0)
        {
            if (currentGasDecreaseTime <= gasDecreaseTime)
                currentGasDecreaseTime++;
            else
            {
                currentGas--;
                currentGasDecreaseTime = 0;
            }
        }
    }


    private void DecreaseGas(int _count)
    {
        if (currentGas - _count < 0)
            currentGas = 0;
        else
            currentGas = -_count;
    }

    private void GasUpdate()
    {
        image_Gas.fillAmount = (float)currentGas / gas;
    }

}
