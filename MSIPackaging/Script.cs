using Microsoft.Win32;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using WixSharp;

namespace MSIPackaging
{
    class Script
    {
        static public void Main(string[] args)
        {
            var version = "1.5.7";

#if DEBUG
            if (System.IO.File.Exists("WinCertes-Debug." + version + "-pre.msi")) System.IO.File.Delete("WinCertes-Debug." + version + "-pre.msi");
            if (System.IO.File.Exists("WinCertes-Debug." + version + ".msi")) System.IO.File.Move("WinCertes-Debug." + version + ".msi", "WinCertes-Debug." + version + "-pre.msi");
#else
            if (System.IO.File.Exists("WinCertes-" + version + "-pre.msi")) System.IO.File.Delete("WinCertes-" + version + "-pre.msi");
            if (System.IO.File.Exists("WinCertes-" + version + ".msi")) System.IO.File.Move("WinCertes-" + version + ".msi", "WinCertes-" + version + "-pre.msi");
#endif

            var path = "..\\..\\..";
            if (args.Length > 0) { path = args[0]; path = path.Replace(@"\", @"\\"); path = path.Replace("\"", ""); }
            if (path.Contains("MSBUILD")) { return; }
            Console.WriteLine("**** This is the path for building: " + path);
            var project = new Project("WinCertes",
                  new Dir(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\WinCertes",
#if DEBUG
                                  new WixSharp.File(path + @"\WinCertes\bin\Debug\net5.0-windows\WinCertes.exe")
                                  {
                                      Shortcuts = new[] { new FileShortcut("WinCertes", "ProgramMenuFolder") }
                                  },
                                  new Files(path + @"\WinCertes\bin\Debug\net5.0-windows\*.*", (f) => !f.EndsWith(".exe"))
#else
                                  new WixSharp.File(path + @"\WinCertes\bin\Release\net5.0-windows\WinCertes.exe")
                                  {
                                      Shortcuts = new[] { new FileShortcut("WinCertes", "ProgramMenuFolder") }
                                  },
                                  new Files(path + @"\WinCertes\bin\Release\net5.0-windows\*.*", (f) => !f.EndsWith("WinCertes.exe"))
#endif
                                  ),
                  new RegValue(WixSharp.RegistryHive.LocalMachine, @"Software\WinCertes", "license", "GPLv3") { Win64 = true },
                  new RemoveRegistryValue(WixSharp.RegistryHive.LocalMachine, @"Software\WinCertes"),
                  new RemoveRegistryKey(WixSharp.RegistryHive.LocalMachine, @"Software\WinCertes"),
                  new EnvironmentVariable("Path", @"[INSTALLDIR]") {
                      Id = "Path_WinCertes_INSTALLDIR",
                      Action = EnvVarAction.set,
                      Part = EnvVarPart.last,
                      Permanent = false,
                      System = true
                  }
                  );
            project.GUID = new Guid("bb0a8e11-24a8-4d7e-a7d6-6fc5bd8166d2");
            project.Version = Version.Parse(version);
            project.LicenceFile = path + @"\MSIPackaging\Resources\gpl-3.0.rtf";
            project.BannerImage = path + @"\MSIPackaging\Resources\banner.png";
            project.BackgroundImage = path + @"\MSIPackaging\Resources\background.png";
            project.Platform = Platform.x64;
            project.InstallScope = InstallScope.perMachine;
            project.ControlPanelInfo.Manufacturer = "Evertrust";
            Compiler.BuildMsi(project);
#if DEBUG
            if (System.IO.File.Exists("WinCertes.msi")) System.IO.File.Move("WinCertes.msi", "WinCertes-Debug." + version +".msi");
#else
            if (System.IO.File.Exists("WinCertes.msi")) System.IO.File.Move("WinCertes.msi", "WinCertes-" + version + ".msi");
#endif
        }
    }
}
