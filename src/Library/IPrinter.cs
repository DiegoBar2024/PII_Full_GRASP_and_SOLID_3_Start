using System;

namespace Full_GRASP_And_SOLID.Library
{
    // Creo una interfaz IPrinter
    public interface IPrinter
    {
        // Defino una operación PrintRecipe
        void PrintRecipe(Recipe recipe);
    }
}