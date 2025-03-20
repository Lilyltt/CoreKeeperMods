﻿using System;
using CoreLib.Commands;
using CoreLib.Commands.Communication;
using CoreLib.Util;
using PugMod;
using Unity.Entities;

namespace ChatCommands.Chat.Commands
{
    public class MaxSkillsCommandHandler : IServerCommandHandler
    {
        public CommandOutput Execute(string[] parameters, Entity sender)
        {
            Entity player = sender.GetPlayerEntity();
            
            for (int i = 0; i < (int)SkillID.NUM_SKILLS; ++i)
            {
                SkillID skillID = (SkillID) i;
                int maxSkillLevel = SkillExtensions.GetMaxSkillLevel(skillID);
                SetSkillCommandHandler.SetSkillValue(player, skillID, maxSkillLevel);
            }
            
            return "Successfully maxed all skills";
        }

        public string GetDescription()
        {
            return "Use /maxSkills to maxes out all skills.";
        }

        public string[] GetTriggerNames()
        {
            return new[] {"maxSkills"};
        }
    }
}