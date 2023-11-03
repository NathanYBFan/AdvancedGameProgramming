using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    public static ExpManager _Instance { get; private set; }
    
    [SerializeField]
    private Transform expContainer;
    
    
    public List<Transform> expOrbs;

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.Log("Extra Exp Manager singleton destroyed");
            Destroy(this);
        }
        else
            _Instance = this;
    }

    public List<Transform> GetAllOrbs() { return expOrbs; }
    public Transform GetExpContainer() { return expContainer; }
}
