using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Core
{
    public class ShadowBlockMover : MonoBehaviour
    {
        public void Initialize()
        {
            transform_ = transform;
        }

        public void MoveLeft()
        {
            if (transform_.position.x > min_)
            {
                transform_.Translate(-speed_, 0.0f, 0.0f);

                var position = transform_.position;
                if (position.x < min_)
                {
                    position.x = min_;
                    transform_.position = position;
                }
            }
        }

        public void MoveRight()
        {
            if (transform_.position.x < max_)
            {
                transform_.Translate(speed_, 0.0f, 0.0f);

                var position = transform_.position;
                if (position.x > max_)
                {
                    position.x = max_;
                    transform_.position = position;
                }
            }
        }

        [SerializeField]
        private float speed_ = 0.1f;

        [SerializeField]
        private float max_ = 10.0f;

        [SerializeField]
        private float min_ = -10.0f;

        private Transform transform_ = null;
    }
}