# 01 - Présentation du projet

---

# 1. Introduction

Ce projet a été réalisé dans le cadre d'un stage de fin d'études effectué au sein du laboratoire **H-FAB** de **HESTIM Engineering & Business School**, sur la plateforme **Smart Factory Connected (SFC)**.

Il consiste à concevoir et développer un **Digital Twin immersif** d'une ligne de production de flacons en **PEHD (Polyéthylène Haute Densité)** à l'aide des technologies de Réalité Virtuelle (VR).

L'objectif est de reproduire fidèlement le fonctionnement de la mini-usine dans un environnement virtuel interactif tout en intégrant une première architecture de supervision connectée permettant de visualiser des données issues du système physique.

Le projet constitue à la fois :

- une plateforme pédagogique destinée à la formation immersive ;
- un démonstrateur de Digital Twin connecté ;
- un support expérimental pour des travaux de recherche en Industrie 4.0.

---

# 2. Contexte

L'évolution des systèmes industriels vers les concepts de l'Industrie 4.0 conduit à une intégration croissante des technologies numériques telles que les objets connectés (IoT), les systèmes cyber-physiques, les Digital Twins et les technologies immersives.

Dans ce contexte, les établissements d'enseignement et les laboratoires de recherche cherchent à proposer des environnements permettant aux étudiants d'expérimenter ces technologies sans perturber les installations industrielles réelles.

La plateforme **Smart Factory Connected (SFC)** de HESTIM répond à cette problématique en mettant à disposition une ligne de production pédagogique reproduisant les principales étapes d'un procédé industriel automatisé.

Le présent projet s'inscrit dans cette démarche en développant une représentation virtuelle immersive de cette ligne de production capable de servir à la fois d'outil pédagogique, de plateforme de supervision et de support à la recherche.

---

# 3. Présentation de la Smart Factory Connected

La **Smart Factory Connected (SFC)** est une mini-usine pédagogique reproduisant le fonctionnement d'une ligne industrielle de fabrication de flacons en PEHD.

Elle est composée de plusieurs postes de travail automatisés et manuels reproduisant les différentes étapes du procédé de fabrication.

La ligne de production comprend notamment :

- Extrusion-soufflage ;
- Décarottage ;
- Robot manipulateur ;
- Remplissage ;
- Bouchonnage manuel ;
- Poste manuel d'étiquetage ;
- Contrôle qualité ;
- Conditionnement robotisé ;
- Zone de stockage.

L'ensemble de ces équipements a été modélisé puis intégré dans l'environnement virtuel afin de reproduire le comportement de la mini-usine avec le plus haut niveau de fidélité possible.

> **Figure 1 :** Vue générale de la Smart Factory Connected.

---

# 4. Objectifs du projet

## Objectif général

Développer un Digital Twin immersif de la Smart Factory Connected permettant de reproduire virtuellement la ligne de production tout en intégrant une première architecture de supervision temps réel.

## Objectifs spécifiques

Le projet poursuit plusieurs objectifs complémentaires :

- Modéliser l'ensemble des équipements industriels de la Smart Factory.
- Développer un environnement immersif sous Unity compatible avec le casque Meta Quest 3.
- Reproduire le fonctionnement des différents postes de travail.
- Développer des scénarios pédagogiques destinés à la formation des étudiants.
- Concevoir une architecture de communication reliant la mini-usine au Digital Twin.
- Collecter des données expérimentales pour les travaux de recherche.
- Concevoir une architecture suffisamment modulaire pour intégrer de futures évolutions.

---

# 5. Périmètre du projet

Le projet est organisé autour de trois composantes principales.

## Environnement immersif

Reconstitution virtuelle de la Smart Factory permettant l'interaction avec les différents postes de production.

## Formation immersive

Développement de scénarios pédagogiques destinés à l'apprentissage des procédures industrielles dans un environnement sécurisé.

## Supervision connectée

Mise en place d'une architecture de communication permettant de recevoir certaines données provenant de la mini-usine physique et de les visualiser dans le Digital Twin.

À ce stade du projet, la synchronisation temps réel est limitée à un premier ensemble de données servant de preuve de concept.

---

# 6. Fonctionnalités principales

Le projet intègre actuellement les fonctionnalités suivantes :

- Modélisation complète de la Smart Factory ;
- Intégration des modèles dans Unity Engine 6 ;
- Simulation du fonctionnement de la ligne de production ;
- Développement d'un environnement VR compatible Meta Quest 3 ;
- Communication ESP32 → FastAPI → Unity ;
- Visualisation de données temps réel ;
- Scénario pédagogique d'étiquetage chronométré ;
- Enregistrement des performances utilisateur ;
- Plateforme expérimentale destinée aux travaux de recherche.

---

# 7. Vue d'ensemble de la ligne de production

Le Digital Twin reproduit le flux de production suivant :

```text
Extrusion-soufflage
        │
        ▼
Décarottage
        │
        ▼
Robot manipulateur
        │
        ▼
Remplissage
        │
        ▼
Bouchonnage manuel
        │
        ▼
Étiquetage manuel
        │
        ▼
Contrôle qualité
        │
        ▼
Conditionnement robotisé
        │
        ▼
Stockage
```

Chaque poste possède ses propres modèles 3D, animations, interactions et logique de fonctionnement.

---

# 8. Technologies utilisées

| Domaine | Technologies |
|----------|--------------|
| CAO | CATIA V5 |
| Modélisation 3D | Blender, FreeCAD |
| Développement VR | Unity Engine 6 |
| Langage | C# |
| Backend | FastAPI |
| Communication | HTTP, WebSocket |
| IoT | ESP32 |
| Casque VR | Meta Quest 3 |
| Gestion de versions | Git & GitHub |

---

# 9. État actuel du projet

| Fonctionnalité | État |
|----------------|------|
| Modélisation 3D | ✅ Terminée |
| Environnement VR | ✅ Fonctionnel |
| Logique des machines | ✅ Fonctionnelle |
| Communication ESP32 | ✅ Fonctionnelle |
| Serveur FastAPI | ✅ Fonctionnel |
| Visualisation temps réel | ✅ Première version |
| Scénario pédagogique | ✅ Implémenté |
| Collecte de données | ✅ Fonctionnelle |
| Mode multijoueur | 🚧 Prévu |
| Synchronisation complète | 🚧 En développement |

---

# 10. Documentation du dépôt

L'ensemble de la documentation technique est disponible dans le dossier **docs/**.

Les documents sont organisés afin d'accompagner progressivement le lecteur dans la compréhension du projet.

- `docs/02_System_Architecture.md`
- `docs/03_Unity_Architecture.md`
- `docs/04_FastAPI.md`
- `docs/05_ESP32.md`
- `docs/06_Installation.md`
- `docs/07_Educational_Scenarios.md`
- `docs/08_Roadmap.md`
- `docs/09_Troubleshooting.md`
- `docs/10_Research.md`

---

# 11. Perspectives

L'architecture du projet a été pensée pour faciliter son évolution.

Les principales perspectives sont :

- Synchronisation complète de la Smart Factory ;
- Intégration de nouveaux capteurs industriels ;
- Communication avec des automates (PLC) ;
- Développement du mode multijoueur collaboratif ;
- Création de nouveaux scénarios pédagogiques ;
- Déploiement de tableaux de bord immersifs ;
- Exploitation de techniques d'intelligence artificielle pour l'analyse des performances et l'assistance aux opérateurs.