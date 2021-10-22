// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace StartingAmmo
{
    using System.Collections.Generic;
    using Exiled.Events.EventArgs;
    using MEC;

    /// <summary>
    /// Handles events from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnChangingRole(ChangingRoleEventArgs)"/>
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (plugin.Config.Ammo.TryGetValue(ev.NewRole, out Dictionary<ItemType, ushort> ammoSet))
                Timing.RunCoroutine(RunSetAmmo(ev, ammoSet));
        }

        private IEnumerator<float> RunSetAmmo(ChangingRoleEventArgs ev, Dictionary<ItemType, ushort> ammoSet)
        {
            yield return Timing.WaitUntilTrue(() => ev.Player.Role == ev.NewRole);
            yield return Timing.WaitForSeconds(1f);
            foreach (var kvp in ammoSet)
                ev.Player.Ammo[kvp.Key] = kvp.Value;

            ev.Player.ReferenceHub.inventory.ServerSendAmmo();
        }
    }
}