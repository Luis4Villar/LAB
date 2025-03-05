using Persona.Domain;
using Persona.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Persona.Infrastructure.Repository
{
	public class PersonaRepository: IPersonaRepository
	{
        private readonly PersonaContext context;
        public PersonaRepository(PersonaContext context)
        {
            this.context = context;
        }
        public async Task<List<ListaPersona>> GetAll()
        {
            return await context.ListaPersona.ToListAsync();
        }

        public async Task<ListaPersona> GetByDocumento(string numeroDocumento)
        {
            return await context.ListaPersona.FirstOrDefaultAsync(p => p.numeroDocumento == numeroDocumento);
        }

        public async Task<List<ListaPersona>> GetByTipoUsuario(string tipoUsuario)
        {
            return await context.ListaPersona
                                .Where(p => p.tipoUsuario == tipoUsuario)
                                .ToListAsync();
        }

        public async Task<bool> UpdatePersonaByDocumento(string numeroDocumento, ListaPersona persona)
        {
            var existingPersona = await context.ListaPersona
                .FirstOrDefaultAsync(p => p.numeroDocumento == numeroDocumento);

            if (existingPersona == null)
                return false;

            // Actualizar propiedades
            existingPersona.tipoDocumento = persona.tipoDocumento;
            existingPersona.nombre = persona.nombre;
            existingPersona.apellidoUno = persona.apellidoUno;
            existingPersona.apellidoDos = persona.apellidoDos;
            existingPersona.direccion = persona.direccion;
            existingPersona.telefono = persona.telefono;
            existingPersona.correo = persona.correo;
            existingPersona.fechaNacimiento = persona.fechaNacimiento;
            existingPersona.tipoUsuario = persona.tipoUsuario;

            try
            {
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                // Capturar errores específicos de validación
                var errores = ex.EntityValidationErrors
                    .SelectMany(e => e.ValidationErrors)
                    .Select(e => $"Propiedad: {e.PropertyName}, Error: {e.ErrorMessage}")
                    .ToList();

                // Mostrar errores en la consola (opcional: loguear en archivo o DB)
                Console.WriteLine("Errores de validación:");
                errores.ForEach(Console.WriteLine);

                // También podrías lanzar una excepción con más detalles
                throw new Exception("Errores de validación: " + string.Join(" | ", errores));
            }
        }
        public async Task<bool> AddPersona(ListaPersona nuevaPersona)
        {
            context.ListaPersona.Add(nuevaPersona);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeletePersonaByDocumento(string numeroDocumento)
        {
            var persona = await context.ListaPersona.FirstOrDefaultAsync(p => p.numeroDocumento == numeroDocumento);
            if (persona == null)
            {
                return false;
            }

            context.ListaPersona.Remove(persona);
            await context.SaveChangesAsync();
            return true;
        }





    }
}