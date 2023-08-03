using System.Runtime.CompilerServices;

namespace NxEditor.PluginBase.Extensions;

internal static class DirectoryExtension
{
    public static void Copy(string src, string dst)
    {
        Directory.CreateDirectory(dst);
        CopyFiles(src, dst);

        foreach (var directory in Directory.EnumerateDirectories(src)) {
            string output = Path.Combine(dst, Path.GetRelativePath(src, directory));
            Directory.CreateDirectory(output);
            Copy(directory, output);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void CopyFiles(string src, string dst)
    {
        foreach (var file in Directory.EnumerateFiles(src)) {
            File.Copy(file, Path.Combine(dst, Path.GetFileName(file)));
        }
    }
}
