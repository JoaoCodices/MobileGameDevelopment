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

- No Changes

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
![devenv_ASkjgkaVQd](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/7d6f1c4a-4914-4418-8b3a-462bb667c4a2)

![Unity_26eCv3stLb](https://github.com/JoaoCodices/MobileGameDevelopment/assets/91282174/fa21b54e-68fa-41b7-a645-8b2e396eaf4e)
