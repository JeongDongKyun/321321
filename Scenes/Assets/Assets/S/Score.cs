using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("인스턴스화")]
    [SerializeField] Escape_stage1 escape_stage1_class;
    [SerializeField] Dungeon_timer dungeon_timer_class;
    Text text;

    int enemy_score = 0;
    int time_score = 0;
    int total_score = 0;

    private void Awake()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    private void Start()
    {
        enemy_score = 0;

        text.text = $"Score: {Get_enemy_score()}";
    }

    private void LateUpdate()
    {
        Sum_score();
    }

    private void Sum_score()
    {
        text.text = $"Score: {Get_total_score()}";
    }

    public void Set_enemy_score(int enemy_score)
    {
        this.enemy_score += enemy_score;
    }

    public int Get_enemy_score()
    {
        return enemy_score;
    }

    public int Get_time_score()
    {
        time_score = (int)dungeon_timer_class.Get_timer() * 25;

        return time_score;
    }

    public int Get_total_score()
    {
        total_score = enemy_score + time_score;

        return total_score;
    }
}