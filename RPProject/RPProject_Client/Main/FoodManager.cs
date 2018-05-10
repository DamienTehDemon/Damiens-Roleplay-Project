﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace roleplay.Main
{
    public class FoodManager : BaseScript
    {
        public static FoodManager Instance;

        private const int MaximumHunger = 100;
        private const int MaximumThirst = 100;
        private const int HungerDrainRate = 1;
        private const int ThirstDrainRate = 1;
        private const int DamageWhenDrained = 15;
        private int _currentHunger = 100;
        private int _currentThirst = 100;
        public FoodManager()
        {
            var playerPed = API.PlayerPedId();
            Instance = this;

            EventHandlers["feedPlayer"] += new Action<bool,int>(FeedPlayer);

            Tick += new Func<Task>(async delegate
            {
                await Delay(1000);

                if (API.IsPedSprinting(playerPed))
                {
                    _currentThirst -= ThirstDrainRate * 5;
                }
            });

            Tick += new Func<Task>(async delegate
            {
                await Delay(60000);
                if (_currentHunger > 0)
                {
                    _currentHunger -= HungerDrainRate;
                }
                else
                {
                    API.ApplyDamageToPed(playerPed, DamageWhenDrained, false);
                }
                if (_currentThirst > 0)
                {
                    _currentThirst -= ThirstDrainRate;
                }
                else
                {
                    API.ApplyDamageToPed(playerPed, DamageWhenDrained, false);
                }
            });
        }

        private void FeedPlayer(bool food, int amount)
        {
            if (food)
            {
                _currentHunger += amount;
                if (_currentHunger > MaximumHunger)
                {
                    _currentHunger = MaximumHunger;
                }
                return;
            }
            _currentThirst += amount;
            if (_currentThirst > MaximumThirst)
            {
                _currentThirst = MaximumThirst;
            }
        }

        public float GetHungerPercentage()
        {
            return ((float)_currentHunger / (float)MaximumHunger) * 100.0f;
        }

        public float GetThirstPercentage()
        {
            return ((float)_currentThirst / (float)MaximumThirst) * 100.0f;
        }
    }
}