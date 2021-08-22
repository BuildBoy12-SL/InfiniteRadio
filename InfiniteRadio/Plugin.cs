// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace InfiniteRadio
{
    using Exiled.API.Features;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private static readonly Plugin InstanceValue = new Plugin();

        private Plugin()
        {
        }

        /// <summary>
        /// Gets the only existing instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; } = InstanceValue;

        /// <summary>
        /// Gets an instance of the <see cref="InfiniteRadio.EventHandlers"/> class.
        /// </summary>
        public EventHandlers EventHandlers { get; private set; }

        /// <inheritdoc />
        public override void OnEnabled()
        {
            EventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Player.UsingRadioBattery += EventHandlers.OnUsingRadioBattery;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.UsingRadioBattery -= EventHandlers.OnUsingRadioBattery;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}