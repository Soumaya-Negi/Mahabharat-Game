# Mahabharat Game  

A 2D action-adventure game based on the **Mahabharat** universe.  
Built in **Unity (C#)**, this project focuses on class-based character abilities, enemy AI, and environmental interaction systems.  

---

## 🎮 Overview  
Players can choose among different **Pandavas**, each with unique combat abilities and gameplay styles.  
The current build includes:
- **Bheem** – Melee-based brawler with strong punches and knockback attacks.  
- **Arjun** – Ranged fighter using arrows and projectiles.  

Enemies pursue and attack the player, while interactive terrain elements respond only to the correct Pandav class.

---

## 🧩 Features  
- Character selection and persistent data system.  
- Player health and damage system.  
- Enemy health, movement, and knockback mechanics.  
- Projectile-based ranged combat.  
- Interactable terrain objects linked to specific characters.  
- Enemy spawner with adjustable limits.  

---

## ⚙️ Scripts Overview  
| Script | Purpose |
|--------|----------|
| `PlayerMovement.cs` | Handles movement, attack logic, and class-based abilities. |
| `Arrow.cs` | Controls projectile behavior and damage. |
| `Enemy.cs` / `EnemyHealth.cs` | Manage enemy health and death. |
| `EnemyFollow.cs` | Enables enemy pathing toward the player. |
| `EnemySpawner.cs` | Spawns enemies periodically with configurable limits. |
| `PlayerHealth.cs` | Manages player health, healing, and death logic. |
| `CharacterSelectManager.cs` / `CharacterSelectUI.cs` | Handle Pandav selection and UI visuals. |
| `TerrainInteractable.cs` | Defines objects interactable only by specific Pandavs. |
| `GameData.cs` | Stores selected Pandav data across scenes. |

---

## 🛠️ Tech Stack  
- **Engine:** Unity 2022+  
- **Language:** C#  
- **Tools:** Visual Studio, GitHub, Itch.io  

---

## 📁 Repository Purpose  
This repository contains only the **C# code and scene files** — art, audio, and large assets are excluded.  
Used as a **portfolio project** to demonstrate gameplay systems and clean Unity scripting.  

---

## 🔗 Links  
- **Playable Builds:** [Itch.io Profile](https://soumaya-neqi.itch.io)  
- **LinkedIn:** [Soumaya Negi](https://www.linkedin.com/in/soumaya-neqi-2046a131a/)  

---

## 📜 License  
This project is shared for learning and demonstration.  
Not for commercial use.
