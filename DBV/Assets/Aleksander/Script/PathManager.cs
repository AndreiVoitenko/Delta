using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class PathManager
{

    static Dictionary<string, Dictionary<string, NavMeshPath>> pathCache = new Dictionary<string, Dictionary<string, NavMeshPath>>();

    public static void CachePath(string source, string destination, NavMeshPath path)
    {
        if (!pathCache.ContainsKey(source))
        {
            pathCache.Add(source, new Dictionary<string, NavMeshPath>());
        }
        if (!pathCache[source].ContainsKey(destination))
        {
            pathCache[source].Add(destination, path);
        }
    }

    public static NavMeshPath GetPath(string source, string destination)
    {
        if (HasPath(source, destination))
        {
            return pathCache[source][destination];
        }

        return null;
    }

    public static bool HasPath(string source, string destination)
    {
        return pathCache.ContainsKey(source) && pathCache[source].ContainsKey(destination);
    }
}
