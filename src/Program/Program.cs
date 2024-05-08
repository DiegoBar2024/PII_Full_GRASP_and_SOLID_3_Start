//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static ArrayList productCatalog = new ArrayList();

        private static ArrayList equipmentCatalog = new ArrayList();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = GetProduct("Café con leche");
            recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));

            // AllInOnePrinter printer = new AllInOnePrinter();
            // printer.PrintRecipe(recipe, Destination.Console);
            // printer.PrintRecipe(recipe, Destination.File);

            // Creo una variable printer del tipo IPrinter
            IPrinter printer;

            // Asigno la variable printer del tipo IPrinter a una instancia de la clase ConsolePrinter
            printer = new ConsolePrinter();

            // Uso el metodo PrintTicket implementado en ConsolePrinter para hacer la impresión en consola
            printer.PrintRecipe(recipe);

            // Asigno la variable printer del tipo IPrinter a una instancia de la clase FilePrinter
            printer = new FilePrinter();

            // Uso el metodo PrintTicket implementado en FilePrinter para hacer la impresión en un archivo de texto
            printer.PrintRecipe(recipe);
        }

        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }

        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        private static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        private static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
    }
}

/*
Para asignar las responsabilidades de la impresión de la receta en consola o en un archivo de texto, se usa el patron Polimorfismo.
Se obtiene una operación polimórfica PrintRecipe definida (pero no implementada) en la interfaz IPrinter
Dicha operación tiene dos implementaciones diferentes en las clases ConsolePrinter y FilePrinter según el destino de la impresión de la receta
Al tener un mismo nombre y dos comportamientos diferentes se justifica el hecho de que ésta es una operación polimórfica
*/
