using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Slider _hpSlider = null;
    [SerializeField]
    private Text _hpInfo = null;
    [SerializeField]
    private Text _shieldInfo = null;
    [SerializeField]
    private string _targetTag = "Player";

    private BaseStats _targetStats = null;

    private void Awake()
    {
        _targetStats = GameObject.FindGameObjectWithTag(_targetTag).GetComponent<BaseStats>();
        if (_targetStats != null)
        {
            _hpSlider.maxValue = _targetStats.heatlh;
            _hpSlider.value = _targetStats.heatlh;
            _hpInfo.text = _targetStats.heatlh.ToString();
            _shieldInfo.text = string.Format("Shield: {0}", _targetStats.shield.ToString());
            _targetStats.HealthChanged += TargetStats_HealthChanged;
            _targetStats.ShieldChanged += TargetStats_ShieldChanged;
        }
    }

    private void TargetStats_ShieldChanged()
    {
        _shieldInfo.text = string.Format("Shield: {0}", _targetStats.shield.ToString());

    }

    private void TargetStats_HealthChanged()
    {
        _hpSlider.value = _targetStats.heatlh;
        _hpInfo.text = _targetStats.heatlh.ToString();
    }
}