using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {
    try
    {
        using var connection = new MySqlConnection("Server=mysql_db;Database=holamundo;User=root;Password=root;");
        connection.Open();
        return "¡Hola Mundo! Conectado a MySQL exitosamente mediante Docker Compose.";
    }
    catch (Exception ex)
    {
        return $"Hola Mundo, pero falló la conexión a BD: {ex.Message}";
    }
});

// Configuración obligatoria para despliegues en Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");