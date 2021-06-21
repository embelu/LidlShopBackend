Scaffold-DbContext "Server=S319SQLT1\DEVSQL319;Database=DB_Formation;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -t Lidl_Categorie_LB, Lidl_Produit_LB, Lidl_Commande_LB, Lidl_DetailCommande_LB -OutputDir Entities -Force

Nugget's nécessaires pour Scaffolding : 
EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design

Nugget nécessaire pour l'automapper :
Install-Package AutoMapper

Package nécessaires pour HealthChecks (accessible via https://localhost:44330/health)
Install-Package Microsoft.Extensions.Diagnostics.HealthChecks
Install-Package Newtonsoft.Json
// Pour vérifications de la connection à une DB via le DB context :
Install-Package Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore   
// Pour vérifications de la disponibilité d'une URL ou d'un fichier externe. 
Install-Package AspNetCore.HealthChecks.Uris