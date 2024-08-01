using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dungeon_timer : MonoBehaviour
{
    Text timer_text;

    [SerializeField] Animator player_ar;
    [SerializeField] GameObject player_obj;
    [SerializeField] GameObject bomb_obj;

    float timer = 0;

    bool timer_stop_tr = false;

    [SerializeField] string Player_side_stand_AM1;

    private void Awake()
    {
        timer_text = this.gameObject.GetComponent<Text>();
    }

    private void Start()
    {
        Time.timeScale = 1;

        player_ar.Play(Player_side_stand_AM1);

        player_obj.gameObject.transform.position = new Vector2(-0.15f, -0.14f);
        bomb_obj.gameObject.transform.position = new Vector2(-0.42f, -0.25f);

        timer = Gamemanager.game_manager.dungeon_timer2;
    }

    private void Update()
    {
        if (timer_stop_tr == false)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            // 점수 저장 로직
        }

        if (timer <= 0)
        {
            timer = 0;

            Time.timeScale = 0;

            Debug.Log("게임 종료!");

            SceneManager.LoadScene("Lobby");
        }
    }

    private void LateUpdate()
    {
        int timer_min = Mathf.FloorToInt(timer / 60);
        int timer_sec = Mathf.FloorToInt(timer % 60);

        timer_text.text = string.Format("{0:00}:{1:00}", timer_min, timer_sec);
    }

    public void Set_timer(float timer)
    {
        this.timer = timer;
    }

    public float Get_timer()
    {
        return timer;
    }

    public void Set_timer_stop(bool timer_stop_tr)
    {
        this.timer_stop_tr = timer_stop_tr;
    }
}