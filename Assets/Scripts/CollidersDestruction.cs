﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersDestruction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.SetActive(false);
    }
}
