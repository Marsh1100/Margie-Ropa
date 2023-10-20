using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class ApiDbContextSeed
{
    public static async Task SeedAsync(ApiDbContext context, ILoggerFactory loggerFactory)
    {
         try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Rol>
                {
                    new() { Name = "Administrator" },
                    new() { Name = "Employee" },
                    new() { Name = "WithoutRol" }
                };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
            if (!context.Paises.Any())
            {
                var paises = new List<Pais>
                {
                    new() { Nombre = "Colombia" },
                };
                context.Paises.AddRange(paises);
                await context.SaveChangesAsync();
            }
            if (!context.Departamentos.Any())
            {
                var list = new List<Departamento>
                {
                    new() { Nombre = "Santander",
                            PaisId= 1},
                };
                context.Departamentos.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.Municipios.Any())
            {
                var municipios = new List<Municipio>
                {
                    new() { Nombre = "Bucaramanga",
                            DepartamentoId= 1},
                    new() { Nombre = "Floridablanca",
                            DepartamentoId= 1},
                    new() { Nombre = "Giron",
                            DepartamentoId= 1}
                };
                context.Municipios.AddRange(municipios);
                await context.SaveChangesAsync();
            }
            if (!context.TipoPersonas.Any())
            {
                var list = new List<TipoPersona>
                {
                    new() { Nombre = "Natural" },
                    new() { Nombre = "Jurídica" }

                };
                context.TipoPersonas.AddRange(list);
                await context.SaveChangesAsync();
            }
        }catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiDbContext>();
            logger.LogError(ex.Message);
        }

        try
        {
            if(!context.Users.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/user.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<User>();
                        List<User> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new User
                            {
                                Id = item.Id,
                                IdenNumber = item.IdenNumber,
                                UserName=item.UserName,
                                Email = item.Email,
                                Password = item.Password
                            });
                        }
                        context.Users.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.Proveedores.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/proveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Proveedor>();
                        List<Proveedor> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Proveedor
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                NitProveedor = item.NitProveedor,
                                TipoPersonaId=item.TipoPersonaId,
                                MunicipioId = item.MunicipioId
                            });
                        }
                        context.Proveedores.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.UserRoles.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/userrol.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<UserRol>();
                        List<UserRol> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new UserRol
                            {
                                UserId= item.UserId,
                                RolId = item.RolId
                            });
                        }
                        context.UserRoles.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiDbContext>();
            logger.LogError(ex.Message);
        }
        
    } 
}
