using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_blood : MonoBehaviour
{
    Image blood_UI;

    [SerializeField] Gradient gradient;
    [SerializeField] GameObject enemy_obj;

    public static float[] blood = { };

    private void Awake()
    {
        blood_UI = this.gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        blood = new float[Gamemanager.game_manager.enemy_objs.Length];

        for (int i = 0; i < blood.Length; i++)
        {
            blood[i] = 100;
        }
    }

    public void Blood()
    {
        for (int i = 0; i < Gamemanager.game_manager.enemy_objs.Length; i++)
        {
            if (Gamemanager.game_manager.bomb_weapon.Get_enemy_tr(i))
            {
                blood_UI.fillAmount = blood[i] / 100;

                blood_UI.color = gradient.Evaluate(blood[i]);

                Gamemanager.game_manager.bomb_weapon.Set_enemy_tr(i, false);

                if (blood[i] <= 0)
                {
                    Gamemanager.game_manager.score.Set_enemy_score(100);

                    enemy_obj.gameObject.SetActive(false);

                    Gamemanager.game_manager.bomb_weapon.Set_enemy_tr(i, false);
                }
            }
        }
    }
}