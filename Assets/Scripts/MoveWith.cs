using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWith : MonoBehaviour
{
    [SerializeField] private GameObject moveWith;
    void Update()
    {
        transform.position = moveWith.transform.position;
    }
}
