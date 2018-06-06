﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using roleplay.Main.Users;

namespace roleplay.Main
{
    public class RPCommands:BaseScript
    {
        public static RPCommands Instance;

        public RPCommands()
        {
            Instance = this;
            SetupCommands();
            EventHandlers["ActionCommandFromClient"] += new Action<Player,string>(ActionCommand);
        }

        private async void SetupCommands()
        {
            while (CommandManager.Instance == null)
            {
                await Delay(0);
            }
            while (Utility.Instance == null)
            {
                await Delay(0);
            }

            #region Chat Commands
            CommandManager.Instance.AddCommand("hotwire", HotwireCommand);
            CommandManager.Instance.AddCommand("me", ActionCommand);
            CommandManager.Instance.AddCommand("tweet", TweetCommand);
            CommandManager.Instance.AddCommand("tor", TorCommand);
            CommandManager.Instance.AddCommand("ooc", OocCommand);
            CommandManager.Instance.AddCommand("looc", LoocCommand);
            CommandManager.Instance.AddCommand("report", SupportCommand);
            CommandManager.Instance.AddCommand("help", HelpCommand);
            CommandManager.Instance.AddCommand("emshelp", EMSHelpCommand);
            CommandManager.Instance.AddCommand("cophelp", PoliceHelpCommand);
            #endregion

            #region Vehicle Commands
            CommandManager.Instance.AddCommand("engine", (user, strings) =>
            {
                TriggerClientEvent(user.Source,"ToggleEngine");
            });
            CommandManager.Instance.AddCommand("hood", (user, strings) =>
            {
                TriggerClientEvent(user.Source, "ToggleHood");
            });
            CommandManager.Instance.AddCommand("trunk", (user, strings) =>
            {
                TriggerClientEvent(user.Source, "ToggleTrunk");
            });
            CommandManager.Instance.AddCommand("lock", (user, strings) =>
            {
                TriggerClientEvent(user.Source, "ToggleLock");
            });
            CommandManager.Instance.AddCommand("windowsdown", (user, strings) =>
            {
                TriggerClientEvent(user.Source, "WindowsDown");
            });
            CommandManager.Instance.AddCommand("windowsup", (user, strings) =>
            {
                TriggerClientEvent(user.Source, "WindowsUp");
            });
            #endregion

            
            CommandManager.Instance.AddCommand("repair", (user, strings) =>
            {
                TriggerClientEvent(user.Source, "RepairCar");
            });

            CommandManager.Instance.AddCommand("selldrugs", (user, strings) =>
            {
                TriggerClientEvent(user.Source, "StartSellingDrugs");
            });

            CommandManager.Instance.AddCommand("injuries", (user, strings) =>
            {
                TriggerClientEvent(user.Source, "InjuryCheckCommand");
            });

            CommandManager.Instance.AddCommand("checkinjuries", (user, strings) =>
            {
                TriggerClientEvent(user.Source, "InjuryCheckCommand");
            });

        }
        private void HelpCommand(User user, string[] args)
        {
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "-------------HELP-------------", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "---F1 to open interaction menu---", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "--------COMMANDS--------", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/me | To roleplay out actions.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/tweet message | To send out a tweet.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/tor name message | To send out a anonymous message with a custom name", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/looc message | Local out of character chat", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/ooc message | Global out of character chat", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/report message | Send a report to online admins", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/hood | Open the vehicle hood. Cane be done inside or out. Vehicle must be unlocked.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/trunk | Opens the trunk of the vehicle, can be done in or out, vehicle must be unlocked.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/lock | Locks the car. Can only do it from the outside if you own the car.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/windowsdown | Rolls the windows down of the car that you are inside of.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/windowsup | Rolls the windows up of the car that you are inside of.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/repair | Repair your vehicle to a drivable state. (Hood must be open)", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/checkinjuries | Check the closest down'd players injuries.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/injuries |  Check the closest down'd players injuries.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/hotwire | Hotwire the vehicle that you are inside of. Can only be used once every 10 minutes.", 255, 0, 0);
        }

