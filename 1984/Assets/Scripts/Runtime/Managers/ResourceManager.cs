using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private readonly Dictionary<string, GameObject> _prefabs = new Dictionary<string, GameObject>();
    private readonly Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();
    private readonly Dictionary<string, AudioClip> _sounds = new Dictionary<string, AudioClip>();

    private const string PrefabPath = "Prefabs/";
    private const string SpritePath = "Sprites/";
    private const string SoundPath = "Sounds/";
    public GameObject LoadPrefab(string path)
    {
        if (_prefabs.ContainsKey(path))
            return _prefabs[path];

        GameObject prefab = Resources.Load<GameObject>(PrefabPath + path);
        if (prefab == null)
        {
            Debug.LogError($"[ResourceManager] LoadPrefab Error: {path}");
            return null;
        }

        _prefabs.Add(path, prefab);
        return prefab;
    }

    public Sprite LoadSprite(string path)
    {
        if (_sprites.ContainsKey(path))
            return _sprites[path];

        Sprite sprite = Resources.Load<Sprite>(SpritePath + path);
        if (sprite == null)
        {
            Debug.LogError($"[ResourceManager] LoadSprite Error: {path}");
            return null;
        }

        _sprites.Add(path, sprite);
        return sprite;
    }

    public AudioClip LoadSound(string path)
    {
        if (_sounds.ContainsKey(path))
            return _sounds[path];

        AudioClip sound = Resources.Load<AudioClip>(SoundPath + path);
        if (sound == null)
        {
            Debug.LogError($"[ResourceManager] LoadSound Error: {path}");
            return null;
        }

        _sounds.Add(path, sound);
        return sound;
    }
    
    public T Load<T>(string path) where T : Object
    {
        GameObject prefab = Resources.Load<GameObject>(PrefabPath + path);
        if (prefab == null)
        {
            Debug.LogError($"[ResourceManager] LoadAsync Error: {path}");
            return null;
        }

        return prefab.GetComponent<T>();
    }
}
