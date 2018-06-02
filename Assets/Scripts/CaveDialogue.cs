using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDialogue : Dialogue {

    public override string GetWhoDis()
    {
        return "Growling Voice";
    }

    public override IEnumerator StartDialogue()
    {
        bool keepTalking = true;
        do
        {
            switch (LastReply)
            {
                case 0:
                    {
                        diagCont.Say("<b>Stay out!</b>");
                        diagCont.AddOption("Who are you?", 1);
                        if (PlayerInventory.GetItemCount("WaterLetter") > 0 && PlayerInventory.GetItemCount("RottenBanana") == 0)
                        {
                            diagCont.AddOption("I hear you have some stale bananas", 5);
                        }
                        diagCont.AddOption("Bye.", 50);
                        break;
                    }
                case 1:
                    {
                        diagCont.Say("I am the big bad wolf! I have a voice deep as thunder, eyes big as waterwheels, a mouth large enough to swallow you whole and hands large enough to crush these walls! Or, I used to, at least. But that does not concern you!");
                        diagCont.AddOption("You do not scare me!", 2);
                        diagCont.AddOption("Those are some pretty big eyes", 3);
                        diagCont.AddOption("Keep silent", 0);
                        break;
                    }
                case 2:
                    {
                        diagCont.Say("<i>But you scare me ..</i>");
                        diagCont.AddOption("What?", 4);
                        break;
                    }
                case 4:
                    {
                        diagCont.Say("What?");
                        diagCont.AddOption("Nevermind", 0);
                        break;
                    }
                case 3:
                    {
                        diagCont.Say("What! NO! You are not supposed to be able to see me! Now I have to <b>KILL YOU</b>!");
                        diagCont.AddOption("Relax! I was just making a reference!", 0);
                        diagCont.AddOption("Run.", 50);
                        break;
                    }
                case 5:
                    {
                        diagCont.Say("Yes! They taste awful and my cave it beginning to smell!");
                        diagCont.AddOption("Want to exchange them for ripe bananas?", 6);
                        diagCont.AddOption("Why are you even eating banans to begin with?", 7);
                        break;
                    }
                case 6:
                    {
                        diagCont.Say("Yes! Please! Get these off my hand!");
                        diagCont.AddOption("<i>Trade bananas</i>", 9);
                        diagCont.AddOption("Leave", 50);
                        break;
                    }
                case 7:
                    {
                        diagCont.Say("<b><i>sob</i></b>.. I am on my last days.. My teeth are all gone and my stomach all sour. Bananas help ease the pain..");
                        diagCont.AddOption("About those bananas..", 6);
                        diagCont.AddOption("Laugh and walk away", 50);
                        break;
                    }
                case 8:
                    {
                        diagCont.Say("That is none of your business! You do not really care anyways!");
                        diagCont.AddOption("But I want to know! I do care!", 7);
                        diagCont.AddOption("You are right. I don't care!", 0);
                        break;
                    }
                case 9:
                    {
                        int bananaAmount = PlayerInventory.GetItemCount("banana");
                        if (bananaAmount < 6)
                        {
                            diagCont.Say("You do not have enough bananas! Are you trying to trick me? Come back when you have " + (6- bananaAmount) + "more!");
                            diagCont.AddOption("Leave", 50);
                        }
                        else
                        {
                            PlayerInventory.AddItem("RottenBanana", 6);
                            diagCont.Say("Aaaah I can finally fill my empty stomach! Here, as promised, are the rotten bananas");
                            diagCont.AddOption("My pleasure!", 50);
                            diagCont.AddOption("Whatever", 50);
                        }
                        break;
                    }
                case 50:
                    {
                        keepTalking = false;
                        break;
                    }
                default:
                    break;
            }
            if (keepTalking)
                yield return null;
        } while (keepTalking);
    }
}
