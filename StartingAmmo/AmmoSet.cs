// -----------------------------------------------------------------------
// <copyright file="AmmoSet.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace StartingAmmo
{
    /// <summary>
    /// Handles the ammo amounts for the config.
    /// </summary>
    public class AmmoSet
    {
        /// <summary>
        /// Gets or sets the amount of <see cref="ItemType.Ammo556x45"/> ammo to give.
        /// </summary>
        public ushort Nato556 { get; set; } = 9999;

        /// <summary>
        /// Gets or sets the amount of <see cref="ItemType.Ammo762x39"/> ammo to give.
        /// </summary>
        public ushort Nato762 { get; set; } = 9999;

        /// <summary>
        /// Gets or sets the amount of <see cref="ItemType.Ammo9x19"/> ammo to give.
        /// </summary>
        public ushort Nato9 { get; set; } = 9999;

        /// <summary>
        /// Gets or sets the amount of <see cref="ItemType.Ammo12gauge"/> ammo to give.
        /// </summary>
        public ushort Ammo12Gauge { get; set; } = 9999;

        /// <summary>
        /// Gets or sets the amount of <see cref="ItemType.Ammo44cal"/> ammo to give.
        /// </summary>
        public ushort Ammo44Cal { get; set; } = 9999;
    }
}