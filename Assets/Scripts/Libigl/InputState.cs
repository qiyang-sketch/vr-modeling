﻿using UnityEngine;
using XrInput;

namespace Libigl
{
    
    /// <summary>
    /// Struct for storing the current input. (This is a value type so assigning will copy).
    /// Anything that may change as we are executing should be in the InputState as it is copied in PreExecute.
    /// </summary>
    public struct InputState
    {
        // Copy for threading
        public SharedInputState Shared;

        // Generic Input
        public float GripL;
        public float GripR;
        public Vector3 HandPosL;
        public Vector3 HandPosR;
        // The previous position of the hand when the last transformation was made
        public Vector3 PrevTrafoHandPosL;
        public Vector3 PrevTrafoHandPosR;

        // Transform
        public bool DoTransform;
        public bool DoTransformPrev;
        public bool PrimaryTransformHand; // True=R
        public bool SecondaryTransformHandActive;

        // Select
        public int ActiveSelectionId;
        public uint VisibleSelectionMask;
        public bool VisibleSelectionMaskChanged;
        public uint SCountUi; // For UI, will be copied to the state in PreExecute

        public bool DoSelect;
        public bool DoSelectPrev;
        public Vector3 SelectPos;
        public float SelectRadius;
        // A Mask of the selections that should be cleared
        public uint DoClearSelection; 
        
        // Deformations
        public bool DoHarmonic; // Trigger execution once
        public bool DoHarmonicRepeat; // Trigger execution every frame
        public bool HarmonicShowDisplacement;
        public bool DoArap;
        public bool DoArapRepeat;

        public bool ResetV;

        /// <returns>An instance with the default values</returns>
        public static InputState GetInstance()
        {
            return new InputState {VisibleSelectionMask = uint.MaxValue, SelectRadius = 0.1f, HarmonicShowDisplacement = true};
        }
        
        public void ChangeActiveSelection(int increment)
        {
            ActiveSelectionId = (int) ((ActiveSelectionId + increment) % SCountUi);
        }
    }
}