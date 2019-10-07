using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BcgScroller : MonoBehaviour
{
    [SerializeField] private float speed;
    Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }


    void Update()
    {
        material.mainTextureOffset += new Vector2(0f, speed);
    }
}
