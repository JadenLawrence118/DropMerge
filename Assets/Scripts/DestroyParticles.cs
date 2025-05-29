using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
