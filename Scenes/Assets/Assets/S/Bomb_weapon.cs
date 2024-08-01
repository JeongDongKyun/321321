using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bomb_weapon : MonoBehaviour
{
    [SerializeField] Light2D light2d;
    [SerializeField] Enemy_blood[] enemy_blood;

    [SerializeField, Header("폭탄 (무기) 공격력")] int power = 0;

    [SerializeField, Header("폭탄 불빛 삭제 속도")] float speed = 0;

    bool[] enemy_tr;

    private void Awake()
    {
        enemy_tr = new bool[Gamemanager.game_manager.enemy_objs.Length];
    }

    public void Set_enemy_tr(int array_number, bool enemy_tr)
    {
        this.enemy_tr[array_number] = enemy_tr;
    }

    public bool Get_enemy_tr(int array_number)
    {
        return enemy_tr[array_number];
    }

    private void FixedUpdate()
    {
        color();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            for (int i = 0; i < Gamemanager.game_manager.enemy_objs.Length; i++)
            {
                if (collision.gameObject.name == $"Enemy{i + 1}")
                {
                    enemy_tr[i] = true;
                }
            }

            StartCoroutine(Timer_IE());
        }
    }

    IEnumerator Timer_IE()
    {
        for (int i = 0; i < Gamemanager.game_manager.enemy_objs.Length; i++)
        {
            if (enemy_tr[i])
            {
                player_weapon_damge(i, power);

                Gamemanager.game_manager.enemy_blood[i].Blood();

                Gamemanager.game_manager.canvas[i].enabled = true;

                Gamemanager.game_manager.sr[i].color = Color.red;

                light2d.color = Color.red;

                yield return new WaitForSeconds(0.5f);

                Gamemanager.game_manager.canvas[i].enabled = false;

                Gamemanager.game_manager.sr[i].color = Color.white;

                light2d.color = Color.white;
            }
        }
    }

    public void player_weapon_damge(int enemy_number, int damage)
    {
        Enemy_blood.blood[enemy_number] -= damage;
    }

    private void color()
    {
        speed = speed * (float)0.90f;

        light2d.intensity = speed;
    }

    public void Set_speed(float speed)
    {
        this.speed = speed;
    }
}