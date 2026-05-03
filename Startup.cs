using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MEUSITE
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Nenhum serviço necessário para app mínima
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";

                // Lê os metadados do ECS Task Metadata Endpoint V4
                string ecsTaskFamily  = "N/A";
                string ecsServiceName = "N/A";

                var metadataUri = Environment.GetEnvironmentVariable("ECS_CONTAINER_METADATA_URI_V4");
                if (!string.IsNullOrEmpty(metadataUri))
                {
                    try
                    {
                        using var httpClient = new HttpClient();
                        var json = await httpClient.GetStringAsync($"{metadataUri}/task");
                        using var doc = JsonDocument.Parse(json);

                        if (doc.RootElement.TryGetProperty("Family", out var family))
                            ecsTaskFamily = family.GetString() ?? "N/A";

                        if (doc.RootElement.TryGetProperty("ServiceName", out var service))
                            ecsServiceName = service.GetString() ?? "N/A";
                    }
                    catch
                    {
                        // Mantém "N/A" em caso de falha na leitura dos metadados
                    }
                }

                await context.Response.WriteAsync($@"
                    <!DOCTYPE html>
                    <html lang='pt-BR'>
                    <head>
                        <meta charset='utf-8'>
                        <meta name='ecs-task-family'  content='{ecsTaskFamily}'>
                        <meta name='ecs-service-name' content='{ecsServiceName}'>
                        <title>Meu Site</title>
                    </head>
                    <body style='background-color: #2c3e50; color: white; font-family: Arial, Helvetica, sans-serif;'>
                        <h1>Bem-vindo ao Site Projeto 2!</h1>
                        <p>Novo deploy realizado com sucesso.</p>
                        <p><strong>Task:</strong> {ecsTaskFamily}</p>
                        <p><strong>Serviço:</strong> {ecsServiceName}</p>
                    </body>
                    </html>
                ");
            });
        }
    }
}
