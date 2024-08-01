using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_text_UI : MonoBehaviour
{
    [SerializeField] Text[] score_text;

    [SerializeField] string enemy_score_sentence;
    [SerializeField] string time_score_sentence;
    [SerializeField] string total_score_sentence;

    [Header("인스턴스화")]
    [SerializeField] Score score_class;
    [SerializeField] Escape_stage1 escape_stage1_class;

    private void LateUpdate()
    {
        if (escape_stage1_class.Get_Stage1_clear_tr())
        {
            score_text[0].text = $"{enemy_score_sentence} {score_class.Get_enemy_score()}";
            score_text[1].text = $"{time_score_sentence} {score_class.Get_time_score()}";
            score_text[2].text = $"{total_score_sentence} {score_class.Get_total_score()}";
        }
    }
}