using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Rigidbody2D ry;
    SpriteRenderer sr;
    Animator ar;
    NavMeshAgent nma;

    [SerializeField] GameObject player_obj;
    [SerializeField] GameObject game_out_ui_obj;

    [SerializeField] float speed = 3;

    bool follow_player_tr = false;

    [Header("몬스터 이동 애니메이션")]
    [SerializeField] string enemy_side_walk_AM;
    [SerializeField] string enemy_up_walk_AM;
    [SerializeField] string enemy_down_walk_AM;

    string enemy_AM = null;

    private void Awake()
    {
        ry = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        nma = this.gameObject.GetComponent<NavMeshAgent>();
        ar = this.gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        ry.gravityScale = 0;
        ry.constraints = RigidbodyConstraints2D.FreezeRotation;

        nma.updateRotation = false;
        nma.updateUpAxis = false;

        nma.speed = 0;
    }

    /* private void Update()
    {
        float move_pos = Vector2.Distance(player_obj.transform.position, this.transform.position);

        // float move_x = (player_obj.transform.position.x - this.transform.position.x);
        // float move_y = (player_obj.transform.position.y - this.transform.position.y);

        if (move_pos <= 20 || follow_player_tr)
        {
            follow_player_tr = true;

            nma.SetDestination(player_obj.transform.position);

            if (nma.remainingDistance < 0.5f)
            {
                Vector3 direction = (player_obj.transform.position - transform.position).normalized;

                ry.velocity = direction * speed;

                Vector2 move = (player_obj.transform.position - this.transform.position).normalized * speed * Time.fixedDeltaTime;

                this.transform.Translate(move, 0);
            }
            else
            {
                ry.velocity = Vector3.zero;
            }
        }
    } */

    private void FixedUpdate()
    {
        Vector2 move_pos = player_obj.transform.position - this.transform.position;

        // float move_x = (player_obj.transform.position.x - this.transform.position.x);
        // float move_y = (player_obj.transform.position.y - this.transform.position.y);

        if (Mathf.Abs(move_pos.x) > Mathf.Abs(move_pos.y))
        {
            // 수평 이동이 더 큰 경우
            if (move_pos.x > 0)
            {
                sr.flipX = true;
            }
            else if (move_pos.x < 0)
            {
                sr.flipX = false;
            }
            enemy_AM = enemy_side_walk_AM;
        }
        else
        {
            // 수직 이동이 더 큰 경우
            if (move_pos.y > 0)
            {
                enemy_AM = enemy_up_walk_AM;
            }
            else if (move_pos.y < 0)
            {
                enemy_AM = enemy_down_walk_AM;
            }
        }


        if (move_pos.x <= 10 && move_pos.y <= 10 || follow_player_tr)
        {
            follow_player_tr = true;

            nma.SetDestination(player_obj.transform.position);

            Vector2 move = (player_obj.transform.position - this.transform.position).normalized * speed * Time.fixedDeltaTime;

            this.transform.Translate(move, 0);
        }
    }

    private void LateUpdate()
    {
        ar.Play(enemy_AM);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;

            Debug.Log("게임 아웃!");

            game_out_ui_obj.SetActive(true);

            // SceneManager.LoadScene("Lobby");
        }
    }
}