using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Image _imageFillHp;
    [SerializeField] private Image _imageFillExp;
    private void Awake()
    {
        EventManager.TakeDamageEvent += UpdateHp;
    }
    private void UpdateHp(float index)
    {
        _imageFillHp.fillAmount = index;
    }
    public void UpdateExp(float index)
    {
        _imageFillExp.fillAmount = index;
    }
    private void OnDestroy()
    {
        EventManager.TakeDamageEvent -= UpdateHp;
    }
}
