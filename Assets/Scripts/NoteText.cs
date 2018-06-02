using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NoteText : MonoBehaviour, IInteractable {
 
    [SerializeField]
    private GameObject noteHierarchy;
    [SerializeField]
    private Text noteText;

    [MultilineAttribute]
    public string text;
    public UnityAction OnClose;

    public void LookAt()
    {

    }

    public void Interact()
    {
        noteHierarchy.SetActive(true);
        noteText.text = text;
    }

    public void Bye()
    {
        if(OnClose != null)
            OnClose();
        noteHierarchy.SetActive(false);
    }
}
