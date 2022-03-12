// -----------------------------------------------------------------------
// <copyright file="GetAmmoLimit.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace StartingAmmo.Patches
{
#pragma warning disable SA1118
    using System.Collections.Generic;
    using System.Reflection.Emit;
    using HarmonyLib;
    using InventorySystem;
    using InventorySystem.Configs;
    using InventorySystem.Items.Armor;
    using NorthwoodLib.Pools;
    using static HarmonyLib.AccessTools;

    /// <summary>
    /// Patches <see cref="BodyArmorUtils.RemoveEverythingExceedingLimits"/> to enforce <see cref="Config.Ammo"/>.
    /// </summary>
    [HarmonyPatch(typeof(BodyArmorUtils), nameof(BodyArmorUtils.RemoveEverythingExceedingLimits))]
    internal static class GetAmmoLimit
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);

            LocalBuilder startingAmmo = generator.DeclareLocal(typeof(Dictionary<ItemType, ushort>));
            LocalBuilder startingAmount = generator.DeclareLocal(typeof(ushort));

            const int offset = 2;
            int index = newInstructions.FindIndex(i => i.OperandIs(Method(typeof(InventoryLimits), nameof(InventoryLimits.GetAmmoLimit), new[] { typeof(BodyArmor), typeof(ItemType) }))) + offset;

            Label skipOverwriteLabel = generator.DefineLabel();
            newInstructions[index].labels.Add(skipOverwriteLabel);

            const int kvpIndex = 8;
            const int ammoLimitIndex = 9;

            // if (Plugin.Instance.Config.Ammo.TryGetValue(inv._hub.characterClassManager.CurClass, out Dictionary<ItemType, ushort> startingAmmo) &&
            //     startingAmmo.TryGetValue(keyValuePair.Key, out ushort startingAmount) &&
            //     startingAmount > ammoLimit)
            // {
            //    ammoLimit = startingAmount;
            // }
            newInstructions.InsertRange(index, new[]
            {
                // if (!Plugin.Instance.Config.Ammo.TryGetValue(inv._hub.characterClassManager.CurClass, out Dictionary<ItemType, ushort> startingAmmo) goto skipOverwrite;
                new CodeInstruction(OpCodes.Call, PropertyGetter(typeof(Plugin), nameof(Plugin.Instance))),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(Plugin), nameof(Plugin.Config))),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(Config), nameof(Config.Ammo))),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(Inventory), nameof(Inventory._hub))),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(ReferenceHub), nameof(ReferenceHub.characterClassManager))),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(CharacterClassManager), nameof(CharacterClassManager.CurClass))),
                new CodeInstruction(OpCodes.Ldloca_S, startingAmmo.LocalIndex),
                new CodeInstruction(OpCodes.Callvirt, Method(typeof(Dictionary<RoleType, Dictionary<ItemType, ushort>>), nameof(Dictionary<RoleType, Dictionary<ItemType, ushort>>.TryGetValue))),
                new CodeInstruction(OpCodes.Brfalse_S, skipOverwriteLabel),

                // if (!startingAmmo.TryGetValue(keyValuePair.Key, out ushort startingAmount)) goto skipOverwrite;
                new CodeInstruction(OpCodes.Ldloc_S, startingAmmo.LocalIndex),
                new CodeInstruction(OpCodes.Ldloca_S, kvpIndex),
                new CodeInstruction(OpCodes.Call, PropertyGetter(typeof(KeyValuePair<ItemType, ushort>), nameof(KeyValuePair<ItemType, ushort>.Key))),
                new CodeInstruction(OpCodes.Ldloca_S, startingAmount.LocalIndex),
                new CodeInstruction(OpCodes.Callvirt, Method(typeof(Dictionary<ItemType, ushort>), nameof(Dictionary<ItemType, ushort>.TryGetValue))),
                new CodeInstruction(OpCodes.Brfalse_S, skipOverwriteLabel),

                // if (startingAmount <= ammoLimit) goto skipOverwrite;
                new CodeInstruction(OpCodes.Ldloc_S, startingAmount.LocalIndex),
                new CodeInstruction(OpCodes.Ldloc_S, ammoLimitIndex),
                new CodeInstruction(OpCodes.Ble_S, skipOverwriteLabel),

                // ammoLimit = startingAmount;
                new CodeInstruction(OpCodes.Ldloc_S, startingAmount.LocalIndex),
                new CodeInstruction(OpCodes.Stloc_S, ammoLimitIndex),
            });

            for (int z = 0; z < newInstructions.Count; z++)
                yield return newInstructions[z];

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }
    }
}