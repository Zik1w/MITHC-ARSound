using UnrealBuildTool;

public class MITHC_SoundTarget : TargetRules
{
	public MITHC_SoundTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		ExtraModuleNames.Add("MITHC_Sound");
	}
}
