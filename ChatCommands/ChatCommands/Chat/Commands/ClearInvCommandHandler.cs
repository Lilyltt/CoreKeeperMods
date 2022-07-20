﻿using CoreLib;
using UnityEngine;

namespace ChatCommands.Chat.Commands;

public class ClearInvCommandHandler:IChatCommandHandler
{
    public CommandOutput Execute(string[] parameters)
    {
        PlayerController player = Players.GetCurrentPlayer();
        if (player == null) return new CommandOutput("There was an issue, try again later.", Color.red);
        InventoryHandler handler = player.playerInventoryHandler;
        if (handler == null) return new CommandOutput("There was an issue, try again later.", Color.red);
        
        for (int i = 0; i < handler.size; i++)
        {
            ObjectID objId = handler.GetObjectData(i).objectID;
            handler.DestroyObject(i, objId);
        }
        return "Successfully cleared inventory";
    }

    public string GetDescription()
    {
        return "Clear player inventory.";
    }

    public string[] GetTriggerNames()
    {
        return new[] {"clearInv", "clearInventory"};
    }
}