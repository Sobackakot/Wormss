using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FieldUI : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Image _fieldImage;
    [SerializeField] private TextMeshProUGUI _progressLable;

    private float _value;

    private void OnValidate()
    {
        if (_fieldImage)
        {
            _fieldImage.type = Image.Type.Filled;
            _fieldImage.fillMethod = Image.FillMethod.Horizontal;
        }
    }

    public void UpdateValue(float value)
    {
        _value = Mathf.Clamp01(value);
        _fieldImage.fillAmount = _value;
        _progressLable.text = $"{(int)(_value * 100)}";
    }

}
