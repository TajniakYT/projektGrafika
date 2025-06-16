using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System;
using TMPro;

public enum WeaponTypes
{
    Minigun,
    Rocket
}

public class WeaponSwitch : MonoBehaviour
{
    ///starting ammo amounts
    private List<int> ammunitionAmount;
    public TMP_Text ammunitionCounter;
    ///end of ammo amounts

    public List<GameObject> bulletPrefabs;
    public List<Sprite> weaponIconSprites;
    public Image weaponIcon;

    public HeliShoot heliShoot;
    private int weaponId = 0;
    private System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();

    public int GetWeaponId()
    {
        return weaponId;
    }

    public int GetCurrentAmunitionAmount()
    {
        return ammunitionAmount[weaponId];
    }

   

    void Start()
    {
        heliShoot = GetComponent<HeliShoot>();
        
        ammunitionAmount = new List<int> {
        // Czemu to nie jest publiczna metoda aby wybraæ ile jest amunicji? Serio?
        9999999, 
        9999999
        };

        if (weaponIconSprites.Count != bulletPrefabs.Count)
            Debug.LogError("Different number of ammo prefabs and sprites!");

        weaponIcon.sprite = weaponIconSprites[weaponId];
        ammunitionCounter.text = "" + ammunitionAmount[weaponId];
        if (heliShoot == null)
            Debug.LogError("HeliShoot not found!");


        heliShoot.OnShoot += HandleShoot;
        heliShoot.CanShootCallback = CanShoot;
    }

    bool CanShoot()
    {
        return ammunitionAmount[weaponId] > 0;
    }

    void HandleShoot()
    {
        if (ammunitionAmount[weaponId] > 0)
        {
            ammunitionAmount[weaponId]--;
            ammunitionCounter.text = "" + ammunitionAmount[weaponId];
            Debug.Log($"Ammo left for {(WeaponTypes)weaponId}: {ammunitionAmount[weaponId]}");
        }
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        weaponId++;

        if (weaponId >= weaponIconSprites.Count)
        {
            weaponId = 0;
        }

        weaponIcon.sprite = weaponIconSprites[weaponId];
        ammunitionCounter.text = "" + ammunitionAmount[weaponId];
        heliShoot.SetBulletPrefab(bulletPrefabs[weaponId]);

        Debug.Log("Switched to weapon: " + (WeaponTypes)weaponId);
    }
}
