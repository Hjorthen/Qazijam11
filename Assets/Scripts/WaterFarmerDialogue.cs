using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFarmerDialogue : Dialogue
{
    public override string GetWhoDis()
    {
        return "Earl, aka The Water Farmer";
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
                        diagCont.Say("<i>WHATCHU WANT!</i>");
                        if (PlayerInventory.GetItemCount("WaterLetter") == 0)
                        {
                            diagCont.AddOption("Can I buy some water?", 1);
                        }
                        else if(PlayerInventory.GetItemCount("RottenBanana") == 6)
                        {
                            diagCont.AddOption("Here are your bananas", 9);
                        }
                        diagCont.AddOption("Who are you?", 2);
                        diagCont.AddOption("Just having a look around", 3);
                        break;
                    }
                case 3:
                    {
                        diagCont.Say("DON'T COME BACK!");
                        diagCont.AddOption("I guess you do not want my money then", 1);
                        diagCont.AddOption("You're a crazy earl", 50);
                        break;
                    }
                case 1:
                    {
                        diagCont.Say("Do you have money?");
                        diagCont.AddOption("We use money in this place?", 6);
                        diagCont.AddOption("No", 6);
                        diagCont.AddOption("I have found these bananas", 4);
                        break;
                    }
                case 2:
                    {
                        diagCont.Say("Name's Earl Kincaid, better know at the water farmer. I sell the finest water around! Oh! And bananas, too!");
                        diagCont.AddOption("Why are your prices so high?", 5);
                        diagCont.AddOption("What is that tree?", 11);
                        diagCont.AddOption("Okay", 0);
                        break;
                    }
                case 4:
                    {
                        diagCont.Say("That is stealing! Give them back!");
                        diagCont.AddOption("<i>End conversation</i>", 50);
                        break;
                    }
                case 5:
                    {
                        diagCont.Say("Supply and demand!");
                        diagCont.AddOption("But you have so much water stored?", 3);
                        break;
                    }
                case 6:
                    {
                        diagCont.Say("If you have no money, then I have a proposal for you. The nearby wolf came and stole all my rotten bananas, which are a big part of my business model. I will pay you greatly to get them back! I bet he is willing to exchange them for ripe bananas.");
                        diagCont.AddOption("Why do you want the rotten bananas instead of the ripe ones?", 7);
                        diagCont.AddOption("Sounds good to me!", 8);
                        break;
                    }
                case 7:
                    {
                        diagCont.Say("Uh, uhm.. Various reasons.. I think, uh, uhm.. They are good for composting! Yes! That is it!");
                        diagCont.AddOption("Alright. I will get you the rotten ones", 8);
                        break;
                    }
                case 8:
                    {
                        PlayerInventory.AddItem("WaterLetter", 1);
                        diagCont.Say("Great! You hereby have my permission to pick up the bananas that have fallen from the tree. I was going to sell them, but can manage without!");
                        diagCont.AddOption("Great!", 50);
                        break;
                    }
                case 9:
                    {
                        diagCont.Say("Great! Hand them over! Quickly");
                        diagCont.AddOption("<i>Give bananas</i>", 10);
                        diagCont.AddOption("Leave", 50);
                        break;
                    }
                case 10:
                    {
                        PlayerInventory.AddItem("Water", 1);
                        diagCont.Say("Yes! My business is saved! I will give you 5% discount on the next delivery. Here it is! <i>Some water magically appears in your inventory</i>");
                        diagCont.AddOption("Uh, thanks!", 12);
                        break;
                    }
                case 11:
                    {
                        diagCont.Say("It grabs water out of the air, leaving it more dry! Then the water drops off the leaves and I collect it below. I do not know how it works, all I know is that it is mine!");
                        diagCont.AddOption("Can I have some of it?", 1);
                        diagCont.AddOption("Bye!", 50);
                        break;
                    }
                case 12:
                    {
                        diagCont.Say("Remember your mother's note and bring that water home!");
                        diagCont.AddOption("How do you know my mother?", 13);
                        break;
                    }
                case 13:
                    {
                        diagCont.Say("Uh, that's, erhm. <i>The tent becomes silent, expect for slight whispering</i>");
                        diagCont.AddOption("Leave", 50);
                        break;
                    }
                case 50:
                    {
                        keepTalking = false;
                        break;
                    }
            }
            if (keepTalking)
                yield return null;
        } while (keepTalking);
    }
}
