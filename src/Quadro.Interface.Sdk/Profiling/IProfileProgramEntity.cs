using CPBase.Shapes;
using Quadro.Interface.Profiles;
using Quadro.Interface.Programs;

namespace Quadro.Interface.Profiling
{
	public interface IProfileProgramEntity
    {
        string Id { get; }
        string Name { get; set; }
        public string ProfileString { get; }
        ProgramType Type { get; }
        ProfileType ProfileType { get; }
        ProfileSide ProfileSide { get; }
        bool Checked { get; set; }
        bool EnableAsDesigned { get; set; }
        bool EnableFlipped { get; set; }
        double ProfileHeight { get; set; }
        double RabbetDepth { get; }
        IPathShape2D DesignContour { get; }
        IEnumerable<IContraProgramLink> ContraPrograms { get; }
        IEnumerable<IProgramRun> RunsAsDesigned { get; }
        IEnumerable<IProgramRun> RunsFlipped { get; }
        IProfileStyle ProfileStyle { get; }
    }

    public enum ProgramType
    {
        Profiling,
        Contra,
        Ending,
    }

    public enum ProfileType
    {
        Unknown,
        FrameOuter,
        FrameInner,
        WindowDoorOuter,
        WindowDoorInner,
        Border,
        FrameWork,
        GlassBeading,

        FrameContra = 100,
        FrameEnding = 101,
        WindowDoorContra = 110,
        WindowDoorEnding = 111,
        BorderContra = 120,
        BorderEnding = 121,
        FrameWorkContra = 130,
        FrameWorkEnding = 131,
        GlassBeadingContra = 140,
        GlassBeadingEnding = 141,
    }

    public enum ProfileSide
    {
        Unknown,
        Indoors,
        Outdoors,
    }

    public static class ProgramTypeMethods
    {
        public static bool IsLongProfile(this ProgramType programType) => programType == ProgramType.Profiling;
        public static bool IsHeadProfile(this ProgramType programType) => programType == ProgramType.Contra || programType == ProgramType.Ending;

    }
}