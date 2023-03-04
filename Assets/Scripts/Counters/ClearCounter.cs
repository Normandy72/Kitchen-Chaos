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
            if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
               if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
               {
                  GetKitchenObject().DestroySelf();
               }
            }
            else
            {
               if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
               {
                  if(plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                  {
                     player.GetKitchenObject().DestroySelf();
                  }
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
