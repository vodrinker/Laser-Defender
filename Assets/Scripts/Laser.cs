using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool playersShot;
    [SerializeField] private int dmg;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] [Range(0, 0.2f)] float soundVolume = 0.03f;
    private Vector3 direction;

    void Start()
    {
        direction = playersShot ? Vector3.up : Vector3.down;
        AudioSource.PlayClipAtPoint(shootSound, transform.position, soundVolume);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void DidPlayerShotIt(bool own)
    {
        playersShot = own;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        var tagToSeak = playersShot ? "Enemy" : "Player";
        if (collision.transform.tag == tagToSeak)
        {
            collision.GetComponent<Ship>().TakeDmg(dmg);
            Destroy(gameObject);
        }
    }
}
