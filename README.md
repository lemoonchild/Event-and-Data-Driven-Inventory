# Event-Driven & Data-Driven Pickup Lab 

This laboratory demonstrates the use of **Event-Driven Design** and **Data-Driven Design** in Unity 6, implemented through a city-themed pickup system.

---

## Design Patterns Used

### Data-Driven Design
Each pickup is defined by a **ScriptableObject** (`PickUpData`) that holds its data independently from the scene. This means pickup behavior and appearance can be modified directly from the Unity Inspector without touching any code.

```
PickUpData (ScriptableObject)
├── pickUpName       → Display name shown in the UI
├── icon             → Sprite shown in the inventory
├── addsToInventory  → Whether it goes to inventory or score
└── scoreValue       → Points added if it's a score pickup
```

### Event-Driven Design
Pickups communicate with the rest of the systems through **GameEventSO** assets (also ScriptableObjects). When a pickup is collected, it raises an event. Any system that needs to react simply subscribes to that event via a **GameEventListener** component — no direct references between systems needed.

```
Player touches Pickup
      ↓
PickUp.cs calls GameEventSO.Raise()
      ↓
GameEventSO notifies all registered GameEventListeners
      ↓
Each Listener invokes its Response (speed boost, sound plays, etc.)
```

This keeps all systems **fully decoupled** — the pickup doesn't know or care what happens after it's collected.

---

## Pickup Items

### Piggy Bank
Adds **+100 points** to the score displayed on the UI. Does not appear in the inventory.

---

### Smiley Face
Activates a **point light** in the scene.

---

### Hat
Triggers a **sound effect** when collected, played via AudioSource.

---

### Crown
Activates a **speed boost** on the player character, temporarily increasing movement speed for 5 seconds.


---

### Wheel
Triggers a **camera shake** effect using Cinemachine's noise system.

