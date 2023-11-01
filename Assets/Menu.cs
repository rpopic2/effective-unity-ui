using UnityEngine;
using UnityEngine.UI;

class Menu : Singleton<Menu>
{
    [SerializeField] Button _open;
    [SerializeField] Button _resume;

    public bool IsOpen { get; private set; }

    void Awake() {
        SingletonInit(this);
        _open.onClick.AddListener(() => gameObject.SetActive(true));
        _resume.onClick.AddListener(() => gameObject.SetActive(false));
    }
}

