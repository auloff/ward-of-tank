using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public Transform weaponPoint;
    public MonoBehaviour[] gunsToCreate;

    public int weaponCount;
    public int currentWeapon;
    private List<IGun> readyGuns;

    private void Start()
    {
        weaponCount = 0;
        currentWeapon = 0;
        readyGuns = new List<IGun>();
        foreach (MonoBehaviour gunToCreate in gunsToCreate)
        {
            if (gunToCreate is IGun)
            {
                MonoBehaviour gunObject = Instantiate(gunToCreate, weaponPoint.position, weaponPoint.rotation, this.gameObject.transform);
                readyGuns.Add(gunObject.GetComponent<IGun>());
                weaponCount++;
            }
        }
    }

    private void Update()
    {
        if (weaponCount == 0) return;
        //     if (Input.GetButtonDown("Fire1"))
        //     {
        //         Debug.Log("sss");
        //     }
        //     Debug.Log(Input.GetAxis("GunsWheel"));

        if (Input.GetButtonDown("GunsPos"))
        {
            if (currentWeapon >= weaponCount - 1)
            {
                currentWeapon = 0;
            }
            else
                currentWeapon++;
        }
        else if (Input.GetButtonDown("GunsNeg"))
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = weaponCount - 1;
            }
            else
                currentWeapon--;
        }

        if (Input.GetButtonDown("Fire1"))
        {
           readyGuns[currentWeapon].Shoot();
        }
    }
}