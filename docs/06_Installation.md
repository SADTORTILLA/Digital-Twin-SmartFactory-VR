# 06 - Guide d'installation

---

# 1. Introduction

Ce document décrit les étapes nécessaires pour installer, configurer et exécuter le projet **Digital Twin Smart Factory VR**.

Son objectif est de permettre à un nouveau développeur ou stagiaire de reproduire facilement l'environnement de développement utilisé durant le projet et de comprendre les différentes étapes nécessaires avant de commencer à travailler.

Pour mieux comprendre l'architecture globale du projet, il est recommandé de consulter au préalable :

- `docs/01_Project_Overview.md`
- `docs/02_System_Architecture.md`

---

# 2. Configuration matérielle recommandée

Le projet a été développé et testé avec la configuration suivante.

| Composant | Configuration recommandée |
|------------|---------------------------|
| Système d'exploitation | Windows 10 / Windows 11 |
| Processeur | Intel Core i7 ou équivalent |
| Mémoire | 16 Go RAM minimum (32 Go recommandés) |
| Carte graphique | NVIDIA RTX 3060 ou supérieure |
| Casque VR | Meta Quest 3 |
| Connexion | Wi-Fi local |
| Carte IoT | ESP32 |

Une configuration plus performante est recommandée afin d'assurer un fonctionnement fluide de Unity et du casque VR.

---

# 3. Logiciels nécessaires

Avant toute installation, vérifier que les logiciels suivants sont disponibles.

| Logiciel | Version recommandée |
|----------|---------------------|
| Unity Hub | Dernière version |
| Unity Engine | Unity 6 |
| Visual Studio | 2022 |
| Python | 3.9 ou supérieur |
| Arduino IDE | Dernière version |
| Git | Dernière version |

Les versions utilisées pendant le développement sont indiquées dans le dépôt GitHub lorsque cela est nécessaire.

---

# 4. Cloner le dépôt

Cloner le dépôt GitHub :

```bash
git clone https://github.com/SADTORTILLA/Digital-Twin-SmartFactory-VR.git
```

ou télécharger directement l'archive ZIP.

L'organisation générale du dépôt est la suivante :

```text
Digital-Twin-SmartFactory-VR/
│
├── Unity/
├── FastAPI/
├── ESP32/
├── docs/
├── README.md
└── LICENSE
```

Pour une description détaillée de chaque dossier, consulter :

`docs/01_Project_Overview.md`

---

# 5. Installation du projet Unity

## 5.1 Installation de Unity

Installer **Unity Hub**, puis installer **Unity 6** avec les modules suivants :

- Android Build Support
- Android SDK & NDK
- OpenJDK
- OpenXR Support

Documentation officielle :

- https://unity.com/download
- https://learn.unity.com/
- https://docs.unity3d.com/

---

## 5.2 Ouverture du projet

