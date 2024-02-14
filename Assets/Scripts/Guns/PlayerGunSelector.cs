using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerGunSelector : MonoBehaviour
{
    [SerializeField] private GunType Gun;
    [SerializeField] private Transform GunParent;
    [SerializeField] private List<GunScriptableObject> Guns;
    //[SerializeField] private PlayerIK playerIK;

    [Space]
    [Header("Runtime Filled")]
    public GunScriptableObject ActiveGun;

    private void Start()
    {
        GunScriptableObject gun = Guns.Find(gun => gun.Type == Gun);

        if (gun == null)
        {
            Debug.Log($"No GunScriptableObject found for GunType: {gun}");
        }

        ActiveGun = gun;
        gun.Spawn(GunParent, this);
    }

}
