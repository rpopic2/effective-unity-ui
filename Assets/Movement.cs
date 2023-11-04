using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class Movement : Singleton<Movement>
{
    const int MOVE_KEYS_COUNT = 4;
    [SerializeField] float _speed = 0.01f;

    readonly List<GameObject> CurrentWindow = new();
    Collider2D _currentNPC;

    readonly KeyCode[] _keys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    Vector3[] _directions;

    void Awake() {
        SingletonInit(this);
        _directions = new Vector3[] { Vector3.up * _speed, Vector3.left * _speed, Vector3.down * _speed, Vector3.right * _speed };
    }

    public void OpenWindow(GameObject window) {
        window.SetActive(true);
        CurrentWindow.Add(window);
    }

    public void CloseWindow(GameObject window) {
        window.SetActive(false);
        CurrentWindow.Remove(window);
    }

    void Update() {
        if (AlertBox.Instance.IsOpen)
            return;
        if (AsyncAlertBox.Instance.IsOpen)
            return;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!CurrentWindow.Any())
                Menu.Instance.Open();
            else
                CloseWindow(CurrentWindow.Last());
            return;
        }

        if (Menu.Instance.gameObject.activeInHierarchy)
            return;
        if (Talk.Instance.gameObject.activeInHierarchy)
            return;

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (_currentNPC != null)
                Talk.Instance.Open("Jeff", "Hello World!");
            return;
        }

        Move();
    }

    void Move() {
        Vector3 translate = Vector3.zero;
        for (int i = 0; i < MOVE_KEYS_COUNT; ++i) {
            var pressed = Input.GetKey(_keys[i]);
            if (pressed)
                translate += _directions[i];
        }
        transform.Translate(translate);
    }

    void OnTriggerEnter2D(Collider2D other) {
        _currentNPC = other;
    }

    void OnTriggerExit2D(Collider2D other) {
        _currentNPC = null;
    }
}

