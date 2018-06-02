using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
    GameObject panel;
    Text[] shownOptions;
    Text narrator;
    Text loreBox;
    string[] options;
    int[] actionIds;
    int queuedOptionsCount;
    bool dirty;

    [SerializeField]
    private PlayerController player;
    private Dialogue DialogueSetup;
    private IEnumerator CurrentDialouge;

    private void Awake()
    {
        panel = transform.GetChild(0).gameObject;
        narrator = panel.transform.GetChild(0).GetComponent<Text>();
        loreBox = panel.transform.GetChild(1).GetComponent<Text>();

        shownOptions = new Text[panel.transform.childCount - 3];
        for (int i = 0; i < shownOptions.Length; i++)
        {
            shownOptions[i] = panel.transform.GetChild(i + 3).GetComponent<Text>();
        }
        options = new string[shownOptions.Length];
        actionIds = new int[options.Length];
        queuedOptionsCount = 0;
        dirty = false;
    }

    public void AddOption(string option, int actionId)
    {
        options[queuedOptionsCount] = option;
        actionIds[queuedOptionsCount++] = actionId;
        dirty = true;
    }

    public void Say(string what)
    {
        loreBox.text = what;
    }

    public void StopDialogue()
    {
        if (DialogueSetup == null)
            return;

        DialogueSetup.LastReply = 0;
        player.AllowMovement = true;
        CurrentDialouge = null;
        DialogueSetup = null;
        dirty = false;
        panel.SetActive(false);
    }

    public void ShowDialogue(Dialogue dialogue, string who)
    {
        if (DialogueSetup == dialogue)
            return;
        narrator.text = who + ":";
        panel.SetActive(true);
        CurrentDialouge = dialogue.StartDialogue();
        CurrentDialouge.MoveNext();
        DialogueSetup = dialogue;
        player.AllowMovement = false;
    }

    private void Update()
    {
       if(dirty)
       {
            for (int i = 0; i < queuedOptionsCount; i++)
            {
                shownOptions[i].text = string.Format("{0}. {1}", (i + 1), options[i]);
                shownOptions[i].enabled = true;
                options[i] = null;
            }

            for (int i = queuedOptionsCount; i < shownOptions.Length ; i++)
            {
                shownOptions[i].enabled = false;
            }

            dirty = false;
        }

       if (Input.GetKeyDown(KeyCode.Alpha1))
       {
            if (queuedOptionsCount < 1)
                return;

            DialogueSetup.LastReply = actionIds[0];
       }
       else if(Input.GetKeyDown(KeyCode.Alpha2))
       {
            if (queuedOptionsCount < 2)
                return;

            DialogueSetup.LastReply = actionIds[1];
           
       }
       else if(Input.GetKeyDown(KeyCode.Alpha3))
       {
            if (queuedOptionsCount < 3)
                return;

            DialogueSetup.LastReply = actionIds[2]; 
       }
       else
       {
            return;
       }

       queuedOptionsCount = 0;
       if (!CurrentDialouge.MoveNext())
       {
            StopDialogue();
       }
    }


}
