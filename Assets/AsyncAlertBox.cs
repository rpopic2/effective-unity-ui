using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class AsyncAlertBox : Singleton<AsyncAlertBox>
{
    [SerializeField] TMP_Text _text;
    [SerializeField] Button _cancel;
    [SerializeField] Button _ok;
    TaskCompletionSource<bool> _tcs;

    public bool IsOpen { get; private set; }

    void Awake() {
        SingletonInit(this);
        _cancel.onClick.AddListener(OnCancelClick);
        _ok.onClick.AddListener(OnOkClick);
    }

    public async Task<bool> AlertAsk(string message) {
        _tcs = new();
        _text.text = message;
        gameObject.SetActive(true);
        IsOpen = true;
        var ret = await _tcs.Task;
        IsOpen = false;
        return ret;
    }

    void OnCancelClick() {
        _tcs.SetResult(false);
        gameObject.SetActive(false);
    }

    void OnOkClick() {
        _tcs.SetResult(true);
        gameObject.SetActive(false);
    }
}

