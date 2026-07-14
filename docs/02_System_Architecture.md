# 02 - Architecture du système

---

# 1. Introduction

L'objectif de cette documentation est de présenter l'architecture globale du Digital Twin développé pour la plateforme Smart Factory Connected (SFC).

Le système repose sur une architecture modulaire séparant clairement les composants physiques, les mécanismes de communication, les traitements logiciels et l'environnement immersif.

Cette séparation permet de :

- simplifier le développement ;
- faciliter la maintenance ;
- rendre le système évolutif ;
- permettre l'ajout futur de nouvelles machines ou de nouveaux scénarios sans modifier l'ensemble de l'architecture.

---

# 2. Vue d'ensemble

Le Digital Twin est organisé selon quatre couches principales :

1. Couche physique
2. Couche de communication
3. Couche virtuelle
4. Couche de visualisation

Chaque couche possède un rôle spécifique et communique avec les autres à travers des interfaces bien définies.

> **Figure 1 — Architecture générale du système**

<p align="center">
  <img src="./Figures/HESTIM_logo.png" width="300">
</p>
---

# 3. Couche physique

La couche physique correspond à l'ensemble des équipements industriels constituant la Smart Factory Connected.

Elle comprend notamment :

- Machine d'extrusion-soufflage
- Convoyeurs
- Robots manipulateurs
- Machine de remplissage
- Poste de bouchonnage
- Poste d'étiquetage
- Contrôle qualité
- Conditionnement
- Zone de stockage

Ces équipements produisent les informations qui seront progressivement intégrées au Digital Twin.

> **Figure 2 — Photo annotée de la Smart Factory**

---

# 4. Couche d'acquisition

Cette couche est responsable de la récupération des informations provenant de la mini-usine.

Dans la version actuelle du projet, l'acquisition est réalisée grâce à une carte **ESP32** connectée à certains équipements.

L'ESP32 collecte les données disponibles puis les transmet au serveur FastAPI via le réseau Wi-Fi.

L'utilisation de l'ESP32 présente plusieurs avantages :

- faible coût ;
- facilité de programmation ;
- connectivité Wi-Fi native ;
- intégration simple avec des capteurs industriels.

> **Figure 3 — ESP32 connecté à la Smart Factory**

---

# 5. Couche de communication

La couche de communication constitue le cœur de l'architecture.

Elle repose sur un serveur développé avec **FastAPI**.

Ses principales responsabilités sont :

- recevoir les données provenant des ESP32 ;
- stocker temporairement les états des machines ;
- diffuser les nouvelles informations ;
- servir d'intermédiaire entre la Smart Factory et Unity.

Cette approche permet de découpler complètement les applications clientes de la couche matérielle.

Le serveur communique :

- avec les ESP32 via HTTP POST ;
- avec Unity via WebSocket.

Cette architecture facilite également l'ajout futur de plusieurs clients simultanés.

> **Figure 4 — Flux de communication**

```
ESP32
    │ HTTP POST
    ▼
FastAPI
    │
    ├──── WebSocket ───► Unity
    │
    ├──── REST API
    │
    └──── Future Dashboard
```

---

# 6. Couche virtuelle

Cette couche correspond au Digital Twin développé sous Unity Engine 6.

Elle regroupe :

- les modèles 3D ;
- les animations ;
- la logique des machines ;
- les interactions utilisateur ;
- les scénarios pédagogiques ;
- les interfaces immersives.

Unity ne pilote pas directement les équipements industriels.

Son rôle est uniquement de :

- reproduire leur fonctionnement ;
- recevoir les informations transmises par FastAPI ;
- mettre à jour la représentation virtuelle.

Cette séparation garantit une architecture robuste et facilement extensible.

> **Figure 5 — Capture d'écran de la scène Unity**

---

# 7. Couche de visualisation

La couche de visualisation permet aux utilisateurs d'interagir avec le Digital Twin.

Elle repose actuellement sur :

- Meta Quest 3
- Contrôleurs VR
- Interfaces utilisateur immersives

L'utilisateur peut :

- se déplacer dans la Smart Factory ;
- interagir avec certains équipements ;
- suivre les scénarios pédagogiques ;
- consulter les informations de supervision.

> **Figure 6 — Utilisateur dans l'environnement VR**

---

# 8. Flux des données

Le cheminement des informations est résumé ci-dessous.

```
Machine industrielle

        │

Capteur

        │

ESP32

        │

HTTP

        │

FastAPI

        │

WebSocket

        │

Unity

        │

Interface VR

        │

Utilisateur
```

Chaque composant possède une responsabilité unique, ce qui facilite les évolutions futures.

---

# 9. Choix architecturaux

Plusieurs choix de conception ont été retenus.

## Pourquoi FastAPI ?

- Léger
- Rapide
- Asynchrone
- Compatible WebSocket
- Documentation automatique

## Pourquoi Unity ?

- Excellent support XR
- Moteur temps réel
- Large communauté
- Compatible Meta Quest

## Pourquoi ESP32 ?

- Wi-Fi intégré
- Faible coût
- Facilité de programmation
- Nombreuses interfaces matérielles

---

# 10. Évolutions prévues

L'architecture a été pensée pour évoluer progressivement.

Les principales améliorations prévues sont :

- Synchronisation complète de toutes les machines.
- Ajout de nouveaux ESP32.
- Communication avec des automates industriels (PLC).
- Tableau de bord Web.
- Mode multijoueur.
- Base de données pour l'historique.
- Authentification des utilisateurs.
- Analyse avancée des données.

---

# 11. Conclusion

L'architecture proposée permet de séparer clairement les différents niveaux du système tout en garantissant une communication fiable entre la Smart Factory et son Digital Twin.

Cette organisation facilite la maintenance, améliore l'évolutivité de la plateforme et constitue une base solide pour les futurs développements, notamment l'intégration de nouveaux scénarios pédagogiques, l'extension de la supervision industrielle et le déploiement du mode collaboratif.