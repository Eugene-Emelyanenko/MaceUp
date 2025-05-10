using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ThrowWeapon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer weaponSprite;
    [SerializeField] private Slider forceSlider;
    [SerializeField] private Sprite[] weaponSprites;
    [SerializeField] private GameObject[] weaponPrefabs;

    public float timeToDestroy = 10f;
    public float rotationSpeed = 200f;
    public float maxChargeTime = 2f;
    public float throwForce = 10f;
    
    private bool charging;
    private float chargeTime;
    private bool canRotate;

    public static bool canThrow;

    private void Start()
    {
        canThrow = true;
        chargeTime = 0;
        forceSlider.maxValue = maxChargeTime;
        forceSlider.value = chargeTime;
        canRotate = true;
        weaponSprite.GetComponent<SpriteRenderer>().sprite = weaponSprites[PlayerPrefs.GetInt("selectedItem", 0)];
    }

    private void Update()
    {
        if(canRotate)
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    
        if (Input.GetMouseButtonDown(0) && canThrow)
        {
            charging = true;
            chargeTime = 0f;
        }
    
        if (Input.GetMouseButton(0) && charging)
        {
            chargeTime += Time.deltaTime;

            forceSlider.value = chargeTime;

            canRotate = false;
        }
    
        if (Input.GetMouseButtonUp(0) && charging)
        {
            Throw(chargeTime);
            chargeTime = 0;
            forceSlider.value = chargeTime;
            charging = false;
            canRotate = true;
        }
    }
    
    private void Throw(float chargeTime)
    {
        GameObject weapon = Instantiate(weaponPrefabs[PlayerPrefs.GetInt("selectedItem", 0)], transform.position, transform.rotation);
    
        float throwPower = Mathf.Clamp(chargeTime, 0f, maxChargeTime) * throwForce;

        Vector2 throwDirection = transform.up;
        weapon.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwPower, ForceMode2D.Impulse);
        
        Destroy(weapon, timeToDestroy);
    }

}
