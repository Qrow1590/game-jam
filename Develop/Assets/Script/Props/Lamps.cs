using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamps : MonoBehaviour
{

    private MeshRenderer[] meshes;
    private Transform trans;
    [SerializeField] private Material light;

    
    void Awake(){
        trans = GetComponent<Transform>();
        int children = trans.childCount;
        meshes = new MeshRenderer[children];
        Debug.Log("Children Count: " + children);
        for(int i = 0 ; i < children ; i++){
            meshes[i] = trans.GetChild(i).GetComponent<MeshRenderer>();
        }
    }

    public void turnOn(){
        
        for(int i = 0; i < meshes.Length; i++){
        Material[] current = new Material[meshes[i].materials.Length+1];
        for(int f = 0; f < current.Length - 1 ; f++) {
            current[f] = meshes[i].materials[f];
        }
        current[current.Length - 1] = light;
        meshes[i].materials = current;
        }
        }
}
