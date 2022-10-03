using System;
using UnityEngine;

[Serializable]
public class SceneData
{
    [SerializeField] private SceneType sceneType;

    public SceneType SceneType => sceneType;
}
