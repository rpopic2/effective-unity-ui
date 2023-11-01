using UnityEngine;

class Movement : Singleton<Movement>
{
    [SerializeField] float _speed = 0.01f;

    Collider2D _current;
    readonly KeyCode[] _keys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    Vector3[] _directions;

    void Awake() {
        SingletonInit(this);
        _directions = new Vector3[] { Vector3.up * _speed, Vector3.left * _speed, Vector3.down * _speed, Vector3.right * _speed };
    }

    void Update() {
        if (AlertBox.Instance.IsOpen)
            return;
        if (Menu.Instance.gameObject.activeInHierarchy)
            return;

        Vector3 translate = Vector3.zero;
        for (int i = 0; i < 4; ++i) {
            var pressed = Input.GetKey(_keys[i]);
            if (pressed)
                translate += _directions[i];
        }
        transform.Translate(translate);

        if (Input.GetKey(KeyCode.Space)) {
            if (_current == null)
                return;
            Talk.Instance.Open("Jeff", "Hello World!");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        print("enter");
        _current = other;
    }

    void OnTriggerExit2D(Collider2D other) {
        print("exit");
        _current = null;
    }
}

