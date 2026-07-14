# 08 - Feuille de route (Roadmap)

---

# 1. Introduction

Ce document présente l'évolution prévue du projet **Digital Twin Smart Factory VR**.

L'objectif est de fournir une vision claire des développements futurs afin de faciliter la reprise du projet par un nouveau développeur ou stagiaire. Les fonctionnalités sont classées selon leur niveau de priorité et leur impact sur la plateforme.

L'ensemble des évolutions proposées respecte l'architecture modulaire actuelle du projet, ce qui permet leur intégration progressive sans remettre en cause les composants existants.

---

# 2. État actuel du projet

À ce jour, les éléments suivants sont entièrement fonctionnels :

## Environnement immersif

- ✔ Modélisation complète de la mini-usine
- ✔ Intégration dans Unity
- ✔ Navigation VR avec Meta Quest 3
- ✔ Interfaces utilisateur immersives

## Simulation industrielle

- ✔ Logique des postes de production
- ✔ Animations des convoyeurs
- ✔ Robot manipulateur
- ✔ Poste manuel d'étiquetage

## Supervision connectée

- ✔ Communication ESP32 → FastAPI
- ✔ Communication FastAPI → Unity
- ✔ Visualisation de la température de l'extrusion-soufflage

## Recherche

- ✔ Scénario pédagogique d'étiquetage
- ✔ Collecte des données expérimentales
- ✔ Export CSV
- ✔ Intégration du questionnaire NASA-TLX

---

# 3. Développements prioritaires

Les fonctionnalités suivantes constituent la priorité pour la poursuite du projet.

---

## 3.1 Mode multijoueur

### Objectif

Permettre à plusieurs utilisateurs de collaborer simultanément dans le même environnement virtuel.

### État

🟡 Prévu

### Technologies

- Unity Netcode for GameObjects
- Unity Transport
- Client / Host Architecture

### Fonctionnalités attendues

- synchronisation des joueurs ;
- synchronisation des objets manipulables ;
- communication en temps réel ;
- avatars utilisateurs ;
- interactions collaboratives.

---

## 3.2 Scénario collaboratif d'implantation

Ce scénario utilisera le mode multijoueur afin de permettre à plusieurs utilisateurs de concevoir ensemble une ligne de production.

Les utilisateurs devront :

- déplacer les machines ;
- organiser les postes de travail ;
- optimiser les flux de production ;
- discuter des différentes solutions d'implantation.

Ce scénario constitue la continuité naturelle du projet actuel.

---

## 3.3 Extension de la supervision temps réel

Actuellement, seule la température de la machine d'extrusion est supervisée.

L'objectif est d'intégrer progressivement les autres données disponibles.

Exemples :

- vitesse des convoyeurs ;
- états des machines ;
- capteurs supplémentaires ;
- alarmes ;
- consommation énergétique ;
- cadence de production.

---

# 4. Développements à moyen terme

---

## 4.1 Nouveaux scénarios pédagogiques

Développer plusieurs scénarios immersifs permettant de couvrir davantage de situations industrielles.

Par exemple :

- implantation des systèmes de production ;
- robotisation de la ligne ;
- gestion des flux logistiques ;
- modification des paramètres de production.

---

## 4.2 Formation à la robotique

Créer un environnement permettant d'apprendre :

- le fonctionnement des robots manipulateurs ;
- leurs zones de travail ;
- leur programmation ;
- leur intégration dans une ligne de production.

---

## 4.3 Modification dynamique de la production

L'objectif est de transformer le Digital Twin en système interactif.

L'utilisateur pourra modifier différents paramètres depuis la réalité virtuelle.

Par exemple :

- vitesse de production ;
- cadence ;
- paramètres machines ;
- configuration des postes.

Ces commandes pourront ensuite être transmises à la mini-usine physique via l'architecture de communication.

---

# 5. Développements à long terme

---

## 5.1 Tableau de bord immersif

Créer une interface immersive permettant d'afficher en temps réel :

- TRS ;
- cadence ;
- disponibilité ;
- performances ;
- alarmes ;
- indicateurs industriels.

---

## 5.2 Maintenance prédictive

Exploiter les données collectées afin de :

- détecter les anomalies ;
- prévoir les pannes ;
- afficher des alertes immersives ;
- assister les opérations de maintenance.

Cette évolution pourrait intégrer des modèles d'intelligence artificielle.

---

## 5.3 Digital Twin bidirectionnel

À terme, le projet pourra évoluer vers un véritable Digital Twin bidirectionnel.

Aujourd'hui :

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

Architecture future :

```
Mini-usine
      ▲
      │
ESP32
      ▲
      │
FastAPI
      ▲
      │
Unity
```

Dans cette architecture, Unity ne se limite plus à recevoir des données mais peut également envoyer des commandes vers la mini-usine.

---

# 6. Perspectives de recherche

Le projet constitue également une plateforme expérimentale pouvant être utilisée dans plusieurs domaines de recherche.

Quelques pistes possibles :

- apprentissage immersif ;
- collaboration en réalité virtuelle ;
- Digital Twin industriel ;
- interaction homme-machine ;
- ergonomie ;
- supervision industrielle ;
- intelligence artificielle appliquée à l'industrie ;
- maintenance prédictive.

Ces axes pourront donner lieu à de nouveaux projets de recherche, stages ou travaux de fin d'études.

---

# 7. Recommandations pour les futurs développeurs

Avant d'ajouter une nouvelle fonctionnalité, il est recommandé de :

- comprendre l'architecture générale du projet ;
- lire l'ensemble de la documentation présente dans le dossier `docs/` ;
- privilégier des composants modulaires ;
- documenter chaque nouvelle fonctionnalité ;
- tester chaque évolution avant son intégration.

---

# 8. Conclusion

Le projet constitue une première étape vers un environnement immersif complet dédié à la formation et à la supervision industrielle.

Grâce à son architecture modulaire, il peut évoluer progressivement vers un Digital Twin connecté, collaboratif et interactif, capable d'intégrer de nouveaux scénarios pédagogiques, des fonctionnalités avancées de supervision et des applications de recherche en Industrie 4.0.