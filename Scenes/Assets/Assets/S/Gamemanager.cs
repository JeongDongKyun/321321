using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager game_manager;

    [Header("몬스터 추가 필수 설정!")]
    [Tooltip("개수")] public GameObject[] enemy_objs;
    [Tooltip("체력")] public Enemy_blood[] enemy_blood;
    [Tooltip("체력 바")] public Canvas[] canvas;
    [Tooltip("피격")] public SpriteRenderer[] sr;

    [Header("진값 설정")]
    [Tooltip("캐릭터 이동 속도")] public float player_speed = 0;
    [Tooltip("던전 시간")] public float dungeon_timer2 = 0;
    [Tooltip("폭탄 (무기) 공격력")] public int bomb_weapon_power = 0;

    [Header("인스턴스화 설정")]
    public Player player;
    public Enemy enemy;
    public Dungeon_timer dungeon_timer;
    public Score score;
    public Bomb_weapon bomb_weapon;
    public Key key;

    private void Awake()
    {
        game_manager = this;
    }
}