using System;
using System.Collections.Generic;
using UnityEngine;

public static class DataSaver{

    public static Action OnActorSpawned; //when an actor spawns, call this action
    public static Action OnActorDeSpawned; //when an actor despawns, call this action

    public static Action OnCacheHit; //when a path hits, call this action
    public static Action OnCacheMiss; //when a path misses, call this action

    public static Action<int> OnRoomsLoaded; //when rooms have been loaded from the RoomManager, count the amount of rooms


    public static void ActorSpawned()
    {
        if (null != OnActorSpawned) OnActorSpawned();
    }

    public static void ActorDeSpawned()
    {
        if (null != OnActorDeSpawned) OnActorDeSpawned();
    }

    public static void CacheHit()
    {
        if (null != OnCacheHit) OnCacheHit();
    }

    public static void CacheMiss()
    {
        if (null != OnCacheMiss) OnCacheMiss();
    }

    public static void RoomsLoaded(int count)
    {
        if (null != OnRoomsLoaded) OnRoomsLoaded(count);
    }


}
