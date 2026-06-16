# Squelette M3 - Application de Gestion de Lots et Recettes

## 📋 Description du Projet

**Squelette M3** est une application **Windows Forms** développée en **C# (.NET 10.0)** permettant de gérer des **lots de production**, des **recettes**, et un **historique complet des événements**. L'application propose une interface intuitive et moderne avec fonctionnalités complètes de CRUD (Create, Read, Update, Delete), transactions sécurisées et exports de données.

### État du Projet (15.06.2026)
✅ **Version stable avec logique fonctionnelle complète**  
✅ **Interface utilisateur moderne (Windows Forms)**  
✅ **Architecture en couches bien structurée**  
✅ **Gestion transactionnelle robuste avec MySQL**  
✅ **Export de données en XML et CSV fonctionnel**  
✅ **Validation des données complète**  
✅ **Historique avec recherche temps réel**  

---

## 🏗️ Architecture du Projet

```
Squelette_M3/
│
├── 📄 Squelette_M3.slnx             # Solution Visual Studio
├── 📄 README.md                      # Documentation
├── 📄 .gitignore                     # Fichiers à ignorer Git
│
└── 📁 Squelette_M3/                 # Projet principal (C#, .NET 10.0)
    │
    ├── 📄 Program.cs                # Point d'entrée de l'application
    ├── 📄 Squelette_M3.csproj       # Configuration du projet
    │
    ├── 📁 DataAccessLayer/          # 🔴 Couche d'Accès aux Données
    │   └── DBManager.cs             # Gestionnaire centralisé des connexions MySQL
    │
    ├── 📁 Entites/                  # 🟠 Couche Métier (Modèles de données)
    │   ├── Lot.cs                   # Classe Lot (lots de production)
    │   ├── Recette.cs               # Classe Recette (recettes avec opérations)
    │   ├── Operation.cs             # Classe Operation (opérations d'une recette)
    │   ├── Evenement.cs             # Classe Evenement (historique des événements)
    │   ├── Etat.cs                  # Classe Etat (états possibles d'un lot)
    │   └── Contenir.cs              # Classe Contenir (table associative)
    │
    ├── 📁 Properties/               # Ressources et configurations
    │   ├── Resources.resx           # Ressources de l'application
    │   └── Resources.Designer.cs    # Fichier généré pour les ressources
    │
    └── 📁 UI/                       # 🟡 Couche Présentation (Interface Utilisateur)
        │
        ├── 📄 FormMain.cs           # Formulaire principal avec navigation
        ├── 📄 FormMain.Designer.cs  # Interface du formulaire principal (généré)
        ├── 📄 FormMain.resx         # Ressources du formulaire principal
        │
        ├── 📄 FormCreerRecette.cs              # Formulaire création/modification de recette
        ├── 📄 FormCreerRecette.Designer.cs    # Interface du formulaire recette (généré)
        ├── 📄 FormCreerRecette.resx           # Ressources du formulaire recette
        │
        ├── 📄 UserControlRecettes.cs          # Control gestion des recettes
        ├── 📄 UserControlRecettes.Designer.cs # Interface (généré)
        ├── 📄 UserControlRecettes.resx        # Ressources
        │
        ├── 📄 UserControlLots.cs              # Control gestion des lots
        ├── 📄 UserControlLots.Designer.cs     # Interface (généré)
        ├── 📄 UserControlLots.resx            # Ressources
        │
        ├── 📄 UserControlHistorique.cs        # Control historique et exports
        ├── 📄 UserControlHistorique.Designer.cs # Interface (généré)
        └── 📄 UserControlHistorique.resx      # Ressources

└── 📁 .github/
    └── 📄 copilot-instructions.md   # Directives Copilot (commentaires en français)
```

---

## 🔧 Composants Principaux

### 1. **DataAccessLayer/DBManager.cs** 🔴
Classe statique centralisée pour la gestion de **toutes les connexions MySQL**.

**Responsabilités:**
- Gestion de la chaîne de connexion unique
- Ouverture des connexions
- Tests de connectivité
- Format: `server=localhost;database={nom};user={utilisateur};password={motdepasse};port=3306`

