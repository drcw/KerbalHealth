﻿namespace KerbalHealth
{
    /// <summary>
    /// Holds information about a certain health condition (such as exhaustion, sickness, etc.)
    /// </summary>
    public class HealthCondition
    {
        string title;

        /// <summary>
        /// Internal name of the condition
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Displayable name of the condition (similar to Name by default)
        /// </summary>
        public string Title
        {
            get => ((title == null) || (title == "")) ? Name : title;
            set => title = value;
        }

        /// <summary>
        /// Whether this condition should be visible to the player
        /// </summary>
        public bool IsVisible { get; set; } = true;

        public virtual ConfigNode ConfigNode
        {
            get
            {
                ConfigNode n = new ConfigNode("HealthCondition");
                n.AddValue("name", Name);
                if ((title != null) && (title != "") && (title != Name)) n.AddValue("title", Title);
                n.AddValue("visible", IsVisible);
                return n;
            }
            set
            {
                Name = value.GetValue("name");
                if (value.HasValue("title")) Title = value.GetValue("title");
                IsVisible = Core.GetBool(value, "visible", true);
            }
        }

        public HealthCondition(ConfigNode n)
        { ConfigNode = n; }

        public HealthCondition(string name, string title = null, bool isVisible = true)
        {
            Name = name;
            Title = title;
            IsVisible = isVisible;
        }

        public HealthCondition(string name, bool isVisible)
        {
            Name = name;
            IsVisible = isVisible;
        }
    }
}
