using dc.en.hero;
using HaxeProxy.Runtime;
using ModCore.Mods;

namespace CellsX10
{
    public sealed class CellsX10Mod : ModBase
    {
        private const int Multiplier = 10;

        public CellsX10Mod(ModInfo info) : base(info) { }

        public override void Initialize()
        {
            Hook_Beheaded.addCells += OnAddCells;
            Logger.Information("[CellsX10] cells x{mult} on pickup enabled", Multiplier);
        }

        private static void OnAddCells(Hook_Beheaded.orig_addCells orig, Beheaded self, int val, Ref<bool> noStats)
        {
            orig(self, val * Multiplier, noStats);
        }
    }
}
