// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace StartingAmmo
{
    using System.Collections.Generic;
    using Exiled.API.Enums;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a collection of roles to their starting ammo.
        /// </summary>
        public Dictionary<RoleType, Dictionary<AmmoType, ushort>> Ammo { get; set; } = new Dictionary<RoleType, Dictionary<AmmoType, ushort>>
        {
            [RoleType.ClassD] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.Scientist] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.FacilityGuard] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.NtfCaptain] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.NtfSergeant] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.NtfSpecialist] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.NtfPrivate] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.ChaosConscript] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.ChaosMarauder] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.ChaosRepressor] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
            [RoleType.ChaosRifleman] = new Dictionary<AmmoType, ushort>
            {
                [AmmoType.Nato9] = 9999,
                [AmmoType.Ammo12Gauge] = 9999,
                [AmmoType.Ammo44Cal] = 9999,
                [AmmoType.Nato556] = 9999,
                [AmmoType.Nato762] = 9999,
            },
        };
    }
}