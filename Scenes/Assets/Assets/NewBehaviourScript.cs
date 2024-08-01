using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int cash = 10000; // 플레이어 돈 머니
    int apple = 30; // 사과 가격

    private void Start()
    {
        if (cash >= apple)
        {
            Debug.Log("금액이 충분합니다.");

            cash = cash - apple; // 2, 내 돈에서 -30원이 차감된다

            Debug.Log(cash);
        }
        else
        {
            Debug.Log("금액이 부족합니다.");
        }
    }
}