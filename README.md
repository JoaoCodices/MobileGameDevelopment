# MobileGameDevelopment
 Work from Mobile Games Development Module
# Mobile Game Idea
##


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
