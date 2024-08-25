using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

using System.Runtime.CompilerServices;  // Importation du namespace pour accéder à des fonctionnalités liées à la compilation (non utilisé dans ce code mais peut être nécessaire pour des attributs de compilation ou des méthodes spécifiques)

using hero_csharp.Models;  // Importation du namespace où la classe Hero est définie (redondant ici car le code est dans le même namespace, mais utile si d'autres fichiers utilisent ce namespace)
namespace hero_csharp.Models
{
    public class School
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Cette ligne représente la relation One-to-Many
/*        public List<Hero>? Heroes { get; set; }
*/    }
}