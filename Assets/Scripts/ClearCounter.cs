using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
   [SerializeField] private KitchenObjectSO kitchenObjectSO;
   [SerializeField] private Transform counterTopPoint;
   [SerializeField] private ClearCounter secondClearCounter;
   [SerializeField] private bool testing; 

   private KitchenObject kitchenObject;

   private void Update()
   {
      if(testing && Input.GetKeyDown(KeyCode.T))
      {
         if(kitchenObject != null)
         {
            kitchenObject.SetClearCounter(secondClearCounter);
         }
      }
   }

   public void Interact()
   {
      if(kitchenObject == null)
      {
         Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
         kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
      }
      else
      {
         Debug.Log(kitchenObject.GetClearCounter());
      }        
   }

   public Transform GetKitchenObjectFollowTransform()
   {
      return counterTopPoint;
   }

   public void SetKitchenObject(KitchenObject kitchenObject)
   {
      this.kitchenObject = kitchenObject;
   }

   public KitchenObject GetKitchenObject()
   {
      return kitchenObject;
   }

   public void ClearKitchenObject()
   {
      kitchenObject = null;
   }

   public bool hasKitchenObject()
   {
      return kitchenObject != null;
   }
}
