using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 60f;
    public GameObject InpactEffect;
    public AudioClip bulletSound;
    public void Seek(Transform target)
    {
        this.target = target;
    }

    private void Start()
    {
        AudioManager.PlaySound(bulletSound);
    }
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject effect = Instantiate(InpactEffect, transform.position, transform.rotation);
        GameManager.Instance.Money += 50;
        GameManager.Instance.Score += 100;
        Destroy(effect, 2f);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
