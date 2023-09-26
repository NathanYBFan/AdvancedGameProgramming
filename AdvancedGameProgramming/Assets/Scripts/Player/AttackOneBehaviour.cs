using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOneBehaviour : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1f);
    }
}
