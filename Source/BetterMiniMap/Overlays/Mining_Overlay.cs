using System.Linq;
using Verse;
using RimWorld;

namespace BetterMiniMap.Overlays
{
	public class Mining_Overlay : Overlay, IExposable
	{
        public Mining_Overlay(bool visible = true) : base(visible) { }

        public void ExposeData() => this.ExposeData("overlayMining");

		public override void Render()
		{
			foreach (Designation current in Find.VisibleMap.designationManager.allDesignations.Where(d => d.def == DesignationDefOf.Mine).ToList<Designation>())
			{
				IntVec3 cell = current.target.Cell;
				base.Texture.SetPixel(cell.x, cell.z, BetterMiniMapMod.settings.overlayColors.mining);
			}
        }

		public override int GetUpdateInterval() => BetterMiniMapMod.settings.updatePeriods.mining;
	}
}
