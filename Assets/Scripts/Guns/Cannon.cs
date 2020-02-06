using UnityEngine;

public class Cannon : BaseGun
{
    public GameObject bulletPrefab;
    public override void Shoot()
    {
        Instantiate(bulletPrefab, this.transform.position, this.transform.rotation, this.gameObject.transform.parent);
    }
    public override void TurnOn()
    {
        this.gameObject.SetActive(true);
    }
    public override void TurnOff()
    {
        this.gameObject.SetActive(false);
    }
}