**Méthodes publiques:**

| Méthode | Description |
|---------|-------------|
| `ConnectToDB(databaseName, userName, password)` | Initialise la connexion MySQL (appelé au démarrage) |
| `GetConnection()` | Retourne une nouvelle instance de `MySqlConnection` |
| `TestConnexion()` | Teste la connexion à la base de données |

---

### 2. **Entités Métier (Couche Métier)** 🟠

#### **Lot.cs** - Gestion des lots de production

**Propriétés:**
```csharp
public int Id_Lot { get; set; }              // Identifiant unique
public string LOT_Nom { get; set; }          // Nom du lot
public int LOT_Quantite { get; set; }        // Quantité produite
public DateTime LOT_DateHeureCreation { get; set; }  // Date/heure création
public int Id_Etat { get; set; }             // Clé étrangère : état
public int ETA_Libelle { get; set; }         // État du lot
public int Id_Recette { get; set; }          // Clé étrangère : recette
public string REC_Nom { get; set; }          // Nom de la recette associée
```

**Méthodes:**
- `RechercherLotParNom(nom)` - Recherche un lot par son nom
- `AfficherTousLesLots()` - Affiche tous les lots en console
- `CreerLot(nom, quantite, idRecette)` - Crée un lot
- `SupprimerLot(idLot)` - Supprime un lot
- `MettreAJourEtatLot(idLot, idEtat)` - Met à jour l'état d'un lot

---

#### **Recette.cs** - Gestion des recettes et opérations

**Propriétés:**
```csharp
public int Id_Recette { get; set; }                    // Identifiant unique
public string REC_Nom { get; set; }                    // Nom de la recette
public DateTime REC_DateHeureCreation { get; set; }    // Date création
public List<Operation> Operations { get; set; }        // Opérations associées
```

**Méthodes statiques:**

| Méthode | Description |
|---------|-------------|
| `GetAll()` | Retourne la liste de toutes les recettes |
| `GetById(id)` | Charge une recette avec ses opérations associées |
| `CompterOperations(idRecette)` | Compte le nombre d'opérations d'une recette |
| `AjouterRecette(nom, operations)` | Crée une recette avec ses opérations (transaction) |
| `ModifierRecette(idRecette, nom, operations)` | Modifie une recette et remplace ses opérations |
| `SupprimerRecette(idRecette)` | Supprime une recette (transaction) |

---

#### **Operation.cs** - Opérations d'une recette

**Propriétés:**
```csharp
public int Id_Operation { get; set; }        // Identifiant unique
public int OPE_Ordre { get; set; }           // Ordre dans la recette
public string OPE_Nom { get; set; }          // Nom de l'opération
public int OPE_PositionMoteur { get; set; }  // Position (3, 6, 9, 12 heures)
public int OPE_TempsAttente { get; set; }    // Temps d'attente en secondes
public bool OPE_CycleVerin { get; set; }     // Cycle de vérin activé?
public bool OPE_Quittance { get; set; }      // Quittance requise?
public bool OPE_SensMoteur { get; set; }     // Sens du moteur
```

---

#### **Evenement.cs** - Historique des événements

**Propriétés:**
```csharp
public int Id_Evenement { get; set; }        // Identifiant unique
public string EVE_Message { get; set; }      // Message/description
public DateTime EVE_DateHeure { get; set; }  // Horodatage
public int Id_Lot { get; set; }              // Clé étrangère : lot
```

---

#### **Etat.cs** - États possibles d'un lot

**Propriétés:**
```csharp
public int Id_Etat { get; set; }             // Identifiant unique
public string ETA_Libelle { get; set; }      // Libellé (En attente, En cours, Terminé, Erreur)
```

---

### 3. **Interface Utilisateur (Couche Présentation)** 🟡

#### **FormMain.cs** - Formulaire principal

**Rôle:** Navigation par onglets entre les trois sections de l'application.

**Méthodes:**

