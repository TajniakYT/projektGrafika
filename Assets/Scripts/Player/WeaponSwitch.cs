using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public UnityEngine.UI.Image weaponIcon;
    public Sprite rocketSprite;
    public Sprite minigunSprite;

    void SwitchWeapon(int weaponId)
    {
        if (weaponId == 0) weaponIcon.sprite = rocketSprite;
        if (weaponId == 1) weaponIcon.sprite = minigunSprite;
    }
}
