using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    Text coin_text;

    [SerializeField, Header("코인 (화폐)")] int coin = 0;

    private void Awake()
    {
        coin_text = this.gameObject.GetComponent<Text>();
    }

    private void LateUpdate()
    {
        coin_text.text = coin.ToString();
    }
}