using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
  bool hasPackage;
  [SerializeField] float delaydest = 0.5f;
  [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
  [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
  SpriteRenderer spriteRenderer;
   void Start() {
    
    spriteRenderer = GetComponent<SpriteRenderer>();
  }
     void OnCollisionEnter2D(Collision2D other) {
       Debug.Log("OBSTACLE");
    }
     void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage){
          Debug.Log("delivery picked up");
          hasPackage = true ;
          Destroy(other.gameObject,delaydest);
          spriteRenderer.color = hasPackageColor;
        }

        if(other.tag == "Customer" && hasPackage){
          Debug.Log("Package Delivered");
          hasPackage = false ;
          spriteRenderer.color = noPackageColor;
        }
    }
}
