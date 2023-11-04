using UnityEngine;
using UnityEngine.UI;

class Menu : Singleton<Menu>
{
    [SerializeField] Button _open;
    [SerializeField] Button _resume;

    void Awake() {
        SingletonInit(this);
        _open.onClick.AddListener(Open);
        _resume.onClick.AddListener(() => gameObject.SetActive(false));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }

    public void Open() {
        gameObject.SetActive(true);
    }
}

