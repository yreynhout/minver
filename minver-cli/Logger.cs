namespace MinVer
{
    using System;
    using MinVer.Lib;

    internal class Logger : ILogger
    {
        private readonly Verbosity verbosity;

        public Logger(Verbosity verbosity) => this.verbosity = verbosity;

        public bool IsTraceEnabled => this.verbosity >= Verbosity.Trace;

        public bool IsDebugEnabled => this.verbosity >= Verbosity.Debug;

        public void Trace(string message)
        {
            if (this.verbosity >= Verbosity.Trace)
            {
                Message(message);
            }
        }

        public void Debug(string message)
        {
            if (this.verbosity >= Verbosity.Debug)
            {
                Message(message);
            }
        }

        public void Info(string message)
        {
            if (this.verbosity >= Verbosity.Info)
            {
                Message(message);
            }
        }

        public void Warn(int code, string message)
        {
            if (this.verbosity >= Verbosity.Warn)
            {
                Message($"warning : {message}");
            }
        }

        public static void ErrorRepoOrWorkDirDoesNotExist(string repoOrWorkDir) =>
            Error($"Repository or working directory '{repoOrWorkDir}' does not exist.");

        public static void ErrorInvalidMinMajorMinor(string minMajorMinor) =>
            Error($"Invalid minimum MAJOR.MINOR '{minMajorMinor}'. Valid values are {MajorMinor.ValidValues}");

        public static void ErrorInvalidVerbosity(string verbosity) =>
            Error($"Invalid verbosity '{verbosity}'. The value must be {VerbosityMap.ValidValue}.");

        private static void Error(string message) => Message($"error : {message}");

        private static void Message(string message) => Console.Error.WriteLine($"MinVer: {message}");
    }
}
