using UnityEngine;
using UnityEngine.UI;

public class OpenWindowButton : MonoBehaviour
{
    [SerializeField] Button _openButton;
    [SerializeField] GameObject _target;

    void Awake() {
        _openButton.onClick.AddListener(OnOpenClick);
    }

    void OnOpenClick() {
        _target.gameObject.SetActive(true);
    }
}

