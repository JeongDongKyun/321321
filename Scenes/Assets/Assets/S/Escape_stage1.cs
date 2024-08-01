using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape_stage1 : MonoBehaviour
{
    [SerializeField] Animator player_ar;
    [SerializeField] SpriteRenderer player_sr;
    [SerializeField] Rigidbody2D player_ry;
    [SerializeField] GameObject bomb_obj;
    [SerializeField] GameObject win_obj;
    [SerializeField] GameObject stage1_text;
    [SerializeField] GameObject stage2_text;
    [SerializeField] GameObject clear_stage1_obj;
    [SerializeField] GameObject start_stage1_obj;
    [SerializeField] GameObject mission_obj;
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    [SerializeField] Text clear_stage1;
    [SerializeField] Text score_text;

    bool start_tr = true;
    bool stage1_clear_tr = false;

    [SerializeField] string Player_side_stand_AM1;

    private void Update()
    {
        if (start_tr)
        {
            start_stage1_obj.gameObject.SetActive(true);

            start_tr = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Gamemanager.game_manager.key.Get_get_key_tr())
        {
            StartCoroutine(Timer_IE());
        }
    }

    IEnumerator Timer_IE()
    {
        stage1_clear_tr = true;

        for (int i = 0; i < Gamemanager.game_manager.enemy_objs.Length; i++)
        {
            Gamemanager.game_manager.enemy_objs[i].gameObject.SetActive(false);
        }

        stage1_text.gameObject.SetActive(false);
        score_text.enabled = false;

        Gamemanager.game_manager.dungeon_timer.Set_timer_stop(true);

        player_ry.velocity = Vector2.zero;

        mission_obj.gameObject.SetActive(false);
        bomb_obj.gameObject.SetActive(false);
        player_sr.enabled = false;
        Gamemanager.game_manager.player.enabled = false;
        win_obj.gameObject.SetActive(true);

        Gamemanager.game_manager.player.gameObject.transform.position = new Vector2(-102.48f, 81.41f);

        yield return new WaitForSeconds(5);

        bomb_obj.gameObject.SetActive(true);
        player_sr.enabled = true;
        Gamemanager.game_manager.player.enabled = true;
        mission_obj.gameObject.SetActive(true);
        obj2.gameObject.SetActive(true);
        obj1.gameObject.SetActive(false);

        win_obj.gameObject.SetActive(false);

        Gamemanager.game_manager.player.gameObject.transform.position = new Vector2(-128.41f, 83.54f);

        clear_stage1_obj.gameObject.SetActive(true);
        stage2_text.gameObject.SetActive(true);
        score_text.enabled = true;

        Gamemanager.game_manager.dungeon_timer.Set_timer_stop(false);

        Gamemanager.game_manager.dungeon_timer.Set_timer(30);

        player_ar.Play(Player_side_stand_AM1);
        Gamemanager.game_manager.player.gameObject.transform.position = new Vector2(-128.72f, 92.11f);
        bomb_obj.gameObject.transform.position = new Vector2(-0.42f, -0.25f);

        stage1_clear_tr = false;
    }

    public bool Get_Stage1_clear_tr()
    {
        return stage1_clear_tr;
    }
}