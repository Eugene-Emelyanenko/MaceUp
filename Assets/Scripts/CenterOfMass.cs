using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    [SerializeField] private Transform centerOfMass;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().centerOfMass = Vector3.Scale(centerOfMass.localPosition, transform.localScale);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetComponent<Rigidbody2D>().worldCenterOfMass, 0.1f);
    }
}
