using System;

namespace Full_GRASP_And_SOLID.Library
{
    // Creo una clase ConsolePrinter la cual implemente la interfaz IPrinter
    // La clase se encargará de imprimir la receta en consola
    public class ConsolePrinter : IPrinter
    {
        // Implemento la operación PrintRecipe definida en la interfaz IPrinter
        public void PrintRecipe(Recipe recipe)
        {
            // Imprimo la receta en consola
            Console.WriteLine(recipe.GetTextToPrint());
        }
    }
}