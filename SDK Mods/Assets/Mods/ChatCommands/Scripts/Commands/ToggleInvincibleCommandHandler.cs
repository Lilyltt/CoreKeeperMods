﻿using CoreLib.Commands;
using CoreLib.Commands.Communication;
using CoreLib.Util;
using CoreLib.Util.Extensions;
using PugMod;
using Unity.Entities;
using Unity.Entities.Internal;

namespace ChatCommands.Chat.Commands
{
    public class ToggleInvincibleCommandHandler : IServerCommandHandler
    {
        public CommandOutput Execute(string[] parameters, Entity sender)
        {
            if (parameters.Length == 0) return new CommandOutput("Not enough arguments!", CommandStatus.Error);
            if (!bool.TryParse(parameters[0], out bool newValue)) return new CommandOutput($"'{parameters[0]}' is not a valid boolean!", CommandStatus.Error);

            Entity player = sender.GetPlayerEntity();
            World serverWorld = API.Server.World;
            EntityManager entityManager = serverWorld.EntityManager;
            
            entityManager.SetComponentData(player, new PlayerInvincibilityCD
            {
                isInvincible = newValue
            });
            
            return $"Successfully set invincibility to {newValue}";
        }

        public string GetDescription()
        {
            return "Use /invincible {state} to set invincibility for the player.";
        }

        public string[] GetTriggerNames()
        {
            return new[] { "invincible" };
        }
    }
}