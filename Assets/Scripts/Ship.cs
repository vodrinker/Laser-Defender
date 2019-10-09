using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int hp;
    [SerializeField] private int score, gold;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootsPerSec;
    [SerializeField] private string laserPrefabTag;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private string hitPrefabTag;
    [SerializeField] private AudioClip dmgTakenSound;
    [SerializeField] [Range(0, 0.5f)] float dmgTakenSoundVolume = 0.3f;
    [SerializeField] private AudioClip destroyedSound;
    [SerializeField] [Range(0, 0.5f)] float destroyedSoundVolume = 0.3f;
    [SerializeField] private GameObject laserSpawn;
    private WaitForSecondsRealtime timeBetweenShots;

    private void OnEnable()
    {
        hp = maxHP;
        StartCoroutine(Shoot());
        RecalculateShotsPerSec();
        SetLifebar();
    }

    IEnumerator Shoot()
    {
        yield return timeBetweenShots;
        if (Time.timeScale == 1)
        {
            GameObject laser = ObjectPooler.instance.SpawnFromPool(laserPrefabTag, laserSpawn.transform.position, laserSpawn.transform.rotation);
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
        ObjectPooler.instance.SpawnFromPool(hitPrefabTag, transform.position, Quaternion.identity);
        hp -= dmg;
        if (hp <= 0)
        {
            Die();
         }
        else
        {
            AudioSource.PlayClipAtPoint(dmgTakenSound, transform.position, dmgTakenSoundVolume);
            SetLifebar();
        }
    }

    private void SetLifebar()
    {
        float fillAmount = (float)hp / (float)maxHP;
        healthBar.GetComponent<Image>().fillAmount = fillAmount;
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
            gameObject.SetActive(false);
        }
    }

    private void RecalculateShotsPerSec()
    {
        timeBetweenShots = new WaitForSecondsRealtime(1 / shootsPerSec);
    }
}
