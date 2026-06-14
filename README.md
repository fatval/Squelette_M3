# Squelette M3 - Application de Gestion de Lots et Recettes

## 📋 Description du Projet

Squelette M3 est une application **Windows Forms** développée en **C#** permettant de gérer des **lots de production**, des **recettes** et un **historique des événements**. L'application utilise une base de données **MySQL** pour la persistance des données et offre une interface utilisateur moderne et intuitive.

### État du Projet (12.06.2026)
✅ **Version stable avec logique fonctionnelle complète**  
✅ **Interface utilisateur moderne et intuitive**  
✅ **Gestion complète des lots, recettes et historique implémentée**  
✅ **Export de données en XML et CSV fonctionnel**  
✅ **Architecture en couches bien structurée**  

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
│   ├── Recette.cs             # Entité Recette
│   └── Evenement.cs           # Entité Événement
│
├── UI/                        # Interface utilisateur (Windows Forms)
│   ├── FormMain.cs            # Formulaire principal avec navigation
│   ├── UserControlRecettes.cs # Gestion des recettes
│   ├── UserControlLots.cs     # Gestion des lots
│   ├── UserControlHistorique.cs # Historique et export des données
│   └── FormCreerRecette.cs    # Formulaire de création/modification de recette
│
├
│
│
├── Program.cs                 # Point d'entrée de l'application
├── Squelette_M3.csproj        # Configuration du projet
└── Squelette_M3.sln           # Solution Visual Studio
```

---

## 🔧 Composants Principaux

### 1. **DataAccessLayer - DBManager.cs**
Classe statique responsable de la gestion de la connexion MySQL.

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `ConnecterABD(nomBaseDonnees, nomUtilisateur, motDePasse)` | Configure la connexion à la base de données |
| `ObtenirConnexion()` | Retourne une nouvelle connexion MySQL |
| `TesterConnexion()` | Teste la connexion à la base de données |

**Propriétés:**
- `_chaussedConnexion` - Chaîne de connexion statique

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
- `CreerLot(nom, quantite, idRecette)` - Crée un nouveau lot avec validation
- `SupprimerLot(idLot)` - Supprime un lot
- `MettreAJourEtatLot(idLot, idEtat)` - Modifie l'état d'un lot

#### **Recette.cs**
Représente une recette avec ses opérations associées.

**Propriétés principales:**
- `Id_Recette` - Identifiant unique
- `REC_Nom` - Nom de la recette
- `REC_DateCreation` - Date de création
- `Operations` - Liste des opérations de la recette

**Méthodes principales:**
- `CreerRecette(nom)` - Crée une nouvelle recette
- `ModifierRecette(idRecette, nom)` - Modifie une recette existante
- `SupprimerRecette(idRecette)` - Supprime une recette avec validation

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
- `_couleurActive` - Couleur active: RGB(0, 120, 215) - Bleu
- `_couleurInactive` - Couleur inactive: RGB(45, 45, 48) - Gris foncé

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `AfficherPage(UserControl)` | Affiche une page dans le panneau principal |
| `DesactiverTousBoutons()` | Réinitialise les couleurs des boutons |
| `BtnRecettes_Click()` | Navigue vers la gestion des recettes |
| `BtnLots_Click()` | Navigue vers la gestion des lots |
| `BtnHistorique_Click()` | Navigue vers l'historique |

#### **UserControlRecettes.cs**
Gestion et affichage des recettes disponibles.

**Fonctionnalités:**
- DataGridView affichant les recettes
- Colonnes: ID, Nom de la recette, Date de création
- Boutons: Ajouter, Modifier, Supprimer
- Confirmation avant suppression

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `ChargerRecettesDGV()` | Charge les recettes depuis la base de données |
| `BtnAjouter_Click()` | Ouvre le formulaire de création |
| `BtnModifier_Click()` | Édite une recette sélectionnée |
| `BtnSupprimer_Click()` | Supprime une recette avec confirmation |
| `SupprimerRecetteAvecLots(idRecette)` | Supprime en cascade (recette + lots + événements) |

#### **UserControlLots.cs**
Gestion complète des lots de production.

**Fonctionnalités:**
- DataGridView affichant les lots
- ComboBox pour sélectionner la recette
- Formulaire de création avec validation complète
- Affichage du statut et de la date de création

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `ChargerRecettes()` | Charge les recettes dans le ComboBox |
| `ChargerLots()` | Affiche tous les lots dans le DataGridView |
| `BtnCreerLot_Click()` | Crée un nouveau lot avec validation |
| `RafraichirAffichage()` | Recharge l'affichage des lots |

**Helper Class:**
```csharp
/// <summary>
/// Classe utilitaire pour l'affichage des recettes dans le ComboBox
/// </summary>
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
- Recherche temps réel par nom ou ID
- Affichage des détails d'un lot (double-clic)
- Export en XML et CSV
- Rafraîchissement manuel des données

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
- `_operationsEnCours` - Liste des opérations en cours d'édition
- `_recetteIdAModifier` - ID de la recette en modification (-1 si création)

