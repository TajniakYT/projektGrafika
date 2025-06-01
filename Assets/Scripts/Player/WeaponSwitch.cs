using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum WeaponTypes
{
    Minigun,
    Rocket
}

public class WeaponSwitch : MonoBehaviour
{
    public List<GameObject> bulletPrefabs;
    public List<Sprite> weaponIconSprites;

    public Image weaponIcon;
    //public Sprite rocketSprite;
    //public Sprite minigunSprite;
    public HeliShoot heliShoot;
    private int weaponId = 0;


    void Start()
    {
        heliShoot = GetComponent<HeliShoot>();

        if (heliShoot == null)
            Debug.LogError("HeliShoot not found!");

        if(weaponIconSprites.Count!=bulletPrefabs.Count)
            Debug.LogError("Different number of ammo prefabs and sprites!");

        weaponIcon.sprite = weaponIconSprites[weaponId];  
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
