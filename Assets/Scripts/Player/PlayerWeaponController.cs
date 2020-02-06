using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField]
    private List<BaseGun> _gunsToCreate = null;

    [SerializeField]
    private Transform _weaponPoint = null;

    private int _currentWeapon;
    private float _timeToDelay;
    private List<BaseGun> _guns;

    private void Start()
    {
        _currentWeapon = 0;
        _timeToDelay = Time.time;
        _guns = new List<BaseGun>();
        InitializeGuns();
    }

    private void InitializeGuns()
    {
        foreach (BaseGun gun in _gunsToCreate)
        {
            MonoBehaviour gunObject = Instantiate(gun, _weaponPoint.position, _weaponPoint.rotation, this.gameObject.transform);
            _guns.Add(gunObject as BaseGun);
            gunObject.gameObject.SetActive(false);
        }
        if (_guns.Count != 0)
            _guns[_currentWeapon].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_gunsToCreate.Count == 0) return;

        if (Input.GetButtonDown("GunsPos"))
        {
            _guns[_currentWeapon].TurnOff();
            if (_currentWeapon >= _guns.Count - 1)
            {
                _currentWeapon = 0;
            }
            else _currentWeapon++;
            _guns[_currentWeapon].TurnOn();
        }
        else if (Input.GetButtonDown("GunsNeg"))
        {
            _guns[_currentWeapon].TurnOff();
            if (_currentWeapon <= 0)
            {
                _currentWeapon = _guns.Count - 1;
            }
            else _currentWeapon--;
            _guns[_currentWeapon].TurnOn();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time - _timeToDelay > _guns[_currentWeapon].delay)
            {
                _guns[_currentWeapon].Shoot();
                _timeToDelay = Time.time;
            }
        }
    }
}