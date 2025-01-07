TestTask
This is a project built using .NET 9 with Entity Framework (EF) for database management. It includes functionalities such as user registration, login, and basic data retrieval operations.

Features
User Registration: Allows users to register an account.
Login: Provides authentication to log in users.
GET Users: Fetches data about users.
GET ME: Retrieves details of the logged-in user.
Technologies Used
.NET 9
Entity Framework (EF)
SQL Server (or your preferred database)
Setup
To set up this project on your local machine, follow the steps below:

1. Clone the Repository
bash
Copy code
git clone https://github.com/yourusername/yourprojectname.git
2. Navigate to the Project Directory
bash
Copy code
cd yourprojectname
3. Install Dependencies
Ensure that you have the correct version of .NET 9 installed. If you don't have it, download it from the official .NET website.

Install the necessary dependencies:

bash
Copy code
dotnet restore
4. Database Configuration
Ensure your connection string is configured correctly in the appsettings.json file. You can find the connection string section and modify it to match your database settings.

5. Apply Migrations
To set up the database schema, use the following command to apply the migrations:

bash
Copy code
dotnet ef database update
This will create the necessary tables in your database based on the models and migrations.

6. Running the Application
Once everything is set up, you can run the application using:

bash
Copy code
dotnet run
The application should now be running on http://localhost:5000 (or the port specified in your project settings).

API Endpoints
1. User Registration
URL: /api/users/register
Method: POST
Request Body:
json
Copy code
{
  "username": "newuser",
  "password": "password123"
}
Response: Success or failure message.
2. Login
URL: /api/users/login
Method: POST
Request Body:
json
Copy code
{
  "username": "newuser",
  "password": "password123"
}
Response:
Success: Returns a JWT token.
Failure: Returns an error message.
3. GET Users (Fetch All Users)
URL: /api/users
Method: GET
Headers: Authorization: Bearer {your_token}
Response: A list of user objects.
4. GET ME (Get Logged-in User's Info)
URL: /api/users/me
Method: GET
Headers: Authorization: Bearer {your_token}
Response: User details (e.g., username, email, etc.).
Authentication
The API uses JWT (JSON Web Tokens) for authentication. After successfully logging in, you will receive a JWT token. Include this token in the Authorization header as Bearer {your_token} when making requests to secured endpoints such as GET /api/users and GET /api/users/me.

Error Handling
If any request fails (e.g., invalid credentials, missing data), the API will respond with an appropriate error message and status code.

Troubleshooting
Ensure that your connection string is correct in appsettings.json.
If you encounter migration issues, try running dotnet ef migrations add MigrationName followed by dotnet ef database update.
If the application doesn't start, ensure .NET 9 is installed properly.
Contributing
If you'd like to contribute to this project, feel free to fork it, make your changes, and submit a pull request.

License
This project is licensed under the MIT License - see the LICENSE file for details.
