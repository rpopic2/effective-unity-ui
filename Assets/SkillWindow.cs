using UnityEngine;
using UnityEngine.UI;

class SkillWindow : MonoBehaviour
{
    [SerializeField] Button _close;
    [SerializeField] Button _skillLvUp;

    void Awake() {
        _close.onClick.AddListener(OnCloseClick);
        _skillLvUp.onClick.AddListener(OnSkillLvUpClick);
    }

    void OnCloseClick() {
        gameObject.SetActive(false);
    }

    async void OnSkillLvUpClick() {
        var result = await AsyncAlertBox.Instance.AlertAsk("Really level up?");
        if (result)
            print("level up.");
        else
            print("cancelled");
    }
}