1. Ouvrir Unity Hub.
2. Sélectionner **Add Project**.
3. Choisir le dossier **Unity/** du dépôt.
4. Attendre l'importation complète des ressources.

Lors du premier lancement, Unity peut prendre plusieurs minutes pour générer la bibliothèque (`Library`).

---

## 5.3 Vérification des packages

Le projet utilise principalement les packages suivants :

- XR Interaction Toolkit
- OpenXR Plugin
- Input System
- TextMeshPro
- Netcode for GameObjects *(prévu pour les développements futurs)*

Les packages peuvent être installés ou mis à jour depuis le **Package Manager**.

Documentation utile :

- XR Interaction Toolkit :
  https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit

- OpenXR :
  https://docs.unity3d.com/Packages/com.unity.xr.openxr

Pour comprendre l'organisation interne du projet Unity, consulter :

`docs/03_Unity_Architecture.md`

---

## 5.4 Ouverture de la scène principale

Les scènes sont disponibles dans :

```
Assets/
    Scenes/
```

Ouvrir :

```
MAIN_scene
```

ou toute autre scène correspondant au scénario à tester.

---

# 6. Configuration du Meta Quest 3

Le projet est compatible avec le casque **Meta Quest 3**.

Trois modes de développement sont possibles :

- Quest Link (USB)
- Air Link (Wi-Fi)
- Build Android (APK)

Pour configurer correctement le casque, consulter :

- Meta Quest Developer Documentation
- Unity OpenXR Documentation

Avant tout test VR, vérifier que :

- OpenXR est activé ;
- le casque est reconnu par Unity ;
- les contrôleurs sont correctement détectés.

---

# 7. Installation du serveur FastAPI

Se placer dans le dossier :

```bash
cd FastAPI
```

Créer un environnement virtuel :

```bash
python -m venv .venv
```

Activer l'environnement :

Windows :

```bash
.venv\Scripts\activate
```

Installer les dépendances :

```bash
pip install -r requirements.txt
```

Lancer le serveur :

```bash
uvicorn main:app --reload
```

Le serveur sera disponible à :

```
http://localhost:8000
```

La documentation interactive est accessible à :

```
http://localhost:8000/docs
```

Pour comprendre le fonctionnement du backend, consulter :

`docs/04_FastAPI.md`

Documentation officielle :

- https://fastapi.tiangolo.com/
- https://www.uvicorn.org/

---

# 8. Configuration de l'ESP32

Ouvrir le projet dans Arduino IDE.

Modifier les paramètres suivants :

```cpp
const char* ssid = "...";
const char* password = "...";
const char* server_ip = "...";
```

Compiler puis téléverser le programme.

Le serveur FastAPI doit être accessible sur le même réseau Wi-Fi que l'ESP32.

Pour plus de détails sur le firmware et son fonctionnement :

`docs/05_ESP32.md`

Documentation utile :

- https://docs.espressif.com/projects/arduino-esp32/
- https://github.com/espressif/arduino-esp32

---

# 9. Vérification de la communication

Une fois tous les composants démarrés, la chaîne de communication est la suivante :

```
Mini-usine
      │
      ▼
ESP32
      │
      ▼
FastAPI
      │
      ▼
Unity
```

Les données envoyées par l'ESP32 doivent être automatiquement reçues par FastAPI puis affichées dans l'environnement immersif.

En cas de problème, consulter :

`docs/09_Troubleshooting.md`

---

# 10. Premier lancement

Ordre recommandé :

1. Démarrer FastAPI.
2. Alimenter l'ESP32.
3. Vérifier que les données sont reçues.
4. Ouvrir Unity.
5. Charger la scène principale.
6. Connecter le Meta Quest 3.
7. Lancer le scénario pédagogique souhaité.

Les scénarios disponibles sont décrits dans :

`docs/07_Educational_Scenarios.md`

---

# 11. Vérification de l'installation

Si l'installation est correcte :

- ✅ Unity démarre sans erreur.
- ✅ Le projet compile correctement.
- ✅ Le casque Meta Quest est reconnu.
- ✅ FastAPI fonctionne.
- ✅ L'ESP32 transmet les données.
- ✅ Unity reçoit les données temps réel.
- ✅ Les scénarios VR sont opérationnels.

---

# 12. Ressources recommandées

Avant de modifier une partie du projet, il est fortement recommandé de consulter la documentation officielle des technologies utilisées.

## Unity

- Unity Documentation
- Unity Learn
- XR Interaction Toolkit Documentation
- OpenXR Documentation

## FastAPI

- Documentation officielle FastAPI
- Documentation Uvicorn

## ESP32

- Espressif Documentation
- Arduino ESP32 GitHub

## Git

- Git Documentation
- GitHub Documentation

Ces ressources permettent de mieux comprendre les bonnes pratiques et facilitent la maintenance du projet.

---

# 13. Documents complémentaires

Le dossier `docs/` contient une documentation détaillée de chaque partie du projet.

- `docs/01_Project_Overview.md`
- `docs/02_System_Architecture.md`
- `docs/03_Unity_Architecture.md`
- `docs/04_FastAPI.md`
- `docs/05_ESP32.md`
- `docs/06_Installation.md`
- `docs/07_Educational_Scenarios.md`
- `docs/08_Roadmap.md`
- `docs/09_Troubleshooting.md`
- `docs/10_Research.md`
- `docs/11_Guide_For_Next_Intern.md`

Il est recommandé de parcourir ces documents avant d'apporter des modifications importantes au projet.

---

# 14. Remarques

Le projet a été conçu selon une architecture modulaire afin de faciliter son évolution.

Les développements futurs incluent notamment :

- l'extension de la supervision temps réel à l'ensemble de la mini-usine ;
- l'intégration complète du mode multijoueur ;
- l'ajout de nouveaux scénarios pédagogiques ;
- l'amélioration des interfaces utilisateur immersives ;
- l'intégration de nouvelles données industrielles provenant de la Smart Factory.

Toutes ces évolutions pourront être réalisées sans remettre en cause l'architecture générale du système présentée dans cette documentation.