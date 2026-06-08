# Squelette M3 - Application de Gestion de Lots et Recettes

## 📋 Description du Projet

Squelette M3 est une application Windows Forms développée en C# permettant de gérer des **lots de production**, des **recettes** et un **historique des événements**. L'application utilise une base de données MySQL pour stocker et récupérer les données.

### État du Projet (18.05.2026)
✅ **Version stable avec logique fonctionnelle**  
✅ **Interface utilisateur moderne et intuitive**  
✅ **Gestion des lots, recettes et historique implémentée**

---

## 🏗️ Architecture du Projet

```
Squelette_M3/
│
├── DataAccessLayer/           # Couche d'accès aux données
│   └── DBManager.cs           # Gestionnaire de connexions MySQL
│
├── Entites/                   # Classes métier (modèles)
│   ├── Lot.cs                 # Entité Lot
│   └── Evenement.cs           # Entité Événement
│
├── UI/                        # Interface utilisateur (Windows Forms)
│   ├── FormMain.cs            # Formulaire principal avec navigation
│   ├── UserControlRecettes.cs # Gestion des recettes
│   ├── UserControlLots.cs     # Gestion des lots
│   ├── UserControlHistorique.cs # Historique et export des données
│   └── FormCreerRecette.cs    # Formulaire de création de recette
│
├── Program.cs                 # Point d'entrée de l'application
├── Squelette_M3.csproj        # Configuration du projet
└── Squelette_M3.slnx          # Solution Visual Studio
```

---

## 🔧 Composants Principaux

### 1. **DataAccessLayer - DBManager.cs**
Classe statique responsable de la gestion de la connexion MySQL.

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `ConnectToDB(databaseName, userName, password)` | Configure la connexion à la base de données |
| `GetConnection()` | Retourne une nouvelle connexion MySQL |
| `TestConnexion()` | Teste la connexion à la base de données |

**Propriétés:**
- `_connectionString` - Chaîne de connexion statique

### 2. **Entités Métier**

#### **Lot.cs**
Représente un lot de production avec ses propriétés et méthodes.

**Propriétés principales:**
- `Id_Lot` - Identifiant unique
- `LOT_Nom` - Nom du lot
- `LOT_Quantite` - Quantité produite
- `LOT_DateHeureCreation` - Date/heure de création
- `Id_Etat` - État actuel (En attente, En cours, Terminé, Erreur)
- `Id_Recette` - Référence à la recette
- `REC_Nom` - Nom de la recette associée

**Méthodes principales:**
- `AfficherTousLesLots()` - Affiche tous les lots en console
- `CreerLot(nom, quantité, idRecette)` - Crée un nouveau lot
- `SupprimerLot(idLot)` - Supprime un lot
- `MettreAJourEtatLot(idLot, idEtat)` - Modifie l'état d'un lot

#### **Evenement.cs**
Enregistre les événements/logs associés aux lots.

**Propriétés:**
- `Id_Evenement` - Identifiant unique
- `EVE_Message` - Description de l'événement
- `EVE_DateHeure` - Timestamp de l'événement
- `Id_Lot` - Référence au lot concerné

### 3. **Interface Utilisateur (UI)**

#### **FormMain.cs**
Formulaire principal avec navigation par onglets/boutons.

**Propriétés:**
- `colorActif` - Couleur active: RGB(0, 120, 215) - Bleu
- `colorInactif` - Couleur inactive: RGB(45, 45, 48) - Gris foncé

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `AfficherPage(UserControl)` | Affiche une page dans le panneau principal |
| `DesactiverTousBoutons()` | Réinitialise les couleurs des boutons |
| `btnRecettes_Click()` | Navigue vers la gestion des recettes |
| `btnLots_Click()` | Navigue vers la gestion des lots |
| `btnHistorique_Click()` | Navigue vers l'historique |

#### **UserControlRecettes.cs**
Gestion et affichage des recettes disponibles.

