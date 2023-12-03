using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartInitializations : MonoBehaviour
{
    [SerializeField]
    private bool isMainMenu;

    void Start()
    {
        if (!isMainMenu)
            GameManager._Instance.InLevel();
        else
            GameManager._Instance.ExitLevel();
    }
}
