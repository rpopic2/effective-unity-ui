using UnityEngine;
using UnityEngine.UI;

class InventoryWindow : Singleton<InventoryWindow>
{
    [SerializeField] Button _close;
    [SerializeField] Button _open;
    [SerializeField] Button _useItem;

    void Awake() {
        SingletonInit(this);
        _close.onClick.AddListener(OnCloseClick);
        _open.onClick.AddListener(OnOpenClick);
        _useItem.onClick.AddListener(OnItemUseClick);
    }

    void OnCloseClick() {
        Movement.Instance.CloseWindow(gameObject);
    }

    void OnOpenClick() {
        Movement.Instance.OpenWindow(gameObject);
    }

    void OnItemUseClick() {
        AlertBox.Instance.AlertAsk("Really use this item?", OnAnswer);

        void OnAnswer(bool answer) {
            if (answer)
                print("used item");
            else
                print("cancelled");
        }
    }
}

