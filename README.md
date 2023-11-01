# effective-unity-ui-focus

어떻게 하면 UI 포커스를 효과적으로 구현할 수 있을까요?


* 기본 브랜치에는 if문을 이용해서, 만약 창이 열려있다면 플레이어가 이동하지 못하게끔 합니다.

```c#
void Update() {
    if (AlertBox.Instance.IsOpen)
        return;
    if (Menu.Instance.gameObject.activeInHierarchy)
        return;
<후략>
```

만약에 창이 많아지면 이 if문들이 점점 더 많이 늘어나겠죠. 개인적으로는 이렇게 하는게 문제는 없다고 생각합니다만, 더 좋은 방법이 있지 않을까요?


* focus-based 브랜치에서는 FocusToken이라는 객체를 만들어 구현해 보았습니다. 이 객체를 새로 만들 때 포커스를 가져오고, Disposable 패턴을 구현해서 스코프를 나갈 때 포커스를 돌려줍니다.
내부적으로는 Stack을 이용하며, enable 프로퍼티를 이용하여 해당 (Mono)Bahaviour를 꺼서 작동을 중단시킵니다.

```c#
readonly struct FocusToken : IDisposable
{
    static Stack<Behaviour> _stack = new();

    static FocusToken() {
        _stack.Push(Movement.Instance); // 기본적으로 키보드로 플레이어를 조종하는 Behaviour를 넣어두어서 스택이 빌 일이 없게 했습니다
    }

    static void Push(Behaviour b) {
        _stack.Peek().enabled = false;
        _stack.Push(b);
        b.enabled = true;
    }

    static void Pop() {
        _stack.Pop().enabled = false;
        if (_stack.Count > 0)
            _stack.Peek().enabled = true;
    }

    public FocusToken(Behaviour b) {
        Push(b);
    }

    public void Dispose() {
        Pop();
    }
}
```

사용자는 다음과 같은 코드를 작성하면 됩니다:

```c#
class Menu : Singleton<Menu>
{
    [SerializeField] Button _open;
    [SerializeField] Button _resume;
    TaskCompletionSource<bool> _tcs;

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
```

async를 이용해서 스코프에 가두는게 싫다면, 직접 Dispose()를 호출하면 되겠네요. 다만 두 번 객체를 실수로 생성하거나 두 번 Dispose()할 경우 게임이 멈추겠군요.
Disposable 패턴을 이용한 이유는 스택에서 빠지지 않아 게임을 멈추게 하지 않기 위함입니다.

다른 좋은 방법이 있다면 pr 부탁드립니다.