**Méthodes principales:**
| Méthode | Description |
|---------|-------------|
| `RafraichirGrille()` | Synchronise l'affichage avec les données |
| `BtnAjouterOperation_Click()` | Ajoute une opération (max 10) |
| `BtnSupprimerOperation_Click()` | Supprime l'opération sélectionnée |
| `SynchroniserDepuisGrille()` | Récupère les données du formulaire |
| `BtnEnregistrer_Click()` | Enregistre la recette en base de données |

---

## 📦 Dépendances

- **Framework:** .NET Framework / C# (Windows Desktop Application)
- **MySQL.Data** - Connecteur MySQL pour C# (version 8.0+)
- **System.Windows.Forms** - Interface utilisateur
- **System.Drawing** - Gestion des couleurs et du rendu
- **System.Xml** - Sérialisation XML pour les exports

---

## 🗄️ Base de Données MySQL

Tables principales utilisées:

| Table | Description |
|-------|-------------|
| `lot` | Enregistre les lots de production |
| `recette` | Contient les recettes disponibles |
| `operation` | Opérations associées à chaque recette |
| `evenement` | Historique des événements par lot |
| `etat` | États possibles (En attente, En cours, Terminé, Erreur) |

**Exemple de requête:**
```sql
SELECT 
    l.Id_Lot, 
    l.LOT_Nom, 
    l.LOT_Quantite, 
    r.REC_Nom, 
    l.LOT_DateHeureCreation, 
    e.ETA_Libelle
FROM lot l
JOIN recette r ON l.Id_Recette = r.Id_Recette
JOIN etat e ON l.Id_Etat = e.Id_Etat
ORDER BY l.LOT_DateHeureCreation DESC;
```

---

## 🚀 Installation et Configuration

### Prérequis
- Visual Studio 2019 ou supérieur
- .NET Framework 4.7.2 ou supérieur
- MySQL Server 8.0+ (port 3306 par défaut)
- Base de données configurée avec les tables

### Étapes d'installation
1. **Cloner le repository**
   ```bash
   git clone https://github.com/fatval/Squelette_M3.git
   cd Squelette_M3
   ```

2. **Ouvrir le projet**
   - Ouvrir `Squelette_M3.sln` dans Visual Studio

3. **Restaurer les dépendances NuGet**
   - Menu: Outils → Gestionnaire de packages NuGet → Console du Gestionnaire de packages
   - Exécuter: `Update-Package -Reinstall`

4. **Configurer les paramètres MySQL**
   - Créer la base de données MySQL
   - Importer le schéma de tables

5. **Compiler et exécuter**
   - Appuyer sur `F5` ou cliquer sur "Démarrer le débogage"

### Configuration de la Connexion MySQL
```csharp
// Dans Program.cs au démarrage de l'application
DBManager.ConncterABD("m3", "root", ""); // (base, utilisateur, mot_de_passe)

// Ou avec connexion personnalisée
DBManager.ConncterABD("nomBaseDonnees", "nomUtilisateur", "motDePasse");
```

---

## ✅ Checklist de Refactorisation

### Nettoyage du Code
- ✅ **Fonctions:** Éviter les répétitions
  - ✅ Extraire les patterns communes
  - ✅ Utiliser des méthodes utilitaires génériques
- ✅ **Variables:** Enlever les variables temporaires
  - ✅ Vérifier les variables non utilisées
  - ✅ Optimiser la portée des variables

### Cohérence et Standards
- ✅ **Traduction:** Traduire les noms de fonctions en français
  - ✅ `ChargerRecettes()` - Déjà français
  - ✅ `ObtenirConnexion()` - Traduit de `GetConnection()`
  - ✅ `TesterConnexion()` - Français
  - ✅ `ConncterABD()` - Traduit de `ConnectToDB()`
    
- ✅ **Noms de variables:** Cohérence appliquée
  - ✅ `_couleurActive` - Clairement nommée
  - ✅ `_couleurInactive` - Cohérent avec les couleurs
  - ✅ Préfixes/suffixes cohérents appliqués

