using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D ry;
    Animator ar;
    SpriteRenderer sr;

    [SerializeField] Bomb_weapon bomb_weapon_obj;

    [SerializeField] GameObject[] bombs_obj;
    [SerializeField] Transform player_obj;
    [SerializeField] GameObject bomb_obj;
    [SerializeField] SpriteRenderer bomb_sr;

    float speed = 0;
    float move_x = 0;
    float move_y = 0;

    bool sr_tr = false;
    bool attack_tr = false;
    bool timer_IE1 = false;
    bool timer_IE2 = false;
    bool IE_check = false;

    [Header("캐릭터 공격 애니메이션")]
    [SerializeField] string player_side_attack_AM;
    [SerializeField] string player_up_attack_AM;
    [SerializeField] string player_down_attack_AM;

    [Header("캐릭터 멈춘 애니메이션1")]
    [SerializeField] string player_side_stand_AM1;
    [SerializeField] string player_up_stand_AM1;
    [SerializeField] string player_down_stand_AM1;

    [Header("캐릭터 멈춘 애니메이션2")]
    [SerializeField] string player_side_stand_AM2;
    [SerializeField] string player_up_stand_AM2;
    [SerializeField] string player_down_stand_AM2;

    [Header("캐릭터 이동 애니메이션1")]
    [SerializeField] string player_side_walk_AM1;
    [SerializeField] string player_up_walk_AM1;
    [SerializeField] string player_down_walk_AM1;

    [Header("캐릭터 이동 애니메이션2")]
    [SerializeField] string player_side_walk_AM2;
    [SerializeField] string player_up_walk_AM2;
    [SerializeField] string player_down_walk_AM2;

    string player_AM = null;
    string Direction = null;

    private void Awake()
    {
        ry = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        ar = this.gameObject.GetComponent<Animator>();
        bomb_sr = bomb_obj.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ry.gravityScale = 0;
        ry.constraints = RigidbodyConstraints2D.FreezeRotation;

        speed = Gamemanager.game_manager.player_speed;
    }

    private void Update()
    {
        AM();
        Move();
        Attack();
    }

    private void FixedUpdate()
    {
        ry.velocity = new Vector2(move_x, move_y).normalized * speed;
    }

    private void LateUpdate()
    {
        ar.Play(player_AM);

        sr.flipX = sr_tr;
    }

    private void Move()
    {
        move_x = 0;
        move_y = 0;

        if (Input.GetKey(KeyCode.D))
        {
            sr_tr = true;

            if (attack_tr == false)
            {
                bomb_sr.sortingOrder = 2;

                bomb_obj.gameObject.transform.localPosition = new Vector2(0.42f, -0.25f);
            }

            move_x = speed;

            Direction = "오른쪽";
        }

        if (Input.GetKey(KeyCode.A))
        {
            sr_tr = false;

            if (attack_tr == false)
            {
                bomb_sr.sortingOrder = 2;

                bomb_obj.gameObject.transform.localPosition = new Vector2(-0.42f, -0.25f);
            }

            move_x = -speed;

            Direction = "왼쪽";
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (attack_tr == false)
            {
                bomb_sr.sortingOrder = 0;

                bomb_obj.gameObject.transform.localPosition = new Vector2(0, 0.22f);
            }

            move_y = speed;

            Direction = "위쪽";
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (attack_tr == false)
            {
                bomb_sr.sortingOrder = 2;

                bomb_obj.gameObject.transform.localPosition = new Vector2(0, -0.38f);
            }

            move_y = -speed;

            Direction = "아래쪽";
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IE_check == false)
        {
            attack_tr = true;

            if (Direction == "오른쪽" || (Direction == "왼쪽"))
            {
                player_AM = player_side_attack_AM;

                timer_IE2 = true;

                StartCoroutine(Timer_IE());
            }
            else if (Direction == "위쪽")
            {
                player_AM = player_up_attack_AM;

                timer_IE2 = true;

                StartCoroutine(Timer_IE());
            }
            else if (Direction == "아래쪽")
            {
                player_AM = player_down_attack_AM;

                timer_IE2 = true;

                StartCoroutine(Timer_IE());
            }

            Vector2 save_pos = bomb_obj.transform.position;

            bomb_obj.transform.SetParent(null);

            bomb_obj.transform.position = save_pos;

            bomb_sr.sortingOrder = 0;

            timer_IE1 = true;

            StartCoroutine(Timer_IE());
        }
    }

    private void AM()
    {
        if (attack_tr)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                player_AM = player_side_walk_AM2;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                player_AM = player_side_stand_AM2;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                player_AM = player_up_walk_AM2;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                player_AM = player_up_stand_AM2;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                player_AM = player_down_walk_AM2;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                player_AM = player_down_stand_AM2;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                player_AM = player_side_walk_AM1;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                player_AM = player_side_stand_AM1;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                player_AM = player_up_walk_AM1;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                player_AM = player_up_stand_AM1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                player_AM = player_down_walk_AM1;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                player_AM = player_down_stand_AM1;
            }
        }
    }

    IEnumerator Timer_IE()
    {
        if (timer_IE1)
        {
            IE_check = true;

            yield return new WaitForSeconds(2);

            bomb_sr.enabled = false;

            for (int i = 0; i < bombs_obj.Length; i++)
            {
                bombs_obj[i].gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(1);

            for (int i = 0; i < bombs_obj.Length; i++)
            {
                bombs_obj[i].gameObject.SetActive(false);
            }

            bomb_weapon_obj.Set_speed(1);

            bomb_sr.sortingOrder = 2;

            bomb_obj.transform.SetParent(player_obj);

            bomb_obj.transform.position = this.transform.localPosition;

            bomb_sr.enabled = true;

            if (Direction == "오른쪽")
            {
                player_AM = player_side_stand_AM1;

                bomb_obj.gameObject.transform.localPosition = new Vector2(0.42f, -0.25f);
            }
            else if (Direction == "왼쪽")
            {
                player_AM = player_side_stand_AM1;

                bomb_obj.gameObject.transform.localPosition = new Vector2(-0.42f, -0.25f);
            }
            else if (Direction == "위쪽")
            {
                player_AM = player_up_stand_AM1;

                bomb_obj.gameObject.transform.localPosition = new Vector2(0, 0.22f);
            }
            else if (Direction == "아래쪽")
            {
                player_AM = player_down_stand_AM1;

                bomb_obj.gameObject.transform.localPosition = new Vector2(0, -0.38f);
            }

            attack_tr = false;
            timer_IE1 = false;
            IE_check = false;
        }

        if (timer_IE2)
        {
            yield return new WaitForSeconds(1);

            if (Direction == "오른쪽" || (Direction == "왼쪽"))
            {
                player_AM = player_side_stand_AM2;
            }
            else if (Direction == "위쪽")
            {
                player_AM = player_up_stand_AM2;
            }
            else if (Direction == "아래쪽")
            {
                player_AM = player_down_stand_AM2;
            }

            timer_IE2 = false;
        }
    }
}