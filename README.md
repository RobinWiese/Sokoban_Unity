# Sokoban_Unity
**Technical High School Thesis (Facharbeit) | Grade: A-**

## Description
This project is a classic Sokoban implementation developed in **C#** using the **Unity Engine**. It was created as part of my high school thesis to demonstrate fundamental software engineering principles.

## Technical Highlights
* **Custom Level Loader:** Parsed string-based level data into 2D grid structures.
* **State Management:** Implemented centralized handling of core game status (Pause, Victory, Gameplay) to control flow.
* **Collision & Logic:** Developed a grid-based movement system with deterministic collision checks for player, crate, and wall interactions

## Tech Stack
* **Engine:** Unity
* **Language:** C#
* **Architecture:** Static state variables and dictionary-based tracking of dynamic game objects

## Source code
**Assets/Sokoban/scripts**
**Main behaviour is found in:**
*GridManager.cs
*PlayerController.cs
*LevelLoader.cs
*(WebGLLevel.cs for visualization of text based level storage)
