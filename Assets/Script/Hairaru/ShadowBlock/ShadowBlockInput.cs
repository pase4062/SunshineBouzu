using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Core
{
    public class ShadowBlockInput : MonoBehaviour
    {
        public bool GetOpenKey()
        {
            return Input.GetKey(open_key_);
        }

        public bool GetCloseKey()
        {
            return Input.GetKey(close_key_);
        }

        public bool GetLeftKey()
        {
            return Input.GetKey(left_key_);
        }

        public bool GetRightKey()
        {
            return Input.GetKey(right_key_);
        }

        [SerializeField]
        private KeyCode open_key_ = KeyCode.UpArrow;

        [SerializeField]
        private KeyCode close_key_ = KeyCode.DownArrow;

        [SerializeField]
        private KeyCode left_key_ = KeyCode.LeftArrow;

        [SerializeField]
        private KeyCode right_key_ = KeyCode.RightArrow;
    }
}