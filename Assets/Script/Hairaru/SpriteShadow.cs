using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;

public class SpriteShadow : MonoBehaviour {
    void Awake() {
        
        renderer_.shadowCastingMode = ShadowCastingMode.On;
        renderer_.receiveShadows    = true;
    }

    [SerializeField]
    private SpriteRenderer renderer_ = null;
}