        private void PoliceHelpCommand(User user, string[] args)
        {
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "-------------HELP-------------", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "---F1 to open interaction menu---", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "--------COMMANDS--------", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/coponduty | Put on police uniform and go on duty.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/copoffduty | Take off police uniform and go off duty.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/policeonduty | Put on police uniform and go on duty.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/policeoffduty | Take off police uniform and go off duty.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/shield | Take off police uniform and go off duty.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/confiscate | Take all of someones illegal items.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/confiscateweapons | Take all of someones firearms.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/jail id timeInMinutes | Send someone to the jail for x minutes..", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/fine id amount | Fine someone money for thier crimes.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/unjail id | Release someone from the jail.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/addcop id | Add someone to police.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/copadd id | Add someone to police.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/remcop id | Remove someone from police.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/coprem id | Remove someone from police.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/setcoprank id rank | Set someones rank police.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/coppromote id rank | Set someones rank police.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/coprank id rank | Set someones rank police.", 255, 0, 0);
        }

        private void EMSHelpCommand(User user, string[] args)
        {
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "-------------HELP-------------", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "---F1 to open interaction menu---", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "--------COMMANDS--------", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/emsonduty | Put on EMS uniform and go on duty.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/emsoffduty | Take off EMS uniform and go off duty.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/hospital id timeInMinutes | Send someone to the hospital for x minutes..", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/unhospital id | Release someone from the hospital.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/addems id | Add someone to EMS.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/emsadd id | Add someone to EMS.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/remems id | Remove someone from EMS.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/emsrem id | Remove someone from EMS.", 255, 0, 0);
            Utility.Instance.SendChatMessage(user.Source, "[HELP]", "/emspromote id rank | Set someones rank in EMS.", 255, 0, 0);
        }


        private void HotwireCommand(User user, string[] args)
        {
            TriggerClientEvent(user.Source, "HotwireCar");
        }

        private void ActionCommand(User user, string[] args)
        {
            var name = user.CurrentCharacter.FirstName + " " + user.CurrentCharacter.LastName;
            args[0] = null;
            var message = string.Join(" ", args);
            TriggerClientEvent("ActionCommand", user.Source.Handle, name, message);
        }

        private void ActionCommand([FromSource] Player ply, string message)
        {
            var user = UserManager.Instance.GetUserFromPlayer(ply);
            var name = user.CurrentCharacter.FirstName + " " + user.CurrentCharacter.LastName;
            TriggerClientEvent("ActionCommand", user.Source.Handle, name, message);
        }

        public void ActionCommand(string message, Player ply)
        {
            var user = UserManager.Instance.GetUserFromPlayer(ply);
            var name = user.CurrentCharacter.FirstName + " " + user.CurrentCharacter.LastName;
            TriggerClientEvent("ActionCommand", user.Source.Handle, name, message);
        }

        private void TweetCommand(User user, string[] args)
        {
            var name = user.CurrentCharacter.FirstName + "_" + user.CurrentCharacter.LastName;
            args[0] = null;
            var message = string.Join(" ", args);
            Utility.Instance.SendChatMessageAll("^5Twitter | @"+ name.ToLower() + " ", "^7"+message, 255,255,255);
        }

        private void TorCommand(User user, string[] args)
        {
            var name = args[1];
            args[0] = null;
            args[1] = null;
            var message = string.Join(" ", args);
            Utility.Instance.SendChatMessageAll("^9TOR | @" + name + " ", "^7"+message, 255, 255, 255);
        }

        private void OocCommand(User user, string[] args)
        {
            var name = user.Source.Name;
            args[0] = null;
            var message = string.Join(" ", args);
            Utility.Instance.SendChatMessageAll("^6OOC | " + name+" | "+user.Source.Handle + " ", "^7^_(("+message+" )) ", 255, 255, 255);
        }

        private void LoocCommand(User user, string[] args)
        {
            var name = user.Source.Name;
            args[0] = null;
            var message = string.Join(" ", args);
            TriggerClientEvent("LoocCommand", user.Source.Handle + " ", name, message+" ");
        }

        private void SupportCommand(User user, string[] args)
        {
            var name = user.Source.Name;
            args[0] = null;
            var message = string.Join(" ", args);
            Utility.Instance.SendChatMessage(user.Source, "^1[REPORT] " + name + " | " + user.Source.Handle+" ", "^*^7" + message, 255, 255, 255);
            foreach (Player admin in Admin.Instance.ActiveAdmins)
            {
                Utility.Instance.SendChatMessage(admin, "^1[REPORT]" + name+ " | "+user.Source.Handle + " ", "^*^7"+message, 255, 255, 255);
            }
        }
    }
}
