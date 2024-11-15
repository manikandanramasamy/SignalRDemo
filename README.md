# Graceful Shutdown for SignalR in .NET 8 API and Docker

Graceful Shutdown Handling
In this example, the method lifetime.ApplicationStopping.Register() is used to register a cleanup action that will be triggered when the application is shutting down. You can simulate tasks like:

Closing connections to databases
Stopping background jobs
Logging shutdown messages
Releasing resources
In the example above, I used System.Threading.Thread.Sleep(2000) to simulate a 2-second delay for cleanup, but in a real scenario, you would perform actual cleanup tasks like closing database connections or processing pending jobs.

Health Check Endpoint
The MapHealthChecks("/health") line in the Configure method of Startup.cs configures the health check endpoint at /health. When you run the application, you can check the health of the service by visiting:
<br/>
http://localhost:5000/health
<br/>
This will return a response like:
{
  "status": "Healthy"
}
<br/>
http://localhost:5000/api/values
<br/>
Please refer below steps for verfication
<br/>
1) Start your application with Docker Compose:
	docker-compose up -d
This will start the service in detached mode (-d), running the SignalR app inside the container.
2) Stop the services with a timeout:
	docker-compose stop --timeout 10
This will:

Allow up to 10 seconds for each service to gracefully shut down.
If the services don't shut down within 10 seconds, Docker will forcibly terminate them.

3) Get logs from 
	docker-compose logs -f webapi
<br/>
You should see something like this when the app starts to shut down:
<br/>
webapi-1  | info: Microsoft.Hosting.Lifetime[0]<br/>
webapi-1  |       Application is shutting down...<br/>
webapi-1  | info: Program[0]<br/>
webapi-1  |       Application is shutting down...<br/>
webapi-1  | info: Program[0]<br/>
webapi-1  |       Cleanup completed.<br/>
