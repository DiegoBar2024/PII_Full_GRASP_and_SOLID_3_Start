using System;
using System.IO;

namespace Full_GRASP_And_SOLID.Library
{
    // Creo una clase FilePrinter la cual implemente la interfaz IPrinter
    // La clase se encargará de imprimir la receta en un archivo de texto
    public class FilePrinter : IPrinter
    {
        // Implemento la operación PrintRecipe definida en la interfaz IPrinter
        public void PrintRecipe(Recipe recipe)
        {
            // Imprimo la receta en un archivo de texto
            File.WriteAllText("Recipe.txt", recipe.GetTextToPrint());
        }
    }
}