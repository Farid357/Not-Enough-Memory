﻿using UnityEditor;
using UnityEngine;

namespace NotEnoughMemory.SceneLoading
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Create/Scene Data")]
    public sealed class Scene : ScriptableObject, ISerializationCallbackReceiver, IScene
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset _scene;
#endif
        [field: SerializeField] public string Name { get; private set; }

        public void OnAfterDeserialize() { }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR

            if (_scene != null)
                Name = _scene.name;
#endif
        }
    }
}