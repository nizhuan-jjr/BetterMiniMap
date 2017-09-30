using UnityEngine;
using Verse;

namespace BetterMiniMap.Overlays
{
	public class Fog_Overlay : Overlay
	{
        public Fog_Overlay(bool visible = true) : base(visible) { }

        public void Update() => base.Update(false);

        public override void Render()
		{
            bool[] fogGrid = Find.VisibleMap.fogGrid.fogGrid;
			for (int i = 0; i < Find.VisibleMap.cellIndices.NumGridCells; i++)
			{
				IntVec3 intVec = Find.VisibleMap.cellIndices.IndexToCell(i);
				base.Texture.SetPixel(intVec.x, intVec.z, fogGrid[i] ? Color.gray : Color.clear);
			}
        }

		public override int GetUpdateInterval() => BetterMiniMapMod.settings.overlay_Fog;

	}
}
