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

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnNextClick();
        }
    }

    public void Open(string talker, string content) {
        _talker.text = talker;
        _content.text = content;
        gameObject.SetActive(true);
    }

    void OnNextClick() {
        if (!Menu.Instance.gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }
}

