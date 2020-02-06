using UnityEngine;

public class FlameGun : BaseGun
{
    [SerializeField]
    private Vector3 _offset;
    public Vector3 offset
    {
        get => _offset;
        set => _offset = value;
    }
    [SerializeField]
    private Vector3 _halfOfSize;
    public Vector3 halfOfSize
    {
        get => _halfOfSize;
        set => _halfOfSize = value;
    }

    [SerializeField]
    private bool isFlame;
    private ParticleSystem flameParticle;

    private void Awake()
    {
        flameParticle = GetComponent<ParticleSystem>();    
    }

    private void Start()
    {
        isFlame = false;
        flameParticle.Stop();
    }

    private void FixedUpdate()
    {
        if (!isFlame) return;
        Collider[] enemies = Physics.OverlapBox(transform.position + offset, halfOfSize, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position + offset, halfOfSize);
    }

    public override void Shoot()
    {
        isFlame = !isFlame;
        if (isFlame)
            flameParticle.Play();
        else
            flameParticle.Stop();
    }

    public override void TurnOff()
    {
        flameParticle.Stop();
        isFlame = false;
        this.gameObject.SetActive(false);
    }

    public override void TurnOn()
    {
        this.gameObject.SetActive(true);
    }
}
