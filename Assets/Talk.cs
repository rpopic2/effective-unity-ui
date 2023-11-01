using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class Talk : Singleton<Talk>
{
    [SerializeField] TMP_Text _talker;
    [SerializeField] TMP_Text _content;
    [SerializeField] Button _next;
    TaskCompletionSource<bool> _tcs;

    void Awake() {
        SingletonInit(this);
        _next.onClick.AddListener(OnNextClick);
    }

    public async void Open(string talker, string content) {
        _talker.text = talker;
        _content.text = content;
        _tcs = new();
        gameObject.SetActive(true);

        using var focus = new FocusToken(this);
        await _tcs.Task;
        gameObject.SetActive(false);
    }

    public IEnumerator OpenCoroutine(string talker, string content) {
        _talker.text = talker;
        _content.text = content;
        gameObject.SetActive(true);

        using var focus = new FocusToken(this);
        yield return new WaitWhile(() => gameObject.activeInHierarchy);
        gameObject.SetActive(false);
    }

    void OnNextClick() {
        _tcs.SetResult(true);
        gameObject.SetActive(false);
    }
}

