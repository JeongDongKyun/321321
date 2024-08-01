using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_text : MonoBehaviour
{
    [Header("인스턴스화")]
    [SerializeField] Escape_stage1 escape_stage1_class;

    RectTransform rt;

    [SerializeField, Header("UI 이동")] float speed = 0;

    private void Awake()
    {
        rt = this.gameObject.GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (escape_stage1_class.Get_Stage1_clear_tr())
        {
            if (this.rt.anchoredPosition.x >= -100)
            {
                this.rt.anchoredPosition += new Vector2(-speed * Time.fixedDeltaTime, 0);
            }
        }
        else
        {
            this.rt.anchoredPosition = new Vector2(600, 0);
        }
    }
}