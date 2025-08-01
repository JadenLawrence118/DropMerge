using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public int MergeID;
    private bool running = false;
    [SerializeField] private int mergePoints;
    [SerializeField] private ParticleSystem particles;

    [SerializeField] private AudioSource collisionSound;
    private bool soundPlayed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!soundPlayed)
        {
            GetComponent<AudioSource>().Play();
            soundPlayed = true;
        }

        if (!running)
        {
            if (collision.gameObject.tag == gameObject.tag && collision.gameObject.GetComponent<Merge>().MergeID == MergeID)
            {
                if (transform.GetSiblingIndex() > collision.transform.GetSiblingIndex())
                {
                    running = true;
                    Vector3 mergePos = (collision.transform.position + transform.position) / 2;
                    Destroy(collision.gameObject);

                    // particles
                    ParticleSystem.MainModule main = particles.main;
                    main.startColor = new ParticleSystem.MinMaxGradient(GetComponent<SpriteRenderer>().color);
                    Instantiate(particles, mergePos, Quaternion.identity, GameObject.Find("ParticleStore").transform);

                    // merge
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().MergeSpawn(MergeID + 1, mergePos, mergePoints);
                    Destroy(gameObject);
                }
            }
        }
    }
}
