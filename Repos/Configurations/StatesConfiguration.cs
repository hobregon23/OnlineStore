using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;

namespace OnlineStore.Repos
{
    public class StatesConfiguration : IEntityTypeConfiguration<Address_State>
    {
        public void Configure(EntityTypeBuilder<Address_State> builder)
        {
            builder.HasData(
new Address_State { Id = 1, Name = "Consolación del Sur", Province_id = 1 },
new Address_State { Id = 2, Name = "Guane", Province_id = 1 },
new Address_State { Id = 3, Name = "La Palma", Province_id = 1 },
new Address_State { Id = 4, Name = "Los Palacios", Province_id = 1 },
new Address_State { Id = 5, Name = "Mantua", Province_id = 1 },
new Address_State { Id = 6, Name = "Minas de Matahambre", Province_id = 1 },
new Address_State { Id = 7, Name = "Pinar del Río", Province_id = 1 },
new Address_State { Id = 8, Name = "San Juan y Martínez", Province_id = 1 },
new Address_State { Id = 9, Name = "San Luis", Province_id = 1 },
new Address_State { Id = 10, Name = "Sandino", Province_id = 1 },
new Address_State { Id = 11, Name = "Viñales", Province_id = 1 },
new Address_State { Id = 12, Name = "Arroyo Naranjo", Province_id = 2 },
new Address_State { Id = 13, Name = "Boyeros", Province_id = 2 },
new Address_State { Id = 14, Name = "Centro Habana", Province_id = 2 },
new Address_State { Id = 15, Name = "Cerro", Province_id = 2 },
new Address_State { Id = 16, Name = "Cotorro", Province_id = 2 },
new Address_State { Id = 17, Name = "Diez de Octubre", Province_id = 2 },
new Address_State { Id = 18, Name = "Guanabacoa", Province_id = 2 },
new Address_State { Id = 19, Name = "La Habana del Este", Province_id = 2 },
new Address_State { Id = 20, Name = "La Habana Vieja", Province_id = 2 },
new Address_State { Id = 21, Name = "La Lisa", Province_id = 2 },
new Address_State { Id = 22, Name = "Marianao", Province_id = 2 },
new Address_State { Id = 23, Name = "Playa", Province_id = 2 },
new Address_State { Id = 24, Name = "Plaza de la Revolución", Province_id = 2 },
new Address_State { Id = 25, Name = "Regla", Province_id = 2 },
new Address_State { Id = 26, Name = "San Miguel del Padrón", Province_id = 2 },
new Address_State { Id = 27, Name = "Alquízar", Province_id = 3 },
new Address_State { Id = 28, Name = "Artemisa", Province_id = 3 },
new Address_State { Id = 29, Name = "Bahía Honda", Province_id = 3 },
new Address_State { Id = 30, Name = "Bauta", Province_id = 3 },
new Address_State { Id = 31, Name = "Caimito", Province_id = 3 },
new Address_State { Id = 32, Name = "Candelaria", Province_id = 3 },
new Address_State { Id = 33, Name = "Guanajay", Province_id = 3 },
new Address_State { Id = 34, Name = "Güira de Melena", Province_id = 3 },
new Address_State { Id = 35, Name = "Mariel", Province_id = 3 },
new Address_State { Id = 36, Name = "San Antonio de los Baños", Province_id = 3 },
new Address_State { Id = 37, Name = "San Cristóbal", Province_id = 3 },
new Address_State { Id = 38, Name = "Batabanó", Province_id = 4 },
new Address_State { Id = 39, Name = "Bejucal", Province_id = 4 },
new Address_State { Id = 40, Name = "Güines", Province_id = 4 },
new Address_State { Id = 41, Name = "Jaruco", Province_id = 4 },
new Address_State { Id = 42, Name = "Madruga", Province_id = 4 },
new Address_State { Id = 43, Name = "Melena del Sur", Province_id = 4 },
new Address_State { Id = 44, Name = "Nueva Paz", Province_id = 4 },
new Address_State { Id = 45, Name = "Quivicán", Province_id = 4 },
new Address_State { Id = 46, Name = "San José de las Lajas", Province_id = 4 },
new Address_State { Id = 47, Name = "San Nicolás", Province_id = 4 },
new Address_State { Id = 48, Name = "Santa Cruz del Norte", Province_id = 4 },
new Address_State { Id = 49, Name = "Calimete", Province_id = 5 },
new Address_State { Id = 50, Name = "Cárdenas", Province_id = 5 },
new Address_State { Id = 51, Name = "Varadero", Province_id = 5 },
new Address_State { Id = 52, Name = "Ciénaga de Zapata", Province_id = 5 },
new Address_State { Id = 53, Name = "Colón", Province_id = 5 },
new Address_State { Id = 54, Name = "Jagüey Grande", Province_id = 5 },
new Address_State { Id = 55, Name = "Jovellanos", Province_id = 5 },
new Address_State { Id = 56, Name = "Limonar", Province_id = 5 },
new Address_State { Id = 57, Name = "Los Arabos", Province_id = 5 },
new Address_State { Id = 58, Name = "Martí", Province_id = 5 },
new Address_State { Id = 59, Name = "Matanzas", Province_id = 5 },
new Address_State { Id = 60, Name = "Pedro Betancourt", Province_id = 5 },
new Address_State { Id = 61, Name = "Perico", Province_id = 5 },
new Address_State { Id = 62, Name = "Unión de Reyes", Province_id = 5 },
new Address_State { Id = 63, Name = "Abreus", Province_id = 6 },
new Address_State { Id = 64, Name = "Aguada de Pasajeros", Province_id = 6 },
new Address_State { Id = 65, Name = "Cienfuegos", Province_id = 6 },
new Address_State { Id = 66, Name = "Cruces", Province_id = 6 },
new Address_State { Id = 67, Name = "Cumanayagua", Province_id = 6 },
new Address_State { Id = 68, Name = "Lajas", Province_id = 6 },
new Address_State { Id = 69, Name = "Palmira", Province_id = 6 },
new Address_State { Id = 70, Name = "Rodas", Province_id = 6 },
new Address_State { Id = 71, Name = "Caibarién", Province_id = 7 },
new Address_State { Id = 72, Name = "Camajuaní", Province_id = 7 },
new Address_State { Id = 73, Name = "Cifuentes", Province_id = 7 },
new Address_State { Id = 74, Name = "Corralillo", Province_id = 7 },
new Address_State { Id = 75, Name = "Encrucijada", Province_id = 7 },
new Address_State { Id = 76, Name = "Manicaragua", Province_id = 7 },
new Address_State { Id = 77, Name = "Placetas", Province_id = 7 },
new Address_State { Id = 78, Name = "Quemado de Güines", Province_id = 7 },
new Address_State { Id = 79, Name = "Ranchuelo", Province_id = 7 },
new Address_State { Id = 80, Name = "San Juan de los Remedios", Province_id = 7 },
new Address_State { Id = 81, Name = "Sagua la Grande", Province_id = 7 },
new Address_State { Id = 82, Name = "Santa Clara", Province_id = 7 },
new Address_State { Id = 83, Name = "Santo Domingo", Province_id = 7 },
new Address_State { Id = 84, Name = "Cabaiguán", Province_id = 8 },
new Address_State { Id = 85, Name = "Fomento", Province_id = 8 },
new Address_State { Id = 86, Name = "Jatibonico", Province_id = 8 },
new Address_State { Id = 87, Name = "La Sierpe", Province_id = 8 },
new Address_State { Id = 88, Name = "Sancti Spíritus", Province_id = 8 },
new Address_State { Id = 89, Name = "Taguasco", Province_id = 8 },
new Address_State { Id = 90, Name = "Trinidad", Province_id = 8 },
new Address_State { Id = 91, Name = "Yaguajay", Province_id = 8 },
new Address_State { Id = 92, Name = "Baraguá", Province_id = 9 },
new Address_State { Id = 93, Name = "Bolivia", Province_id = 9 },
new Address_State { Id = 94, Name = "Chambas", Province_id = 9 },
new Address_State { Id = 95, Name = "Ciego de Ávila", Province_id = 9 },
new Address_State { Id = 96, Name = "Ciro Redondo", Province_id = 9 },
new Address_State { Id = 97, Name = "Florencia", Province_id = 9 },
new Address_State { Id = 98, Name = "Majagua", Province_id = 9 },
new Address_State { Id = 99, Name = "Morón", Province_id = 9 },
new Address_State { Id = 100, Name = "Primero de Enero", Province_id = 9 },
new Address_State { Id = 101, Name = "Venezuela", Province_id = 9 },
new Address_State { Id = 102, Name = "Camagüey", Province_id = 10 },
new Address_State { Id = 103, Name = "Carlos M. de Céspedes", Province_id = 10 },
new Address_State { Id = 104, Name = "Esmeralda", Province_id = 10 },
new Address_State { Id = 105, Name = "Florida", Province_id = 10 },
new Address_State { Id = 106, Name = "Guáimaro", Province_id = 10 },
new Address_State { Id = 107, Name = "Jimaguayú", Province_id = 10 },
new Address_State { Id = 108, Name = "Minas", Province_id = 10 },
new Address_State { Id = 109, Name = "Najasa", Province_id = 10 },
new Address_State { Id = 110, Name = "Nuevitas", Province_id = 10 },
new Address_State { Id = 111, Name = "Santa Cruz del Sur", Province_id = 10 },
new Address_State { Id = 112, Name = "Sibanicú", Province_id = 10 },
new Address_State { Id = 113, Name = "Sierra de Cubitas", Province_id = 10 },
new Address_State { Id = 114, Name = "Vertientes", Province_id = 10 },
new Address_State { Id = 115, Name = "Amancio", Province_id = 11 },
new Address_State { Id = 116, Name = "Colombia", Province_id = 11 },
new Address_State { Id = 117, Name = "Jesús Menéndez", Province_id = 11 },
new Address_State { Id = 118, Name = "Jobabo", Province_id = 11 },
new Address_State { Id = 119, Name = "Las Tunas", Province_id = 11 },
new Address_State { Id = 120, Name = "Majibacoa", Province_id = 11 },
new Address_State { Id = 121, Name = "Manatí", Province_id = 11 },
new Address_State { Id = 122, Name = "Puerto Padre", Province_id = 11 },
new Address_State { Id = 123, Name = "Bartolomé Masó", Province_id = 12 },
new Address_State { Id = 124, Name = "Bayamo", Province_id = 12 },
new Address_State { Id = 125, Name = "Buey Arriba", Province_id = 12 },
new Address_State { Id = 126, Name = "Campechuela", Province_id = 12 },
new Address_State { Id = 127, Name = "Cauto Cristo", Province_id = 12 },
new Address_State { Id = 128, Name = "Guisa", Province_id = 12 },
new Address_State { Id = 129, Name = "Jiguaní", Province_id = 12 },
new Address_State { Id = 130, Name = "Manzanillo", Province_id = 12 },
new Address_State { Id = 131, Name = "Media Luna", Province_id = 12 },
new Address_State { Id = 132, Name = "Niquero", Province_id = 12 },
new Address_State { Id = 133, Name = "Pilón", Province_id = 12 },
new Address_State { Id = 134, Name = "Río Cauto", Province_id = 12 },
new Address_State { Id = 135, Name = "Yara", Province_id = 12 },
new Address_State { Id = 136, Name = "Contramaestre", Province_id = 13 },
new Address_State { Id = 137, Name = "Guamá", Province_id = 13 },
new Address_State { Id = 138, Name = "Mella", Province_id = 13 },
new Address_State { Id = 139, Name = "Palma Soriano", Province_id = 13 },
new Address_State { Id = 140, Name = "San Luis", Province_id = 13 },
new Address_State { Id = 141, Name = "Santiago de Cuba", Province_id = 13 },
new Address_State { Id = 142, Name = "Segundo Frente", Province_id = 13 },
new Address_State { Id = 143, Name = "Songo-La Maya", Province_id = 13 },
new Address_State { Id = 144, Name = "Tercer Frente", Province_id = 13 },
new Address_State { Id = 145, Name = "Antilla", Province_id = 14 },
new Address_State { Id = 146, Name = "Báguanos", Province_id = 14 },
new Address_State { Id = 147, Name = "Banes", Province_id = 14 },
new Address_State { Id = 148, Name = "Cacocum", Province_id = 14 },
new Address_State { Id = 149, Name = "Calixto García", Province_id = 14 },
new Address_State { Id = 150, Name = "Cueto", Province_id = 14 },
new Address_State { Id = 151, Name = "Frank País", Province_id = 14 },
new Address_State { Id = 152, Name = "Gibara", Province_id = 14 },
new Address_State { Id = 153, Name = "Holguín", Province_id = 14 },
new Address_State { Id = 154, Name = "Mayarí", Province_id = 14 },
new Address_State { Id = 155, Name = "Moa", Province_id = 14 },
new Address_State { Id = 156, Name = "Rafael Freyre", Province_id = 14 },
new Address_State { Id = 157, Name = "Sagua de Tánamo", Province_id = 14 },
new Address_State { Id = 158, Name = "Urbano Noris", Province_id = 14 },
new Address_State { Id = 159, Name = "Baracoa", Province_id = 15 },
new Address_State { Id = 160, Name = "Caimanera", Province_id = 15 },
new Address_State { Id = 161, Name = "El Salvador", Province_id = 15 },
new Address_State { Id = 162, Name = "Guantánamo", Province_id = 15 },
new Address_State { Id = 163, Name = "Imías", Province_id = 15 },
new Address_State { Id = 164, Name = "Maisí", Province_id = 15 },
new Address_State { Id = 165, Name = "Manuel Tames", Province_id = 15 },
new Address_State { Id = 166, Name = "Niceto Pérez", Province_id = 15 },
new Address_State { Id = 167, Name = "San Antonio del Sur", Province_id = 15 },
new Address_State { Id = 168, Name = "Yateras", Province_id = 15 }
                );
        }
    }
}
