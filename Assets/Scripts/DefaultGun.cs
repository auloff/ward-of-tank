using UnityEngine;

public class DefaultGun : MonoBehaviour, IGun
{
    [SerializeField] private float delay;
    public float Delay 
    { 
        get => delay;
        private set => delay = value;
    }
    public GameObject bulletPrefab;
    public void Shoot()
    {
        Instantiate(bulletPrefab, this.transform.position, this.transform.rotation, this.gameObject.transform);
    }
    public void TurnOn()
    {
        this.gameObject.SetActive(true);
    }
    public void TurnOff()
    {
        this.gameObject.SetActive(false);
    }
}