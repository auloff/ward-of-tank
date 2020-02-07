using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlameGun : BaseGun
{
    [Min(1)]
    [SerializeField]
    private int _fireDamage = 1;
    public int fireDamage 
    { 
        get => _fireDamage;
        set
        {
            if (value <= 0) _fireDamage = 1;
            else _fireDamage = value;
        }
    }
    
    private bool _isFlame;
    private ParticleSystem _flameParticle;
    private Collider _flameCollider;

    private void Awake()
    {
        _flameCollider = GetComponent<Collider>();
        _flameParticle = GetComponent<ParticleSystem>();    
    }

    private void Start()
    {
        _isFlame = false;
        _flameParticle.Stop();
        _flameCollider.enabled = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        EnemyController targetController = other.gameObject.GetComponent<EnemyController>();

        if (targetController == null)
            return;

        targetController.EnemyTakeDamage(_fireDamage);
    }

    public override void Shoot()
    {
        _isFlame = !_isFlame;
        if (_isFlame)
        {
            _flameParticle.Play();
            _flameCollider.enabled = true;
        }
        else
        {
            _flameParticle.Stop();
            _flameCollider.enabled = false;

        }
    }

    public override void TurnOff()
    {
        _flameParticle.Stop();
        _isFlame = false;
        this.gameObject.SetActive(false);
    }

    public override void TurnOn()
    {
        this.gameObject.SetActive(true);
    }
}
