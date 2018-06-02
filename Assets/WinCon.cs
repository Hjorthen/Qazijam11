using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour, IInteractable {

    ParticleSystem winSystem;

    public void Start()
    {
        winSystem = GetComponent<ParticleSystem>();
    }
    public void Bye()
    {

    }

    public void Interact()
    {
        if(PlayerInventory.GetItemCount("Water") > 0)
        {
            winSystem.Play();
        }
    }

    public void LookAt()
    {

    }
}
