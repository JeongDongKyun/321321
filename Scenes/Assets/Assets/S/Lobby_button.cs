using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby_button : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = this.gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(Lobby);
    }

    private void Lobby()
    {
        Debug.Log("dsadasdas");

        // SceneManager.LoadScene("Lobby");
    }
}