**Fonctionnalités:**
- DataGridView affichant les recettes
- Colonnes: ID, Nom de la recette, Date de création
- Boutons: Ajouter, Modifier, Supprimer

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `ChargerRecettesDGV()` | Charge les recettes depuis la BD |
| `btnAjouter_Click()` | Ouvre le formulaire de création |
| `btnModifier_Click()` | Édite une recette sélectionnée |
| `btnSupprimer_Click()` | Supprime une recette avec confirmation |
| `SupprimerRecetteAvecLots(idRecette)` | Supprime en cascade (recette + lots + événements) |

#### **UserControlLots.cs**
Gestion complète des lots de production.

**Fonctionnalités:**
- DataGridView affichant les lots
- ComboBox pour sélectionner la recette
- Formulaire de création avec validation

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `ChargerRecettes()` | Charge les recettes dans le ComboBox |
| `ChargerLots()` | Affiche tous les lots dans le DataGridView |
| `btnCreerLot_Click()` | Crée un nouveau lot avec validation |

**Helper Class:**
```csharp
public class RecetteItem
{
    public int Id_Recette { get; set; }
    public string REC_Nom { get; set; }
}
```

#### **UserControlHistorique.cs**
Consultation et export de l'historique des lots.

**Fonctionnalités:**
- DataGridView avec historique complet des lots
- Recherche temps réel
- Affichage des détails d'un lot (double-clic)
- Export en XML et CSV

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `ChargerHistorique()` | Récupère et affiche l'historique |
| `ObtenirHistoriqueLots()` | Requête MySQL pour l'historique |
| `FiltrerDonnees(recherche)` | Filtre les données en mémoire |
| `TxtRecherche_TextChanged()` | Recherche temps réel |
| `AfficherDetailLot(idLot)` | Affiche le détail complet d'un lot |
| `ExporterXML(chemin)` | Export au format XML |
| `ExporterCSV(chemin)` | Export au format CSV |
| `BtnRafraichir_Click()` | Recharge les données |

#### **FormCreerRecette.cs**
Formulaire dédié à la création et modification de recettes.

**Constructeurs:**
- `FormCreerRecette()` - Crée une nouvelle recette
- `FormCreerRecette(Recette recetteAModifier)` - Modifie une recette existante

**Propriétés:**
- `operationsEnCours` - Liste des opérations en cours d'édition
- `recetteIdAModifier` - ID de la recette en modification (-1 si création)

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `RafraichirGrille()` | Synchronise l'affichage avec les données |
| `btnAjouterOp_Click()` | Ajoute une opération (max 10) |
| `btnSupprimerOp_Click()` | Supprime l'opération sélectionnée |
| `SynchroniserDepuisGrille()` | Récupère les données du formulaire |
| `btnEnregistrer_Click()` | Enregistre la recette en BD |

---

## 📦 Dépendances

- **Framework:** .NET / C# - Windows Desktop Application
- **MySQL.Data** - Connecteur MySQL pour C#
- **System.Windows.Forms** - Interface utilisateur
- **System.Drawing** - Gestion des couleurs et du rendu

---

## 🗄️ Base de Données MySQL

Tables principales utilisées:

| Table | Description |
|-------|-------------|
| `lot` | Stocks les lots de production |
| `recette` | Contient les recettes disponibles |
| `evenement` | Enregistre l'historique des événements |
| `etat` | États possibles (En attente, En cours, Terminé, Erreur) |

**Exemple de requête:**
```sql
SELECT l.Id_Lot, l.LOT_Nom, l.LOT_Quantite, 
       r.REC_Nom, l.LOT_DateHeureCreation, e.ETA_Libelle
FROM lot l
JOIN recette r ON l.Id_Recette = r.Id_Recette
JOIN etat e ON l.Id_Etat = e.Id_Etat
ORDER BY l.LOT_DateHeureCreation DESC
```

---

## 🚀 Installation et Configuration

### Prérequis
- Visual Studio 2019 ou supérieur
- MySQL Server (port 3306 par défaut)
- Base de données configurée avec les tables

### Étapes d'installation
1. Cloner le repository
   ```bash
   git clone https://github.com/fatval/Squelette_M3.git
   ```
2. Ouvrir `Squelette_M3.slnx` dans Visual Studio
3. Restaurer les dépendances NuGet
4. Configurer les paramètres MySQL
5. Compiler et exécuter

