// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace StartingAmmo
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
        /// Gets an instance of the <see cref="StartingAmmo.EventHandlers"/> class.
        /// </summary>
        public EventHandlers EventHandlers { get; private set; }

        /// <inheritdoc />
        public override void OnEnabled()
        {
            EventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Player.ChangingRole += EventHandlers.OnChangingRole;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= EventHandlers.OnChangingRole;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}