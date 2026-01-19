using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System.Text.RegularExpressions;


namespace BlazorGrid.Data
{
    public class OrderDataService
    {
        public List<OrderData> GetOrders()
        {
            List<OrderData> orders = new();
            string[] productValues = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] products = { "Chai", "Chang", "Aniseed Syrup", "Chef Anton\'s Cajun Seasoning", "Chef Anton\'s Gumbo Mix", "Grandma\'s Boysenberry Spread",
        "Uncle Bob\'s Organic Dried Pears", "Northwoods Cranberry Sauce", "Mishi Kobe Niku", "Ikura", "Queso Cabrales", "Queso Manchego La Pastora", "Konbu",
        "Tofu", "Genen Shouyu", "Pavlova", "Alice Mutton", "Carnarvon Tigers", "Teatime Chocolate Biscuits", "Sir Rodney\'s Marmalade", "Sir Rodney\'s Scones",
        "Gustaf\'s Knäckebröd", "Tunnbröd", "Guaraná Fantástica", "NuNuCa Nuß-Nougat-Creme", "Gumbär Gummibärchen", "Schoggi Schokolade", "Rössle Sauerkraut",
        "Thüringer Rostbratwurst", "Nord-Ost Matjeshering", "Gorgonzola Telino", "Mascarpone Fabioli", "Geitost", "Sasquatch Ale", "Steeleye Stout", "Inlagd Sill",
        "Gravad lax", "Côte de Blaye", "Chartreuse verte", "Boston Crab Meat", "Jack\'s New England Clam Chowder", "Singaporean Hokkien Fried Mee", "Ipoh Coffee",
        "Gula Malacca", "Rogede sild", "Spegesild", "Zaanse koeken", "Chocolade", "Maxilaku", "Valkoinen suklaa", "Manjimup Dried Apples", "Filo Mix", "Perth Pasties",
        "Tourtière", "Pâté chinois", "Gnocchi di nonna Alice", "Ravioli Angelo", "Escargots de Bourgogne", "Raclette Courdavault", "Camembert Pierrot", "Sirop d\'érable",
        "Tarte au sucre", "Vegie-spread", "Wimmers gute Semmelknödel", "Louisiana Fiery Hot Pepper Sauce", "Louisiana Hot Spiced Okra", "Laughing Lumberjack Lager", "Scottish Longbreads",
        "Gudbrandsdalsost", "Outback Lager", "Flotemysost", "Mozzarella di Giovanni", "Röd Kaviar", "Longlife Tofu", "Rhönbräu Klosterbier", "Lakkalikööri", "Original Frankfurter grüne Soße" };
        string[] customerNames = ["Maria", "Ana Trujillo", "Antonio Moreno", "Thomas Hardy", "Christina Berglund", "Hanna Moos", "Frédérique Citeaux", "Martín Sommer", "Laurence Lebihan", "Elizabeth Lincoln",
        "Victoria Ashworth", "Patricio Simpson", "Francisco Chang", "Yang Wang", "Pedro Afonso", "Elizabeth Brown", "Sven Ottlieb", "Janine Labrune", "Ann Devon", "Roland Mendel", "Aria Cruz", "Diego Roel",
        "Martine Rancé", "Maria Larsson", "Peter Franken", "Carine Schmitt", "Paolo Accorti", "Lino Rodriguez", "Eduardo Saavedra", "José Pedro Freyre", "André Fonseca", "Howard Snyder", "Manuel Pereira",
        "Mario Pontes", "Carlos Hernández", "Yoshi Latimer", "Patricia McKenna", "Helen Bennett", "Philip Cramer", "Daniel Tonini", "Annette Roulet", "Yoshi Tannamuri", "John Steel", "Renate Messner", "Jaime Yorres",
        "Carlos González", "Felipe Izquierdo", "Fran Wilson", "Giovanni Rovelli", "Catherine Dewey", "Jean Fresnière", "Alexander Feuer", "Simon Crowther", "Yvonne Moncada", "Rene Phillips", "Henriette Pfalzheim",
        "Marie Bertrand", "Guillermo Fernández", "Georg Pipps", "Isabel de Castro", "Bernardo Batista", "Lúcia Carvalho", "Horst Kloss", "Sergio Gutiérrez", "Paula Wilson", "Maurizio Moroni", "Janete Limeira", "Michael Holz",
        "Alejandra Camino", "Jonas Bergulfsen", "Jose Pavarotti", "Hari Kumar", "Jytte Petersen", "Dominique Perrier", "Art Braunschweiger", "Pascale Cartrain", "Liz Nixon", "Liu Wong", "Karin Josephs", "Miguel Angel Paolino",
        "Anabela Domingues", "Helvetius Nagy", "Palle Ibsen", "Mary Saveley", "Paul Henriot", "Rita Müller", "Pirkko Koskitalo", "Paula Parente", "Karl Jablonski", "Matti Karttunen", "Zbyszek Piestrzeniewicz"];
        string[] femaleNames = [
        "Maria", "Ana Trujillo", "Christina Berglund", "Hanna Moos", "Frédérique Citeaux",
        "Laurence Lebihan", "Elizabeth Lincoln", "Victoria Ashworth", "Ann Devon",
        "Aria Cruz", "Martine Rancé", "Maria Larsson", "Carine Schmitt", "Elizabeth Brown",
        "Janine Labrune", "Annette Roulet", "Yoshi Tannamuri", "Renate Messner",
        "Catherine Dewey", "Jean Fresnière", "Yvonne Moncada", "Henriette Pfalzheim",
        "Marie Bertrand", "Isabel de Castro", "Lúcia Carvalho", "Paula Wilson",
        "Janete Limeira", "Alejandra Camino", "Jytte Petersen", "Dominique Perrier",
        "Pascale Cartrain", "Liz Nixon", "Karin Josephs", "Anabela Domingues",
        "Mary Saveley", "Rita Müller", "Pirkko Koskitalo", "Paula Parente"
    ];
        string[] maleNames = [
            "Antonio Moreno", "Thomas Hardy", "Martín Sommer", "Patricio Simpson",
        "Francisco Chang", "Yang Wang", "Pedro Afonso", "Sven Ottlieb", "Peter Franken",
        "Paolo Accorti", "Lino Rodriguez", "Eduardo Saavedra", "José Pedro Freyre",
        "André Fonseca", "Howard Snyder", "Manuel Pereira", "Mario Pontes",
        "Carlos Hernández", "Yoshi Latimer", "Philip Cramer", "Daniel Tonini",
        "John Steel", "Jaime Yorres", "Carlos González", "Felipe Izquierdo",
        "Giovanni Rovelli", "Alexander Feuer", "Simon Crowther", "Rene Phillips",
        "Guillermo Fernández", "Georg Pipps", "Bernardo Batista", "Horst Kloss",
        "Sergio Gutiérrez", "Maurizio Moroni", "Michael Holz", "Jonas Bergulfsen",
        "Jose Pavarotti", "Hari Kumar", "Art Braunschweiger", "Liu Wong",
        "Miguel Angel Paolino", "Helvetius Nagy", "Palle Ibsen", "Paul Henriot",
        "Karl Jablonski", "Matti Karttunen", "Zbyszek Piestrzeniewicz"
        ];
        string[] addresses = { "507 - 20th Ave. E.\r\nApt. 2A", "908 W. Capital Way", "722 Moss Bay Blvd.", "4110 Old Redmond Rd.", "14 Garrett Hill", "Coventry House\r\nMiner Rd.", "Edgeham Hollow\r\nWinchester Way",
        "4726 - 11th Ave. N.E.", "7 Houndstooth Rd.", "59 rue de l\"Abbaye", "Luisenstr. 48", "908 W. Capital Way", "722 Moss Bay Blvd.", "4110 Old Redmond Rd.", "14 Garrett Hill", "Coventry House\r\nMiner Rd.", "Edgeham Hollow\r\nWinchester Way",
        "7 Houndstooth Rd.", "2817 Milton Dr.", "Kirchgasse 6", "Sierras de Granada 9993", "Mehrheimerstr. 369", "Rua da Panificadora, 12", "2817 Milton Dr.", "Mehrheimerstr. 369" };
            int[] quantities = { 10, 24, 12, 48, 36, 12, 12, 12, 18, 12, 1, 10, 2, 40, 24, 32, 20, 16, 10, 30, 24, 24, 12, 12, 20, 100 };
            double[] freights = { 11.23, 22.45, 12.37, 9.08, 88.17, 7.05, 120.08, 94.89, 188.82, 64.45, 192.67, 901.78, 876.37, 876.23, 65.56, 11.12, 99.68, 56.78, 89.78, 34.06, 11.09, 98.56, 89.02, 15.45, 45.38, 100.06 };
            string[] shipNames = { "Vins et alcools Chevalier", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices", "Richter Supermarkt", "Wellington Importadora", "HILARION-Abastos", "Ernst Handel", "Centro comercial Moctezuma", "Ottilies Käseladen", "Rattlesnake Canyon Grocery" };
            string[] shipCountries = { "France", "Germany", "Brazil", "Spain", "Switzerland", "Italy" };
            string[] orderStatus = { "Delivered", "Cancelled", "Shipped" };
            double[] rating = { 1.5, 2.5, 3.5, 4.5, 5 };
            int orderID = 10248;
            Random rnd = new();
            double[] femaleIndexes = [1, 3, 4, 8, 9];
            double[] maleIndexes = [2, 5, 6, 7];

            for (int i = 0; i < 10000; i++)
            {
                int randomIndex = rnd.Next(productValues.Length);
                string statusValue = orderStatus[rnd.Next(orderStatus.Length)];
                string customer = customerNames[rnd.Next(customerNames.Length)];
                string gender = femaleNames.Contains(customer) ? "Female" : "Male";
                orders.Add(new OrderData
                {
                    Id = i,
                    ImageIndex = gender == "Female" ? femaleIndexes[rnd.Next(femaleIndexes.Length)] : maleIndexes[rnd.Next(maleIndexes.Length)],
                    EmailID = GenerateEmailID(customer),
                    OrderID = orderID + i,
                    ProductID = productValues[randomIndex] + (100 + i).ToString(),
                    ProductName = products[rnd.Next(products.Length)],
                    CustomerName = customer,
                    Quantity = quantities[rnd.Next(quantities.Length)],
                    Freight = freights[rnd.Next(freights.Length)],
                    ShipName = shipNames[rnd.Next(shipNames.Length)],
                    ShipCountry = shipCountries[rnd.Next(shipCountries.Length)],
                    ShipAddress = addresses[rnd.Next(addresses.Length)],
                    OrderDate = DateTime.Now.AddDays(-rnd.Next(1, 100)),
                    OrderStatus = statusValue,
                    Verified = statusValue == "Delivered" || statusValue == "Shipped" ? true : false,
                    Rating = rating[rnd.Next(rating.Length)],
                    TrackingStatus = statusValue == "Delivered" || statusValue == "Shipped" ? true : false,
                    Genders = gender
                });
            }

            return orders;
        }

        private string GenerateEmailID(string name)
        {
            return Regex.Replace(name, @"\s+", "").ToLower() + "@example.com";
        }

    }
}
