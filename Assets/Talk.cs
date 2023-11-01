using TMPro;
using UnityEngine;
using UnityEngine.UI;

class Talk : Singleton<Talk>
{
    [SerializeField] TMP_Text _talker;
    [SerializeField] TMP_Text _content;
    [SerializeField] Button _next;

    void Awake() {
        SingletonInit(this);
        _next.onClick.AddListener(OnNextClick);
    }

    public void Open(string talker, string content) {
        _talker.text = talker;
        _content.text = content;
        gameObject.SetActive(true);
    }

    void OnNextClick() {
        gameObject.SetActive(false);
    }
}

