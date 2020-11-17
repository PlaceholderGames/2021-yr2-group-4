using UnityEngine;
using System;

public class FallOffMapRespawn : MonoBehaviour
{
    Vector3 InitialPos; // Starting position of the player
    float YOffset;
    void Start()
    {
        InitialPos = transform.position;
        YOffset = InitialPos.y - 50;
    }

    void Update()
    {
        if (InitialPos.y < YOffset)
        {
            transform.position = InitialPos;
        }
    }
}