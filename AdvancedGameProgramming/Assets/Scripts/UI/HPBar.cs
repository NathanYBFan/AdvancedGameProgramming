using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("")]
    private GameCharacterStats gameCharacterStats;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("")]
    private GameObject heartPrefab;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("")]
    private GameObject heartBGPrefab;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("")]
    private Transform heartManager;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("")]
    private Transform heartBGManager;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private List<GameObject> hearts = null;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private List<GameObject> heartBGs = null;

    public void Start()
    {
        hearts.Clear();
        heartBGs.Clear();

        MaxHPChanged();
        CurrentHPChanged();
    }

    public void CurrentHPChanged()
    {
        int numberOfExistingHearts = hearts.Count;

        int newCurrentHP = gameCharacterStats.HP;

        if (numberOfExistingHearts < newCurrentHP) // Increased HP
        {
            for (int i = 0; i < (newCurrentHP - numberOfExistingHearts); i++)
            {
                hearts.Add(GameObject.Instantiate(heartPrefab, heartManager));
            }
        }

        else if (numberOfExistingHearts > newCurrentHP) // Lost HP
        {
            for (int i = 0; i < (numberOfExistingHearts - newCurrentHP); i++)
            {
                Destroy(hearts[0]);
                hearts.RemoveAt(0);
            }
        }
    }

    public void MaxHPChanged()
    {
        int numberOfExistingHeartBGs = heartBGs.Count;
        int numberOfExistingHearts = hearts.Count;

        int newMaxHP = gameCharacterStats.MaxHp;

        if (numberOfExistingHeartBGs < newMaxHP) // Increased HP
        {
            for (int i = 0; i < (newMaxHP - numberOfExistingHeartBGs); i++)
            {
                heartBGs.Add(GameObject.Instantiate(heartBGPrefab, heartBGManager));
                hearts.Add(GameObject.Instantiate(heartPrefab,heartManager));
            }
        }

        else if (numberOfExistingHeartBGs > newMaxHP) // Lost HP
        {
            for (int i = 0; i < (numberOfExistingHeartBGs - newMaxHP); i++)
            {
                if ( numberOfExistingHearts == numberOfExistingHeartBGs)
                {
                    Destroy(hearts[0]);
                    hearts.RemoveAt(0);
                }

                Destroy(heartBGs[0]);
                heartBGs.RemoveAt(0);
            }
        }

    }


}
