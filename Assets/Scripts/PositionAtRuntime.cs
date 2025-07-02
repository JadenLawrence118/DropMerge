using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAtRuntime : MonoBehaviour
{
    [SerializeField] private float xPosPercent;
    [SerializeField] private float yPosPercent;
    void Awake()
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3((xPosPercent / 100), (yPosPercent / 100), 1));
    }
}
