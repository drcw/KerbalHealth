﻿using System;

namespace KerbalHealth
{
    public class GetSickEvent : Event
    {
        public override string Name => "GetSick";

        public override string Message() => khs.Name + " has fallen sick.";

        public override bool Condition() => Core.SicknessEnabled && khs.HasCondition("Infected");

        public override double ChancePerDay() => Math.Min(1 / HighLogic.CurrentGame.Parameters.CustomParams<KerbalHealthEventsSettings>().IncubationDuration, 1);

        protected override void Run()
        {
            Core.Log("Adding sickness to " + khs.Name + "...");
            khs.RemoveCondition("Infected");
            khs.AddCondition(new HealthCondition("Sick"));
        }
    }
}