| Méthode | Description |
|---------|-------------|
| `AfficherPage(UserControl)` | Affiche un UserControl dans le panneau principal |
| `DesactiverTousBoutons()` | Réinitialise la couleur de tous les boutons |
| `btnRecettes_Click()` | Navigue vers la gestion des recettes |
| `btnLots_Click()` | Navigue vers la gestion des lots |
| `btnHistorique_Click()` | Navigue vers l'historique |

---

#### **UserControlRecettes.cs** - Gestion des recettes

**Fonctionnalités:**
- DataGridView affichant toutes les recettes
- Colonnes: ID, Nom, Nombre d'opérations, Date de création
- Boutons: Ajouter, Modifier, Supprimer
- Confirmation avant suppression

**Méthodes principales:**

| Méthode | Description |
|---------|-------------|
| `ChargerRecettesDGV()` | Charge les recettes depuis la BD |
| `btnAjouter_Click()` | Ouvre `FormCreerRecette()` en mode création |
| `btnModifier_Click()` | Ouvre `FormCreerRecette(recette)` en mode modification |
| `btnSupprimer_Click()` | Supprime avec confirmation et cascade |
| `SupprimerRecetteAvecLots(idRecette)` | Transaction: supprime recette → lots → événements |

---

#### **UserControlLots.cs** - Gestion des lots

**Fonctionnalités:**
- DataGridView affichant tous les lots
- ComboBox pour sélectionner la recette
- Champs de saisie pour nom et quantité
- Création avec validation automatique

**Méthodes principales:**

| Méthode | Description |
|---------|-------------|
| `ChargerRecettes()` | Remplit le ComboBox avec les recettes |
| `ChargerLots()` | Charge tous les lots dans le DataGridView |
| `btnCreerLot_Click()` | Crée un nouveau lot avec validation |

---

#### **UserControlHistorique.cs** - Historique et exports

**Fonctionnalités:**
- DataGridView avec historique complet
- Recherche en temps réel par nom, ID ou recette
- Double-clic pour afficher détails complets
- Export XML et CSV
- Rafraîchissement manuel

**Méthodes principales:**

| Méthode | Description |
|---------|-------------|
| `ChargerHistorique()` | Récupère et affiche l'historique |
| `TxtRecherche_TextChanged()` | Filtre les données en temps réel |
| `AfficherDetailLot(idLot)` | Affiche détail complet + événements |
| `ExporterXML(chemin)` | Export au format XML |
| `ExporterCSV(chemin)` | Export au format CSV |

---

#### **FormCreerRecette.cs** - Création/Modification de recette

**Rôle:** Formulaire modal pour créer ou modifier une recette.

**Constructeurs:**
- `FormCreerRecette()` - Crée une nouvelle recette
- `FormCreerRecette(Recette recetteAModifier)` - Modifie une recette

**Méthodes principales:**

| Méthode | Description |
|---------|-------------|
| `RafraichirGrille()` | Synchronise l'affichage avec les opérations |
| `btnAjouterOp_Click()` | Ajoute une opération (max 10) |
| `btnSupprimerOp_Click()` | Supprime l'opération sélectionnée |
| `SynchroniserDepuisGrille()` | Récupère les données du formulaire |
| `btnEnregistrer_Click()` | Enregistre la recette en base de données |

---

## 📦 Dépendances et Configuration

### Framework & Dépendances
```xml
<PropertyGroup>
  <OutputType>WinExe</OutputType>
  <TargetFramework>net10.0-windows</TargetFramework>
  <Nullable>enable</Nullable>
  <UseWindowsForms>true</UseWindowsForms>
  <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>

<ItemGroup>
  <PackageReference Include="MySql.Data" Version="9.7.0" />
</ItemGroup>
```

### Versions
- **Framework:** .NET 10.0 (Windows)
- **Langage:** C# 12+
- **MySQL.Data:** 9.7.0
- **UI:** Windows Forms

---

## 🗄️ Modèle de Données MySQL

### Tables principales

| Table | Description |
|-------|-------------|
| `etat` | États possibles (En attente, En cours, Terminé, Erreur) |
| `recette` | Recettes avec date de création |
| `operation` | Opérations de production |
| `Contenir` | Association Recette ↔ Operation (avec ordre) |
| `lot` | Lots de production |
| `evenement` | Historique des événements par lot |

