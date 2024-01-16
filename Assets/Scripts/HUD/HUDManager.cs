using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Weapon;

public class HUDManager : MonoBehaviour
{
    public TMP_Text weaponModeTextField;

    public void ChangeWeaponMode(ShootingMode shootingMode)
    {
        string mode;
        Debug.Log(shootingMode);
        if (shootingMode == ShootingMode.Auto)
        {
            mode = "auto";
            Debug.Log(mode);
            weaponModeTextField.text = "Mode: " + mode;
        }

        if (shootingMode == ShootingMode.Single)
        {
            mode = "single";
            Debug.Log(mode);
            weaponModeTextField.text = "Mode: " + mode;

        }

        if (shootingMode == ShootingMode.Burst)
        {
            mode = "burst";
            Debug.Log(mode);
            weaponModeTextField.text = "Mode: " + mode;

        }
    }
}
