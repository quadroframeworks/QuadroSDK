using CPBase.Shapes;
using Quadro.Globalization.Attributes;
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
        double RabbetWidth { get; set; }
        double RabbetHeight { get; set; }
        double EdgeWidth { get; set; }
        double ContraOffset { get; }
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
        RabbetChange,
        Misc = 100,
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