using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject[] key_random_pos_obj;

    bool get_key_tr = false;

    private void Start()
    {
        this.transform.position = key_random_pos_obj[Random.Range(0, key_random_pos_obj.Length)].transform.position;
    }

    public bool Get_get_key_tr()
    {
        return get_key_tr;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        get_key_tr= true;
    }
}