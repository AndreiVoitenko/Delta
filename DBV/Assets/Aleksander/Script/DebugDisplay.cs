using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDisplay : MonoBehaviour
{

    protected int actorsCount = 0;
    protected int cacheHitCount = 0;
    protected int cacheMissCount = 0;
	public float deltaTime = 0.0f;

    public Text actorsLabel;
    public Text roomsLabel;
    public Text cacheHitLabel;
    public Text cacheMissLabel;
	public Text FPS;
	
	void Update() //remove this later
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        FPS.text = text;
    }
	

    public void OnEnable()
    {
        DataSaver.OnActorSpawned += OnActorSpawned;
        DataSaver.OnActorDeSpawned += OnActorDeSpawned;
        DataSaver.OnCacheHit += OnCacheHit;
        DataSaver.OnCacheMiss += OnCacheMiss;
        DataSaver.OnRoomsLoaded += OnRoomsLoaded;
    }

    public void OnDisable()
    {
        DataSaver.OnActorSpawned -= OnActorSpawned;
        DataSaver.OnActorDeSpawned -= OnActorDeSpawned;
        DataSaver.OnCacheHit -= OnCacheHit;
        DataSaver.OnCacheMiss -= OnCacheMiss;
        DataSaver.OnRoomsLoaded -= OnRoomsLoaded;
    }

    public void OnActorSpawned()
    {
        AddActorsCount();
    }

    public void OnActorDeSpawned()
    {
        AddActorsCount(-1);
    }

    public void OnCacheHit()
    {
        AddCacheHitCount();
    }

    public void OnCacheMiss()
    {
        AddCacheMissCount();
    }

    public void OnRoomsLoaded(int count)
    {
        roomsLabel.text = "Rooms: " + count;
    }

    public void AddActorsCount(int count = 1)
    {
        actorsCount++;
        if (null != actorsLabel)
        {
            actorsLabel.text = "Actors: " + actorsCount;
        }
    }

    public void AddCacheHitCount(int count = 1)
    {
        cacheHitCount++;
        if (null != cacheHitLabel)
        {
            cacheHitLabel.text = "Cache hits: " + cacheHitCount;
        }
    }

    public void AddCacheMissCount(int count = 1)
    {
        cacheMissCount++;
        if (null != cacheMissLabel)
        {
            cacheMissLabel.text = "Cache misses: " + cacheMissCount;
        }
    }
}
