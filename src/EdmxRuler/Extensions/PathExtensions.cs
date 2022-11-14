﻿using System.IO;
using System.Threading.Tasks;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeInternal

namespace EdmxRuler.Extensions;

public static class PathExtensions {
    public static Task<string[]> FindEdmxFilesNearProjectAsync(this string projectBasePath) {
        return FindEdmxFilesUnderPathAsync(FindSolutionParentPath(projectBasePath));
    }

    public static string[] FindEdmxFilesNearProject(this string projectBasePath) {
        return FindEdmxFilesUnderPath(FindSolutionParentPath(projectBasePath));
    }

    public static Task<string[]> FindEdmxFilesUnderPathAsync(this string solutionBasePath) {
        return Task.Factory.StartNew(() => Directory.GetFiles(solutionBasePath, "*.edmx", SearchOption.AllDirectories));
    }

    public static string[] FindEdmxFilesUnderPath(this string solutionBasePath) {
        return Directory.GetFiles(solutionBasePath, "*.edmx", SearchOption.AllDirectories);
    }

    public static string FindSolutionParentPath(this string projectBasePath) {
        if (projectBasePath.IsNullOrWhiteSpace()) return projectBasePath;
        var di = new DirectoryInfo(projectBasePath);
        while (di?.GetFiles("*.sln", SearchOption.TopDirectoryOnly).Length == 0) di = di.Parent;
        return di?.Exists != true ? projectBasePath : di.FullName;
    }

    public static string FindProjectParentPath(this string projectSubPath) {
        if (projectSubPath.IsNullOrWhiteSpace()) return projectSubPath;
        var di = new DirectoryInfo(projectSubPath);
        while (di?.GetFiles("*.csproj", SearchOption.TopDirectoryOnly).Length == 0) di = di.Parent;
        return di?.Exists != true ? projectSubPath : di.FullName;
    }
}