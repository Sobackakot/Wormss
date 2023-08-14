using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{
    [SerializeField] private string _text;
    [SerializeField] private string _prefix;
    [SerializeField] private string _postfix;
    [Header("Reference")]
    [SerializeField] private TextMeshProUGUI _mesh;

    private void OnValidate()
    {
        _mesh?.SetText(_prefix + _text + _postfix);
    }

    public void SetText(int value)
    {
        _text = value.ToString();
        _mesh?.SetText(_prefix + _text + _postfix);
    }
}
