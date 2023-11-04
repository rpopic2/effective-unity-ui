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

    public bool IsOpen { get; private set; }

    void Awake() {
        SingletonInit(this);
        _cancel.onClick.AddListener(OnCancelClick);
        _ok.onClick.AddListener(OnOkClick);
    }

    public void AlertAsk(string message, Action<bool> onAnswer) {
        _text.text = message;
        _callback = onAnswer;
        gameObject.SetActive(true);
        IsOpen = true;
    }

    void Update() {
        if (Input.GetKey(KeyCode.Escape))
            OnCancelClick();
        else if (Input.GetKey(KeyCode.Return))
            OnOkClick();
    }

    void OnCancelClick() {
        gameObject.SetActive(false);
        _callback.Invoke(false);
        IsOpen = false;
    }

    void OnOkClick() {
        gameObject.SetActive(false);
        _callback.Invoke(true);
        IsOpen = false;
    }
}

