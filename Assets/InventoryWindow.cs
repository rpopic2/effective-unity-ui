using UnityEngine;
using UnityEngine.UI;

class InventoryWindow : MonoBehaviour
{
    [SerializeField] Button _close;
    [SerializeField] Button _open;
    [SerializeField] Button _useItem;

    void Awake() {
        _close.onClick.AddListener(OnCloseClick);
        _open.onClick.AddListener(OnOpenClick);
        _useItem.onClick.AddListener(OnItemUseClick);
    }

    void OnCloseClick() {
        gameObject.SetActive(false);
    }

    void OnOpenClick() {
        gameObject.SetActive(true);
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