- ✅ **Mise en forme du code:** Signature standard appliquée
  ```csharp
  /// <summary>
  /// Description concise et claire de la méthode
  /// </summary>
  /// <param name="nom">Description du paramètre</param>
  /// <returns>Description de la valeur retournée</returns>
  /// <remarks>
  /// Auteur: Valentin
  /// Date: JJ.MM.YYYY
  /// Description: Détails additionnels de l'implémentation
  /// </remarks>
  public static void CreerLot(string nom, int quantite)
  {
      // Implémentation...
  }
  ```

---

## 💡 Bonnes Pratiques et Standards du Projet

### Convention de Nommage
| Type | Convention | Exemple |
|------|-----------|---------|
| Classes/Fichiers | PascalCase | `FormMain.cs`, `DBManager.cs` |
| Méthodes publiques | PascalCase | `ChargerLots()`, `MettreAJourEtatLot()` |
| Variables privées | camelCase avec _ | `_chaussedConnexion`, `_couleurActive` |
| Propriétés | PascalCase | `Id_Lot`, `REC_Nom` |
| Constantes | UPPER_SNAKE_CASE | `_CHAUSSEDE_CONNEXION_DEFAUT` |
| Paramètres | camelCase | `nom`, `quantite`, `idRecette` |

### Documentation du Code
```csharp
/// <summary>
/// Description concise et claire de la méthode
/// </summary>
/// <param name="nom">Description du paramètre</param>
/// <param name="quantite">Autre paramètre</param>
/// <returns>Description de la valeur retournée</returns>
/// <remarks>
/// Auteur: Valentin
/// Date: 08.06.2026
/// Détails: Crée un lot dans la base de données avec validation
/// </remarks>
public static void CreerLot(string nom, int quantite)
{
    // Implémentation...
}
```

### Langage des Commentaires
✅ **FRANÇAIS** - Tous les commentaires et documentation en français  
(Voir `.github/copilot-instructions.md`)

### Langage de Programmation
✅ **C#** - Langage principal pour toute implémentation  
✅ **SQL** - Pour les requêtes de base de données  
✅ **XML/CSV** - Pour les exports de données  

### Séparation des Responsabilités (Layered Architecture)
```
┌─────────────────────────────────────┐
│         Interface (UI Layer)        │  UserControlXxx.cs, FormXxx.cs
│    Affichage, événements utilisateur│
│  Responsabilité: Présentation       │
└──────────────┬──────────────────────┘
               │
┌──────────────┴──────────────────────┐
│      Business Logic / Métier        │  Lot.cs, Recette.cs, Evenement.cs
│  Validation, calculs, règles métier │
│  Responsabilité: Logique métier     │
└──────────────┬──────────────────────┘
               │
┌──────────────┴──────────────────────┐
│     Data Access Layer (DAL)         │  DBManager.cs
│  Opérations MySQL, connexions       │
│  Responsabilité: Persistance        │
└─────────────────────────────────────┘
```

### Pratiques de Développement
- ✅ Pas de logique métier dans les formulaires
- ✅ Validation des données à l'entrée
- ✅ Gestion appropriée des exceptions
- ✅ Closes en cascade pour les suppressions (recette → lots → événements)
- ✅ Confirmation de l'utilisateur pour les opérations destructrices
- ✅ Actualisation automatique de l'interface après modifications

---

## 🔗 Ressources Utiles

- **Repository GitHub:** [fatval/Squelette_M3](https://github.com/fatval/Squelette_M3)
- **Directives Copilot:** `.github/copilot-instructions.md`
- **Documentation MySQL:** [MySQL 8.0 Reference](https://dev.mysql.com/doc/refman/8.0/en/)
- **Microsoft Docs - Windows Forms:** [docs.microsoft.com/windows-forms](https://docs.microsoft.com/en-us/dotnet/desktop/winforms)

---

## 📜 Historique des Modifications

| Date | Auteur | Description |
|------|--------|-------------|
| 18.05.2026 | Valentin | Implémentation initiale - version stable |
| 08.06.2026 | Copilot | Mise à jour détaillée du README |
| 12.06.2026 | Copilot & ESnoea | Mise à jour complète avec refactorisation et standards |

---

## 👥 Équipe de Développement

- **Valentin** - Logique métier et interface utilisateur
- **Noé (ESnoea)** - Refactorisation, architecture, cohérence du code
- **Copilot** - Assistance au développement et documentation

---

**Dernière mise à jour:** 12.06.2026  
**Version:** 1.0.0 (Stable)  
**État:** ✅ Production Ready
