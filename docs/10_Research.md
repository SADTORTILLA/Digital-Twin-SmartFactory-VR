# 10 - Recherche scientifique

---

# 1. Introduction

Au-delà du développement d'un environnement immersif, ce projet constitue également une plateforme expérimentale destinée à soutenir des travaux de recherche portant sur les technologies immersives, les Digital Twins industriels et la formation en Industrie 4.0.

L'environnement développé permet de réaliser des expérimentations contrôlées, de collecter des données quantitatives et qualitatives, puis d'analyser les performances des utilisateurs lors de scénarios pédagogiques immersifs.

Les travaux de recherche associés sont réalisés dans le cadre des activités de recherche de HESTIM.

---

# 2. Objectifs de la recherche

Les principaux objectifs scientifiques sont :

- étudier l'apprentissage en réalité virtuelle ;
- analyser l'influence du guidage progressif sur les performances des utilisateurs ;
- évaluer la charge mentale induite par les scénarios immersifs ;
- proposer une architecture de Digital Twin adaptée à la formation industrielle ;
- contribuer au développement de nouvelles approches de supervision immersive.

---

# 3. Collecte des données

Le scénario pédagogique d'étiquetage permet d'enregistrer automatiquement les performances des utilisateurs.

Les données sont exportées sous forme de fichiers CSV afin de faciliter leur traitement statistique.

Les principaux indicateurs enregistrés sont :

- temps total d'exécution ;
- temps de chaque étape ;
- ordre des actions réalisées ;
- nombre d'erreurs de manipulation ;
- nombre de tentatives incorrectes ;
- progression entre les différentes sessions.

Ces données permettent d'étudier l'évolution des performances au cours de l'apprentissage.

---

# 4. Évaluation subjective

En complément des mesures objectives, chaque participant remplit un questionnaire permettant d'évaluer son ressenti durant l'expérience.

Le projet utilise actuellement :

- **NASA-TLX (Task Load Index)**

Ce questionnaire permet d'évaluer notamment :

- la demande mentale ;
- la demande physique ;
- la demande temporelle ;
- les performances perçues ;
- l'effort fourni ;
- le niveau de frustration.

L'association des données objectives et subjectives permet d'obtenir une analyse plus complète des performances des utilisateurs.

---

# 5. Organisation des données

Les principales données expérimentales sont regroupées dans différents fichiers.

Exemples :

```
UserSessionData.csv
NASA_TLX.csv
ConsentForms/
ExperimentalResults/
```

Ces fichiers peuvent ensuite être importés dans des outils d'analyse statistique tels que :

- Python
- R
- Excel
- SPSS

---

# 6. Publications scientifiques

Le projet sert actuellement de support à deux travaux de recherche en cours de rédaction.

## Publications scientifiques

Deux articles scientifiques sont actuellement en cours de développement.

### Article ICINCO

Cet article présente l'architecture du Digital Twin immersif, les scénarios pédagogiques et le protocole expérimental.

➡️ **Consulter le dossier :** [Research/icinco_paper](../Research/icinco_paper/)

---

### Article WINCOM

Cet article porte sur l'analyse expérimentale des performances des utilisateurs dans les scénarios immersifs.

➡️ **Consulter le dossier :** [Research/Wincom](../Research/Wincom/)

---

# 7. Perspectives de recherche

Plusieurs axes de recherche peuvent être développés à partir de cette plateforme.

Parmi eux :

- apprentissage collaboratif en réalité virtuelle ;
- Digital Twin industriel connecté ;
- collaboration multi-utilisateur ;
- supervision immersive ;
- ergonomie des interfaces VR ;
- maintenance prédictive ;
- intelligence artificielle appliquée à l'industrie ;
- adaptation dynamique des scénarios pédagogiques.

Le caractère modulaire du projet facilite l'intégration de nouvelles expérimentations sans modifier l'architecture générale.

---

# 8. Conseils pour les futurs chercheurs

Si vous poursuivez les travaux scientifiques associés au projet, il est recommandé de :

- conserver le même protocole expérimental afin de garantir la comparabilité des résultats ;
- documenter précisément toute modification apportée aux scénarios ;
- versionner les jeux de données ;
- conserver les questionnaires utilisés ;
- mettre à jour les articles scientifiques en parallèle des évolutions du projet.

Les publications doivent rester synchronisées avec les développements techniques afin de garantir la cohérence entre les résultats expérimentaux et l'implémentation.

---

# 9. Conclusion

Ce projet ne constitue pas uniquement une plateforme logicielle ; il représente également un support de recherche permettant d'étudier les apports de la réalité virtuelle et des Digital Twins dans le contexte de la formation industrielle.

Grâce à son architecture ouverte et modulaire, il pourra servir de base à de futurs travaux scientifiques, stages et projets de fin d'études portant sur l'Industrie 4.0, les technologies immersives et l'interaction homme-machine.