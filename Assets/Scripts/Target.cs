using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Score score;
    private TargetManager targetManager;

    private void Start()
    {
        score = FindObjectOfType<Score>().GetComponent<Score>();
        targetManager = FindObjectOfType<TargetManager>().GetComponent<TargetManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            score.IncreaseScore();
            targetManager.SpawnTarget();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
