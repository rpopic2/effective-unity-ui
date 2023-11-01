using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class AlertBox : Singleton<AlertBox>
{
    [SerializeField] TMP_Text _text;
    [SerializeField] Button _cancel;
    [SerializeField] Button _ok;
    Action<bool> _callback;

    void Awake() {
        SingletonInit(this);
        _cancel.onClick.AddListener(OnCancelClick);
        _ok.onClick.AddListener(OnOkClick);
    }

    public void AlertAsk(string message, Action<bool> onAnswer) {
        _text.text = message;
        _callback = onAnswer;
        gameObject.SetActive(true);
    }

    void OnCancelClick() {
        gameObject.SetActive(false);
        _callback.Invoke(false);
    }

    void OnOkClick() {
        gameObject.SetActive(false);
        _callback.Invoke(true);
    }
}

