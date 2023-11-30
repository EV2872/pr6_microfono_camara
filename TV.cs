using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class TV : MonoBehaviour {
    private Material tvMaterial;
    private WebCamTexture webCamTexture;
    private string pathCapturas = "C:\\Users\\Usuario\\Descargas";
    int captureCounter = 0;
    // Start is called before the first frame update
    void Start() {
        webCamTexture = new WebCamTexture();
        WebCamDevice[] camaras = WebCamTexture.devices;
        for (int i = 0; i < camaras.Length; i++) {
            Debug.Log(camaras[i].name);
        }
        tvMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("s")) {
            tvMaterial.mainTexture = webCamTexture; 
            webCamTexture.Play(); 
        }
        if (Input.GetKey("p")) { 
            webCamTexture.Pause(); 
        }
        if (Input.GetKeyDown("x")) { 
            Texture2D snapshot = new Texture2D(webCamTexture.width, webCamTexture.height);
            snapshot.SetPixels(webCamTexture.GetPixels());
            snapshot.Apply();
            System.IO.File.WriteAllBytes(pathCapturas + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
            captureCounter++;
         }
    }
}
