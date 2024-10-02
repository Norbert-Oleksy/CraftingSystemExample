# CraftingSystemExample
 Recruitment task / Unity Developer Test

## Controls:

Character movement - WSAD

Camera control, rotation - Mouse

Interaction - F

Inventory, Crafting window - Tab

## Objectives:
- There should be 3 different objects on stage to interact with (wood, stone, iron) and the player
- The player should be able to move and interact with each object
- When interacting, the object is added to the player's inventory
- From the inventory level, the player has the ability to perform 2 actions
   - throwing the object back back onto the stage
   - switching to the crafting panel
- The player should be able to craft the following example objects from the crafting panel:
   1. wood + wood = plank 
   2. board + stone = stone axe 
   3. iron + iron = nail  
   4. plank + nail = spiked baton
- Each resulting object should have a certain percentage chance of success. For example, a nail might have a 60% chance of being created and a spiked bludgeon only 20%. 
In both successful and unsuccessful crafting, we should be able to add any behaviour, effect or method to a given situation from within the editor without the need to write additional code in the class that manages crafting
- The crafting and inventory system should operate on a simple UI
- Any object discarded from the inventory should appear on the stage and have the possibility to be picked up and then returned to the inventory

## Used:
- [Low-poly Medieval Free Pack by VanillaArt](https://assetstore.unity.com/packages/3d/environments/low-poly-medieval-free-pack-253520?srsltid=AfmBOoo7ooWPXENsnP0d0b6zBwrRr1uB2Y-0qFv6ZQwc_PAEM8v6ohAL)
