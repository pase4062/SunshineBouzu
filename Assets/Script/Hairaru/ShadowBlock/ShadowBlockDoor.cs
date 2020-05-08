using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Core
{
    public class ShadowBlockDoor : MonoBehaviour
    {
        public void Open()
        {
            if (right_transform_.position.x < max_)
            {
                left_transform_.Translate(-speed_, 0.0f, 0.0f);
                right_transform_.Translate(speed_, 0.0f, 0.0f);

                var left_position = left_transform_.position;
                if (left_position.x > max_)
                {
                    left_position.x = max_;
                    left_transform_.position = left_position;
                }
            }
        }

        public void Close()
        {
            if (right_transform_.position.x > min_)
            {
                left_transform_.Translate(speed_, 0.0f, 0.0f);
                right_transform_.Translate(-speed_, 0.0f, 0.0f);

                var right_position = right_transform_.position;
                if (right_position.x < min_)
                {
                    right_position.x = min_;
                    right_transform_.position = right_position;
                }
            }
        }

        [SerializeField]
        private Transform left_transform_ = null;

        [SerializeField]
        private Transform right_transform_ = null;

        [SerializeField]
        private float speed_ = 0.1f;

        [SerializeField]
        private float max_ = 100.0f;

        [SerializeField]
        private float min_ = 12.0f;
    }
}