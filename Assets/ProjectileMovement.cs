using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5;
    [SerializeField] GameObject HitEffect;

    void Update() {
        transform.position += transform.forward * Time.deltaTime * MoveSpeed;
    }

    void OnCollisionEnter(Collision col) {
        if(HitEffect != null) {
            GameObject spawnedEffect = Instantiate(HitEffect, col.GetContact(0).point, Quaternion.Euler(col.GetContact(0).normal));
            spawnedEffect.GetComponent<VisualEffect>().Play();
            Destroy(spawnedEffect, 5);
        }
        Destroy(gameObject);
    }
}
