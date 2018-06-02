using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTipper : NoteText {

    [SerializeField]
    private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        OnClose += OnClosed;
    }
	
    void OnClosed()
    {
        rigidbody.AddForceAtPosition(new Vector3(-80f, 0, 0), new Vector3(0, 50, 0));
    }

}
