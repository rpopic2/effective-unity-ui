using UnityEngine;

class Movement : MonoBehaviour
{
    [SerializeField] float _speed = 0.01f;

    Collider2D _current;

    void Update() {
        if (AlertBox.Instance.IsOpen)
            return;
        if (AsyncAlertBox.Instance.IsOpen)
            return;
        if (Menu.Instance.gameObject.activeInHierarchy)
            return;
        if (Talk.Instance.gameObject.activeInHierarchy)
            return;

        Vector3 translate = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            translate += Vector3.up * _speed;
        } if (Input.GetKey(KeyCode.A)) {
            translate += Vector3.left * _speed;
        } if (Input.GetKey(KeyCode.S)) {
            translate += Vector3.down * _speed;
        } if (Input.GetKey(KeyCode.D)) {
            translate += Vector3.right * _speed;
        }

        if (Input.GetKey(KeyCode.Space)) {
            if (_current == null)
                return;
            Talk.Instance.Open("Jeff", "Hello World!");
        }
        transform.Translate(translate);
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

