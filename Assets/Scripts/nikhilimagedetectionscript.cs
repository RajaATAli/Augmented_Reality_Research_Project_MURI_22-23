// Credits to this script goes to Nikhil Dhoka, who worked on the image detection part of the project with me

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognitionExample : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;

    private void Awake(){
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();

    }

    public void OnEnable(){
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable(){
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args){
           foreach(var trackedImage in args.added){
             Debug.Log(trackedImage.name);
           } 
    }
   
}
