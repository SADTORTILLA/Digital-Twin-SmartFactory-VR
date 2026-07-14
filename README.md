# Digital Twin Immersif d'une Smart Factory

<div align="center">
  <img src="figures/HESTIM_logo.png" alt="HESTIM Logo">
</div>

> Développement d'un **Digital Twin immersif** d'une ligne de production de flacons en PEHD destiné à la **formation immersive**, à la **supervision industrielle** et à la **recherche en Industrie 4.0**, réalisé dans le cadre de la plateforme **HESTIM Smart Factory Connected (SFC)**.

<p align="center">

![Unity](https://img.shields.io/badge/Unity-6-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-Programming-blue)
![Meta Quest](https://img.shields.io/badge/Meta%20Quest%203-VR-blueviolet)
![FastAPI](https://img.shields.io/badge/FastAPI-Backend-green?logo=fastapi)
![ESP32](https://img.shields.io/badge/ESP32-IoT-red)
![Status](https://img.shields.io/badge/Status-In_Development-orange)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

</p>

![SFC Virtual Environment](figures/3d_assembled_envirement_of_sfc.png)

---

## 📖 Présentation

Ce dépôt contient l'ensemble des développements réalisés durant un stage de fin d'études portant sur la conception d'un **Digital Twin immersif** d'une ligne de production de flacons en PEHD.

Le projet a été développé au sein du laboratoire **H-FAB** de **HESTIM**, dans le cadre de la plateforme **Smart Factory Connected (SFC)**.

L'objectif est de proposer un environnement de **Réalité Virtuelle (VR)** reproduisant fidèlement le fonctionnement d'une mini-usine industrielle afin de :

- former des étudiants et opérateurs dans un environnement immersif ;
- expérimenter des scénarios pédagogiques interactifs ;
- superviser certaines données provenant du système physique en temps réel ;
- servir de plateforme expérimentale pour des travaux de recherche en **Industrie 4.0**, **Digital Twin** et **formation immersive**.

Le projet combine plusieurs domaines technologiques :

- 🏭 Smart Factory
- 🧩 Digital Twin
- 🥽 Réalité Virtuelle
- 🌐 Internet des Objets (IoT)
- 🔄 Communication temps réel
- 🎓 Formation immersive
- 📊 Supervision industrielle

---

> **⚠️ Important**
>
> Ce dépôt ne constitue pas uniquement le code source du projet.
>
> Il a été conçu comme une **documentation technique complète** et un **support de transfert de connaissances** destiné aux futurs stagiaires, étudiants et chercheurs amenés à poursuivre le développement du Digital Twin de la Smart Factory de HESTIM.
>
> Avant toute modification du projet, il est fortement recommandé de consulter la documentation disponible dans le dossier **`docs/`**.

# 📚 Documentation

Afin de faciliter la prise en main du projet et d'assurer une continuité de son développement, une documentation technique détaillée est disponible dans le dossier **`docs/`**.

Chaque document répond à un objectif précis et il est recommandé de les consulter dans l'ordre indiqué ci-dessous.

| Document | Description |
|----------|-------------|
| 📄 [`docs/01_Project_Overview.md`](docs/01_Project_Overview.md) | Présentation générale du projet, contexte, objectifs et fonctionnement global. |
| 📄 [`docs/02_System_Architecture.md`](docs/02_System_Architecture.md) | Architecture globale du système, flux de données et interactions entre les composants matériels et logiciels. |
| 📄 [`docs/03_Unity_Architecture.md`](docs/03_Unity_Architecture.md) | Organisation du projet Unity, structure des scènes, scripts, prefabs, interactions VR et architecture logicielle. |
| 📄 [`docs/04_FastAPI.md`](docs/04_FastAPI.md) | Documentation du serveur FastAPI, architecture du backend, API REST/WebSocket et communication avec Unity. |
| 📄 [`docs/05_ESP32.md`](docs/05_ESP32.md) | Fonctionnement de l'ESP32, acquisition des données, configuration matérielle et communication réseau. |
| 📄 [`docs/06_Installation.md`](docs/06_Installation.md) | Guide complet d'installation de l'environnement de développement et de mise en route du projet. |
| 📄 [`docs/07_Educational_Scenarios.md`](docs/07_Educational_Scenarios.md) | Description des scénarios pédagogiques implémentés, des objectifs d'apprentissage et des scénarios prévus. |
| 📄 [`docs/08_Roadmap.md`](docs/08_Roadmap.md) | État d'avancement du projet, fonctionnalités restantes, améliorations envisagées et plan de développement. |
| 📄 [`docs/09_Troubleshooting.md`](docs/09_Troubleshooting.md) | Résolution des problèmes les plus fréquents rencontrés lors de l'installation ou du développement. |
| 📄 [`docs/10_Research.md`](docs/10_Research.md) | Présentation des travaux de recherche associés au projet, des expérimentations et des publications scientifiques. |
| 📄 [`docs/11_Guide_For_Next_Intern.md`](docs/11_Guide_For_Next_Intern.md) | Guide de reprise du projet destiné au prochain stagiaire, avec les recommandations pour poursuivre le développement. |

---

## 📖 Ordre de lecture recommandé

Pour une prise en main efficace, il est conseillé de suivre l'ordre suivant :

1. `README.md`
2. `docs/01_Project_Overview.md`
3. `docs/02_System_Architecture.md`
4. `docs/03_Unity_Architecture.md`
5. `docs/06_Installation.md`
6. `docs/07_Educational_Scenarios.md`
7. `docs/08_Roadmap.md`
8. `docs/11_Guide_For_Next_Intern.md`

> 💡 **Conseil :** Avant de commencer le développement, prenez le temps de comprendre l'architecture générale du système. Cette étape vous permettra de mieux appréhender les interactions entre Unity, FastAPI, l'ESP32 et la Smart Factory, et facilitera l'ajout de nouvelles fonctionnalités.

# 🏭 Vue d'ensemble du projet

Ce projet a été développé dans le cadre d'un stage de fin d'études réalisé au sein du laboratoire **H-FAB** de **HESTIM Engineering & Business School**, sur la plateforme **Smart Factory Connected (SFC)**.

Il consiste à concevoir un **Digital Twin immersif** d'une ligne de production de flacons en **PEHD (Polyéthylène Haute Densité)**, en reproduisant fidèlement l'environnement industriel dans un espace de Réalité Virtuelle (VR).

L'objectif principal est de proposer une plateforme immersive permettant à la fois :

- la **formation des étudiants et des opérateurs** à travers des scénarios pédagogiques interactifs ;
- la **visualisation de données provenant de la ligne de production réelle** grâce à une architecture de communication temps réel ;
- l'**expérimentation de nouveaux scénarios industriels** dans un environnement sécurisé ;
- le développement d'une plateforme évolutive pouvant servir de support à de futurs travaux de recherche sur les **Digital Twins**, l'**Industrie 4.0** et les **technologies immersives**.

Contrairement à une simple simulation 3D, ce projet vise à établir un lien entre une installation physique et sa représentation virtuelle grâce à une chaîne de communication composée d'un **ESP32**, d'un serveur **FastAPI** et d'une application développée sous **Unity Engine 6**.

À ce stade du développement, une première synchronisation temps réel a été mise en œuvre afin de transmettre certaines informations issues de la mini-usine vers le Digital Twin. Cette architecture a été conçue pour être progressivement enrichie avec de nouvelles données et de nouvelles fonctionnalités.

Le projet constitue également un support expérimental pour plusieurs travaux de recherche portant sur l'apprentissage immersif, l'évaluation des performances des utilisateurs et l'intégration des technologies XR dans les environnements industriels.

---

## 🎯 Fonctionnalités principales

Le projet comprend actuellement les fonctionnalités suivantes :

- ✅ Modélisation 3D complète de la Smart Factory.
- ✅ Intégration des équipements industriels dans Unity.
- ✅ Développement d'un environnement immersif compatible avec **Meta Quest 3**.
- ✅ Simulation du fonctionnement de la ligne de production.
- ✅ Architecture de communication **ESP32 → FastAPI → Unity**.
- ✅ Visualisation temps réel de données provenant du système physique.
- ✅ Scénario pédagogique d'étiquetage chronométré.
- ✅ Collecte de données expérimentales pour l'évaluation des utilisateurs.

Les développements futurs prévoient notamment :

- 🚧 Synchronisation complète de la ligne de production.
- 🚧 Intégration d'un mode multijoueur collaboratif.
- 🚧 Développement de nouveaux scénarios pédagogiques.
- 🚧 Amélioration des interfaces de supervision.
- 🚧 Extension du Digital Twin vers une plateforme collaborative complète.

---

## 🛠️ Technologies utilisées

| Domaine | Technologies |
|----------|--------------|
| Modélisation CAO | CATIA V5, FreeCAD |
| Modélisation 3D | Blender |
| Développement VR | Unity Engine 6 |
| Langage | C# |
| Casque VR | Meta Quest 3 |
| Backend | FastAPI |
| Communication | HTTP, WebSocket |
| IoT | ESP32 |
| Gestion de versions | Git & GitHub |

> 📖 Pour une description détaillée de l'architecture et des technologies employées, consultez :
>
> - [`docs/02_System_Architecture.md`](docs/02_System_Architecture.md)
> - [`docs/03_Unity_Architecture.md`](docs/03_Unity_Architecture.md)
> - [`docs/04_FastAPI.md`](docs/04_FastAPI.md)
> - [`docs/05_ESP32.md`](docs/05_ESP32.md)

# 🎯 Objectifs du projet

Le développement de ce Digital Twin s'inscrit dans une démarche visant à rapprocher les environnements industriels réels des technologies immersives afin de proposer une plateforme de formation, de supervision et d'expérimentation adaptée aux enjeux de l'Industrie 4.0.

Le projet répond à plusieurs besoins identifiés au sein de la Smart Factory Connected (SFC), notamment la nécessité de disposer d'un environnement permettant de former les étudiants sans immobiliser les équipements industriels, de tester de nouveaux scénarios pédagogiques et de préparer l'intégration progressive d'un véritable Digital Twin connecté.

---

## Objectif général

Concevoir et développer un **Digital Twin immersif** de la ligne de production de flacons en PEHD de la Smart Factory Connected de HESTIM, permettant de reproduire son fonctionnement dans un environnement de Réalité Virtuelle tout en intégrant une première architecture de supervision connectée.

---

## Objectifs spécifiques

Le projet se décompose en plusieurs objectifs techniques.

### 🏭 Reproduire fidèlement la Smart Factory

- Modéliser l'ensemble des équipements industriels.
- Reconstituer l'environnement réel de la mini-usine.
- Optimiser les modèles 3D pour une utilisation en Réalité Virtuelle.

---

### 🥽 Développer un environnement immersif

- Intégrer les modèles dans Unity.
- Développer les interactions utilisateur.
- Simuler le fonctionnement de chaque poste de travail.
- Garantir une expérience fluide sur Meta Quest 3.

---

### 🔄 Mettre en place une supervision connectée

Développer une architecture permettant de transmettre des informations issues de la mini-usine vers le Digital Twin grâce à :

- un ESP32 pour l'acquisition des données ;
- un serveur FastAPI assurant les échanges ;
- une communication HTTP/WebSocket ;
- une visualisation en temps réel dans Unity.

Cette architecture constitue la première étape vers un Digital Twin entièrement synchronisé.

---

### 🎓 Développer des scénarios pédagogiques

Créer des scénarios immersifs permettant :

- l'apprentissage des procédures industrielles ;
- l'évaluation des performances des utilisateurs ;
- l'analyse des erreurs de manipulation ;
- la collecte de données expérimentales destinées aux travaux de recherche.

Le premier scénario implémenté concerne une opération chronométrée d'étiquetage.

---

### 🔬 Fournir une plateforme expérimentale

Le projet sert également de support pour :

- les expérimentations en Réalité Virtuelle ;
- les recherches sur les Digital Twins industriels ;
- l'analyse de l'apprentissage immersif ;
- l'évaluation de nouvelles approches pédagogiques.

---

### 🚀 Préparer les développements futurs

L'architecture a été conçue afin de faciliter l'intégration de nouvelles fonctionnalités, notamment :

- la synchronisation de nouveaux équipements industriels ;
- le développement de scénarios pédagogiques supplémentaires ;
- l'intégration d'un mode multijoueur collaboratif ;
- l'amélioration des interfaces de supervision ;
- l'extension vers un Digital Twin industriel plus complet.

---

## 📌 Périmètre actuel du projet

À la date de cette version, les développements portent principalement sur :

- la modélisation de la Smart Factory ;
- l'environnement immersif sous Unity ;
- la logique de fonctionnement de la ligne de production ;
- la communication ESP32 → FastAPI → Unity ;
- un premier scénario pédagogique opérationnel ;
- une première démonstration de supervision temps réel.

Les fonctionnalités collaboratives et certaines extensions de supervision sont encore en cours de développement et font partie de la feuille de route présentée dans [`docs/08_Roadmap.md`](docs/08_Roadmap.md).

> 📖 Pour une description détaillée des scénarios pédagogiques et des perspectives d'évolution, consultez :
>
> - [`docs/07_Educational_Scenarios.md`](docs/07_Educational_Scenarios.md)
> - [`docs/08_Roadmap.md`](docs/08_Roadmap.md)
> - [`docs/10_Research.md`](docs/10_Research.md)

# 🏗️ Architecture générale

Le projet repose sur une architecture modulaire permettant de séparer les différentes responsabilités du système tout en facilitant son évolution.

Le Digital Twin est composé de quatre couches principales :

- **La couche physique**, correspondant à la Smart Factory Connected de HESTIM.
- **La couche d'acquisition**, assurant la récupération des données issues des équipements industriels.
- **La couche de communication**, responsable du transport et de la distribution des données.
- **La couche immersive**, permettant la visualisation, l'interaction et l'exécution des scénarios pédagogiques en Réalité Virtuelle.

Le schéma suivant résume l'architecture globale du système.

```text
                    Smart Factory Connected
                           │
                           ▼
                     ESP32 (IoT Gateway)
                           │
                     Réseau WiFi
                           │
                           ▼
                     Serveur FastAPI
                  (API + WebSocket)
                           │
             ┌─────────────┴─────────────┐
             │                           │
             ▼                           ▼
      Unity Engine 6             Tableau de bord
      Digital Twin VR             (Future évolution)
             │
             ▼
        Meta Quest 3
```

Chaque composant possède un rôle spécifique :

| Composant | Rôle |
|-----------|------|
| **Smart Factory Connected** | Production physique des flacons en PEHD. |
| **ESP32** | Acquisition des données provenant des équipements industriels. |
| **FastAPI** | Centralisation des échanges de données entre les équipements et le Digital Twin. |
| **Unity Engine 6** | Simulation immersive, logique métier, scénarios pédagogiques et visualisation des données. |
| **Meta Quest 3** | Interaction immersive avec la Smart Factory virtuelle. |

L'architecture a été conçue de manière modulaire afin de faciliter l'ajout de nouveaux équipements, de nouveaux capteurs, de nouvelles interfaces de supervision ainsi que l'intégration future d'un mode multijoueur collaboratif.

> 📖 Les détails techniques de cette architecture sont disponibles dans :
>
> - [`docs/02_System_Architecture.md`](docs/02_System_Architecture.md)
> - [`docs/03_Unity_Architecture.md`](docs/03_Unity_Architecture.md)
> - [`docs/04_FastAPI.md`](docs/04_FastAPI.md)
> - [`docs/05_ESP32.md`](docs/05_ESP32.md)

# 🚀 Démarrage rapide

Cette section présente les étapes essentielles permettant d'exécuter rapidement le projet.

Pour une installation détaillée, consultez [`docs/06_Installation.md`](docs/06_Installation.md).

## Prérequis

Avant de commencer, assurez-vous de disposer des éléments suivants :

- Unity Engine 6
- Meta Quest 3
- Git
- Python 3.11 ou supérieur
- Visual Studio 2022 (ou Visual Studio Code)
- Blender (optionnel)
- FreeCAD (optionnel)

---

## 1. Cloner le dépôt

```bash
git clone https://github.com/<username>/Digital-Twin-SmartFactory-VR.git
```

---

## 2. Ouvrir le projet Unity

- Ouvrir **Unity Hub**.
- Ajouter le dossier contenant le projet.
- Vérifier que tous les packages sont correctement importés.
- Ouvrir la scène principale (`MAIN_scene`).

---

## 3. Lancer le serveur FastAPI

Depuis le dossier **FastAPI** :

```bash
pip install -r requirements.txt

uvicorn main:app --host 0.0.0.0 --port 8000
```

---

## 4. Exécuter l'application

Connecter le casque **Meta Quest 3** puis lancer le projet depuis Unity.

Le Digital Twin se connectera automatiquement au serveur FastAPI afin de récupérer les données disponibles.

---

## Première découverte recommandée

Pour comprendre rapidement le fonctionnement du projet :

1. Explorer la Smart Factory virtuelle.
2. Tester le scénario **Étiquetage chronométré**.
3. Observer les données temps réel provenant de la mini-usine.
4. Consulter ensuite la documentation technique.

```

---

# 🏭 Ligne de production

La Smart Factory Connected (SFC) de HESTIM reproduit une ligne de production de flacons en PEHD à échelle réduite. Elle permet de simuler un environnement industriel réel tout en servant de support à l'enseignement, à la recherche et à l'expérimentation.

Le Digital Twin développé dans ce projet reproduit l'ensemble de cette ligne de production en Réalité Virtuelle.

Les principaux postes de travail sont :

1. Extrusion-soufflage
2. Décarottage
3. Robot manipulateur
4. Remplissage
5. Bouchonnage manuel
6. Étiquetage manuel
7. Contrôle qualité
8. Conditionnement robotisé
9. Stockage

Chaque poste possède son propre comportement, ses animations ainsi que ses interactions utilisateur lorsqu'elles sont implémentées.

> 📖 Une description détaillée des différents équipements est disponible dans
> [`docs/01_Project_Overview.md`](docs/01_Project_Overview.md).

# 🎓 Scénarios pédagogiques

Le Digital Twin est conçu comme une plateforme pédagogique permettant de développer différents scénarios de formation immersive.

### ✅ Implémenté

**Scénario d'étiquetage chronométré**

Ce scénario permet d'entraîner l'utilisateur à réaliser une opération d'étiquetage dans un environnement immersif tout en enregistrant ses performances.

Les données collectées sont utilisées dans le cadre des travaux de recherche associés au projet.

### 🚧 En développement

- Implantation des systèmes de production
- Robotisation de la ligne de production
- Systèmes de manutention (AGV)
- Modification dynamique des paramètres de production
- Mode multijoueur collaboratif

> 📖 Plus d'informations :
> [`docs/07_Educational_Scenarios.md`](docs/07_Educational_Scenarios.md)

