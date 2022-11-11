using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace SolutionComponentSplit
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Solution Component Split"),
        ExportMetadata("Description", "Help you to Split Solution Component to Other Solution"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAABoAAAAaCAYAAACpSkzOAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAEnQAABJ0Ad5mH3gAAAS3SURBVEhLvZZ/bFNVFMc/Xcu6tdtamMC2srkBgU1gbBnijCBBAzqI4D8QjASEBJ1BAYMJSsQ/QBMFFImgxBB/bICgiWIm40cCA3TySzbGjwFjMDZGKrCtm11Z+9a1ntc+UsDXJUb0k9y+e9+973zfOe/cc2sICvwPxGjX/5zoQsGe8PXPE+HrvyS6UHcr3NgK7uPQdigiLFx3uTAUF1OwcSMen0+72zv6Qj1d0HEYTs+GU6+Bcg0MRm0SHH37smLmTKrq6khYvhylu1ubgXavE6f7vDaKED0Zuq5A9WTx6DI8JqKxA8AyPDTV7nZjT0xkamkJ5bW1PJqezaEFhWw4Voyrqxml5zaWPv1Y+fTZ0HqVXoQaxbM2MGeAS8I3oAhnaxvDZ7+Mu0k8xEBcWirewjzS7e28Pe4AQYOZfvHpjE55iZz+z4XtaPyj9C7dtZevD/xC461bdLo7udHWKcli5Y0Puogz+SmpHkKm7XE+nDSBJzJTtKfC9Cr0aeUxFpXtZcmThaybImG8j5M3SjjS9DG7KxyUnxsJQ+3Q2Q4eD4unTOETaXeImnU7ai6zqHwTc8ZW8/mJraza/7s2E6Fg4By2/2ih2SYGL9UginxUVER6VhbrS0vpVBRtZS9C+xreJTclnmNNmWTZ7dTcfEebibBs01ckB6dR88pC5k9/VrJTofnUeZqWLqVq7VruDpauUEOrmx3VseSlteJRYilw3OTAlVQq6q9qK+C2tNVvbqbkvbdC49XF88Hr5eeaM6FxvsNBotkc6qvoCtW3V2C3mLjaZqdo2GXaPPHExFhxGaVKOBW6dk3Ast9A8OBvWPbNQGnxkmxLIicvlzGDMzUr96KbDJ9VbueIs4Syunw63AmY47zMzD+NrXE0izdXkr6wEnOhbGopHi1HbVzblsvoPT9QZwyQnSL7TQddjy65/Gw5OpYOn7ge58MXNFJ6fByrGn7CmKpwMrAGw6SJ+CcGMaStI86h4NzwfFQRFV0hrz9RKoFkTIzqrAECRsYnX8A++xRZX5rYmZADuUmYZDZ57jxy1v6BY1KlbPLIN7wfXaFBSSIUCGgjFQP9zB7ZH9JNGE/54QomjxoRnlKJGQNqbVVawmMddIWmZssb312VDQGOtkhYxIWLZeWcq7pIyqBw3VN99tXvlghIxxq+p4euUJ7UsD62h8Qr1Yw0pYdZI4fis60hdk8BO3OdFNneh7MZNC+bRu3KZ7hatkBeRCIRhb8LNa2HShPfjtguoZJk6JZvZOomL7OULzr3s2VuPdPHVDFrRJ0U22tYUw8SP6Q/mXN+lV0ua6ufkm/VoBmLcG96H06STHDLcSAFceRWvjnZyMoz7byebYW+33Pd28kjicOYRxrBwCH5cib8xnGYMsaC3yZnmCRE4wrpi638bZDyQtiuEBFSD7tdFvnY6l1pRjFuHQzxaRI98azHyu2AX84ZKZxqOIOyKOiV+x3itSSBIseKcj00FUqMQTNg1HfSCXOvR55auPCqnGxy0KmL1cCqomq7m8gT4b7a1CSNl5YgGZixRLx5UQYRdCtDiID8R/CcFsEmeWNX2NAd1CeM8mMUy30GyqZ+WETE+16ILvSA0U3vBw/8BRipxr2TWAwQAAAAAElFTkSuQmCC"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}