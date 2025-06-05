using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System;

public enum WeaponTypes
{
    Minigun,
    Rocket
}

public class WeaponSwitch : MonoBehaviour
{
    ///starting ammo amounts
    private List<int> ammunitionAmount; 
    
    ///end of ammo amounts
    
    public List<GameObject> bulletPrefabs;
    public List<Sprite> weaponIconSprites;
    public Image weaponIcon;

    public HeliShoot heliShoot;
    private int weaponId = 0;


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
        100, 
        15
        };
        
        if (heliShoot == null)
            Debug.LogError("HeliShoot not found!");

        if(weaponIconSprites.Count!=bulletPrefabs.Count)
            Debug.LogError("Different number of ammo prefabs and sprites!");

        weaponIcon.sprite = weaponIconSprites[weaponId];

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

        heliShoot.SetBulletPrefab(bulletPrefabs[weaponId]);

        Debug.Log("Switched to weapon: " + (WeaponTypes)weaponId);
    }
}
