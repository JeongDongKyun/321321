using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs : MonoBehaviour
{
    [SerializeField] GameObject[] enemy_obj;

    bool spawn_obs_tr = false;

    private void Update()
    {
        StartCoroutine(Timer_IE());
    }

    IEnumerator Timer_IE()
    {
        for (int i = 0; i < enemy_obj.Length; i++)
        {
            if (enemy_obj[i].activeSelf == false)
            {
                Enemy_blood.blood[i] = 100;

                enemy_obj[i].transform.position = this.transform.position;

                yield return new WaitForSeconds(5);

                enemy_obj[i].gameObject.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        spawn_obs_tr = true;
    }
}