//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using Google.XR.Cardboard;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    public const float maxDistance = 10;
    private GameObject _gazedAtObject = null;

    public Sprite foundObjectReticle;
    Sprite defaultReticle;

    public Image reticleImage;

    [HideInInspector]
    public Vector3 gazedObjectPosition = Vector3.negativeInfinity;
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    ///
    public LayerMask layerMask;

    private void Start()
    {
        defaultReticle = reticleImage?.sprite;
    }

    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.

        

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
                gazedObjectPosition = hit.point;
                reticleImage.sprite = foundObjectReticle;
            }
        }
        else
        {
            if(_gazedAtObject && _gazedAtObject.activeInHierarchy)
            {
                // No GameObject detected in front of the camera.
                _gazedAtObject?.SendMessage("OnPointerExit");

               
            }

            if (reticleImage.sprite != defaultReticle)
                reticleImage.sprite = defaultReticle;

            gazedObjectPosition = Vector3.negativeInfinity;
            _gazedAtObject = null;

        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }

#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
#endif
    }
}
