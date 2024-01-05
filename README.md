# MobileGameDevelopment
 Work from Mobile Games Development Module
# Mobile Game Idea
## HyperCasual Infinite Survival Game
A Game where the player has to move survive on a set of tiles for as long as possible, collecting coins that win you points and dodging falling objects that block the tiles and hurt the player. HyperCasual Game that the player can quickly open and start playing. High replayability since the gameplay is always randomized and with increasing difficulty for hardcore gamers.

### Inputs
- Player swipes across the screen to move in the direction of the swipe to the next tile;
- Player Double Taps the screen to jump + combined with a swipe to move 2 Tiles(skipping 1 tile);
- Player Shakes phone to rotate the tiles upside down and clear the tiles covered in rubble from the fallen obstacles;

### Monetization
- In-App Purchases of extra Lives and Map & Player Re-Skins;
- ADs for 1 extra life once player runs out. ADs everytime the player ends loses;
- ADs when the player closes an Active Game and then returns, with option to continue last active game for watching an AD;
  
### Analytics
- Analytics on when the player is most likely to watch an AD to continue playing;
- Analytics on average playtime before engaging in In-App purchases;
- Analytics on when the player 1st checks the store;


# Development Log
## Week 1
- First Mock up of Scene in Unity based on Vision of game. Simple tiles for game map, player (red Cube).

![SS_1](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/a4971de4-3160-4703-be69-fa18c9581194)

## Week 2
### Player 
- Added Movement Script based on Swiping screen, different directions of swipe move the cube  a different direction ( no detection if a tile is blocked or not yet) until a set distance for the X and Y axis;
- Added Double Tap mechanic to so player jumps when double tapping the screen, havent added the combination of double tap and swipe to move 2 tiles, just testing the double tap detection;
- Added Score script to player that track time elapsed, highscore and the lives of the player, dispaying those values in the UI;

### Tiles
- Added Shake script to test spinning the tiles around on a UI button click (* to be changed to shaking the phone as the trigger), dropping everything ontop of the tile.
- Added as prefab to scene.

### Obstacles
- Added Obstacle Spawner that takes in the position of every tile and then adds an offset to the Y value for the spawn point of the obstacles, droping them at random times (*Soon to be added a difficulty variable that scales the interval between spawns);
- Added Obstacles prefab that detects collisions with the tiles, player and coins triggering a explosion crumbling the obstacle, blocking the tile it fell on or if hitting the player, removing a life from it. Obstacles break in to pieces that clean themselves up once they hit a point in the Y value, improving performance.

### Coins
- Added Coins to the scene that the player can collect by stepping on, these add score to the players Highscore. Get destroyed by the obstacles when they land on a coin.

![SS_2](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/0d06241e-f5d5-4dd4-949b-48119eb8b3bd)


## Week 3

### Movement 
- Changed the movement script to now only accept diagonal swipes, which dictate the direction of movement for the player, also added a deadzone for swipes, meaning the player has to swipe in a significant direction and swipes to closely aligned with the y and x axis will be ignored.

### Obstruction Detection
- Started working on the player detection for the obstructed tiles using raycast sensors for collisions.

![SS_3](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/15ffaf09-2b5c-4646-a973-991fbb64397d)

## Week 4
- No Changes

## Week 5

- No Changes

## Week 6

### Mobile Controls
- Implemented Finished Swipe Mechanic with better response rate.
![devenv_AUq7oblqkg](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/96b5e38f-04ec-4fd0-96c3-42e4bd7c3e1d)
![devenv_iJIWPJc8Jo](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/de83a20f-406f-498a-b2fe-c9c99b6b762a)
![devenv_okkbK4tY3Y](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/75a1b61b-62ee-47d1-9542-0b934eba0404)
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/e2e22b69-03b2-4789-9b7c-ffe7e1d54b02)


- Implemented Accelerometer Input for Rotating the Tiles
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/aa2bb373-3bb0-4c40-b363-26489cd1da21)
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/081ea01c-a13e-4110-b946-f3cd5752a99d)
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/4a12e7b8-0be9-411d-b15f-df5febbd2229)

- Implemented Vibration to Device.
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/883bcf01-ec1c-41be-accf-1333a712f858)


## Week 7 - Hand In

### Store Setup
- Split the Store between IAP Store and In-Game Store, to simplify user experience.

![Unity_ob4wX31vaa](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/e7a64b44-2234-432e-98d6-0cef5f6339d6)![Unity_FahCqX85Nk](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/4d912abb-a966-464a-8aec-a005b1b130da)

- Implemented Google Play Console IAP into my Game
![msedge_Co7Nx6uVPE](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/35e73a45-450d-4649-bb9f-40b595e625cc)
![Unity_UUimsPyARi](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/1fb25398-caa4-4f4e-8ecc-d1e0c4f0eca2)

### Ads Setup
- Implemented Banner Ads to The Scenes as well as the ability to Purchase a No ADS Experience.

- Implemented Reward Ads when the Player Reaches 0 Lives for the 1st Time. This grants the player 1 extra life one time.
![devenv_ASkjgkaVQd](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/7d6f1c4a-4914-4418-8b3a-462bb667c4a2)![Unity_26eCv3stLb](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/fa21b54e-68fa-41b7-a645-8b2e396eaf4e)

### Obstacles
- Implemented a Obstacle Manager which Controls the Spawning of Obstacle Blocks, this takes in all the tile Positions and Instanciates a Block a set distance above it, according to a timed cooldown period that decreases the higher the player score.
![Unity_m8lojYdRn3](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/950d63da-77c9-4cf2-b2ef-31f0b4a2ee33)
![devenv_h9k1w21tjY](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/c6feb84f-15c2-4fb7-b98a-7489919e1c71)

- The obstacles detect collisions with other gameobject and have different responses:
   - Player: deals damage to player and explodes.
   - Coins: destroys coins
   - Tiles: Explodes
![devenv_PFQ51GCxr1](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/753fa9d1-9cae-46f4-b9a7-495cddbf160b)

### Coins
- Implemented a Coins Spawner just like the Obstacles.
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/e257d108-fde9-40ed-9c96-af543d4bea03)

#### The Obstacles once colliding with the tiles Explode into small cubes meanwhile, The Coins start to spin around
![Unity_SzJthBfoqy](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/961ed36f-394b-4dab-9210-bb97d673890c)


### Cinemachine Implementation

- Implemented Shake To the Camera as a function that can be called from other Scripts to trigger a shake of Set Intensity and Duration
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/b63065cb-7db3-42f9-a079-5188c92ea77a)
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/8deb4c1d-90b1-4cf9-b3ac-4236e7391864)
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/b773cd68-6380-4180-af90-49d8420a83a5)

### Twitter Score Sharing
![image](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/5808807d-3ca9-4328-9d14-d04f83282248)


