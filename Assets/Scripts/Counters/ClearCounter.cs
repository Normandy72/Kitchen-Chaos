using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
   [SerializeField] private KitchenObjectSO kitchenObjectSO;

   public override void Interact(Player player)
   {
      if(!HasKitchenObject())
      {
         if(player.HasKitchenObject())
         {
            player.GetKitchenObject().SetKitchenObjectParent(this);
         }
         else
         {

         }
      }
      else
      {
         if(player.HasKitchenObject())
         {
            if(player.GetKitchenObject() is PlateKitchenObject)
            {
               PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
               if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
               {
                  GetKitchenObject().DestroySelf();
               }               
            }
         }
         else
         {
            GetKitchenObject().SetKitchenObjectParent(player);
         }
      }   
   }
}
