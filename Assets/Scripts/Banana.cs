using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour, IInteractable {
    public void Bye()
    {
    }

    public void Interact()
    {
        PlayerInventory.AddItem("banana", 1);
        GameObject.Destroy(gameObject);
    }

    public void LookAt()
    {
    }
}
