using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_UI : MonoBehaviour
{
    Button button;

    [SerializeField] GameObject[] menu_obj;
    [SerializeField] GameObject setting_popups_obj;
    [SerializeField] GameObject explanation_popups_obj;
    [SerializeField] GameObject dungeon_popups_obj;

    bool click_tr = false;

    private void Awake()
    {
        button = this.gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(Click_UI);
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(Click_UI);
        }
    }

    private void Click_UI()
    {
        if (gameObject.CompareTag("Setting_UI"))
        {
            setting_popups_obj.gameObject.SetActive(true);
        }
        else if (gameObject.CompareTag("Explanation_UI"))
        {
            explanation_popups_obj.gameObject.SetActive(true);
        }
        else if (gameObject.CompareTag("Dungeon_UI"))
        {
            dungeon_popups_obj.gameObject.SetActive(true);
        }
        else if (gameObject.CompareTag("Lightning_UI"))
        {

        }
        else if (gameObject.CompareTag("Weapon_UI"))
        {

        }
        else if (gameObject.CompareTag("Character_UI"))
        {

        }

        if (gameObject.CompareTag("Menu_UI"))
        {
            click_tr = !click_tr;

            if (click_tr)
            {
                for (int i = 0; i < menu_obj.Length; i++)
                {
                    menu_obj[i].gameObject.SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < menu_obj.Length; i++)
                {
                    menu_obj[i].gameObject.SetActive(false);
                }
            }
        }

        if (gameObject.CompareTag("Popups_exit"))
        {
            setting_popups_obj.gameObject.SetActive(false);
            explanation_popups_obj.gameObject.SetActive(false);
            dungeon_popups_obj.gameObject.SetActive(false);
        }
    }
}