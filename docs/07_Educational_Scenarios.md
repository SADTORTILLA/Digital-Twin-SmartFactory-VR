# 07 - Scénarios pédagogiques

---

# 1. Introduction

L'un des principaux objectifs de ce projet est de proposer un environnement immersif permettant non seulement de représenter une ligne de production industrielle, mais également de créer des situations d'apprentissage interactives.

Les scénarios pédagogiques constituent le cœur de cette plateforme. Ils permettent de placer l'utilisateur dans des situations proches des conditions réelles de production tout en garantissant un environnement sécurisé, répétable et facilement modifiable.

Chaque scénario est conçu afin d'évaluer différentes compétences telles que :

- l'apprentissage d'une procédure industrielle ;
- la mémorisation des étapes de travail ;
- la gestion des erreurs ;
- l'adaptation à des situations inattendues ;
- l'analyse des performances de l'utilisateur.

---

# 2. Objectifs pédagogiques

Les scénarios développés poursuivent plusieurs objectifs.

## Formation

Permettre aux étudiants de découvrir le fonctionnement d'une ligne de production avant toute intervention sur les équipements réels.

## Expérimentation

Créer un environnement contrôlé permettant de modifier facilement les paramètres d'une activité afin d'observer leur influence sur les performances.

## Évaluation

Mesurer objectivement les performances des utilisateurs grâce à différents indicateurs enregistrés automatiquement.

---

# 3. Scénario implémenté : Opération chronométrée d'étiquetage

## 3.1 Présentation

Ce scénario constitue actuellement le principal scénario pédagogique développé dans le projet.

Il reproduit fidèlement le poste manuel d'étiquetage présent sur la Smart Factory Connected (SFC) de HESTIM.

L'utilisateur doit appliquer correctement une étiquette sur chaque flacon PEHD en respectant la procédure définie.

Le scénario est entièrement interactif et exploite les contrôleurs du casque Meta Quest 3 afin de reproduire les gestes de manipulation.

---

## 3.2 Objectifs du scénario

Les objectifs sont les suivants :

- apprendre la procédure correcte d'étiquetage ;
- améliorer progressivement la vitesse d'exécution ;
- réduire le nombre d'erreurs ;
- favoriser la mémorisation de la procédure ;
- analyser l'évolution des performances entre plusieurs sessions.

---

## 3.3 Déroulement du scénario

Le scénario est composé de trois sessions successives.

### Session 1 : Apprentissage guidé

L'utilisateur découvre la procédure.

Le système fournit :

- des instructions audio ;
- des indications visuelles ;
- des messages d'aide ;
- une validation étape par étape.

L'objectif est de permettre l'acquisition progressive de la procédure.

---

### Session 2 : Exécution autonome

Toutes les aides sont supprimées.

L'utilisateur doit reproduire la procédure uniquement à partir de ce qu'il a appris lors de la première session.

Cette étape permet d'évaluer :

- la mémorisation ;
- l'autonomie ;
- la rapidité d'exécution.

---

### Session 3 : Test d'adaptation

Cette session introduit volontairement une situation imprévue.

Dans la version actuelle, certaines étiquettes sont volontairement absentes afin d'obliger l'utilisateur à adapter son comportement.

L'objectif est d'observer :

- la capacité d'adaptation ;
- la gestion des erreurs ;
- le maintien des performances sous contrainte.

---

# 4. Évaluation des performances

Durant chaque session, différentes informations sont enregistrées automatiquement.

Les principaux indicateurs sont :

- temps total d'exécution ;
- temps par étape ;
- nombre d'erreurs de manipulation ;
- ordre des actions réalisées ;
- nombre de tentatives incorrectes.

Ces données permettent d'étudier la progression de l'utilisateur entre les différentes sessions.

---

# 5. Données expérimentales

Le projet a également servi de support à une étude expérimentale portant sur l'apprentissage immersif.

Les données enregistrées sont exportées automatiquement sous forme de fichiers CSV afin de faciliter leur traitement statistique.

Les informations collectées comprennent notamment :

- durée des sessions ;
- performances individuelles ;
- nombre d'erreurs ;
- questionnaire NASA-TLX relatif à la charge mentale ;
- formulaire de consentement des participants.

Ces données sont exploitées dans le cadre des travaux de recherche associés au projet.

Pour plus d'informations :

`docs/10_Research.md`

---

# 6. Architecture des scénarios

Chaque scénario est développé de manière modulaire.

De façon générale, un scénario est constitué des éléments suivants :

- environnement 3D ;
- objets interactifs ;
- conditions de progression ;
- gestionnaire d'étapes (Step Manager) ;
- système de chronométrage ;
- système d'évaluation ;
- interface utilisateur ;
- collecte automatique des données.

Cette organisation facilite la création de nouveaux scénarios sans modifier l'architecture générale du projet.

---

# 7. Scénarios prévus

Plusieurs scénarios sont prévus afin d'étendre les capacités pédagogiques de la plateforme.

## Implantation des systèmes de production

Les utilisateurs devront organiser les différentes machines afin de construire une ligne de production fonctionnelle.

Ce scénario servira également de base à l'implémentation du mode multijoueur.

---

## Robotisation de la ligne de production

Simulation de l'intégration de robots manipulateurs dans la chaîne de production.

Les utilisateurs devront optimiser leur positionnement ainsi que leurs zones de travail.

---

## Gestion des flux logistiques

Simulation des déplacements de matières premières, des produits semi-finis et des produits finis.

Ce scénario permettra d'introduire des AGV et différents moyens de manutention.

---

## Modification des paramètres de production

L'utilisateur pourra modifier différents paramètres industriels afin d'observer leur impact sur la production.

Quelques exemples :

- cadence ;
- température ;
- vitesse des convoyeurs ;
- paramètres machines.

---

# 8. Développements futurs

Le projet prévoit plusieurs améliorations.

Les principales sont :

- intégration complète du mode multijoueur ;
- nouveaux scénarios collaboratifs ;
- supervision temps réel de plusieurs machines ;
- nouvelles interfaces utilisateur immersives ;
- tableaux de bord industriels interactifs ;
- génération automatique de rapports de performance.

---

# 9. Conclusion

Les scénarios pédagogiques constituent la principale valeur ajoutée de cette plateforme.

Ils permettent de transformer un simple modèle 3D en un véritable environnement de formation immersive capable d'évaluer objectivement les performances des utilisateurs tout en préparant les futures évolutions vers une Smart Factory collaborative et entièrement connectée.