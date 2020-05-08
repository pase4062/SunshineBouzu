using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Core
{
    public class ShadowBlockController : MonoBehaviour
    {
        private void Awake()
        {
            mover_.Initialize();
        }

        private void Update()
        {
            if (input_.GetLeftKey())
            {
                mover_.MoveLeft();
            }

            if (input_.GetRightKey())
            {
                mover_.MoveRight();
            }

            if (input_.GetOpenKey())
            {
                door_.Open();
            }

            if (input_.GetCloseKey())
            {
                door_.Close();
            }
        }

        [SerializeField]
        private ShadowBlockMover mover_ = null;

        [SerializeField]
        private ShadowBlockInput input_ = null;

        [SerializeField]
        private ShadowBlockDoor door_ = null;
    }
}