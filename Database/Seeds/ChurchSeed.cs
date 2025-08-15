using Microsoft.EntityFrameworkCore;
using SMJRegisterAPI.Entities;
using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Database.Seeds
{
    public class ChurchSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            int id = 1;
            var churches = new List<Church>();
            #region Sur
            // Sur
            var surChurches = new[]
            {
                "El Valle",
                "Higüey I",
                "Higüey II",
                "Magua",
                "Romana I (Central)",
                "Romana II, Quisqueya",
                "Romana III, (Casa de Alabanzas)",
                "Romana IV, Villa Progreso",
                "Romana V, La Lechoza",
                "Romana VI, Barrio George",
                "Romana VII, Piedra Linda",
                "Romana VIII",
                "Romana IX",
                "Romana X",
                "Romana XI (Benjamín)",
                "Sabana de la Mar",
                "San Pedro I, Central",
                "San Pedro II, Villa Olímpica",
                "San Pedro IV (Canaan) - Capilla S. Pedro II",
                "San Pedro III, Barrio Miramar",
                "Azua Central",
                "Azua, Finca 6",
                "Azua, Finca Etnico",
                "Azua, Las Charcas (Étnico)",
                "Azua, Sector El Hoyo",
                "Baní",
                "Bani, El Fundo - Capilla Bani",
                "Barahona",
                "Elías Piña",
                "Ocoa Etnico",
                "San Cristóbal",
                "San Cristóbal (Étnico)",
                "San Cristóbal Étnico II",
                "San José de Ocoa",
                "San Juan I (Central)",
                "San Juan II - Casa de Adoración",
                "San Juan III (El Renuevo)",
                "Alma Rosa Primera",
                "Carretera Mella (Luz en las Tinieblas)",
                "Ens. Isabelita",
                "Ensanche Cancela (Étnico)",
                "Ensanche Ozama",
                "Mendoza (Capilla Ozama",
                "Invivienda",
                "Villa Esfuerzo - Capilla Invivienda",
                "Los Frailes I",
                "Los Mina",
                "Los Tres Brazos",
                "Los Tres Ojos",
                "Urbanización Ciudad Juan Bosch",
                "Urbanización Lomisa",
                "Valiente  (Étnico)",
                "Villa Faro",
                "Villa Mella, Buena Vista II.",
                "Villa Mella, El Edén",
                "Villa Mella, Guaricano Étnico",
                "Villa Mella, Vista Bella III",
                "Casa del Padre - Hotel Golden House",
                "Cristo Rey",
                "Ensanche La Fe",
                "Ensanche Luperón",
                "Ensanche Quisqueya",
                "Arroyo Bonito - Capilla Quisqueya",
                "Haina Étnico",
                "Boca Nigua - Capilla Haina Boca Etnico",
                "Haina Shalom",
                "Herrera - Barrio Enriquillo",
                "Palmarejo - Capilla Herrera",
                "Jardines del Norte",
                "Jesús el Mesías, (La 15) Barrio 27 de Febrero",
                "Juan de Morfa (Central)",
                "Km 24 , Barrio Eduardo Brito, Autop. Duarte",
                "Km.24 Etnico - Capilla",
                "Manoguayabo - Hato Nuevo",
                "Nación Santa, Enriquillo",
                "Haina Balsequillo - Capilla N. Santa",
                "Majagual, Sabana Perdida - Capilla N. Santa",
                "Pantoja",
                "Roca Mar, En Su presencia",
                "Constanza - Capilla En Su presencia",
                "Simon Bolivar",
                "Villa Linda - Ciudad Satelite - Capilla"
            };
            churches.AddRange(surChurches.Select(name => new Church
            {
                ID = id++,
                Name = name,
                Conference = Conference.Sureste
            }));
            #endregion
            
            #region Noroeste
            var noroesteChurches = new[]
            {
                "Beller",
                "Camboya",
                "Canca La Piedra",
                "Casa de Reposo",
                "Casa Viva",
                "Cien Fuegos",
                "El Ingenio",
                "El INVI",
                "El Paraíso",
                "Ensanche Libertad",
                "Ensanche Mella",
                "Hoya del Caimito",
                "La Herradura",
                "Los Cerritos",
                "Los Cocos",
                "Los Jardines",
                "Monte Bonito",
                "Navarrete",
                "Palmar Arriba",
                "Pekín",
                "Puesto Grande",
                "Tamboril",
                "Castañuelas",
                "Cerro Gordo",
                "Damajagua",
                "El Pocito",
                "Esperanza 1",
                "Esperanza Manantial de Vida",
                "Esperanza Paraíso",
                "Hatico, Mao",
                "Hatillo Palma",
                "Hato Nuevo",
                "Jaibón",
                "Loma de Cabrera",
                "Los Tomines",
                "Maizal",
                "Mao Central",
                "Martín García",
                "Monte Cristi 1",
                "Monte Cristi 2",
                "Monte Cristi 3",
                "Ranchadero",
                "Santiago Rodríguez",
                "Villa Sinda",
                "Villa Vásquez",
                "Altamira",
                "Bethel",
                "Cabía",
                "Caonao",
                "El Tabernáculo",
                "Guananico",
                "Imbert",
                "La Balsa",
                "La Escalereta",
                "La Isabela",
                "La Jagua",
                "Las Canas",
                "Luperón",
                "Navas",
                "Palmarito",
                "Proyecto Ama",
                "Puerto Plata Central",
                "Rincón",
                "San Marcos"
            };
            churches.AddRange(noroesteChurches.Select(name => new Church
            {
                ID = id++,
                Name = name,
                Conference = Conference.Noroeste
            }));
            #endregion

            #region Central
            var centralChurches = new[]
            {
                "San Francisco Central",
                "Piantini",
                "Ventura Grullon",
                "Cotuí",
                "La Bija",
                "La Espínola",
                "La Enea",
                "La Soledad",
                "Vista del Valle SFM",
                "Pimentel",
                "Villa Arriba",
                "El Indio",
                "Castillo",
                "Bonao",
                "La Vega",
                "Palmarito",
                "Salcedo",
                "Bayacanes",
                "Moca",
                "IML de la Majagua",
                "IML de Sánchez",
                "IML de las Terrenas",
                "IML de Samaná",
                "IML de los Corales",
                "IML de Arroyo Hondo",
                "IML de la Ceiba",
                "IML de la Pascuala",
                "IML de los Robalos",
                "IML del Catey",
                "IML del Limón",
                "Nagua central",
                "Telanza",
                "Km3",
                "El Yayal",
                "Matancitas",
                "Sabaneta",
                "Las 500tas",
                "Bella Vista",
                "El Juncal",
                "Baoba del piñal",
                "Baoba central",
                "La Entrada",
                "Los rincones",
                "Los naranjos",
                "Las gordas",
                "Boba",
                "La Cienega",
                "Abreu"
            };
            churches.AddRange(centralChurches.Select(name => new Church
            {
                ID = id++,
                Name = name,
                Conference = Conference.Central
            }));
            #endregion

            modelBuilder.Entity<Church>().HasData(churches);
        }
    }
}
