using UnityEngine;

public class FlameGun : MonoBehaviour, IGun
{
    public Vector3 offset;
    public Vector3 halfOfSize;

    [SerializeField] private float delay;
    private bool isFlame;
    private ParticleSystem flameParticle;
    public float Delay
    {
        get => delay;
        private set => delay = value;
    }

    private void Awake()
    {
        flameParticle = GetComponent<ParticleSystem>();    
    }

    private void Start()
    {
        isFlame = false;
        flameParticle.Stop();
    }

    private void Update()
    {
        if (!isFlame) return;

        Collider[] enemies = Physics.OverlapBox(transform.position + offset, halfOfSize, Quaternion.identity);
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawCube(transform.position + offset, halfOfSize);
    //}

    public void Shoot()
    {
        if (isFlame)
            flameParticle.Play();
        else
            flameParticle.Stop();

        isFlame = !isFlame;
    }

    public void TurnOff()
    {
        this.gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        this.gameObject.SetActive(true);
    }
}
