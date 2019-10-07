using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool isVisible;

    private void Start()
    {
        isVisible = false;
        gameObject.GetComponent<Canvas>().enabled = isVisible;
    }

    public void ToggleVisiblity()
    {
        isVisible = !isVisible;
        gameObject.GetComponent<Canvas>().enabled = isVisible;
        Time.timeScale = isVisible ? 0 : 1;
    }

}
