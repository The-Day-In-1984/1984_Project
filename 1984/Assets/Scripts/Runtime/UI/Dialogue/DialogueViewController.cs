using System;
using UnityEngine;

public class DialogueViewController : MonoBehaviour
{
    private DialogueView _dialogueView;

    private void Awake()
    {
        _dialogueView = gameObject.GetComponent<DialogueView>();
    }

    private void Start()
    {
        _dialogueView.Show();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _dialogueView.Run();
        }
    }
}