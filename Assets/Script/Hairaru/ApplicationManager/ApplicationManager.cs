using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Core
{
    public class ApplicationManager : MonoBehaviour
    {
        public void SetSceneContent(SceneContentBase content)
        {
            content_ = content;
        }

        public T PopSceneContent<T>() where T : SceneContentBase
        {
            T result = content_ as T;
            return result;
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            var go = new GameObject("ApplicationManager");
            go.AddComponent<ApplicationManager>();
        }

        private void Awake()
        {
            Debug.Assert(instance_ == null);
            instance_ = this;
            DontDestroyOnLoad(gameObject);
        }

        public static ApplicationManager instance_ = null;

        private SceneContentBase content_ = null;
    }
}