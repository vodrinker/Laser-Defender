using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    [SerializeField] private int score, gold;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootsPerSec;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject hitPrefab;
    [SerializeField] private AudioClip dmgTakenSound;
    [SerializeField] [Range(0, 0.5f)] float dmgTakenSoundVolume = 0.3f;
    [SerializeField] private AudioClip destroyedSound;
    [SerializeField] [Range(0, 0.5f)] float destroyedSoundVolume = 0.3f;
    private GameObject laserSpawn;

    void Start()
    {
        laserSpawn = transform.Find("LaserSpawn").gameObject;
        StartCoroutine(Shoot());
    }
    
    void Update()
    {

    }

    IEnumerator Shoot()
    {
        yield return new WaitForSecondsRealtime(1 / shootsPerSec);
        if (Time.timeScale == 1)
        {
            GameObject laser = Instantiate(laserPrefab, laserSpawn.transform.position, Quaternion.identity);
            laser.GetComponent<Laser>().DidPlayerShotIt((gameObject.tag == "Player"));
        }
        StartCoroutine(Shoot());
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void TakeDmg(int dmg)
    {
        Instantiate(hitPrefab, transform.position, Quaternion.identity);
        HP -= dmg;
        if (HP <= 0) Die();
        else
        {
            AudioSource.PlayClipAtPoint(dmgTakenSound, transform.position, dmgTakenSoundVolume);
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(destroyedSound, transform.position, destroyedSoundVolume);
        if (gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Start");
        }
        else
        {
            FindObjectOfType<Score>().AddScore(score);
            FindObjectOfType<Gold>().AddGold(gold);
            Destroy(gameObject);
        }
    }

}
