using UnityEngine;
using UnityEngine.UI;

class SkillWindow : Singleton<SkillWindow>
{
    [SerializeField] Button _close;
    [SerializeField] Button _open;
    [SerializeField] Button _skillLvUp;

    void Awake() {
        SingletonInit(this);
        _close.onClick.AddListener(OnCloseClick);
        _open.onClick.AddListener(OnOpenClick);
        _skillLvUp.onClick.AddListener(OnSkillLvUpClick);
    }

    void OnCloseClick() {
        Movement.Instance.CloseWindow(gameObject);
    }

    void OnOpenClick() {
        Movement.Instance.OpenWindow(gameObject);
    }

    async void OnSkillLvUpClick() {
        var result = await AsyncAlertBox.Instance.AlertAsk("Really level up?");
        if (result)
            print("level up.");
        else
            print("cancelled");
    }
}

