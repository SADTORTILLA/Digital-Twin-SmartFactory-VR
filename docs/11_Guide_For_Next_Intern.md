# 11 - Guide du prochain stagiaire

---

# 1. Bienvenue

Si vous lisez ce document, cela signifie que vous reprenez le développement du projet **Digital Twin Smart Factory VR** réalisé au sein de la plateforme **Smart Factory Connected (SFC)** de HESTIM.

Ce projet représente environ six mois de développement et combine plusieurs domaines :

- Réalité virtuelle (VR)
- Digital Twin
- Industrie 4.0
- Développement Unity
- Communication réseau
- Internet des Objets (IoT)
- Développement embarqué (ESP32)

L'objectif de ce document est de faciliter votre prise en main du projet et de vous faire gagner plusieurs semaines de compréhension.

---

# 2. Avant toute chose

Ne commencez pas immédiatement à modifier le code.

Prenez d'abord le temps de comprendre le projet dans son ensemble.

Je recommande fortement de suivre l'ordre suivant.

## Étape 1

Lire complètement :

```
README.md
```

---

## Étape 2

Lire ensuite toute la documentation.

```
docs/
│
├── 01_Project_Overview.md
├── 02_System_Architecture.md
├── 03_Unity_Architecture.md
├── 04_FastAPI.md
├── 05_ESP32.md
├── 06_Installation.md
├── 07_Educational_Scenarios.md
├── 08_Roadmap.md
├── 09_Troubleshooting.md
└── 10_Research.md
```

Ne commencez pas à programmer avant d'avoir compris le fonctionnement général.

---

# 3. Comprendre le projet

Le projet est constitué de trois parties indépendantes.

```
                Digital Twin
                     │
      ┌──────────────┼──────────────┐
      │              │              │
      ▼              ▼              ▼
   Unity         FastAPI          ESP32
```

Ces trois composants communiquent entre eux mais peuvent être développés séparément.

C'est l'un des principaux avantages de cette architecture.

---

# 4. Comprendre Unity

Unity représente la partie la plus importante du projet.

Avant toute modification, prenez le temps de comprendre :

- l'organisation des scènes ;
- la hiérarchie des GameObjects ;
- les Prefabs ;
- les Scripts ;
- le système XR ;
- les interactions ;
- le système de progression des scénarios.

Le scénario d'étiquetage constitue le meilleur point de départ.

Essayez d'abord de comprendre son fonctionnement avant d'ajouter de nouvelles fonctionnalités.

---

# 5. Comprendre FastAPI

Le serveur FastAPI agit comme une passerelle entre la mini-usine physique et Unity.

Son rôle est simple :

- recevoir les données envoyées par l'ESP32 ;
- les stocker temporairement ;
- les transmettre à Unity.

FastAPI ne contient volontairement que très peu de logique métier.

Essayez de conserver cette philosophie.

---

# 6. Comprendre l'ESP32

L'ESP32 est uniquement chargé de récupérer des données provenant de la mini-usine.

Il ne doit pas contenir de logique complexe.

Son rôle est simplement :

```
Capteur

↓

Lecture

↓

JSON

↓

FastAPI
```

Plus le code embarqué reste simple, plus il sera facile à maintenir.

---

# 7. Feuille de route recommandée

## Première semaine

Objectif :

Comprendre complètement le projet.

À faire :

- installer le projet ;
- lancer Unity ;
- lancer FastAPI ;
- connecter l'ESP32 ;
- tester le scénario d'étiquetage ;
- lire toute la documentation.

À éviter :

Commencer immédiatement à modifier le code.

---

## Deuxième semaine

Objectif :

Comprendre le code Unity.

Je recommande d'étudier :

- StepManager
- Conditions
- UI
- Système VR
- Architecture des scènes

Essayez ensuite de créer un petit scénario de test.

---

## Troisième semaine

Objectif :

Comprendre la communication réseau.

Étudier :

- WebSocket
- HTTP
- FastAPI
- ESP32

Puis ajouter une nouvelle donnée provenant de la mini-usine.

Par exemple :

- vitesse convoyeur ;
- compteur ;
- état machine.

---

## Quatrième semaine

Commencer les nouveaux développements.

La priorité actuelle est :

- le mode multijoueur.

---

# 8. Développement recommandé

Les prochaines évolutions proposées sont :

## Priorité élevée

- Mode multijoueur
- Synchronisation réseau
- Nouveaux scénarios pédagogiques
- Ajout de nouveaux capteurs

---

## Priorité moyenne

- Tableaux de bord immersifs
- Amélioration des interfaces
- Optimisation graphique
- Optimisation des performances

---

## Priorité faible

- Intelligence artificielle
- Maintenance prédictive
- Statistiques avancées

---

# 9. Bonnes pratiques

Pendant le développement :

- réaliser de petits commits Git fréquents ;
- documenter chaque nouvelle fonctionnalité ;
- commenter uniquement lorsque cela est utile ;
- tester avant chaque commit ;
- maintenir une architecture modulaire.

Éviter les modifications importantes sans avoir compris les impacts sur les autres composants.

---

# 10. Les erreurs que j'ai rencontrées

Durant le développement, plusieurs difficultés sont apparues.

Les principales sont :

- mauvaise configuration OpenXR ;
- problèmes de couches (Layers) XR ;
- erreurs de synchronisation WebSocket ;
- problèmes de réseau entre l'ESP32 et FastAPI ;
- modèles 3D trop lourds pour la VR ;
- optimisation insuffisante des scènes Unity.

Ces points méritent une attention particulière.

---

# 11. Conseils personnels

Quelques recommandations issues de l'expérience acquise durant le projet.

- Comprendre avant de modifier.
- Tester une fonctionnalité à la fois.
- Ne pas chercher à déboguer Unity, FastAPI et l'ESP32 simultanément.
- Isoler chaque problème.
- Lire la documentation officielle avant de chercher une solution sur Internet.
- Garder le projet simple et modulaire.

La plupart des problèmes peuvent être résolus en identifiant précisément à quel niveau de la chaîne de communication ils apparaissent.

---

# 12. Si vous souhaitez poursuivre le projet

Plusieurs pistes sont particulièrement intéressantes.

- Finaliser le mode multijoueur.
- Étendre la supervision à toutes les machines.
- Ajouter de nouveaux scénarios pédagogiques.
- Permettre une communication bidirectionnelle avec la mini-usine.
- Ajouter un tableau de bord industriel immersif.
- Développer des fonctionnalités de maintenance prédictive.

Le projet possède une base suffisamment solide pour évoluer vers un véritable Digital Twin industriel.

---

# 13. Dernier conseil

N'essayez pas de tout comprendre en une journée.

Commencez par faire fonctionner le projet, puis comprenez progressivement chaque composant.

Une fois que vous maîtrisez l'architecture générale, l'ajout de nouvelles fonctionnalités devient beaucoup plus simple.

Je vous souhaite une excellente continuation sur ce projet et j'espère que cette documentation vous permettra de gagner un temps précieux.

GOOD LUCK!!!