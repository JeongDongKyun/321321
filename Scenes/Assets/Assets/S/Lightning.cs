using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightning : MonoBehaviour
{
    Text lightning_text;

    [SerializeField, Header("번개 (화폐)")] int lightning = 0;

    private void Awake()
    {
        lightning_text = this.gameObject.GetComponent<Text>();
    }

    private void LateUpdate()
    {
        lightning_text.text = lightning.ToString();
    }
}