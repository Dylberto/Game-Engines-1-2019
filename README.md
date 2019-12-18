# Assignment Proposal
## Details

I want to make a procedurally generated dungeon crawler. Similar to games like the Binding of Issac and spelunky. 
In the game the map, enemies and wepons the player finds are all prcedurally generated. Enemies would spawn using a spawner and come in waves. After a certain number of waves the player will be asked to enter one of three rooms. Each one procedually generated with random weapons and enemy types inside.

### Task list
 - Different dungeons for the map
 
 - Varied enemie types to spawn
 
 - Multiple weapon types
 
 - Will demonstrate ability to use multipe systems and a functions in unity
 
 ### Insperations
 
 [Binding Of Issac](https://www.youtube.com/watch?v=BiZ6mMlOF7c)
 
 [Spelunky](https://www.youtube.com/watch?v=n50JIBBwcbM&t=17s)





#                                                     Final Version Proposal

## Description:

No less then a week following my proposal idea I decided to switch my idea from a 2d dungeon crawler to a 3d wave based zombie shooter. I choose this because not only was I more familiar working in 3d then 2d unity but also I had been wanting to make a shooter for a long time and this seemed like the perfect chance to do so.



## player:

while the movement script is the standards assests script and not my own (this was origonally for testing purposes but give myself enough time to change) the shooting mechanic is my main achievement. Using a combination of a raycast, coroutines and pulling from other scripts in the scene I feel I've created a relativly useable shooting mechanic. The ammo reload in particular was tricky as I need two different "current ammo" values, the one that was begin used and the one that was availible to use. This was so that if the player reloaded but the player still had bullets so use the "current max ammo" didn't just take the "max ammo availible". I also added particale effects to make the gun shooting more satisfying. I added a muzzle flash at the barrel of the gun and an impact effect on where the raycast shot to emulate a bullet impact. I also added a sci-fi gun sound effect.
The player also has a different health script then I'm used to where instead of counting down a vaule (on the surface anyway) the players health is represented by heart images. After each hit the fill on a heart dissappears (changes png file), it restores after a certain amount of time has passed.

## Zombies:

The zombies are both by happiest achievement and my most frustrating, unfinished mess in this project. I originally had planned for a variety of zombie which is still possible as I left room for changes thanks to setting up a prefab. However I did not give myslef enough time to make the various zombie types I had envisioned. There movement script uses the Navmesh agent component in unity that scans all the objects in the sence and created a baseline "map" that the zombies use to move throughout the scene. Then I simply coded the zombies to always move to the current posistion of the player. The navmesh and characterController compontents in unity determine if there are any obstecles in between the player and a zombie and changes the route accordingly which is why zombies don't always just walk in a straight towards the player and get stuck on everything. Although my method is not perfect and does need work its a great example of what can be done.
Animation is not my strongest aspect in unity and as such the zombie animations are somewhat cluncky. Zombies have their running, attacking and dying animations (all found on Mixamo.com) and are triggered at their appropriate times but the attacking animation does sometimes bug out and will trigger even when not in collision with the player. The zombies also have a health bar attachted to them to let the player know their status. Each zombies health bar is a png that using components in unity compresses and changes color has the zombies health value in the script decreases.

## Pickup, Wavespawner & AmmoSpawner:

To get it out of the way, the pick up is a simeply a gun with rotating animation that also has a light attached to make it stand out. It also gives off a sound that gets louder the closer the player gets so its easly found. Once The player collides with its hit box is't destroyed and resest the ammo in the gun script so the players "current max ammo" is equal to the actual "max ammo" of the gun.

The wavespawner the AmmoSpawner (i.e the procedural generation), are esentailly the same thing with minor changes. using various arrays, the Wavespawner instansiates a set number of Zombie prefabs at various set posistions in the map however, each zombie is spawned in a random position. Meaning the player never knows where the hoards will come from. The number of zombies spawned increased after each wave.
The "wave" funcation is called once there are no zombie prefabs detected in the scene, each time its called the "wave counter" increases which determines the wave number. (i.e) when the game starts there are no zombies in the scene so the "wave" function is called and "wave counter" increases from 0 to 1. Once a set number of waves have been called the player wins!
The "Ammo spawn" function is called whenever the players "current max ammo" falls below the max ammo in a clip. This spawns a pickup prefab in a random posistion using an array. This is why I implemented the auido mechanic to the pickup prefab as it wont always spawn in the same place so the player will have to look for it each time.


#                                                         Final thoughts

Overall I feel as though I could have put more time into the project, I am very happy with what I did and fully intend to work on it after submission to get it up to a point that I can proudly have it on my itch.io page.
I'd been meaning to work on a shooter for a long time and now that I know the basics I feel it will allow me to better deveopl projects in the future and give me different ways to tackle tasks. Having also worked on basic enemy Ai I feel that I can now do a cleaner more streamlined version in my next approach as I'll keep the limitations of my ability to use Navmesh in mind when desgining the level.
