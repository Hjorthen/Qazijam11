using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialogue : MonoBehaviour, IInteractable
{
    [HideInInspector]
    public int LastReply = 0;

    [SerializeField]
    protected DialogueController diagCont;

    public abstract IEnumerator StartDialogue();

    public abstract string GetWhoDis();

    public void LookAt()
    {

    }
    public void Interact()
    {
        diagCont.ShowDialogue(this, GetWhoDis());
    }
    public void Bye()
    {
        diagCont.StopDialogue();
    }
}
