using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public Camera playerCamera; 

    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 2f;

    //Burst
    public int bulletsPerBurst = 3;
    public int burstBulletsLeft;

    //Spread
    public float spreadIntensity;

    // Bullet
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabLifeTime = 3f;

    public enum ShootingMode
    {
        Single,
        Burst,
        Auto
    }

    public ShootingMode currentShootingMode;
    public TMP_Text weaponModeTextField;
    private HUDManager hudManager;

    private void Awake()
    {
        readyToShoot = true;
        burstBulletsLeft = bulletsPerBurst;

        ChangeWeaponMode(currentShootingMode);
    }

    void Update()
    {
        if (currentShootingMode == ShootingMode.Auto)
        {
            // Holding Down left mouse button
            isShooting = Input.GetKey(KeyCode.Mouse0);
        } else if (currentShootingMode == ShootingMode.Single || currentShootingMode  == ShootingMode.Burst)
        {
            // Clicking left mouse button once
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if(readyToShoot && isShooting)
        {
            burstBulletsLeft = bulletsPerBurst;
            FireWeapon();
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            if (currentShootingMode == ShootingMode.Single)
            {
                ChangeWeaponMode(ShootingMode.Burst);
                shootingDelay = 0.2f;
            }
            else if (currentShootingMode == ShootingMode.Burst)
            {
                ChangeWeaponMode(ShootingMode.Auto);
                shootingDelay = 0.1f;
            }
            else if (currentShootingMode == ShootingMode.Auto)
            { 
                ChangeWeaponMode(ShootingMode.Single);
                shootingDelay = 0.3f;
            }
        }
    }

    private void FireWeapon()
    {
        readyToShoot = false;

        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        bullet.transform.forward = shootingDirection;

        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

        if(allowReset)
        {
            Invoke("ResetShoot", shootingDelay);
            allowReset = false;
        } 

        // Burst Mode
        if(currentShootingMode == ShootingMode.Burst && burstBulletsLeft > 1) // we already shoot once before this check
        {
            burstBulletsLeft--;
            Invoke("FireWeapon", shootingDelay);
        }
    }

    private void ResetShoot()
    {
        readyToShoot = true;
        allowReset = true;
    }

    public Vector3 CalculateDirectionAndSpread()
    {
        // Shooting from the middle of the screen to check where are we pointing at
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            // Hitting Something
            targetPoint = hit.point;
        } else
        {
            // Shooting at the air
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - bulletSpawn.position;

        float x = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);

        // Returning the shooting direction and spread
        return direction + new Vector3(x, y, 0);
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    public void ChangeWeaponModeHUD(ShootingMode shootingMode)
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

    private void ChangeWeaponMode(ShootingMode mode)
    {
        currentShootingMode = mode;
        ChangeWeaponModeHUD(currentShootingMode);
    }

}
