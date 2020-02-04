using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public Transform weaponPoint;
    public MonoBehaviour[] gunsToCreate;

    private int weaponCount;
    private int currentWeapon;
    private float timeToDelay;
    private List<IGun> readyGuns;

    private void Start()
    {
        weaponCount = 0;
        currentWeapon = 0;
        timeToDelay = Time.time;
        readyGuns = new List<IGun>();
        foreach (MonoBehaviour gunToCreate in gunsToCreate)
        {
            if (gunToCreate is IGun)
            {
                MonoBehaviour gunObject = Instantiate(gunToCreate, weaponPoint.position, weaponPoint.rotation, this.gameObject.transform);
                gunObject.gameObject.SetActive(false);
                readyGuns.Add(gunObject.GetComponent<IGun>());
                weaponCount++;
            }
        }
    }

    private void Update()
    {
        if (weaponCount == 0) return;

        if (Input.GetButtonDown("GunsPos"))
        {
            readyGuns[currentWeapon].TurnOff();
            if (currentWeapon >= weaponCount - 1)
            {
                currentWeapon = 0;
            }
            else
                currentWeapon++;
            readyGuns[currentWeapon].TurnOn();
        }
        else if (Input.GetButtonDown("GunsNeg"))
        {
            readyGuns[currentWeapon].TurnOff();
            if (currentWeapon <= 0)
            {
                currentWeapon = weaponCount - 1;
            }
            else
                currentWeapon--;
            readyGuns[currentWeapon].TurnOn();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time - timeToDelay > readyGuns[currentWeapon].Delay)
            {
                readyGuns[currentWeapon].Shoot();
                timeToDelay = Time.time;
            }
        }
    }
}