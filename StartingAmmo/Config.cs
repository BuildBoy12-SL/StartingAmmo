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
        public Dictionary<RoleType, AmmoSet> Ammo { get; set; } = new Dictionary<RoleType, AmmoSet>
        {
            [RoleType.FacilityGuard] = new AmmoSet(),
        };
    }
}