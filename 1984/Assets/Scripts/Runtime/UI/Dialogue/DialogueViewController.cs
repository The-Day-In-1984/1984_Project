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

}