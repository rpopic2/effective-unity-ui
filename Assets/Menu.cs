using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class Menu : Singleton<Menu>
{
    [SerializeField] Button _open;
    [SerializeField] Button _resume;
    TaskCompletionSource<bool> _tcs;

    public bool IsOpen { get; private set; }

    void Awake() {
        SingletonInit(this);
        _open.onClick.AddListener(Open);
        _resume.onClick.AddListener(() => _tcs.SetResult(true));
    }

    async void Open() {
        gameObject.SetActive(true);
        using var focus = new FocusToken(this);
        _tcs = new();
        await _tcs.Task;
        gameObject.SetActive(false);
    }
}

