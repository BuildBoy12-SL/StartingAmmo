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
            if (plugin.Config.Ammo.TryGetValue(ev.NewRole, out var ammoSet))
            {
                Timing.RunCoroutine(RunSetAmmo(ev, ammoSet));
            }
        }

        private IEnumerator<float> RunSetAmmo(ChangingRoleEventArgs ev, AmmoSet ammoSet)
        {
            yield return Timing.WaitUntilTrue(() => ev.Player.Role == ev.NewRole);
            ev.Player.Ammo[ItemType.Ammo556x45] = ammoSet.Nato556;
            ev.Player.Ammo[ItemType.Ammo762x39] = ammoSet.Nato762;
            ev.Player.Ammo[ItemType.Ammo9x19] = ammoSet.Nato9;
            ev.Player.Ammo[ItemType.Ammo12gauge] = ammoSet.Ammo12Gauge;
            ev.Player.Ammo[ItemType.Ammo44cal] = ammoSet.Ammo44Cal;
        }
    }
}