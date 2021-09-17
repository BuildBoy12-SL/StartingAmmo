// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace StartingAmmo
{
    using System.Collections.Generic;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a collection of roles to their starting ammo.
        /// </summary>
        public Dictionary<RoleType, Dictionary<ItemType, ushort>> Ammo { get; set; } = new Dictionary<RoleType, Dictionary<ItemType, ushort>>()
        {
            [RoleType.FacilityGuard] = new Dictionary<ItemType, ushort>
            {
                [ItemType.Ammo9x19] = 9999,
                [ItemType.Ammo12gauge] = 9999,
                [ItemType.Ammo44cal] = 9999,
                [ItemType.Ammo556x45] = 9999,
                [ItemType.Ammo762x39] = 9999,
            },
        };
    }
}