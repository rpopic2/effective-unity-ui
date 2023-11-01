using System.Collections.Generic;
using UnityEngine;

class ForceCallAwake : MonoBehaviour
{
    [SerializeField] List<GameObject> callList;

    void Awake() {
        foreach (var go in callList) {
            go.SetActive(true);
            go.SetActive(false);
        }
    }
}

