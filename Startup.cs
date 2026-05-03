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
                string ecsTaskName    = "N/A";
                string ecsServiceName = "N/A";

                var metadataUri = Environment.GetEnvironmentVariable("ECS_CONTAINER_METADATA_URI_V4");
                if (!string.IsNullOrEmpty(metadataUri))
                {
                    try
                    {
                        using var httpClient = new HttpClient();
                        var json = await httpClient.GetStringAsync($"{metadataUri}/task");
                        using var doc = JsonDocument.Parse(json);

                        // Extrai o nome da task a partir do TaskARN (última parte após '/')
                        // Exemplo de TaskARN: arn:aws:ecs:us-east-1:123456789:task/proj2site/5a82615d2759416fb2b0ffd83bb6cfe1
                        if (doc.RootElement.TryGetProperty("TaskARN", out var taskArn))
                        {
                            var arnValue = taskArn.GetString() ?? string.Empty;
                            var arnParts = arnValue.Split('/');
                            ecsTaskName = arnParts[^1]; // última parte do ARN
                        }

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
                        <meta name='ecs-task-name'    content='{ecsTaskName}'>
                        <meta name='ecs-service-name' content='{ecsServiceName}'>
                        <title>Meu Site</title>
                    </head>
                    <body style='background-color: #2c3e50; color: white; font-family: Arial, Helvetica, sans-serif;'>
                        <h1>Bem-vindo ao Site Projeto 2!</h1>
                        <p>Novo deploy realizado com sucesso.</p>
                        <p><strong>Task:</strong> {ecsTaskName}</p>
                        <p><strong>Serviço:</strong> {ecsServiceName}</p>
                    </body>
                    </html>
                ");
            });
        }
    }
}