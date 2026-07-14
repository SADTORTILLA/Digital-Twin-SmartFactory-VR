# 09 - Résolution des problèmes (Troubleshooting)

---

# 1. Introduction

Ce document regroupe les principaux problèmes pouvant être rencontrés lors du développement ou de l'exécution du projet **Digital Twin Smart Factory VR**.

Les solutions proposées proviennent des problèmes rencontrés durant le développement du projet ainsi que des recommandations issues des documentations officielles de Unity, FastAPI et ESP32.

Avant toute modification importante, il est conseillé de vérifier :

- que le projet compile correctement ;
- que toutes les dépendances sont installées ;
- que le serveur FastAPI est démarré ;
- que l'ESP32 est connecté au même réseau ;
- que le casque Meta Quest est correctement détecté.

---

# 2. Unity

## 2.1 Le projet ne compile pas

### Symptômes

- erreurs rouges dans la console ;
- scripts manquants ;
- packages introuvables.

### Vérifications

- vérifier que tous les packages Unity sont installés ;
- ouvrir le **Package Manager** ;
- laisser Unity terminer l'importation du projet.

Si nécessaire :

```
Assets
→ Reimport All
```

---

## 2.2 Les scènes ne fonctionnent pas

### Vérifications

- ouvrir la bonne scène (`MAIN_scene`) ;
- vérifier que tous les objets sont présents dans la Hiérarchie ;
- vérifier que les références des scripts n'ont pas été perdues.

---

## 2.3 Les interactions XR ne fonctionnent pas

### Symptômes

- impossible de saisir les objets ;
- les boutons ne répondent pas ;
- les interactions sont absentes.

### Vérifications

- présence du composant **XR Grab Interactable** ;
- présence d'un **Collider** ;
- présence d'un **Rigidbody** si nécessaire ;
- couches (Layers) correctement configurées.

Consulter :

https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit

---

# 3. Meta Quest 3

## 3.1 Le casque n'est pas détecté

Vérifier :

- Quest Link ou Air Link actif ;
- câble USB fonctionnel (si utilisé) ;
- OpenXR activé dans Unity ;
- casque autorisé dans Meta Quest Link.

---

## 3.2 Les contrôleurs ne sont pas détectés

Vérifier :

- batteries des contrôleurs ;
- OpenXR Runtime actif ;
- Input System correctement installé.

---

## 3.3 Les performances VR sont faibles

Quelques pistes d'optimisation :

- réduire le nombre de polygones ;
- utiliser l'occlusion culling ;
- limiter les éclairages temps réel ;
- optimiser les matériaux ;
- réduire les appels de rendu (Draw Calls).

---

# 4. FastAPI

## 4.1 Le serveur ne démarre pas

Vérifier :

- environnement virtuel activé ;
- dépendances installées ;
- version de Python compatible.

Tester :

```bash
pip install -r requirements.txt
```

Puis :

```bash
uvicorn main:app --reload
```

---

## 4.2 Impossible d'accéder au serveur

Tester dans un navigateur :

```
http://localhost:8000
```

Puis :

```
http://localhost:8000/docs
```

Si cela ne fonctionne pas :

- vérifier le pare-feu Windows ;
- vérifier que le port 8000 est libre.

---

## 4.3 Unity ne reçoit aucune donnée

Vérifier :

- FastAPI est démarré ;
- l'adresse IP utilisée dans Unity est correcte ;
- le WebSocket est bien ouvert ;
- aucun message d'erreur n'apparaît dans la console Unity.

---

# 5. ESP32

## 5.1 L'ESP32 ne se connecte pas au Wi-Fi

Vérifier :

- SSID correct ;
- mot de passe correct ;
- réseau 2.4 GHz disponible.

Utiliser le Moniteur Série pour identifier l'erreur.

---

## 5.2 Les données ne sont pas envoyées

Vérifier :

- adresse IP du serveur FastAPI ;
- port utilisé ;
- même réseau Wi-Fi.

Tester l'API avec un navigateur ou Postman.

---

## 5.3 Erreur lors du téléversement

Vérifier :

- bon port COM sélectionné ;
- bonne carte ESP32 choisie dans Arduino IDE ;
- câble USB compatible avec le transfert de données.

---

# 6. Réseau

## Aucun échange entre les composants

La chaîne suivante doit être respectée :

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

Chaque élément doit être testé indépendamment.

Ordre conseillé :

1. Vérifier FastAPI.
2. Vérifier l'ESP32.
3. Vérifier les messages reçus.
4. Vérifier Unity.

---

# 7. Git

## Le projet ne s'ouvre pas après un pull

Essayer :

```bash
git pull
```

Puis :

```bash
git restore .
```

ou supprimer le dossier **Library** afin de forcer Unity à le reconstruire.

⚠️ Ne jamais supprimer :

- Assets
- Packages
- ProjectSettings

---

## Conflits Git

Avant tout push :

```bash
git pull
```

Puis :

```bash
git status
```

Résoudre les conflits avant de poursuivre.

---

# 8. Conseils de débogage

Lorsqu'un problème apparaît, il est conseillé de procéder dans l'ordre suivant :

1. Lire le message d'erreur.
2. Identifier le composant concerné.
3. Vérifier la documentation officielle.
4. Tester le composant indépendamment.
5. Consulter les logs Unity.
6. Consulter les logs FastAPI.
7. Vérifier le Moniteur Série de l'ESP32.

---

# 9. Ressources utiles

## Unity

- Documentation Unity
- XR Interaction Toolkit Documentation
- Unity Learn

## FastAPI

- Documentation FastAPI
- Documentation Uvicorn

## ESP32

- Documentation Espressif
- Arduino ESP32 GitHub

## Git

- Documentation Git
- GitHub Docs

---

# 10. Conclusion

La majorité des problèmes rencontrés proviennent d'une mauvaise configuration des dépendances, du réseau ou des paramètres Unity.

En suivant les procédures décrites dans ce document, il est généralement possible d'identifier rapidement l'origine d'un dysfonctionnement et de rétablir le fonctionnement normal du projet.

Pour toute évolution importante, il est recommandé de documenter les nouveaux problèmes rencontrés ainsi que leurs solutions afin d'enrichir progressivement ce guide.