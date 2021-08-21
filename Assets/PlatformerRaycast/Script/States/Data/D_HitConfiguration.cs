using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHitConfiguration", menuName = "Data/Hit Configuration Data")]
public class D_HitConfiguration : ScriptableObject
{
    public Vector2 knockbackValue;
    public Vector2 knockbackTime;
    public LayerMask WhatIsPlayer;
}
    

