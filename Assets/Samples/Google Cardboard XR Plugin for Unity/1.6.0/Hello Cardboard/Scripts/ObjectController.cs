//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
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
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectController : MonoBehaviour
{
    protected CanvasManager sceneCanvasManager;

    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    public bool canHighlight = true;

    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _startingPosition = transform.localPosition;
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
        sceneCanvasManager = FindObjectOfType<CanvasManager>();
        if(!InactiveMaterial)
        {
            InactiveMaterial = _myRenderer.material;
        }
    }

    

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public virtual void OnPointerEnter()
    {
        // Debug.Log("Hovered on : " + name);
        if(sceneCanvasManager)
            sceneCanvasManager.SetDebugText("Hovered on : " + name);
        SetMaterial(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public virtual void OnPointerExit()
    {
        if (sceneCanvasManager)
            sceneCanvasManager.ClearDebugText();
        SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public virtual void OnPointerClick()
    {
        // TeleportRandomly();

        Debug.Log("Clicked on : " + name);
        
        
        

    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    /// 
    public virtual void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            if(canHighlight)
                _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
