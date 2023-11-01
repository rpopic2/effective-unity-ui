using System;
using System.Collections.Generic;
using UnityEngine;

readonly struct FocusToken : IDisposable
{
    static Stack<Behaviour> _stack = new();

    static FocusToken() {
        _stack.Push(Movement.Instance);
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

