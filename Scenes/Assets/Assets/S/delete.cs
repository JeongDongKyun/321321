using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delete_text : MonoBehaviour
{
    Color color;

    Text text;

    [SerializeField, Header("삭제 속도")] float speed = 0;

    private void Awake()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        if (speed <= 0.1f)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        speed = speed * (float)0.97f;

        color.a = speed;

        text.color = color;
    }
}