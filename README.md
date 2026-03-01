# 🎮 My First Unity Video Game

**Created for the Video Game Programming Course**

---

## About This Project

This is a **5-level escape room game** where the player must navigate through challenging environments by collecting objects, transporting them from one place to another, and avoiding obstacles to reach the finish line.

---

## Game Features

- **5 Unique Levels**: Each level presents new challenges and puzzles
- **Object Collection System**: Pick up and carry items to solve puzzles
- **Obstacle Avoidance**: Navigate around hazards that will send you back to the last checkpoint
- **Checkpoint System**: Progress is saved at key points throughout each level
- **Victory Screen**: Complete all objectives to win!

---

## How to Play

1. **Move** around using WASD or arrow keys
2. **Press E** to interact with objects
3. **Collect** the required items
4. **Transport** them to the designated areas
5. **Avoid** obstacles (tomatoes)
6. **Reach** the finish line to complete the level

---

## Gameplay Video

https://github.com/user-attachments/assets/0735946c-bf00-4f41-95df-c14a5038de22

---

## Built With

- **Unity** (Version 6.3 LTS)
- **C#** for scripting
- **SimpleAssets** for character controller
- [Assets for environment](https://assetstore.unity.com/packages/3d/environments/low-poly-environment-park-242702)
- [Assets for the characters](https://assetstore.unity.com/packages/3d/characters/animals/little-friends-cartoon-animals-lite-262505)
- [Assets for the food](https://assetstore.unity.com/packages/3d/props/food/food-pack-free-demo-225294)
- [Enemies and Animations](https://www.mixamo.com/)

---

## Enemies 
The enemies are located in the Scenes folder with the name “Enemies.”

### Enemy 1 — Patrol & Salsa Dancer
This enemy patrols between a set of predefined points. When the player enters its vision range (defined by a detection distance and a field of view angle), the enemy stops and breaks into a salsa dance. Once the player moves out of range, it resumes patrolling.

https://github.com/user-attachments/assets/a8f2c779-69ef-4779-9f88-8148abe23d69

### Enemy 2 — Shy Runner
This enemy stands idle until the player gets too close. Once the player enters its detection radius, it flees in the opposite direction and stops at a safe distance. If the player approaches again, it runs away once more.

https://github.com/user-attachments/assets/3ab8d7e9-b723-47f9-a861-2364d0d8090e

### Enemy 3 — Chaser & Attacker
This enemy stands idle until the player enters its field of view. Once detected, it chases the player. When close enough, it stops and performs a melee attack. If the player escapes its range, it returns to idle.

https://github.com/user-attachments/assets/28597aad-83a1-4b31-ac96-0496eabd15b4

---

## Author

**Madeline Nahomy Castro Morales**  
*Video Game Programming Course - [2026]*

---

## License

This project was created for educational purposes.

---
