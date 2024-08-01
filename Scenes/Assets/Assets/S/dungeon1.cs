using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dungeon1 : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Dungeon");
    }
}