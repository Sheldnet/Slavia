using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDoubleClickListener : MonoBehaviour, IPointerClickHandler {
    [Range (0.01f, 0.5f)] public float doubleClickDuration = 0.3f;
    
    public UnityEvent onDoubleClick;

    private byte clicks = 0;
    private DateTime firstClickTime;
    private Button button;

    void Awake() {
        button = GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        double elapsedSeconds = (DateTime.Now - firstClickTime).TotalSeconds;
        if (elapsedSeconds > doubleClickDuration) clicks = 0;
        clicks++;

        if (clicks == 1) {
            firstClickTime = DateTime.Now;
        } else if (clicks > 1) {
            if (elapsedSeconds <= doubleClickDuration) {
                if (button.interactable) onDoubleClick?.Invoke();
            }
            clicks = 0;
        }
    }
}