### Relations

```
Recette (1) ──── (n) Contenir ──── (n) Operation
Recette (1) ──── (n) Lot ──── (1) Etat
Lot (1) ──── (n) Evenement
```

---

## 🚀 Installation et Configuration

### Prérequis
- Visual Studio 2022+ (ou VS Code avec C#)
- .NET 10.0 SDK
- MySQL Server 8.0+ (port 3306 par défaut)
- Base de données MySQL créée

### Étapes d'installation

1. **Cloner le repository**
   ```bash
   git clone https://github.com/fatval/Squelette_M3.git
   cd Squelette_M3
   ```

2. **Ouvrir le projet**
   - Ouvrir `Squelette_M3.slnx` dans Visual Studio

3. **Restaurer les dépendances NuGet**
   ```bash
   dotnet restore
   ```

4. **Configurer la connexion MySQL**
   - Ouvrir `Program.cs`
   - Modifier: `DBManager.ConnectToDB("m3", "root", "");`
   - Remplacer par vos paramètres MySQL

5. **Créer la base de données**
   - Créer la base: `CREATE DATABASE m3;`
   - Importer le schéma SQL

6. **Compiler et exécuter**
   ```bash
   dotnet run
   ```

---

## 💡 Bonnes Pratiques et Standards

### Convention de Nommage

| Type | Convention | Exemple |
|------|-----------|---------|
| **Classes/Fichiers** | PascalCase | `FormMain.cs`, `DBManager.cs` |
| **Méthodes publiques** | PascalCase | `ChargerRecettes()`, `AjouterRecette()` |
| **Variables privées** | camelCase avec `_` | `_colorActif`, `_donneesCompletes` |
| **Propriétés** | PascalCase | `Id_Lot`, `REC_Nom` |
| **Constantes** | UPPER_SNAKE_CASE | `_CONNEXION_STRING` |
| **Paramètres** | camelCase | `nom`, `quantite`, `idRecette` |

### Documentation du Code

```csharp
/// <summary>
/// Description brève et claire de la méthode en français.
/// </summary>
/// <param name="nom">Description du paramètre</param>
/// <returns>Description de la valeur retournée</returns>
/// <remarks>
/// Auteur: [Prénom] [Nom]
/// Date: [JJ.MM.YYYY]
/// Détails: Explications de l'implémentation
/// </remarks>
public static void CreerLot(string nom, int quantite)
{
    // Implémentation...
}
```

### Langage des Commentaires
✅ **FRANÇAIS** - Tous les commentaires et documentation en français

### Séparation des Responsabilités
- ✅ Pas de logique métier dans les formulaires
- ✅ DBManager centralise toutes les connexions
- ✅ Validation des données à l'entrée
- ✅ Transactions pour opérations multi-table
- ✅ Confirmation utilisateur pour suppressions

---

## 🔗 Ressources Utiles

- **Repository:** [fatval/Squelette_M3](https://github.com/fatval/Squelette_M3)
- **MySQL Docs:** [MySQL 8.0 Reference](https://dev.mysql.com/doc/refman/8.0/en/)
- **Windows Forms:** [Microsoft WinForms Docs](https://docs.microsoft.com/en-us/dotnet/desktop/winforms)
- **C# Documentation:** [Microsoft C# Docs](https://docs.microsoft.com/en-us/dotnet/csharp)

---

## 📜 Historique des Modifications

| Date | Auteur | Description |
|------|--------|-------------|
| 18.05.2026 | Valentin | Implémentation initiale - version stable |
| 08.06.2026 | Copilot | Mise à jour détaillée du README |
| 12.06.2026 | Copilot & ESnoea | Refactorisation et standards |
| 15.06.2026 | ESnoea | Mise à jour complète architecture avec analyse complète |

---

## 👥 Équipe de Développement

- **Valentin** - Logique métier et interface utilisateur
- **ESnoea** - Architecture, refactorisation, cohérence du code
- **Copilot** - Assistance au développement et documentation

---

**Dernière mise à jour:** 15.06.2026  
**Version:** 1.0.0 (Stable)  
**État:** ✅ Production Ready
