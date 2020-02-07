using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BaseStats))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _delayToRespawn = 5;
    private BaseStats _playerStats;

    private void Awake()
    {
        _playerStats = GetComponent<BaseStats>();
    }

    private void Start()
    {
        _playerStats.HealthChanged += _playerStats_HealthChanged;
    }

    private void _playerStats_HealthChanged()
    {
        if (_playerStats.heatlh <= 0)
        {
            gameObject.SetActive(false);
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(_delayToRespawn);
        gameObject.transform.position = Vector3.zero;
        gameObject.SetActive(true);
    }
}