### Configuration de la Connexion MySQL
```csharp
// Dans Program.cs au démarrage
DBManager.ConnectToDB("m3", "root", ""); // (base, utilisateur, mot_de_passe)

// Ou avec connexion personnalisée
DBManager.ConnectToDB("nomBaseDonnees", "nomUtilisateur", "motDePasse");
```

---
#### Nettoyage du Code
- [ ] **Fonctions:** Éviter les répétitions
  - Extraire les patterns communes
  - Utiliser des méthodes utilitaires génériques
- [ ] **Variables:** Enlever les variables temporaires ("Kleenex")
  - Vérifier les variables non utilisées
  - Optimiser la portée des variables

#### Cohérence et Standards
- [ ] **Traduction:** Traduire les noms de fonctions en français
  - Fonctions actuelles (exemples):
    - `ChargerRecettes()` ✅ Déjà français
    - `GetConnection()` ❌ À traduire
    - `TestConnexion()` ✅ Français
    
- [ ] **Noms de variables:** Trouver des noms plus cohérents
  - Exemples:
    - `dgvHistorique` ✅ Cohérent (dgv = DataGridView)
    - `colorActif` ✅ Clair
    - Préfixes/suffixes cohérents

- [ ] **Mise en forme du code:** Ajouter la signature standard
  ```csharp
  /// <summary>
  /// [Description de la méthode]
  /// </summary>
  /// <remarks>
  /// Auteur: [Nom]
  /// Date: [JJ.MM.YYYY]
  /// Description: [Détails additionnels]
  /// </remarks>
  ```

---

## 💡 Bonnes Pratiques et Standards du Projet

### Convention de Nommage
| Type | Convention | Exemple |
|------|-----------|---------|
| Classes/Fichiers | PascalCase | `FormMain.cs`, `DBManager.cs` |
| Méthodes publiques | PascalCase | `ChargerLots`, `MettreAJourEtatLot` |
| Variables privées | camelCase avec _ | `_connectionString`, `colorActif` |
| Propriétés | PascalCase | `Id_Lot`, `REC_Nom` |
| Constantes | UPPER_SNAKE_CASE | `_CONNEXION_STRING` |

### Documentation du Code
```csharp
/// <summary>
/// Description concise et claire de la méthode
/// </summary>
/// <param name="nom">Description du paramètre</param>
/// <param name="quantite">Autre paramètre</param>
/// <returns>Description de la valeur retournée</returns>
/// <remarks>
/// Auteur: Noé
/// Date: 08.06.2026
/// Détails: Crée un lot dans la base de données avec validation
/// </remarks>
public static void CreerLot(string nom, int quantite)
{
    // Code...
}
```

### Langage des Commentaires
✅ **FRANÇAIS** - Tous les commentaires et documentation en français  
(Voir `.github/copilot-instructions.md`)

### Séparation des Responsabilités
```
┌─────────────────────────────────────┐
│         Interface (UI Layer)        │  UserControlXxx.cs, FormXxx.cs
│    Affichage, événements utilisateur│
└──────────────┬──────────────────────┘
               │
┌──────────────┴──────────────────────┐
│      Business Logic / Métier        │  Lot.cs, Recette.cs
│  Validation, calculs, règles métier │
└──────────────┬──────────────────────┘
               │
┌──────────────┴──────────────────────┐
│     Data Access Layer (DAL)         │  DBManager.cs
│  Opérations MySQL, connexions       │
└─────────────────────────────────────┘
```

---

## 🔗 Ressources Utiles

- **Repository GitHub:** [fatval/Squelette_M3](https://github.com/fatval/Squelette_M3)
- **Directives Copilot:** `.github/copilot-instructions.md`
- **Documentation MySQL:** [MySQL 8.0 Reference](https://dev.mysql.com/doc/refman/8.0/en/)

---

## 📜 Historique des Modifications

| Date | Auteur | Description |
|------|--------|-------------|
| 18.05.2026 | Valentin | Implémentation de la logique - version stable |
| 08.06.2026 | Copilot | Mise à jour complète et détaillée du README |

---

## 👥 Équipe de Développement

- **Valentin** - Logique métier et interface utilisateur
- **Noé** - Refactorisation, architecture, cohérence du code

---

**Dernière mise à jour:** 08.06.2026
