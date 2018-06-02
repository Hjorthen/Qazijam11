using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInventory  {
    private static Dictionary<string, int> Content = new Dictionary<string, int>();
    public static void AddItem(string id, int amount)
    {
        int currentAmount;
        if(Content.TryGetValue(id, out currentAmount))
        {
            Content[id] = currentAmount + amount;
        }
        else
        {
            Content.Add(id, amount);
        }
    }

    public static int GetItemCount(string id)
    {
        int currentAmount;
        if (Content.TryGetValue(id, out currentAmount))
        {
            return currentAmount;
        }

        return 0;
    }
}
